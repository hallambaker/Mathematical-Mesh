
Given the following Ed25519 public key:

~~~~

  FC D1 4F D5  E5 76 C9 9C  86 1D 55 49  E4 DE 0B EB
  7B A8 08 70  DE 5F 5A 29  EE 1D D0 8D  41 C4 88 AD
~~~~

The equivalent DER encoding is:

~~~~

  30 2C 30 05  06 03 2B 65  70 03 23 00  04 20 FC D1
  4F D5 E5 76  C9 9C 86 1D  55 49 E4 DE  0B EB 7B A8
  08 70 DE 5F  5A 29 EE 1D  D0 8D 41 C4  88 AD
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-YMAF-AYBS-WZLQ-AMRQ-ABBA-7TIU-7VPF-O3EZ-ZBQ5-KVE6-J
        XQL-5N52-QCDQ-3ZPV-UKPO-DXII-2QOE-RCWQ
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MBKT-LLYT-SI6S-AZSL-H4FO-A4CJ-22JZ
~~~~
