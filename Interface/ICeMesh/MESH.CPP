//
// Based on 'Inside Com by Dale Rogerson' book, CH7
//

//
// mesh.cpp
//
#include <iostream>
#include <objbase.h>

#include "Iface.h"      // Interface declarations
#include "Registry.h"   // Registry helper functions

using namespace std;

// Trace function
void trace(const char* msg) { cout << msg << endl ;}

///////////////////////////////////////////////////////////
//
// Global variables
//
static HMODULE g_hModule = NULL ;   // DLL module handle
static long g_cComponents = 0 ;     // Count of active components
static long g_cServerLocks = 0 ;    // Count of locks

// Friendly name of component
const char g_szFriendlyName[] = "Mesh Decrypt Component" ;

// Version-independent ProgID
const char g_szVerIndProgID[] = "Mesh.Decrypt" ;

// ProgID
const char g_szProgID[] = "Mesh.Decrypt.1" ;

// Interface to the C# code
using DecryptFn = int(__stdcall *) (
	const char* InputArray, int InputLength,
	char**OutputArray, int *OutputLength);

HMODULE mod;
DecryptFn ManagedDecrypt;


static char ToLower(char In) {
	return (In < 'A' || In > 'O') ? In : In + 32;
	}

///////////////////////////////////////////////////////////
//
// Component 
//
class MeshComponent : public IDecrypt {
public:
	// IUnknown
	virtual HRESULT __stdcall QueryInterface(const IID& iid, void** ppv);
	virtual ULONG __stdcall AddRef();
	virtual ULONG __stdcall Release();
	virtual HRESULT __stdcall Decrypt(
		CHAR *InputArray,
		ULONG InputLength,
		CHAR **OutputArray,
		ULONG *OutLength,
		ULONG *ContentType);

	// Constructor
	MeshComponent();

	// Destructor
	~MeshComponent();

private:
	// Reference count
	long m_cRef;
	};


//
// Constructor
//
MeshComponent::MeshComponent() : m_cRef(1)
{
    InterlockedIncrement(&g_cComponents) ; 
}

//
// Destructor
//
MeshComponent::~MeshComponent()
{ 
    InterlockedDecrement(&g_cComponents) ; 
    trace("Component:\t\tDestroy self.") ;
}

//
// IUnknown implementation
//
HRESULT __stdcall MeshComponent::QueryInterface(const IID& iid, void** ppv) {
	if (iid == IID_IUnknown) {
		*ppv = static_cast<IDecrypt*>(this);
		}
	else if (iid == IID_IDecrypt) {
		*ppv = static_cast<IDecrypt*>(this);
		trace("Component:\t\tReturn pointer to IDecrypt.");
		}
	else {
		*ppv = NULL;
		return E_NOINTERFACE;
		}
	reinterpret_cast<IUnknown*>(*ppv)->AddRef();
	return S_OK;
	}

ULONG __stdcall MeshComponent::AddRef() {
	return InterlockedIncrement(&m_cRef);
	}

ULONG __stdcall MeshComponent::Release() {
	if (InterlockedDecrement(&m_cRef) == 0) {
		delete this;
		return 0;
		}
	return m_cRef;
	}


ULONG MakeString(const char *input, char**output) {
	int length = strlen(input) + 1;
	char *OutBuffer = static_cast<PCHAR>(CoTaskMemAlloc(length * sizeof(CHAR)));

	strncpy(OutBuffer, input, length);

	*output = OutBuffer;
	return length;
	}


void adx_store_data(const char *filepath, const char *data) {
	FILE *fp = fopen(filepath, "ab");
	if (fp != NULL) {
		fputs(data, fp);
		fclose(fp);
		}
	}

HRESULT __stdcall MeshComponent::Decrypt(
	CHAR *InputArray,
	ULONG InputLength,
	CHAR **OutputArray,
	ULONG *OutLength,
	ULONG *ContentType) {
	PCHAR OutBuffer;
	ULONG i;
	trace("Component:\t\tDecrypt called");

	if (!InputArray || !OutputArray || !OutLength)
		return E_FAIL;



	mod = LoadLibraryA("C:\\Users\\hallam\\Work\\Experiment\\Pinvoke\\ExportedCodeSolution\\bin\\x86\\Release\\ExportedCodeSolution.dll");
	ManagedDecrypt = reinterpret_cast<DecryptFn>(GetProcAddress(mod, "Decrypt"));


	//const int bufsize = 10000;
	//char buffer[bufsize];
	//
	//snprintf(buffer, bufsize, "Make my day %p / %p", mod, ManagedDecrypt);
	//*OutLength = MakeString(buffer, OutputArray);

	int outlen;
	ManagedDecrypt(InputArray, InputLength, OutputArray, &outlen);
	*OutLength = (ULONG)outlen;


	//OutBuffer = static_cast<PCHAR>(CoTaskMemAlloc(InputLength * sizeof(CHAR)));
	//if (!OutBuffer)
	//	return E_FAIL;

	//FILE *fp = fopen("C:\\Users\\hallam\\Work\\ICEDragonDump.txt", "w");

	//for (i = 0; i < InputLength; i++) {
	//	OutBuffer[i] = ToLower(InputArray[i]);
	//	fputc(OutBuffer[i], fp);
	//	}
	//fclose(fp);

	 //set output buffer
	//
	//*OutputArray = OutBuffer;
	//*OutLength = InputLength;

	if (ContentType != NULL)
		*ContentType = 1;

	return S_OK;
	}







