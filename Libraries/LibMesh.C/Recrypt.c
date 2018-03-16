#include <stddef.h>
#include <MetaHost.h>
#include"LibMeshPrivate.h"





/// <summary>
/// Begin recryption of a document.
/// </summary>
/// <param name="Environment">The returned environment variable.</param>
/// <returns>Status result</returns>
int RecryptStart(RecryptEnvironment** EnvironmentOut) {
	RecryptEnvironmentPrivate *Environment = ALLOCATE(NULL, RecryptEnvironmentPrivate);
	
	Environment->Public.MetadataComplete = false;
	Environment->Public.ContentType = NULL;
	Environment->Public.ContentLength = -1;
	Environment->Public.RecryptionState = RECRYPT_ENGINE_Parse_Header;
	Environment->Public.SignerUDF = NULL;
	Environment->Public.Convert = RecryptConvert;
	Environment->Public.Free = RecryptFree;

	EnvironmentOut = (RecryptEnvironment*) &Environment;
	return RECRYPT_STATUS_Success;
	}


char ToLower(char In) {
	return (In < 'A' | In > 'Z') ? In : In - 32;
	}

/// <summary>
/// Transform a block of data and receive incremental results (if supported).
/// </summary>
/// <param name="Environment">A recryption environment returned by RecryptStart</param>
/// <param name="BytesIn">The bytes to transform</param>
/// <param name="LengthIn">The number of bytes to transform</param>
/// <param name="BytesOut">The transformed bytes</param>
/// <param name="LengthOut">The number of bytes to transform</param>
/// <param name="Last">If 1, this is the last data block to process. Otherwise, further
/// blocks will follow. Note that a transformer is not required to provide intermediate
/// results.</param>
/// <returns>Status result</returns>
int RecryptConvert(RecryptEnvironment* Environment, char* BytesIn, size_t LengthIn,
	char** BytesOut, size_t* LengthOut, bool Last) {

	// For the sake of example, we will merely convert upper to lower case.
	char* Bytes = ALLOCATE_ARRAY(Environment, char, LengthIn);

	size_t i;

	for (i = 0; i < LengthIn; i++) {
		Bytes[i] = ToLower(BytesIn[i]);
		}

	BytesOut = &Bytes;
	LengthOut = LengthIn;
	}

/// <summary>
/// Allocate managed memory
/// </summary>
/// <param name="Parent">The parent for this memory block</param>
/// <param name="Size">The number of bytes to allocate</param>
/// <returns>The allocated memory</returns>
void *RecryptAllocate(void *Parent, size_t Length) {
	void *Memory = malloc(Length + sizeof(MemoryHeader));

	if (Memory == NULL) {
		return NULL;
		}
	
	MemoryHeader *Header = (MemoryHeader*)Memory;
	Header->Length = Length;
	Header->Child = NULL;
	Header->Previous = NULL;

	if (Parent == NULL) {
		Header->Child = NULL;
		Header->Next = NULL;
		}
	else {
		MemoryHeader *ParentHeader = OFFSET_REVERSE(Parent, sizeof(MemoryHeader));
		if (ParentHeader->Child == NULL) {
			// Start a new chain.
			ParentHeader->Child = Header;
			Header->Next = NULL;
			}
		else {
			// loop into existing chain.
			Header->Next = ParentHeader->Child;
			ParentHeader->Child->Previous = Header;
			ParentHeader->Child = Header;
			}
		}


	return OFFSET(Memory, sizeof(MemoryHeader));
	}


/// <summary>
/// Free memory allocated by recryption library.
///
/// If called on an object of type RecryptEnvironment, it deallocates all the memory previously 
/// allocated to process that environment that has not been previously deallocated. This avoids
/// the need for callers to track and deallocate this memory.
/// </summary>
/// <param name="Object">The data object to free.</param>
/// <returns>Status result</returns>
int RecryptFree(void* Object) {
	MemoryHeader *Header = OFFSET_REVERSE(Object, sizeof(MemoryHeader));

	if (Header->Child != NULL) {
		// free all children
		RecryptFreeChildren(Header->Child);
		}

	// Unlink from double linked chain.
	if (Header->Previous != NULL) {
		Header->Previous->Next = Header->Next;
		}
	if (Header->Next != NULL) {
		Header->Next->Previous = Header->Previous;
		}

	free(Header);

	return RECRYPT_STATUS_Success;
	}

/// <summary>
/// Recursively free list of child memory blocks
/// </summary>
/// <param name="Object">The first object in the list</param>
/// <returns>Status result</returns>
int RecryptFreeChildren(MemoryHeader *Header) {
	while (Header != NULL) {
		if (Header->Child != NULL) {
			// free all children
			RecryptFreeChildren(Header->Child);
			}
		MemoryHeader *Next = Header->Next;
		free(Header);
		Header = Next;
		}

	return RECRYPT_STATUS_Success;
	}
