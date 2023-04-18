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

using Goedel.Cryptography;


namespace Goedel.Protocol.Presentation;

/// <summary>
/// Credential interface
/// </summary>
public interface ICredentialPublic : ICredential {
    #region // Properties

    ///<summary>The public authentication key.</summary> 
    public KeyPairAdvanced AuthenticationPublic { get; }

    #endregion
    #region // Methods 


    /// <summary>
    /// Return a private ephemeral key and compatible public key from the 
    /// credential keys
    /// </summary>
    /// <returns>The ephemeral private key and credential public key.</returns>
    (KeyPairAdvanced, KeyPairAdvanced) SelectKey();


    /// <summary>
    /// SelectEnvelope an ephemeral from <paramref name="ephemerals"/> that is compatible with 
    /// the creedential key <paramref name="keyId"/>.
    /// </summary>
    /// <param name="keyId">If specified, the first ephemeral in the list compatible
    /// with the specified key will be used.</param> 
    /// <param name="ephemerals">List of ephemerals previously offered to
    /// perform a key agreement against.</param>

    /// <returns>The ephemeral private key and credential public key.</returns>
    (KeyPairAdvanced, KeyPairAdvanced) SelectKey(
            List<KeyPairAdvanced> ephemerals,
            string keyId);


    #endregion
    }

/// <summary>
/// Credential with private key affordances.
/// </summary>
public interface ICredentialPrivate : ICredentialPublic {
    #region // Properties


    #endregion
    #region // Methods 


    /// <summary>
    /// Extract the first recognized credential from the exension list 
    /// <paramref name="extensions"/>
    /// </summary>
    /// <param name="extensions">List of extensions to parse.</param>
    /// <returns>The credential if found, otherwise null.</returns>
    ICredentialPublic GetCredentials(
                List<PacketExtension> extensions);


    /// <summary>
    /// Generate a set of ephemerals for the supported algorithms to offer for 
    /// key agreement and add to <paramref name="extensions"/>.
    /// </summary>
    /// <param name="extensions">List of extensions to add the ephemerals to.</param>
    /// <param name="ephmeralsOffered">List of ephemerals that have been offered, if
    /// this is not null, the ephemerals in this list will be returned. Otherwise a list
    /// will be created and populated with the ephemerals offered.</param>
    public void AddEphemerals(
        List<PacketExtension> extensions,
        ref List<KeyPairAdvanced> ephmeralsOffered);

    /// <summary>
    /// Add an extension containing this credential to <paramref name="extensions"/>.
    /// </summary>
    /// <param name="extensions">List of extensions to add the credential to.</param>
    void AddCredentials(
                List<PacketExtension> extensions
                );


    /// <summary>
    /// SelectEnvelope a private key compatible with the ephemeral keys offered in 
    /// <paramref name="extensions"/> and return the private key and ephemeral
    /// chosen.
    /// </summary>
    /// <param name="extensions">List of extensions offering ephemeral keys to
    /// perform a key agreement against.</param>

    /// <returns>The private key and public key.</returns>
    (KeyPairAdvanced, KeyPairAdvanced) SelectKey(
            List<PacketExtension> extensions);



    /// <summary>
    /// Return a private key and public key compatible with the values specified
    /// by <paramref name="keyId"/> and <paramref name="ephemeral"/>.
    /// chosen.
    /// </summary>
    /// <param name="keyId">The key identifier.</param>
    /// <param name="ephemeral">Ephemeral data specifying a public key </param>
    /// <returns>The ephemeral private key and credential public key.</returns>
    (KeyPairAdvanced, KeyPairAdvanced) SelectKey(
            string keyId, byte[] ephemeral);


    /// <summary>
    /// Return the public credential corresponding to the private.
    /// </summary>
    /// <returns></returns>
    public ICredentialPublic GetICredentialPublic();
    #endregion
    }
