
Given the following Ed25519 public key:

~~~~

  EF A6 32 F1  2A 29 D5 6E  C2 EE 0A 86  B3 AA AB F8
  D5 8F 0C C7  90 A2 67 EF  21 21 FF 8D  FC 7D FA C4
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  EF A6 32 F1  2A 29 D5 6E  C2 EE 0A 86  B3 AA AB F8
  D5 8F 0C C7  90 A2 67 EF  21 21 FF 8D  FC 7D FA C4
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQO-7JRS-6EVC-TVLO-YLXA-VBVT-VKV7-RVMP-BTDZ-BITH-54QS-D74N-7R67-VRA
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MB2L-H5NC-THHU-BLCX-O7YW-LPR7-BJR2
~~~~
