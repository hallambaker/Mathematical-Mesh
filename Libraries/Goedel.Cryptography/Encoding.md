=Cryptographic operations



==Signing Data

The signing providers have convenience routines for signing and verifying data.

~~~~
public void TestSign () {
    var Signer = CryptoCatalog.Default.GetSignature(CryptoAlgorithmID.RSASign2048);
    Signer.Generate(KeySecurity.Exportable);
    var Result = Signer.Sign(TestString);
    }
~~~~

This example uses the default digest algorithm. We can specify an alternative algorithm
as follows:

~~~~
public void TestSign2() {
    var Signer = CryptoCatalog.Default.GetSignature(CryptoAlgorithmID.RSASign2048,
                CryptoAlgorithmID.SHA_2_512);
    Signer.Generate(KeySecurity.Exportable);
    var Result = Signer.Sign(TestString);
    }
~~~~

The key storage class 'Exportable' means that the key will be persisted on the local
machine, stored under a name constructed from the UDF fingerprint. We can retrieve the
signed data by the signing key UDF:

~~~~
public void TestSign3() {
    var Signer = CryptoCatalog.Default.GetSignature(CryptoAlgorithmID.RSASign2048);
    Signer.Generate(KeySecurity.Exportable);

    var UDF = Signer.UDF;

    var CopyKey = KeyPair.FindLocal(UDF);
    var CopyProvider = CopyKey.SignatureProvider ();
    CopyProvider.Sign(TestString);
    }
~~~~

This mode of operation is of course the most usual one since persistent key 
generation is a rare event while key use is typically repeated.

Marking the key value as 'exportable' means that we can extract the private key value.


==Encrypting Data

To encrypt data using public key encryption we need to perform the following operations

* Generate the encryption keys and IV
* Perform the public key operation
* Process the bulk data

The order in which these steps are performed is a little different depending on whether
the encryption algorithm provides key recovery (like RSA) or not.

To support both modes, the following calling sequence is used:

1. Create the bulk encryption provider

2. Create the key exchange provider giving the bulk provider as a parameter

3. Perform the bulk operation

To do this to a single 

~~~~
    var KeyExchange = Public.ExchangeProviderEncrypt(CryptoAlgorithmID.AES256CBC);
    var ExchangeParams = KeyExchange.Parameters;
    var Result = KeyExchange.Bulk.Process(TestString);
~~~~

If a DH type key agreement is used, it may be preferable to encrypt under the agreed key
or an intermediate key. This may be forced by specifying the wrap property on the
bulk cipher or the first call to it. This is usually done when encrypting to
multiple recipients

~~~~
    var Bulk = Platform.AES_256.CryptoProviderEncryption();
    var KeyExchange1 = Public.ExchangeProviderEncrypt(Bulk);
    var ExchangeParams1 = KeyExchange1.Parameters;
    var KeyExchange2 = Public.ExchangeProviderEncrypt(Bulk);
    var ExchangeParams2 = KeyExchange2.Parameters;
    var Result = Bulk.Process(TestString);
~~~~

If multiple recipients are specified without key wrap, the key agreed in the first
will be used for the bulk cipher and subsequent callers will get a wrapped copy.

This approach allows the same calling sequence to be used for RSA and DH encryption.


==Encrypting and Authenticating Data

The same approach may be used for encrypting with authentication. We just use a different 
bulk algorithm.

~~~~
    var Bulk = CryptoCatalog.Default.GetEncryption(CryptoAlgorithmID.ModeGCM);
    ...
~~~~


==Encrypting multiple blocks

It is sometimes desirable to perform a single key agreement and then encrypt multiple 
blocks under separate keys and initialization vectors which are in turn encrypted 
under the agreed key.

~~~~
    var KeyExchange = Public.ExchangeProviderEncrypt(CryptoAlgorithmID.AES256CBC);
    var ExchangeParams = KeyExchange.Parameters;
    var Result1 = KeyExchange.Bulk.Process(TestString);
    var Result2 = KeyExchange.Bulk.Process(TestString);
~~~~

This scheme may be used as a convenience routine for encrypting a single block to
a single recipient:

We can even encrypt multiple blocks to multiple recipients:

~~~~
    var Bulk = Platform.AES_256.CryptoProviderEncryption();
    var KeyExchange1 = Public.ExchangeProviderEncrypt(Bulk);
    var ExchangeParams1 = KeyExchange1.Parameters;
    var KeyExchange2 = Public.ExchangeProviderEncrypt(Bulk);
    var ExchangeParams2 = KeyExchange2.Parameters;

    var Bulk1 = Bulk.Bulk;
    var Result1 = Bulk1.Process(TestString);
    var Bulk2 = Bulk.Bulk;
    var Result2 = Bulk1.Process(TestString);
~~~~


==Verifying


==Decryption

==Recryption