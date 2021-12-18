
Given the following Ed25519 public key:

~~~~

  79 52 16 20  0F 6B 82 F2  72 31 AB 4E  24 8E 8B 4D
  59 B8 6A 6F  AE 0E 55 CA  1E 97 1B A1  01 4A F8 ED
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  79 52 16 20  0F 6B 82 F2  72 31 AB 4E  24 8E 8B 4D
  59 B8 6A 6F  AE 0E 55 CA  1E 97 1B A1  01 4A F8 ED
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQH-SUQW-EAHW-XAXS-OIY2-W
        TRE-R2FU-2WNY-NJX2-4DSV-ZIPJ-OG5B-AFFP-R3I
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MAU6-2TUH-FDYK-4TH2-UJDW-DPNR-KMMC
~~~~
