using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;
using NetFwTypeLib;


namespace Connection
{
    public class FirewallHelper
    {
        private readonly INetFwMgr mgr;
        private string applicationFullPath;
        private string appName;
   
        public FirewallHelper()
        {
            Type netFwMgrType = Type.GetTypeFromProgID("HNetCfg.FwMgr", false);

            mgr = null;

            if (netFwMgrType != null)
            {
                mgr = (INetFwMgr)Activator.CreateInstance(netFwMgrType);
            }
        }
        
        #region Methods
      
        private bool IsFirewallInstalled
        {
            get
            {
                if (mgr != null && mgr.LocalPolicy != null && mgr.LocalPolicy.CurrentProfile != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsFirewallEnabled
        {
            get
            {
                if (IsFirewallInstalled && mgr.LocalPolicy.CurrentProfile.FirewallEnabled)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// 
        /// Returns whether or not the firewall allows Application "Exceptions".
        /// Added to allow access to this method
        /// 
        private bool AppAuthorizationsAllowed
        {
            get
            {
                if (IsFirewallInstalled && !mgr.LocalPolicy.CurrentProfile.ExceptionsNotAllowed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool HasAuthorization(string applicationFullPath)
        {
            if (applicationFullPath == null)
            {
                throw new ArgumentNullException("applicationFullPath");
            }
            if (!File.Exists(applicationFullPath))
            {
                throw new FileNotFoundException("File does not exist.", applicationFullPath);
            }
            if (!IsFirewallInstalled)
            {
                throw new FirewallHelperException("Cannot remove authorization, firewall is not enabled.");
            }

            foreach (string appName in GetAuthorizedAppPaths())
            {
                if (appName.ToLower() == applicationFullPath.ToLower())
                    return true;
            }
            return false;
        }

        /// 
        /// Retrieves a collection of paths to applications that are authorized.
        ///   
        private ICollection GetAuthorizedAppPaths()
        {
            // State checking
            if (!IsFirewallInstalled)
            {
                throw new FirewallHelperException("Cannot remove authorization, firewall is not enabled.");
            }

            ArrayList list = new ArrayList();
            //  Collect the paths of all authorized applications
            foreach (INetFwAuthorizedApplication app
                in mgr.LocalPolicy.CurrentProfile.AuthorizedApplications)
            {
                list.Add(app.ProcessImageFileName);
            }

            return list;
        }
              
        #endregion

        #region application

        /// 
        /// create authorization rule for application
        /// 
        /// To verify app permissions with cmd prompt use command:
        /// "netsh advfirewall firewall show rule name=udptool.vshost.exe"
        /// 
        public void GrantAuthorization(string applicationFullPath)
        {
            ValidateFields(applicationFullPath);
          
            if (!IsFirewallInstalled)
            {
                throw new FirewallHelperException("Cannot grant authorization: Firewall is not installed.");
            }

            if (!AppAuthorizationsAllowed)
            {
                throw new FirewallHelperException("Application exemptions are not allowed.");
            }

            if (!HasAuthorization(applicationFullPath))
            {
                INetFwProfile profileDomain = mgr.LocalPolicy.GetProfileByType(NET_FW_PROFILE_TYPE_.NET_FW_PROFILE_STANDARD);
                profileDomain.AuthorizedApplications.Add(GetAuthAppObj(applicationFullPath, appName));

                profileDomain = mgr.LocalPolicy.GetProfileByType(NET_FW_PROFILE_TYPE_.NET_FW_PROFILE_DOMAIN);
                profileDomain.AuthorizedApplications.Add(GetAuthAppObj(applicationFullPath, appName));

                profileDomain = mgr.LocalPolicy.GetProfileByType(NET_FW_PROFILE_TYPE_.NET_FW_PROFILE_CURRENT);
                profileDomain.AuthorizedApplications.Add(GetAuthAppObj(applicationFullPath, appName));
            }
        }

        /// 
        /// Remove app authorization rules.
        /// 
        public void RemoveAuthorization(string applicationFullPath)
        {

            ValidateFields(applicationFullPath);

            if (!IsFirewallInstalled)
            {
                throw new FirewallHelperException("Cannot remove authorization: Firewall is not installed.");
            }

            if (HasAuthorization(applicationFullPath))
            {
                foreach (string appName in GetAuthorizedAppPaths())
                {
                    if (appName.ToLower() == applicationFullPath.ToLower())
                    {
                        // Remove Authorizations for this application
                        INetFwProfile profileDomain = mgr.LocalPolicy.GetProfileByType(NET_FW_PROFILE_TYPE_.NET_FW_PROFILE_STANDARD);
                        profileDomain.AuthorizedApplications.Remove(applicationFullPath);

                        profileDomain = mgr.LocalPolicy.GetProfileByType(NET_FW_PROFILE_TYPE_.NET_FW_PROFILE_DOMAIN);
                        profileDomain.AuthorizedApplications.Remove(applicationFullPath);

                        profileDomain = mgr.LocalPolicy.GetProfileByType(NET_FW_PROFILE_TYPE_.NET_FW_PROFILE_CURRENT);
                        profileDomain.AuthorizedApplications.Remove(applicationFullPath);

                    }
                }

            }
        }

        private void ValidateFields(string applicationFullPath)
        {
            if (applicationFullPath == null)
            {
                throw new ArgumentNullException("applicationFullPath");
            }
            if (applicationFullPath.Trim().Length == 0)
            {
                throw new ArgumentException("applicationFullPath must not be blank");
            }
            if (!File.Exists(applicationFullPath))
            {
                throw new FileNotFoundException("File does not exist", applicationFullPath);
            }
          
            this.applicationFullPath = applicationFullPath;
            //To find the name of the executable
            this.appName = Path.GetFileName(applicationFullPath);

            if (appName == null)
            {
                throw new ArgumentNullException("appName");
            }
         
        }

        private static INetFwAuthorizedApplication GetAuthAppObj(string applicationFullPath, string appName)
        {
            // Get the type of HNetCfg.FwMgr, or null if an error occurred
            Type authApp = Type.GetTypeFromProgID("HNetCfg.FwAuthorizedApplication", false);

            // Assume failed.
            INetFwAuthorizedApplication appInfo = null;

            if (authApp != null)
            {
                try
                {
                    appInfo = (INetFwAuthorizedApplication)Activator.CreateInstance(authApp);
                }
                catch (Exception)
                {
                    // In all other circumnstances, appInfo is null.
                }
            }

            if (appInfo == null)
            {
                throw new FirewallHelperException("Could not grant authorization: can't create INetFwAuthorizedApplication instance.");
            }

            appInfo.Name = appName;
            appInfo.ProcessImageFileName = applicationFullPath;
            return appInfo;
        }

        #endregion

        #region Ports

        /// 
        /// Create authorization rule for a specific  port 
        /// 
        /// To view app permissions from command line use:
        /// "netsh advfirewall firewall show rule name=udptool.vshost.exe"
        /// 
        public void GrantPortAuthorization(string applicationFullPath, string usedPort, NET_FW_IP_PROTOCOL_ protocol)
        {
            ValidateFields(applicationFullPath);

            if (usedPort == null)
            {
                throw new ArgumentNullException("usedPort");
            }
            if (!IsFirewallInstalled)
            {
                throw new FirewallHelperException("Cannot grant authorization, firewall is not enabled.");
            }
            if (!AppAuthorizationsAllowed)
            {
                throw new FirewallHelperException("Application exceptions are not allowed.");
            }
            // Other properties like Protocol, IP Version can also be set accordingly
            // Now add this to the GloballyOpenPorts collection
            INetFwProfile profile = mgr.LocalPolicy.GetProfileByType(NET_FW_PROFILE_TYPE_.NET_FW_PROFILE_CURRENT);

            profile.GloballyOpenPorts.Add(GetPortObj(usedPort, protocol));
            profile = mgr.LocalPolicy.GetProfileByType(NET_FW_PROFILE_TYPE_.NET_FW_PROFILE_STANDARD);
            profile.GloballyOpenPorts.Add(GetPortObj(usedPort, protocol));
            profile = mgr.LocalPolicy.GetProfileByType(NET_FW_PROFILE_TYPE_.NET_FW_PROFILE_DOMAIN);
            profile.GloballyOpenPorts.Add(GetPortObj(usedPort, protocol));

        }

        /// 
        /// Remove port authorization rules.
        /// 
        public void RemovePortAuthorization(string applicationFullPath, string usedPort, NET_FW_IP_PROTOCOL_ protocol)
        {
            ValidateFields(applicationFullPath);

            if (usedPort == null)
            {
                throw new ArgumentNullException("usedPort");
            }

            int port = Int32.Parse(usedPort);
     
            INetFwProfile profile = mgr.LocalPolicy.GetProfileByType(NET_FW_PROFILE_TYPE_.NET_FW_PROFILE_CURRENT);
            profile.GloballyOpenPorts.Remove(port, protocol);
            profile = mgr.LocalPolicy.GetProfileByType(NET_FW_PROFILE_TYPE_.NET_FW_PROFILE_STANDARD);
            profile.GloballyOpenPorts.Remove(port, protocol);
            profile = mgr.LocalPolicy.GetProfileByType(NET_FW_PROFILE_TYPE_.NET_FW_PROFILE_DOMAIN);
            profile.GloballyOpenPorts.Remove(port, protocol);

        }

        private INetFwOpenPort GetPortObj(string portNumber, NET_FW_IP_PROTOCOL_ ipProtocol)
        {
            Type tpResult = Type.GetTypeFromCLSID(new Guid("{0CA545C6-37AD-4A6C-BF92-9F7610067EF5}"));
            INetFwOpenPort port = (INetFwOpenPort)Activator.CreateInstance(tpResult);
            port.Port = Int32.Parse(portNumber); // port number
            port.Name = appName; // name of the application using the port
            port.Enabled = true; // enable the port
            port.Protocol = ipProtocol;
            return port;
        }
      
        #endregion
    }


}
