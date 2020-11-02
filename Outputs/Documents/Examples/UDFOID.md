
Given the following Ed25519 public key:

~~~~

  F3 E7 FE A2  3D 82 3C 2A  49 A5 FC 39  4B A7 0B 20
  10 6B 7A B5  B3 51 92 AB  68 AA BB 11  9B C2 F6 2F
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  F3 E7 FE A2  3D 82 3C 2A  49 A5 FC 39  4B A7 0B 20
  10 6B 7A B5  B3 51 92 AB  68 AA BB 11  9B C2 F6 2F
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQP-HZ76-UI6Y-EPBK-JGS7-YOKL-U4FS-AEDL-PK23-GUMS-VNUK-VOYR-TPBP-MLY
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MANF-QO3I-2WTL-42LR-OV4E-P5Q6-HUSO
~~~~
