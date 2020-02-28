// NativeLib.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"

extern "C"
{
	typedef __declspec(dllexport) void (*Callback)(__int32 senderId, void* data, size_t data_len);

	static Callback g_callback;

	// Trigger ���Ă񂾎��ɁAcallback ���Ăяo�����B
	// callback �ɓn���� data �|�C���^�[�́A�ʏ�ł���� callback ���ł����L���B
	// callback ���𒴂��ėL���ɂ��邽�߂ɂ� AddRef ���Ă�(���̏ꍇ�ARelease �������ƌĂ΂Ȃ��ƃ��������[�N����)�B
	__declspec(dllexport) void SetCallback(Callback callback)
	{
		g_callback = callback;
	}

	// �{�� NativeLib ���ŋN�����C�x���g�ɉ����� callback ���Ă΂��悤�ȑz��Ȃ񂾂��ǁA
	// �T���v���Ƃ������ƂŊO����C�x���g���N�����Ă��炤�B
	// callback �ɓn�� data ���K���B�����ł�����Ă����B
	__declspec(dllexport) void Trigger(__int32 senderId)
	{
		auto data_len = std::rand() % 1024;

		__int8* p = new __int8[data_len + sizeof(size_t)];
		__int8* data = p + +sizeof(size_t);

		for (int i = 0; i < data_len; i++)
		{
			data[i] = rand();
		}

		g_callback(senderId, data, data_len);

		// AddRef ���Ă΂�ĂȂ��Ƃ��Ɍ��葦���� delete

		// �ق�Ƃ͂��Ԃ񃍃b�N���K�v
		auto refCount = (size_t*)p;
		if (*refCount == 0)
			delete data;
	}

	__declspec(dllexport) void AddRef(void* data)
	{
		auto refCount = (size_t*)((__int8*)data - sizeof(size_t));

		// �ق�Ƃ͂��Ԃ񃍃b�N���K�v
		*refCount++;
	}

	__declspec(dllexport) void Release(void* data)
	{
		auto refCount = (size_t*)((__int8*)data - sizeof(size_t));

		// �ق�Ƃ͂��Ԃ񃍃b�N���K�v
		if (*refCount-- == 0)
		{
			delete (__int8*)refCount;
		}
	}
}
