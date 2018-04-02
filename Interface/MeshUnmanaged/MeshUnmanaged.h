#pragma once


#ifdef MESHUNMANAGED_EXPORTS
#define API_CALL __declspec(dllexport)
#else
#define API_CALL __declspec(dllimport)
#endif


extern "C" API_CALL int Mesh_Initialize(const char *Module);

extern "C" API_CALL int Mesh_Decrypt(
	const char* InputArray, int InputLength,
	char**OutputArray, int *OutputLength);

extern "C" API_CALL int Mesh_Free(void *Memory);
