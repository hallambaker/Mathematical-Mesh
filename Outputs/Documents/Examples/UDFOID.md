
Given the following Ed25519 public key:

~~~~

  82 8D 35 9A  1F 1B 45 E4  56 56 60 D2  7A CB A6 67
  6B 24 E9 A3  95 F7 48 70  A9 2D 4E F7  90 D3 85 CD
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  82 8D 35 9A  1F 1B 45 E4  56 56 60 D2  7A CB A6 67
  6B 24 E9 A3  95 F7 48 70  A9 2D 4E F7  90 D3 85 CD
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQI-FDJV-TIPR-WRPE-KZLG-B
        UT2-ZOTG-O2ZE-5GRZ-L52I-OCUS-2TXX-SDJY-LTI
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MCAA-A7IY-EP2X-K5OA-SWYJ-DWK4-H6TP
~~~~
