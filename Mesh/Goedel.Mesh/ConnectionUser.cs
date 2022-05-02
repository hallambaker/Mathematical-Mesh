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

public partial class ConnectionStripped {
    ///<summary>Typed enveloped data</summary> 
    public Enveloped<ConnectionStripped> GetEnvelopedConnectionAddress() =>
        new(DareEnvelope);

    /// <summary>
    /// Minimize the connection data to remove unnecessary data.
    /// </summary>
    public void Strip() {
        if (Authentication != null) {
            Authentication.Udf = null;
            }
        }

    }

public partial class ConnectionDevice {
    ///<summary>Typed enveloped data</summary> 
    public Enveloped<ConnectionDevice> GetEnvelopedConnectionDevice() =>
        new(DareEnvelope);

    }


public partial class ConnectionService {

    ///<summary>Typed enveloped data</summary> 
    public Enveloped<ConnectionService> GetEnvelopedConnectionService() =>
        new(DareEnvelope);


    ///<inheritdoc cref="ICredential"/>
    public KeyPairAdvanced AuthenticationPublic => Authentication.GetKeyPairAdvanced();


    /// <summary>
    /// Constructor for use by deserializers.
    /// </summary>
    public ConnectionService() {
        }


    /// <summary>
    /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
    /// a leading indent of <paramref name="indent"/> units. The cryptographic context from
    /// the key collection <paramref name="keyCollection"/> is used to decrypt any encrypted data.
    /// </summary>
    /// <param name="builder">The string builder to write to.</param>
    /// <param name="indent">The number of units to indent the presentation.</param>
    /// <param name="keyCollection">The key collection to use to obtain decryption keys.</param>
    public override void ItemToBuilder(StringBuilder builder, int indent = 0, IKeyCollection keyCollection = null) {

        builder.AppendIndent(indent, $"Connection Device");
        indent++;
        DareEnvelope.Report(builder, indent);
        indent++;
        //builder.AppendIndent(indent, $"KeyOfflineSignature: {KeyOfflineSignature.UDF} ");

        //if (KeysOnlineSignature != null) {
        //    foreach (var online in KeysOnlineSignature) {
        //        builder.AppendIndent(indent, $"   KeysOnlineSignature: {online.UDF} ");
        //        }
        //    }
        //builder.AppendIndent(indent, $"KeyEncryption:       {Encryption.Udf} ");
        builder.AppendIndent(indent, $"KeyAuthentication:   {Authentication.Udf} ");

        }

    ///<inheritdoc cref="ICredential"/>
    public (KeyPairAdvanced, KeyPairAdvanced) SelectKey() =>
        (KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced,
                    AuthenticationPublic);

    ///<inheritdoc cref="ICredential"/>
    public (KeyPairAdvanced, KeyPairAdvanced) SelectKey(List<KeyPairAdvanced> ephemerals, string keyId) =>
        (ephemerals[0], AuthenticationPublic);



    /// <summary>
    /// Minimize the connection data to remove unnecessary data.
    /// </summary>
    public void Strip() {
        if (Authentication != null) {
            Authentication.Udf = null;
            }
        }

    }
