#include "pch.h"

#include <Windows.h>
#include <WinUser.h>
#pragma comment(lib, "User32.lib") 

#include "User32.h"

bool Native::Window::LockUpdate(IntPtr handle)
{
    if (Environment::OSVersion->Platform != PlatformID::Win32NT)
    {
        return false;
    }
    return LockWindowUpdate((HWND)handle.ToInt32());
}

bool Native::Window::ReleaseUpdate()
{
    if (Environment::OSVersion->Platform != PlatformID::Win32NT)
    {
        return false;
    }
    return LockWindowUpdate(0);
}
