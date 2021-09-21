
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQG-BCL4-76VS-IKU3-5B7I-BCW5-QGKB",
    "Salt":"Pbuu6Z1ylrpb4FQNaY-yMA",
    "annotations":["iAEAiCBmrS6VBknkxwXwpvtU70hPqS95EYCUIQB700jDWt
  5f_A",
      "iAEBiCAi7aoMXG6YMpgYUjWEhelFnrLVsm8gwPYoGVmnRphXuw",
      "iAECiDDPD-shyJL-LDZTSFJg7XTx5ccKL9qauZNu0Uew3YusTwOwz3iuYe
  Dd-i-GKbs82-Q"
      ],
    "recipients":[{
        "kid":"MAAK-DSAH-2TZ2-WZYL-VXJH-ECLN-NFXO",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"checvUCma3i7WJsC7Kd4RvaSjsHee4s5q5W4v2NS2lc"}},
        "wmk":"LSeEyon43vbrmB-p3v_ivNfUN-fqBTXwU8cic5sCsbdOnOkt3y
  45gQ"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "jKdQzzhsc8tS8LhDla-xgzEzzzM5Mu8ZANVhOdD6q9HcrzTMdthX87mdKi4BOa
  wwgL6fwxnwWiAoArbZYkE4oA"
  ]
~~~~

