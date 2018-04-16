//
// Based on 'Inside Com by Dale Rogerson' book, CH7
//

//
// Client.cpp - client implementation
//
#include <iostream>
#include <objbase.h>
#include "Iface.h"

using namespace std;

void trace(const char* msg) { cout << "Client: \t\t" << msg << endl ;}

//
// main function
//
int main()
{
    IDecrypt* pDecrypt = NULL ;
    CHAR InputText[] = "This is a test";
    CHAR *OutputArray;
    ULONG OutLength, ContentType;

    // Initialize COM Library
    CoInitialize(NULL);
    trace("Call CoCreateInstance to create component and get interface IDecrypt.") ;

    HRESULT hr = ::CoCreateInstance(CLSID_Mesh,
                                    NULL, 
                                    CLSCTX_INPROC_SERVER,
                                    IID_IDecrypt,
                                    (void**)&pDecrypt) ;
    if (FAILED(hr))
    {
        trace("CoCreateInstance failed.");
        return -1;
    }
    
    trace("Succeeded getting IDecrypt interface.");
    hr = pDecrypt->Decrypt(InputText,
                           strlen(InputText),
                           &OutputArray, 
                           &OutLength,
                           &ContentType);
    if (SUCCEEDED(hr))
    {
        trace("Call to IDecrypt->Decrypt() succeeded");
        CoTaskMemFree(OutputArray);
    }
    else
    {
        trace("Call to IDecrypt->Decrypt() failed") ;
    }
    pDecrypt->Release();
    
    // Uninitialize COM Library
    CoUninitialize();
    
    return 0;
}
