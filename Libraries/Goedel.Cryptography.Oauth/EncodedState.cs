namespace Goedel.Cryptography.Oauth;

public record EncodedState {
    public byte[] Nonce;
    public string Handle;
    public string DID;
    public string RedirectUri;
    public byte[] Bytes;

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
