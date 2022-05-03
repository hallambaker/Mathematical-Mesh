
Given the following Ed25519 public key:

~~~~

  85 76 30 C4  2C B1 51 98  F9 32 F6 80  D2 35 95 5E
  56 4A 28 E5  05 08 B3 9C  10 61 5E 5F  82 BB 18 F7
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  85 76 30 C4  2C B1 51 98  F9 32 F6 80  D2 35 95 5E
  56 4A 28 E5  05 08 B3 9C  10 61 5E 5F  82 BB 18 F7
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQI-K5RQ-YQWL-CUMY-7EZP-N
        AGS-GWKV-4VSK-FDSQ-KCFT-TQIG-CXS7-QK5R-R5Y
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MACJ-BWDW-BTLW-CHDC-VWBJ-SHD3-XMB2
~~~~
