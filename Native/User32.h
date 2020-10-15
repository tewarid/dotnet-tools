#pragma once

using namespace System;

namespace Native {
	public ref class Window
	{
	public:
		static bool LockUpdate(IntPtr handle);
		static bool ReleaseUpdate();
	};
}
