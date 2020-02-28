// Win32Dll.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"

extern "C"
{
	// UTF-16 null�I�[������
	__declspec(dllexport) void __stdcall FillA16(wchar_t* str)
	{
		for (auto p = str; *p; p++)
		{
			*p = L'a';
		}
	}

	// ANSI null�I�[������
	__declspec(dllexport) void __stdcall FillA8(char* str)
	{
		for (auto p = str; *p; p++)
		{
			*p = 'a';
		}
	}

	__declspec(dllexport) int __stdcall GetValue()
	{
		return 123;
	}

	__declspec(dllexport) void __stdcall SetValue(UINT16& x)
	{
		x = 0x1234;
	}

	struct Data
	{
		BYTE A;
		BYTE B;
		UINT16 C;
		UINT32 D;
	};

	__declspec(dllexport) Data __stdcall Shift(Data data)
	{
		UINT64* l = (UINT64*)&data;
		*l <<= 1;
		return data;
	}

	typedef void(__stdcall* Callback)(void* param, UINT32 value);

	static void* g_param;
	static Callback g_callback;

	__declspec(dllexport) void __stdcall SetCallback(void* param, Callback callback)
	{
		g_param = param;
		g_callback = callback;
	}

	__declspec(dllexport) void __stdcall FireCallback(UINT32 value)
	{
		g_callback(g_param, value);
	}
}
