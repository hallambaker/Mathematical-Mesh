
Given the following Ed25519 public key:

~~~~

  D3 DF 21 71  CF DE 9F 3D  76 D8 22 AB  9B 28 5D 28
  C2 03 D0 9A  4C 60 BE 50  92 C1 E5 6E  5E B8 EB A1
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  D3 DF 21 71  CF DE 9F 3D  76 D8 22 AB  9B 28 5D 28
  C2 03 D0 9A  4C 60 BE 50  92 C1 E5 6E  5E B8 EB A1
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQN-HXZB-OHH5-5HZ5-O3MC-F
        K43-FBOS-RQQD-2CNE-YYF6-KCJM-DZLO-L24O-XII
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MDXX-AP5M-MK4K-BM5M-FE3J-NZFJ-QQUF
~~~~
