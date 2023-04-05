#region // Copyright - MIT License
//  Copyright © 2015 by Comodo Group Inc.
//  Copyright © 2019-2021 by Phill Hallam-Baker
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

using Goedel.Cryptography.Core;

namespace Goedel.Mesh.Core;

/// <summary>
/// Machine using a client directly bound to the underlying service.
/// </summary>
public class MeshMachineDirect : Disposable, IMeshMachineClient {

    IMeshMachineClient MeshMachineClient { get; }
    MeshService PublicMeshService { get; }


    public Dictionary<string, JpcInterface> DirectServices { get; } = new();


    /// <summary>
    /// Constructor returning a new instance connecting to the service 
    /// <paramref name="publicMeshService"/> by means of the client 
    /// <paramref name="meshMachineClient"/>.
    /// </summary>
    /// <param name="meshMachineClient">A client instance provisioned with the
    /// necessary credential.</param>
    /// <param name="publicMeshService">The service instance.</param>
    public MeshMachineDirect(
                IMeshMachineClient meshMachineClient,
                MeshService publicMeshService
                ) {
        MeshMachineClient = meshMachineClient;
        PublicMeshService = publicMeshService;
        }

    ///<inheritdoc/>
    public virtual string? Instance => null;

    ///<inheritdoc/>
    public MeshHost MeshHost => MeshMachineClient.MeshHost;

    ///<inheritdoc/>
    public string DirectoryMesh => MeshMachineClient.DirectoryMesh;

    ///<inheritdoc/>
    public string DirectoryKeys => MeshMachineClient.DirectoryKeys;

    ///<inheritdoc/>
    public string DirectoryAccounts => MeshMachineClient.DirectoryAccounts;

    ///<inheritdoc/>
    public IKeyCollection KeyCollection => MeshMachineClient.KeyCollection;

    ///<summary>The Callsign resolution service (if bound).</summary> 
    public ResolverService ResolverService { get; private set; }

    ///<summary>The Carnet payment service (if bound).</summary> 
    public CarnetService CarnetService { get; private set; }

    ///<inheritdoc/>
    public KeyPair CreateKeyPair(CryptoAlgorithmId algorithmID, KeySecurity keySecurity, int keySize = 0, KeyUses keyUses = KeyUses.Any) =>
        MeshMachineClient.CreateKeyPair(algorithmID, keySecurity, keySize, keyUses);

    ///<inheritdoc/>
    public ICredentialPrivate GetCredential(string deviceUdf, string connectionUdf) =>
        MeshMachineClient.GetCredential(deviceUdf, connectionUdf);

    ///<inheritdoc/>
    public string GetFilePath(string filepath) =>
        MeshMachineClient.GetFilePath(filepath);

    ///<inheritdoc/>
    public string GetServiceDirectory(string service) =>
        KeyCollectionCore.GetServiceDirectory(service);

    ///<inheritdoc/>
    public MeshServiceClient GetMeshClient(ICredentialPrivate credential, string accountAddress) {

        var publicCredential = credential.GetICredentialPublic();
        var jpcSessionSerialized = new JpcSessionSerialized(PublicMeshService, publicCredential) {
            TargetAccount = accountAddress
            };
        return jpcSessionSerialized.GetWebClient<MeshServiceClient>();

        }

    ///<inheritdoc/>
    public T GetClient<T>(
        string wellKnown, ICredentialPrivate credential = null,
                string accountAddress = null) where T : JpcClientInterface, new() {

        (DirectServices.TryGetValue(wellKnown, out var jpcServiceClient)).AssertTrue(NYI.Throw);

        var jpcSessionSerialized = new JpcSessionSerialized(jpcServiceClient, credential) {
            TargetAccount = accountAddress
            };

        var result = jpcSessionSerialized.GetWebClient<T>();

        return result;

        }

    /// <summary>
    /// Add service to direct interface machine.
    /// </summary>
    /// <param name="jpcInterface"></param>
    public void AddService(JpcInterface jpcInterface) {
        DirectServices.Add(jpcInterface.GetWellKnown, jpcInterface);

        switch (jpcInterface) {
            case ResolverService resolverService: {
                ResolverService = resolverService;
                break;
                }
            case CarnetService carnetService: {
                CarnetService = carnetService;
                break;
                }
            }
        }


    ///<inheritdoc/>
    public virtual IResolver GetResolver(ICredentialPrivate credential) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public virtual ICarnet GetCarnet(ICredentialPrivate credential) {
        throw new NotImplementedException();
        }

    }
