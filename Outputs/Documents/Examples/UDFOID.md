
Given the following Ed25519 public key:

~~~~

  59 14 E1 50  E2 25 56 62  CE E7 8A 3F  A4 74 1F 88
  45 BC AC 64  3E EF 54 D7  E1 CD 14 34  2C 7B F3 D6
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  59 14 E1 50  E2 25 56 62  CE E7 8A 3F  A4 74 1F 88
  45 BC AC 64  3E EF 54 D7  E1 CD 14 34  2C 7B F3 D6
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQF-SFHB-KDRC-KVTC-Z3TY-U
        P5E-OQPY-QRN4-VRSD-532U-27Q4-2FBU-FR57-HVQ
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MAPD-26VJ-HUAN-KD3Q-FEQU-RA3I-2HXO
~~~~
