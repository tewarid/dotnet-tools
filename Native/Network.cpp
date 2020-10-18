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
    DWORD dwSize = 0;
    DWORD dwRetVal = 0;

    unsigned int i, j;

    MIB_IFTABLE* pIfTable;
    MIB_IFROW* pIfRow;

    System::Collections::Generic::List<Native::Interface^>^ interfaces;

    // Allocate memory for our pointers.
    pIfTable = (MIB_IFTABLE*)malloc(sizeof(MIB_IFTABLE));
    if (pIfTable == NULL) {
        return nullptr;
    }
    // Make an initial call to GetIfTable to get the
    // necessary size into dwSize
    dwSize = sizeof(MIB_IFTABLE);
    if (GetIfTable(pIfTable, &dwSize, FALSE) == ERROR_INSUFFICIENT_BUFFER) {
        free(pIfTable);
        pIfTable = (MIB_IFTABLE*)malloc(dwSize);
        if (pIfTable == NULL) {
            return nullptr;
        }
    }
    // Make a second call to GetIfTable to get the actual
    // data we want.
    if ((dwRetVal = GetIfTable(pIfTable, &dwSize, FALSE)) != NO_ERROR) {
        if (pIfTable != NULL) {
            free(pIfTable);
            pIfTable = NULL;
        }
        return nullptr;
    }

    printf("\tNum Entries: %ld\n\n", pIfTable->dwNumEntries);
    interfaces = gcnew System::Collections::Generic::List<Native::Interface^>();

    for (i = 0; i < pIfTable->dwNumEntries; i++) {
        Native::Interface^ iface = gcnew Native::Interface;
        pIfRow = (MIB_IFROW*)&pIfTable->table[i];
        iface->InterfaceIndex = pIfRow->dwIndex;
        iface->Name = gcnew String(pIfRow->wszName);
        iface->Description = gcnew String((char *)pIfRow->bDescr, 0, pIfRow->dwDescrLen);
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
        interfaces->Add(iface);
    }

    if (pIfTable != NULL) {
        free(pIfTable);
        pIfTable = NULL;
    }

    return interfaces;
}

array<Native::Route^>^ Native::Route::List()
{
    /* variables used for GetIfForwardTable */
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

        /* Convert IPv4 addresses to strings */

        /* Note that the IPv4 addresses returned in
         * GetIpForwardTable entries are in network byte order
         */

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
