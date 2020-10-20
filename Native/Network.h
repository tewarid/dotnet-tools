#pragma once

using namespace System;
using namespace System::Collections::Generic;

namespace Native {
    public ref class Interface
    {
    public:
        int InterfaceIndex;
        String^ Name;
        String^ Description;
        String^ InterfaceType;
        String^ OperationalStatus;
        String^ IPAddress;
        String^ IPAddressMask;
        String^ BroadcastIPAddress;
        String^ IPAddressStatus;

        static IList<Interface^>^ List();
    };

    public ref class Route
    {
    private:
        static MIB_IPFORWARDROW RouteToRow(Route^ route);
    public:
        String^ DestinationAddress;
        String^ DestinationMask;
        String^ NextHop;
        int RouteMetric;
        int InterfaceIndex;

        static array<Route^>^ List();
        static void Add(Route^ route);
        static void Delete(Route^ route);
    };
}
#pragma once
