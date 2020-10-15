#pragma once

using namespace System;

namespace Routing {
	public ref class Route
	{
	public:
		String^ DestinationPrefix;
		String^ NextHop;
		int RouteMetric;
		bool Persistent;
		int InterfaceIndex;
		String^ InterfaceAlias;
		static array<Route^>^ List();
		static void Add(String^ destinationPrefix, int interfaceIndex, String^ nextHop, int routeMetric, bool persistent);
		static void Delete(String^ destinationPrefix, int interfaceIndex, String^ nextHop, int routeMetric, bool persistent);
	};
}
#pragma once
