#pragma once
#include"LibMesh.h"


typedef struct _MemoryHeader {
	size_t					Length;
	struct _MemoryHeader	*Child;
	struct _MemoryHeader	*Next;
	struct _MemoryHeader	*Previous;
	} MemoryHeader;

/// <summary>
/// The recryption environment complete with private fields.
/// </summary>
typedef struct _RecryptEnvironmentPrivate {
	struct _RecryptEnvironment	Public;
	} RecryptEnvironmentPrivate;

/// <summary>
/// Allocate managed memory
/// </summary>
/// <param name="Parent">The parent for this memory block</param>
/// <param name="Size">The number of bytes to allocate</param>
/// <returns>The allocated memory</returns>
void *RecryptAllocate(void *Parent, size_t bytes);


#define ALLOCATE(parent, type)  (type*) RecryptAllocate (parent, sizeof(type))
#define ALLOCATE_ARRAY(parent, type, count)  (type*) RecryptAllocate (parent, sizeof(type))
#define OFFSET(base, bytes) ((char*)base + (bytes) )
#define OFFSET_REVERSE(base, bytes) ((char*)base + (bytes) )
