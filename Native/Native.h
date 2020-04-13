#pragma once

using namespace System;

namespace Native {
	public ref class Windows
	{
	public:
		static bool LockUpdate(IntPtr handle);
		static bool ReleaseUpdate();
	};
}
