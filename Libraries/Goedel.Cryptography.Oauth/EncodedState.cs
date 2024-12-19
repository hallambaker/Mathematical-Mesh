namespace Goedel.Cryptography.Oauth;

/// <summary>
/// The encoded state vector.
/// </summary>
public record EncodedState {

    ///<summary>The OAUTH nonce to ensure uniquness of the request</summary> 
    public byte[] Nonce;

    ///<summary>The user handle (e.g. @alice.example.com)</summary> 
    public string Handle;

    ///<summary>The user's DID</summary> 
    public string DID;

    ///<summary>The redirect URI to return to after completing authentication.</summary> 
    public string RedirectUri;

    ///<summary>The encrypted bytes.</summary> 
    public byte[] Bytes;


    /// <summary>
    /// Constructor, returns an instance under the token manager <paramref name="manager"/>
    /// for the handle <paramref name="handle"/> and redirect <paramref name="redirectUri"/>.
    /// </summary>
    /// <param name="manager">The state manager.</param>
    /// <param name="handle">The OAUTH handle and DID</param>
    /// <param name="redirectUri">The redirect URI.</param>
    public EncodedState(
            EncryptedTokenManager manager,
            OauthHandleResolution handle,
            string redirectUri
            ) {
        Nonce = Platform.GetRandomBytes(16);
        Handle = handle.Handle;
        DID = handle.DidDocument.Id;
        RedirectUri = redirectUri;


        using var memory = new MemoryStream();
        using var writer = new JsonBWriter(memory);

        writer.WriteBinary(Nonce);
        writer.WriteString(Handle);
        writer.WriteString(DID);
        writer.WriteString(RedirectUri);


        Bytes = manager.Encrypt(memory.ToArray());

        }

    /// <summary>
    /// Constructor returns an instance by decrypting the BASE64 encoded string 
    /// <paramref name="encodedDataString"/>
    /// </summary>
    /// <param name="manager">The state manager.</param>
    /// <param name="encodedDataString">The BASE64 encoded encrypted string.</param>
    public EncodedState(
            EncryptedTokenManager manager,
            string encodedDataString
            ) {
        var ciphertext = encodedDataString.FromBase64();
        var plaintext = manager.Decrypt(ciphertext);

        using var memory = new MemoryStream(plaintext);
        using var reader = new JsonBcdReader(plaintext);

        Nonce = reader.ReadBinary();
        Handle = reader.ReadString();
        DID = reader.ReadString();
        RedirectUri = reader.ReadString();
        }

    }
