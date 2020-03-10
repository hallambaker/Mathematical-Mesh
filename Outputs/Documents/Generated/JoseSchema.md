

###Structure: JoseWebSignature

A signed JOSE data object. The data contents are all binary encoded to 
enable direct authentication of the contents.

<dl>
<dt>Unprotected: Header (Optional)
<dd>Data not protected by the signature
<dt>Payload: Binary (Optional)
<dd>The signed data
<dt>Signatures: Signature [0..Many]
<dd>The signature value
</dl>
###Structure: JoseWebEncryption

<dl>
<dt>Inherits:  JoseWebSignature
</dl>

A signed JOSE data object. The encrypted data contents are all binary encoded.

<dl>
<dt>Protected: Binary (Optional)
<dd>Data protected by the signature
<dt>IV: Binary (Optional)
<dd>The initialization vector for the bulk cipher.
<dt>Recipients: Recipient [0..Many]
<dd>Per recipient decryption data.
<dt>EncryptedKey: Binary (Optional)
<dd>The decryption data for use by this recipient.
<dt>AdditionalAuthenticatedData: Binary (Optional)
<dd>Additional data that is included in the authentication scope but not the encryption
<dt>CipherText: Binary (Optional)
<dd>The encrypted data
<dt>JTag: Binary (Optional)
<dd>Authentication tag
</dl>
###Structure: Signed

Compact representation for signed data

<dl>
<dt>Protected: Binary (Optional)
<dd>Data protected by the signature
<dt>Payload: Binary (Optional)
<dd>The authenticated data
<dt>Signature: Binary (Optional)
<dd>The signature data
</dl>
###Structure: Encrypted

Compact representation for encrypted data

<dl>
<dt>Header: Header (Optional)
<dd>Header
<dt>IV: Binary (Optional)
<dd>The initialization vector for the cipher
<dt>CipherText: Binary (Optional)
<dd>The encrypted data 
<dt>Signature: Binary (Optional)
<dd>The signature data
</dl>
###Structure: KeyData

Describe a cryptographic key

<dl>
<dt>Enc: String (Optional)
<dd>Bulk encryption algorithm for content
<dt>Dig: String (Optional)
<dd>Digest algorithm hint
<dt>Alg: String (Optional)
<dd>Key exchange algorithm
<dt>Kid: String (Optional)
<dd>Key identifier. If a UDF fingerprint is used to identify the 
key it is placed in this field.
<dt>X5u: String (Optional)
<dd>URL identifying an X.509 public key certificate
<dt>X5c: Binary (Optional)
<dd>An X.509 public key certificate
<dt>X5t: Binary (Optional)
<dd>SHA-1 fingerprint of X.509 certificate
<dt>X5tS256: Binary (Optional)
<dd>SHA-2-256 fingerprint of X.509 certificate
</dl>
###Structure: Header

A JOSE Header.

<dl>
<dt>Inherits:  KeyData
</dl>

<dl>
<dt>Jku: String (Optional)
<dd>JWK Set URL
<dt>Typ: String (Optional)
<dd>Another IANA content type parameter
<dt>Cty: String (Optional)
<dd>Content type parameter
<dt>Crit: String [0..Many]
<dd>List of header parameters that a recipient MUST understand to interpret
the authentication portion of the JOSE object.
<dt>Val: Binary (Optional)
<dd>The digest value
</dl>
###Structure: Signature

The signature value

<dl>
<dt>Header: Header (Optional)
<dd>The signature header
<dt>Protected: Binary (Optional)
<dd>Data protected by the signature
<dt>SignatureValue: Binary (Optional)
<dd>The signature value
</dl>
###Structure: KeyContainer

A wrapper object for storing key data.

<dl>
<dt>Exportable: Boolean (Optional)
<dd>If false a handler library MUST NOT permit the private key to be exported.
<dt>KeyData: Binary (Optional)
<dd>The key data.
</dl>
###Structure: Key

A JOSE key. All fields map onto the equivalent fields defined in
RFC 7517

<dl>
<dt>Inherits:  KeyData
</dl>

<dl>
<dt>Exportable: Boolean (Optional)
<dd>If true, a stored key may be exported from the machine on 
which it is stored.
<dt>Kty: String (Optional)
<dd>Key type
<dt>Use: String (Optional)
<dd>Public Key use
<dt>Key_ops: String (Optional)
<dd>Key operations
<dt>K: Binary (Optional)
<dd>Symmetric key value.
</dl>
###Structure: Recipient

Recipient information

<dl>
<dt>Header: Header (Optional)
<dd>Specify the recipient and per recipient data
<dt>EncryptedKey: Binary (Optional)
<dd>The decryption data for use by this recipient.
</dl>
###Structure: PublicKeyRSA

An RSA Public key

<dl>
<dt>Inherits:  Key
</dl>

<dl>
<dt>N: Binary (Optional)
<dd>The public modulus
<dt>E: Binary (Optional)
<dd>The public exponent
</dl>
###Structure: PrivateKeyRSA

RSA private key parameters

<dl>
<dt>Inherits:  PublicKeyRSA
</dl>

<dl>
<dt>D: Binary (Optional)
<dd>The parameter d
<dt>P: Binary (Optional)
<dd>The parameter p
<dt>Q: Binary (Optional)
<dd>The parameter q
<dt>DP: Binary (Optional)
<dd>The parameter dp
<dt>DQ: Binary (Optional)
<dd>The parameter dq
<dt>QI: Binary (Optional)
<dd>The parameter QInverse
</dl>
###Structure: PublicKeyDH

A Diffie Helllman Public key

<dl>
<dt>Inherits:  Key
</dl>

<dl>
<dt>Domain: Binary (Optional)
<dd>The fingerprint of the domain
<dt>Public: Binary (Optional)
<dd>The public key
</dl>
###Structure: PrivateKeyDH

Diffie Helllman private key parameters

<dl>
<dt>Inherits:  PublicKeyDH
</dl>

<dl>
<dt>Private: Binary (Optional)
<dd>The private key.
</dl>
###Structure: PublicKeyECDH

An Elliptic Curve Diffie Hellman public key

<dl>
<dt>Inherits:  Key
</dl>

<dl>
<dt>Curve: String (Optional)
<dd>The curve specifier (X25519, Ed25519, X448, Ed448), etc.
<dt>Public: Binary (Optional)
<dd>The public key
</dl>
###Structure: PrivateKeyECDH

Diffie Helllman private key parameters

<dl>
<dt>Inherits:  PublicKeyECDH
</dl>

<dl>
<dt>Private: Binary (Optional)
<dd>The private key
</dl>
###Structure: KeyAgreement

Result of applying a key agreement.

[No fields]

###Structure: KeyAgreementDH

Result of applying a key agreement.

<dl>
<dt>Inherits:  KeyAgreement
</dl>

<dl>
<dt>Result: Binary (Optional)
<dd>The result
</dl>
###Structure: KeyAgreementECDH

Result of applying a key agreement.

<dl>
<dt>Inherits:  KeyAgreement
</dl>

<dl>
<dt>Result: Binary (Optional)
<dd>The result
</dl>
