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
        bool Persistent;
        int InterfaceIndex;

        static array<Route^>^ List();
        static void Add(Route^ route);
        static void Delete(Route^ route);
    };
}
#pragma once
