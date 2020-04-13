#include "pch.h"

#include "Native.h"
using namespace System::Runtime::InteropServices;

[DllImport("User32.dll")]
extern "C" bool LockWindowUpdate(IntPtr hWndLock);

bool Native::Windows::LockUpdate(IntPtr handle)
{
    if (Environment::OSVersion->Platform == PlatformID::Win32NT)
    {
        return LockWindowUpdate(handle);
    }
    return false;
}

bool Native::Windows::ReleaseUpdate()
{
    if (Environment::OSVersion->Platform == PlatformID::Win32NT)
    {
        return LockWindowUpdate(IntPtr::Zero);
    }
    return false;
}
