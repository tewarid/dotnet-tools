#include "pch.h"

#include <Windows.h>
#include <RtmV2.h>
#pragma comment(lib, "Rtm.lib") 

#include "Routing.h"

using namespace System;

array<Routing::Route^>^ Routing::Route::List()
{
    return nullptr;
}

void Routing::Route::Add(String^ destinationPrefix, int interfaceIndex, String^ nextHop, int routeMetric, bool persistent)
{

}

void Routing::Route::Delete(String^ destinationPrefix, int interfaceIndex, String^ nextHop, int routeMetric, bool persistent)
{

}
