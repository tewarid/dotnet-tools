#include "pch.h"

#include <Windows.h>
#include <iphlpapi.h>
#include <stdio.h>
#include "Network.h"

#pragma comment(lib, "Iphlpapi.lib")
#pragma comment(lib, "ws2_32.lib")

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

IList<Native::Interface^>^ Native::Interface::List()
{
    int i;
    PMIB_IPADDRTABLE pIPAddrTable;
    DWORD dwSize = 0;
    DWORD dwRetVal = 0;
    IN_ADDR ipAddr;
    MIB_IFROW* pIfRow;
    System::Collections::Generic::List<Native::Interface^>^ interfaces;

    pIPAddrTable = (MIB_IPADDRTABLE*)malloc(sizeof(MIB_IPADDRTABLE));

    if (pIPAddrTable) {
        // Make an initial call to GetIpAddrTable to get the
        // necessary size into the dwSize variable
        if (GetIpAddrTable(pIPAddrTable, &dwSize, 0) ==
            ERROR_INSUFFICIENT_BUFFER) {
            free(pIPAddrTable);
            pIPAddrTable = (MIB_IPADDRTABLE*)malloc(dwSize);

        }
        if (pIPAddrTable == NULL) {
            return nullptr;
        }
    }
    // Make a second call to GetIpAddrTable to get the
    // actual data we want
    if ((dwRetVal = GetIpAddrTable(pIPAddrTable, &dwSize, 0)) != NO_ERROR) {
        return nullptr;
    }

    interfaces = gcnew System::Collections::Generic::List<Native::Interface^>();

    for (i = 0; i < (int)pIPAddrTable->dwNumEntries; i++) {
        pIfRow = (MIB_IFROW*)malloc(sizeof(MIB_IFROW));
        pIfRow->dwIndex = pIPAddrTable->table[i].dwIndex;
        if ((dwRetVal = GetIfEntry(pIfRow)) == NO_ERROR) {
            Native::Interface^ iface = gcnew Native::Interface;
            iface->InterfaceIndex = pIfRow->dwIndex;
            iface->Name = gcnew String(pIfRow->wszName);
            iface->Description = gcnew String((char*)pIfRow->bDescr, 0, pIfRow->dwDescrLen);
            switch (pIfRow->dwType) {
            case IF_TYPE_ETHERNET_CSMACD:
                iface->InterfaceType = "Ethernet";
                break;
            case IF_TYPE_SOFTWARE_LOOPBACK:
                iface->InterfaceType = "Loopback";
                break;
            case IF_TYPE_IEEE80211:
                iface->InterfaceType = "IEEE 802.11 Wireless";
                break;
            case IF_TYPE_TUNNEL:
                iface->InterfaceType = "Tunnel";
                break;
            default:
                continue;
            }
            switch (pIfRow->dwOperStatus) {
            case IF_OPER_STATUS_OPERATIONAL:
                iface->OperationalStatus = "Operational";
                break;
            default:
                continue;
            }
            ipAddr.S_un.S_addr = (u_long)pIPAddrTable->table[i].dwAddr;
            iface->IPAddress = gcnew String(inet_ntoa(ipAddr));
            ipAddr.S_un.S_addr = (u_long)pIPAddrTable->table[i].dwMask;
            iface->IPAddressMask = gcnew String(inet_ntoa(ipAddr));
            ipAddr.S_un.S_addr = (u_long)pIPAddrTable->table[i].dwBCastAddr;
            iface->BroadcastIPAddress = gcnew String(inet_ntoa(ipAddr));
            if (pIPAddrTable->table[i].wType & MIB_IPADDR_PRIMARY)
                iface->IPAddressStatus = "Primary IP Address";
            if (pIPAddrTable->table[i].wType & MIB_IPADDR_DYNAMIC)
                iface->IPAddressStatus = "Dynamic IP Address";
            if (pIPAddrTable->table[i].wType & MIB_IPADDR_DISCONNECTED)
                iface->IPAddressStatus = "Address is on disconnected interface";
            if (pIPAddrTable->table[i].wType & MIB_IPADDR_DELETED)
                iface->IPAddressStatus = "Address is being deleted";
            if (pIPAddrTable->table[i].wType & MIB_IPADDR_TRANSIENT)
                iface->IPAddressStatus = "Transient address";
            interfaces->Add(iface);
        }
        free(pIfRow);
    }

    if (pIPAddrTable) {
        free(pIPAddrTable);
        pIPAddrTable = NULL;
    }
    return interfaces;
}

