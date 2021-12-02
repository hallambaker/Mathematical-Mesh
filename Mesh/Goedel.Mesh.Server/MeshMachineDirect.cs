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

namespace Goedel.Mesh.Server;

public class MeshMachineDirect : IMeshMachineClient {

    IMeshMachineClient MeshMachineClient { get; }
    PublicMeshService PublicMeshService { get; }

    public MeshMachineDirect(
                IMeshMachineClient meshMachineClient,
                PublicMeshService publicMeshService
                ) {
        MeshMachineClient = meshMachineClient;
        PublicMeshService = publicMeshService;
        }

    ///<inheritdoc/>
    public MeshHost MeshHost => MeshMachineClient.MeshHost;

    ///<inheritdoc/>
    public string DirectoryMesh => MeshMachineClient.DirectoryMesh;

    ///<inheritdoc/>
    public IKeyCollection KeyCollection => MeshMachineClient.KeyCollection;

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
    public MeshServiceClient GetMeshClient(ICredentialPrivate credential, string service, string accountAddress) {
        var jpcSessionSerialized = new JpcSessionSerialized(PublicMeshService, credential) {
            TargetAccount = accountAddress
            };
        return jpcSessionSerialized.GetWebClient<MeshServiceClient>();

        }

    }
