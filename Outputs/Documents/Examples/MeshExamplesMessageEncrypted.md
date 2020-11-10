
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQP-PNEE-FMGE-VKJX-BZ2G-RWXV-OZ4B",
    "Salt":"O1s8DbVMtKyKbkJEujLPgg",
    "Annotations":["iAEBiCA7EGnUGPh-vjelD65K5xCwKKHbkLVggUgKogjl9i
  S-kA",
      "iAECiCCZ5GeffverH3ASkPK_VRo5SGOHPgScWnw7m_lm5RMcYg",
      "iAEDiDBvfZVWcz_bQUJWPvAtIjMat03ufrtwRKBM8ZcWSGnTm3-4lkopO0
  j0obEvjhG7y9E"
      ],
    "recipients":[{
        "kid":"MAE2-3NJU-IUW7-N44W-W6F6-IBEK-D6JI",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"sQI7EfpIfnjFQC-TyfCOTNTJvTpqKgKLDUXrgA72NPE"}},
        "wmk":"aLxDoo8lcRcYu7OoUOyQMh3GXcJ9W8fiRRok-pdSqmVpTq4Abn
  VE8w"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "OPhcdFlahTjYgXXwe5t3F8Z5YSCTjnkcV_GFIAbYd2USiaTZFHecO9PY2dv_Co
  bJv1DLxKQkbabyocsLi9ij1A"
  ]
~~~~