array<Native::Route^>^ Native::Route::List()
{
    PMIB_IPFORWARDTABLE pIpForwardTable;
    DWORD dwSize = 0;
    DWORD dwRetVal = 0;

    char szDestIp[128];
    char szMaskIp[128];
    char szGatewayIp[128];

    struct in_addr ipAddr;

    int i;

    array<Native::Route^>^ routes;

    pIpForwardTable =
        (MIB_IPFORWARDTABLE*)malloc(sizeof(MIB_IPFORWARDTABLE));
    if (pIpForwardTable == NULL) {
        return nullptr;
    }

    if (GetIpForwardTable(pIpForwardTable, &dwSize, 0) ==
        ERROR_INSUFFICIENT_BUFFER) {
        free(pIpForwardTable);
        pIpForwardTable = (MIB_IPFORWARDTABLE*)malloc(dwSize);
        if (pIpForwardTable == NULL) {
            return nullptr;
        }
    }

    if ((dwRetVal = GetIpForwardTable(pIpForwardTable, &dwSize, 0)) != NO_ERROR) {
        return nullptr;
    }

    routes = gcnew array<Native::Route^>((int)pIpForwardTable->dwNumEntries);
    for (i = 0; i < (int)pIpForwardTable->dwNumEntries; i++) {
        Native::Route^ route = gcnew Native::Route;

        ipAddr.S_un.S_addr =
            (u_long)pIpForwardTable->table[i].dwForwardDest;
        strcpy_s(szDestIp, sizeof(szDestIp), inet_ntoa(ipAddr));
        route->DestinationAddress = gcnew String(szDestIp);

        ipAddr.S_un.S_addr =
            (u_long)pIpForwardTable->table[i].dwForwardMask;
        strcpy_s(szMaskIp, sizeof(szMaskIp), inet_ntoa(ipAddr));
        route->DestinationMask = gcnew String(szMaskIp);

        ipAddr.S_un.S_addr =
            (u_long)pIpForwardTable->table[i].dwForwardNextHop;
        strcpy_s(szGatewayIp, sizeof(szGatewayIp), inet_ntoa(ipAddr));
        route->NextHop = gcnew String(szGatewayIp);

        route->RouteMetric = pIpForwardTable->table[i].dwForwardMetric1;
        route->InterfaceIndex = pIpForwardTable->table[i].dwForwardIfIndex;

        routes[i] = route;
    }
    free(pIpForwardTable);
    return routes;
}

void Native::Route::Add(Native::Route^ route)
{
    MIB_IPFORWARDROW row;
    DWORD dwStatus;

    row = RouteToRow(route);
    row.dwForwardProto = PROTO_IP_NETMGMT;

    dwStatus = CreateIpForwardEntry(&row);
    switch (dwStatus) {
    case NO_ERROR:
        return;
    case ERROR_INVALID_PARAMETER:
        break;
    }
}

void Native::Route::Delete(Native::Route^ route)
{
    MIB_IPFORWARDROW row;
    DWORD dwStatus;

    row = RouteToRow(route);

    dwStatus = DeleteIpForwardEntry(&row);
    switch (dwStatus) {
    case NO_ERROR:
        return;
    case ERROR_INVALID_PARAMETER:
        break;
    }
}

MIB_IPFORWARDROW Native::Route::RouteToRow(Route^ route) {
    MIB_IPFORWARDROW row;
    char* pChars;

    pChars = (char*)Marshal::StringToHGlobalAnsi(route->DestinationAddress).ToPointer();
    row.dwForwardDest = inet_addr(pChars);
    Marshal::FreeHGlobal((IntPtr)pChars);
    pChars = (char*)Marshal::StringToHGlobalAnsi(route->DestinationMask).ToPointer();
    row.dwForwardMask = inet_addr(pChars);
    Marshal::FreeHGlobal((IntPtr)pChars);
    pChars = (char*)Marshal::StringToHGlobalAnsi(route->NextHop).ToPointer();
    row.dwForwardNextHop = inet_addr(pChars);
    Marshal::FreeHGlobal((IntPtr)pChars);
    row.dwForwardIfIndex = route->InterfaceIndex;
    row.dwForwardMetric1 = route->RouteMetric;

    return row;
}
