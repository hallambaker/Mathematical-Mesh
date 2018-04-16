//
// Based on 'Inside Com by Dale Rogerson' book, CH7
//

//
// Iface.h - 
//    Declarations of interfaces, IIDs, and CLSID
//    shared by the client and the component.
//
interface IDecrypt : IUnknown
{
    virtual HRESULT __stdcall Decrypt(
        CHAR *InputArray,
        ULONG InputLength,
        CHAR **OutputArray,
        ULONG *OutLength,
        ULONG *ContentType) = 0;
};

//
// Declaration of GUIDs for interfaces and component.
//   These constants are defined in GUIDs.cpp.
//
extern "C" const IID IID_IDecrypt;
extern "C" const CLSID CLSID_Mesh;