///////////////////////////////////////////////////////////
//
// Class factory
//
class CFactory : public IClassFactory
{
public:
    // IUnknown
    virtual HRESULT __stdcall QueryInterface(const IID& iid, void** ppv);
    virtual ULONG   __stdcall AddRef() ;
    virtual ULONG   __stdcall Release() ;
    
    // Interface IClassFactory
    virtual HRESULT __stdcall CreateInstance(IUnknown* pUnknownOuter,
                                             const IID& iid,
                                             void** ppv) ;
    virtual HRESULT __stdcall LockServer(BOOL bLock) ; 
    
    // Constructor
    CFactory() : m_cRef(1) {}
    
    // Destructor
    ~CFactory() { trace("Class factory:\t\tDestroy self.") ;}

private:
    long m_cRef ;
};

//
// Class factory IUnknown implementation
//
HRESULT __stdcall CFactory::QueryInterface(const IID& iid, void** ppv)
{    
    if ((iid == IID_IUnknown) || (iid == IID_IClassFactory))
    {
        *ppv = static_cast<IClassFactory*>(this) ; 
    }
    else
    {
        *ppv = NULL ;
        return E_NOINTERFACE ;
    }
    reinterpret_cast<IUnknown*>(*ppv)->AddRef() ;
    return S_OK ;
}

ULONG __stdcall CFactory::AddRef()
{
	return InterlockedIncrement(&m_cRef) ;
}

ULONG __stdcall CFactory::Release() 
{
    if (InterlockedDecrement(&m_cRef) == 0)
    {
        delete this ;
        return 0 ;
    }
    return m_cRef ;
}

//
// IClassFactory implementation
//
HRESULT __stdcall CFactory::CreateInstance(IUnknown* pUnknownOuter,
                                           const IID& iid,
                                           void** ppv) 
{
    trace("Class factory:\t\tCreate component.") ;
    
    // Cannot aggregate.
    if (pUnknownOuter != NULL)
    {
        return CLASS_E_NOAGGREGATION ;
    }
    
    // Create component.
    MeshComponent* pA = new MeshComponent;
    if (pA == NULL)
    {
        return E_OUTOFMEMORY ;
    }
    
    // Get the requested interface.
    HRESULT hr = pA->QueryInterface(iid, ppv) ;
    
    // Release the IUnknown pointer.
    // (If QueryInterface failed, component will delete itself.)
    pA->Release() ;
    return hr ;
}

// LockServer
HRESULT __stdcall CFactory::LockServer(BOOL bLock) 
{
    if (bLock)
    {
        InterlockedIncrement(&g_cServerLocks) ; 
    }
    else
    {
        InterlockedDecrement(&g_cServerLocks) ;
    }
    return S_OK ;
}


///////////////////////////////////////////////////////////
//
// Exported functions
//

//
// Can DLL unload now?
//
STDAPI DllCanUnloadNow()
{
    if ((g_cComponents == 0) && (g_cServerLocks == 0))
    {
        return S_OK ;
    }
    else
    {
        return S_FALSE ;
    }
}

//
// Get class factory
//
STDAPI DllGetClassObject(const CLSID& clsid,
                         const IID& iid,
                         void** ppv)
{
    trace("DllGetClassObject:\tCreate class factory.") ;
    
    // Can we create this component?
    if (clsid != CLSID_Mesh)
    {
        return CLASS_E_CLASSNOTAVAILABLE ;
    }
    
    // Create class factory.
    CFactory* pFactory = new CFactory ;  // Reference count set to 1
                                         // in constructor
    if (pFactory == NULL)
    {
        return E_OUTOFMEMORY ;
    }
    
    // Get requested interface.
    HRESULT hr = pFactory->QueryInterface(iid, ppv) ;
    pFactory->Release() ;

    return hr ;
}


//
// Server registration
//
STDAPI DllRegisterServer() {
	mod = LoadLibraryA("C:\\Users\\hallam\\Work\\Experiment\\Pinvoke\\ExportedCodeSolution\\bin\\x86\\Release\\ExportedCodeSolution.dll");
	ManagedDecrypt = reinterpret_cast<DecryptFn>(GetProcAddress(mod, "Decrypt"));

	return RegisterServer(g_hModule,
		CLSID_Mesh,
		g_szFriendlyName,
		g_szVerIndProgID,
		g_szProgID);
	}


//
// Server unregistration
//
STDAPI DllUnregisterServer() {
	return UnregisterServer(CLSID_Mesh,
		g_szVerIndProgID,
		g_szProgID);
	}

///////////////////////////////////////////////////////////
//
// DLL module information
//
BOOL APIENTRY DllMain(HANDLE hModule,
	DWORD dwReason,
	void* lpReserved) {
	if (dwReason == DLL_PROCESS_ATTACH) {
		g_hModule = (HMODULE)hModule;
		}
	return TRUE;
	}
