
Given the following Ed25519 public key:

~~~~

  C4 BA CA E0  9B B5 26 DE  37 A5 66 44  3C 26 71 6E
  A5 D4 99 3B  66 89 8D A4  00 AD 92 A8  90 1C A7 71
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  C4 BA CA E0  9B B5 26 DE  37 A5 66 44  3C 26 71 6E
  A5 D4 99 3B  66 89 8D A4  00 AD 92 A8  90 1C A7 71
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQM-JOWK-4CN3-KJW6-G6SW-M
        RB4-EZYW-5JOU-TE5W-NCMN-UQAK-3EVI-SAOK-O4I
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MD7N-MPK6-4BDF-DYMC-XIYC-WVHJ-HI64
~~~~
