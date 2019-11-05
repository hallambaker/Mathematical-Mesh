namespace Goedel.Cryptography {

    ///<summary>Enumeration used to specify information requested from the platform
    ///to enable use of platform specific features.</summary>
    public enum PlatformInformation {

        ///<summary>Current user's home directory</summary>
        DirectoryPersonalHome,

        ///<summary>Current user's home directory</summary>
        DirectoryApplicationHome,

        ///<summary>Directory used to store  personal cryptographic keys.</summary>
        DirectoryPersonalKeys,

        ///<summary>Directory used to store Mesh container logs.</summary>
        DirectoryMeshContainer

        }

    ///<summary>Returns information used to configure the platform.</summary>
    public delegate string GetPlatformInformationDelegate(PlatformInformation platformInformation);

    }
