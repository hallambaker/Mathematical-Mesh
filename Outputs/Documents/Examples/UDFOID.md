
Given the following Ed25519 public key:

~~~~

  C6 05 0B 96  3D 88 C4 B8  D8 BF 4A C8  1F C7 3B 95
  A5 26 E8 2D  02 13 2F DF  E6 2F 01 14  9A 8A 80 51
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  C6 05 0B 96  3D 88 C4 B8  D8 BF 4A C8  1F C7 3B 95
  A5 26 E8 2D  02 13 2F DF  E6 2F 01 14  9A 8A 80 51
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQM-MBIL-SY6Y-RRFY-3C7U-VSA7-Y45Z-LJJG-5AWQ-EEZP-37TC-6AIU-TKFI-AUI
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MB47-XH45-36EW-E7NN-HWMK-RQJK-2JBR
~~~~
