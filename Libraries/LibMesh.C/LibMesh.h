#pragma once
#include <stdbool.h>

/*

Recryption API stub.

This is a draft of an API to interface a Web Browser to the recryption service. While it
is intended that the initial implementation will rely on a shell script or P-Invoke call
to the C# library, the API is designed to support a native implementation at a later date.

The code is written in C but may be wrapped with a C++ class should that be desired.

The code is intended to be 64 bit clean.
*/

/*

Code example. The following code reads data from a stream 'DataSource' and presents it chunk by
chunk to the Recryption API.

typedef struct _DataSource {
int EOF;
int(*Read) (char** BytesIn, long long LengthIn);
int(*Write) (char** BytesIn, long long LengthIn);
} DataSource;

void convert (DataSource *Browser) {
char* ciphertext; long long ciphertext_l;
char* plaintext; long long plaintext_l;

RecryptEnvironment *EnvironmentRecrypt;

RecryptStart(&EnvironmentRecrypt);

while (!Browser->EOF) {

// Get a chunk
Browser->Read(ciphertext, ciphertext_l);

// Process this chunk
RecryptConvert(EnvironmentRecrypt, ciphertext, ciphertext_l, plaintext, plaintext_l, 0);
Browser->Write(plaintext, plaintext_l);

// (Optional) Uncomment to free the memory buffer as we go along.
// RecryptFree(plaintext);
}

// Process the last chunk
RecryptConvert(EnvironmentRecrypt, (void*) 0, 0, plaintext, plaintext_l, 1);
Browser->Write(plaintext, plaintext_l);

// Free the memory
RecryptFree(EnvironmentRecrypt);
}

*/

/// <summary>
/// The recryption environment. The public members describe the decrypted content.
/// </summary>
typedef struct _RecryptEnvironment {
	// Public fields
	bool		MetadataComplete;			// Is 1 if the package metadata has been parsed, otherwise 0.
	char		*ContentType;				// The Content Type of the decrypted data.
	size_t		ContentLength;				// The content length if known, otherwise -1.
	int			RecryptionState;			// The decryption engine state.
	char		*SignerUDF;					// The UDF fingerprint of the signer.

											// Public methods
	int(*Convert)(
		struct _RecryptEnvironment *Env,	// this object
		char* BytesIn, size_t LengthIn,		// The ciphertext
		char** BytesOut, size_t* LengthOut,	// The plaintext
		bool Last);							// If true, is the last buffer.

	int(*Free)(							// The Free method.
		void*);					// The data to free.
	} RecryptEnvironment;

#define RECRYPT_STATUS_Success					 1
#define RECRYPT_STATUS_Fail						-1
#define RECRYPT_STATUS_Fail_Unknown_Group		-2
#define RECRYPT_STATUS_Fail_Refused				-3
#define RECRYPT_STATUS_Fail_Authentication		-4
#define RECRYPT_STATUS_Fail_Invalid_Object		-5


#define RECRYPT_ENGINE_Parse_Header				0
#define RECRYPT_ENGINE_Parse_Get_Key			1
#define RECRYPT_ENGINE_Parse_Decrypt			2
#define RECRYPT_ENGINE_Parse_Failed				3

/// <summary>
/// Begin recryption of a document.
/// </summary>
/// <param name="Environment">The returned environment variable.</param>
/// <returns>Status result</returns>
int RecryptStart(RecryptEnvironment** Environment);

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
	char** BytesOut, size_t* LengthOut, bool Last);

/// <summary>
/// Free memory allocated by recryption library.
///
/// If called on an object of type RecryptEnvironment, it deallocates all the memory previously 
/// allocated to process that environment that has not been previously deallocated. This avoids
/// the need for callers to track and deallocate this memory.
/// </summary>
/// <param name="Object">The data object to free.</param>
/// <returns>Status result</returns>
int RecryptFree(void* Object);


