
Given the following Ed25519 public key:

~~~~

  02 39 B7 C2  2A E1 3A 5C  50 D6 84 AC  F8 DB A1 2D
  1A CA E5 75  32 2C 20 F1  8D 35 6C E9  B4 43 A9 E2
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  02 39 B7 C2  2A E1 3A 5C  50 D6 84 AC  F8 DB A1 2D
  1A CA E5 75  32 2C 20 F1  8D 35 6C E9  B4 43 A9 E2
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQA-EONX-YIVO-COS4-KDLI-J
        LHY-3OQS-2GWK-4V2T-ELBA-6GGT-K3HJ-WRB2-TYQ
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MCLU-IPDW-ZZOT-5MZH-PZIS-NKZR-YJ24
~~~~
