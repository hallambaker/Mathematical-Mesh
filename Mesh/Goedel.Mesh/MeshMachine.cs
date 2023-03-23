#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion


namespace Goedel.Mesh;

/// <summary>
/// Return a new IMeshMachine.
/// </summary>
/// <returns>The created instance.</returns>
public delegate IMeshMachine GetMachineDelegate();


///// <summary>
///// Support class for MeshMachine containing static methods and delegate dispatch.
///// </summary>
//public static class MeshMachine {

//    ///<summary>The default number of bits in a master key.</summary>
//    public static int DefaultMasterKeyBits = 256;

//    /////<summary>Factory returning an IMeshMachine instance</summary>
//    //public static GetMachineDelegate IMeshMachineFactory;

//    ///<summary>Path to directory where the profiles are stored.</summary>
//    public static string DirectoryProfiles;


//    }


/// <summary>
/// Interface exposed by all Mesh Machine classes.
/// </summary>
public interface IMeshMachine {

    /// <summary>
    /// Convert the file path <paramref name="filepath"/> to a file path that will be 
    /// correctly interpreted relative to the current working directory of the machine.
    /// </summary>
    /// <param name="filepath">The file path to translate.</param>
    /// <returns>The translated file path.</returns>
    string GetFilePath(string filepath);

    ///<summary>The machine instance. May be used to run multiple machine instances on the 
    ///same host for testing, etc.</summary> 
    string? Instance { get; }

    ///<summary>The directory the Mesh data is stored in.</summary>
    string DirectoryMesh { get; }

    ///<summary>The directory the Mesh data is stored in.</summary>
    string DirectoryKeys { get; }

    ///<summary>The key collection to use.</summary>
    IKeyCollection KeyCollection { get; }

    /// <summary>
    /// Factory method to generate a keypair of a type specified by <paramref name="algorithmID"/>
    /// and the specified parameters using the default implementation registered with the
    /// KeyPair type.
    /// </summary>
    /// <param name="algorithmID">The type of keypair to create.</param>
    /// <param name="keySize">The key size (ignored if the algorithm supports only one key size)</param>
    /// <param name="keySecurity">The key security model</param>
    /// <param name="keyUses">The permitted uses (signing, exchange) for the key.</param>
    /// <returns>The created key pair</returns>
    KeyPair CreateKeyPair(
                CryptoAlgorithmId algorithmID,
                KeySecurity keySecurity,
                int keySize = 0,
                KeyUses keyUses = KeyUses.Any);


    /// <summary>
    /// Return a MeshService client for the service ID <paramref name="credential"/>.
    /// </summary>
    /// <param name="credential">Credential to be used to establish the client.</param>
    /// <param name="accountAddress">Account under which service is requested.</param>
    /// <returns>The client instance.</returns>
    MeshServiceClient GetMeshClient(
            ICredentialPrivate credential,
            string accountAddress);



    /// <summary>
    /// Return a client bound to the connection via the relevant protocol
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetClient<T>(
        string wellKnown, ICredentialPrivate credential = null,
                string accountAddress = null) where T : JpcClientInterface, new();

    
    public IResolver GetResolver(ICredentialPrivate credential);


    public ICarnet GetCarnet(ICredentialPrivate credential);


    /// <summary>
    /// Returns the private credential to be presented by the device <paramref name="deviceUdf"/>,
    /// connected to the account or service as <paramref name="connectionUdf"/>.
    /// </summary>
    /// <param name="deviceUdf">The fingerprint of the device profile.</param>
    /// <param name="connectionUdf">The fingerprint of the connection of the device to the
    /// service or account.</param>
    /// <returns>The private credential.</returns>
    ICredentialPrivate GetCredential(string deviceUdf, string connectionUdf);






    }

