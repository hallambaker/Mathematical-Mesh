
Given the following Ed25519 public key:

~~~~

  E3 D1 86 30  DC CC B6 6F  35 85 18 78  12 1C 9A F3
  40 72 84 D4  B7 F6 BA 9C  6C DF 89 2D  B8 5E 57 F8
~~~~

The equivalent DER encoding is:

~~~~

  30 2C 30 05  06 03 2B 65  70 03 23 00  04 20 E3 D1
  86 30 DC CC  B6 6F 35 85  18 78 12 1C  9A F3 40 72
  84 D4 B7 F6  BA 9C 6C DF  89 2D B8 5E  57 F8
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-YMAF-AYBS-WZLQ-AMRQ-ABBA-4PIY-MMG4-ZS3G-6NMF-DB4B-E
        HE2-6NAH-FBGU-W73L-VHDM-36ES-3OC6-K74A
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MCEP-RS54-TEOY-UPY4-XB7I-MVMV-LRFB
~~~~
