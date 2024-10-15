
Given the following Ed25519 public key:

~~~~

  71 26 6B 00  CC B7 82 3C  A1 50 55 10  7A AA 6C 04
  48 7F 4B C5  B9 8E 2D A2  25 A1 66 5B  17 14 2B D4
~~~~

The equivalent DER encoding is:

~~~~

  30 2C 30 05  06 03 2B 65  70 03 23 00  04 20 71 26
  6B 00 CC B7  82 3C A1 50  55 10 7A AA  6C 04 48 7F
  4B C5 B9 8E  2D A2 25 A1  66 5B 17 14  2B D4
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-YMAF-AYBS-WZLQ-AMRQ-ABBA-OETG-WAGM-W6BD-ZIKQ-KUIH-V
        KTM-AREH-6S6F-XGHC-3IRF-UFTF-WFYU-FPKA
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MCCR-IPW7-AUHT-I7HV-FX4A-CLD3-LU7E
~~~~
