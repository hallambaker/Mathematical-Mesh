

//
// Code generated automatically
//
// Do not edit!

// 


#ifndef _HEADER_ConfirmationBroker
#define _HEADER_ConfirmationBroker 1

// Protocol:	ConfirmationBroker
// Prefix:		CNF

#include <protogenlib\common.h>

// Structure ConfirmationRequest

typedef struct _CNF_ConfirmationRequest {
	struct _CNF_ConfirmationRequest		*_Next;
	int								_Type;
	struct _JSON_String				_String;		// Maybe only include if declared to be a FORMAT?
	JSON_String			Account;
	JSON_String			Text;
	JSON_Group				Option;
	} CNF_ConfirmationRequest;

// Structure ConfirmationRequest2

typedef struct _CNF_ConfirmationRequest2 {
	struct _CNF_ConfirmationRequest2		*_Next;
	int								_Type;
	struct _JSON_String				_String;		// Maybe only include if declared to be a FORMAT?
	JSON_String			Account;
	JSON_String			Text;
	JSON_Group				Option;
	JSON_String			Test;
	} CNF_ConfirmationRequest2;

// Structure ConfirmationResponse

typedef struct _CNF_ConfirmationResponse {
	struct _CNF_ConfirmationResponse		*_Next;
	int								_Type;
	struct _JSON_String				_String;		// Maybe only include if declared to be a FORMAT?
	JSON_Binary			TransactionID;
	} CNF_ConfirmationResponse;

// Structure StatusRequest

typedef struct _CNF_StatusRequest {
	struct _CNF_StatusRequest		*_Next;
	int								_Type;
	struct _JSON_String				_String;		// Maybe only include if declared to be a FORMAT?
	JSON_Binary			TransactionID;
	} CNF_StatusRequest;

// Structure StatusResponse

typedef struct _CNF_StatusResponse {
	struct _CNF_StatusResponse		*_Next;
	int								_Type;
	struct _JSON_String				_String;		// Maybe only include if declared to be a FORMAT?
	JSON_String			Option;
	} CNF_StatusResponse;

// Structure CancelRequest

typedef struct _CNF_CancelRequest {
	struct _CNF_CancelRequest		*_Next;
	int								_Type;
	struct _JSON_String				_String;		// Maybe only include if declared to be a FORMAT?
	JSON_Binary			TransactionID;
	} CNF_CancelRequest;

// Structure CancelResponse

typedef struct _CNF_CancelResponse {
	struct _CNF_CancelResponse		*_Next;
	int								_Type;
	struct _JSON_String				_String;		// Maybe only include if declared to be a FORMAT?
	} CNF_CancelResponse;


// Type tag values

#define CNF_TYPE_String  0
#define CNF_TYPE_Binary  1
#define CNF_TYPE_Int64  2
#define CNF_TYPE_Decimal64  3
#define CNF_TYPE_Real64  4
#define CNF_TYPE_Boolean  5
#define CNF_TYPE_DateTime  6
#define CNF_TYPE_URI  7
#define CNF_TYPE_Format  8
#define CNF_TYPE_ConfirmationRequest  9
#define CNF_TYPE_ConfirmationRequest2  10
#define CNF_TYPE_ConfirmationResponse  11
#define CNF_TYPE_StatusRequest  12
#define CNF_TYPE_StatusResponse  13
#define CNF_TYPE_CancelRequest  14
#define CNF_TYPE_CancelResponse  15
#define CNF_TYPE__Count 16

// Function Prototype Definitions..

// Structure ConfirmationRequest
int CNF_Serialize_ConfirmationRequest (
		JSON_Context *Context, CNF_ConfirmationRequest *Data);
int CNF_Deserialize_ConfirmationRequest (
		JSON_Context *Context, CNF_ConfirmationRequest **Data);
// Structure ConfirmationRequest2
int CNF_Serialize_ConfirmationRequest2 (
		JSON_Context *Context, CNF_ConfirmationRequest2 *Data);
int CNF_Deserialize_ConfirmationRequest2 (
		JSON_Context *Context, CNF_ConfirmationRequest2 **Data);
// Structure ConfirmationResponse
int CNF_Serialize_ConfirmationResponse (
		JSON_Context *Context, CNF_ConfirmationResponse *Data);
int CNF_Deserialize_ConfirmationResponse (
		JSON_Context *Context, CNF_ConfirmationResponse **Data);
// Structure StatusRequest
int CNF_Serialize_StatusRequest (
		JSON_Context *Context, CNF_StatusRequest *Data);
int CNF_Deserialize_StatusRequest (
		JSON_Context *Context, CNF_StatusRequest **Data);
// Structure StatusResponse
int CNF_Serialize_StatusResponse (
		JSON_Context *Context, CNF_StatusResponse *Data);
int CNF_Deserialize_StatusResponse (
		JSON_Context *Context, CNF_StatusResponse **Data);
// Structure CancelRequest
int CNF_Serialize_CancelRequest (
		JSON_Context *Context, CNF_CancelRequest *Data);
int CNF_Deserialize_CancelRequest (
		JSON_Context *Context, CNF_CancelRequest **Data);
// Structure CancelResponse
int CNF_Serialize_CancelResponse (
		JSON_Context *Context, CNF_CancelResponse *Data);
int CNF_Deserialize_CancelResponse (
		JSON_Context *Context, CNF_CancelResponse **Data);

PUBLIC_ENTRY CNF__Initialize ();
PUBLIC_ENTRY CNF_Initialize ();
PUBLIC_ENTRY CNF__End ();
PUBLIC_ENTRY CNF_End ();

#define CNF_Initialize CNF__Initialize
#define CNF_End CNF__End

PUBLIC_ENTRY CNF_Create (void *parent, long type, void **Result_Out);
PUBLIC_ENTRY CNF_Create_Context (JSON_Stream *Stream, JSON_Context **Result_Out);
PUBLIC_ENTRY CNF_Free (void *item);
PUBLIC_ENTRY CNF_Deserialize_List (JSON_Context *Context, void **Data_out) ;
PUBLIC_ENTRY CNF_Deserialize (JSON_Context *Context, void **Data_out) ;

PUBLIC_ENTRY CNF_Create_ConfirmationRequest (void *parent, CNF_ConfirmationRequest **Result_Out) ;
PUBLIC_ENTRY CNF_Create_ConfirmationRequest2 (void *parent, CNF_ConfirmationRequest2 **Result_Out) ;
PUBLIC_ENTRY CNF_Create_ConfirmationResponse (void *parent, CNF_ConfirmationResponse **Result_Out) ;
PUBLIC_ENTRY CNF_Create_StatusRequest (void *parent, CNF_StatusRequest **Result_Out) ;
PUBLIC_ENTRY CNF_Create_StatusResponse (void *parent, CNF_StatusResponse **Result_Out) ;
PUBLIC_ENTRY CNF_Create_CancelRequest (void *parent, CNF_CancelRequest **Result_Out) ;
PUBLIC_ENTRY CNF_Create_CancelResponse (void *parent, CNF_CancelResponse **Result_Out) ;

#endif // _HEADER_ConfirmationBroker



