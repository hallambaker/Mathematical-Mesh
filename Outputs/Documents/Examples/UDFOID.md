
Given the following Ed25519 public key:

~~~~

  AE A9 B9 D3  BF C8 39 D6  0D 09 DC DA  8D 25 AB 85
  E1 43 1A 6F  D2 88 73 9C  68 E8 EC F0  D7 93 DF DD
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  AE A9 B9 D3  BF C8 39 D6  0D 09 DC DA  8D 25 AB 85
  E1 43 1A 6F  D2 88 73 9C  68 E8 EC F0  D7 93 DF DD
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQK-5KNZ-2O74-QOOW-BUE5-Z
        WUN-EWVY-LYKD-DJX5-FCDT-TRUO-R3HQ-26J5-7XI
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MD2N-37QO-NPB6-HEOJ-UYOK-6BWT-RZ2Z
~~~~
