
Given the following Ed25519 public key:

~~~~

  85 57 66 E9  0A EC A8 4D  86 68 57 73  B3 40 97 42
  CC B3 3C E2  7F 68 25 C2  16 22 25 B7  B1 9E 07 8F
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  85 57 66 E9  0A EC A8 4D  86 68 57 73  B3 40 97 42
  CC B3 3C E2  7F 68 25 C2  16 22 25 B7  B1 9E 07 8F
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQI-KV3G-5EFO-ZKCN-QZUF-O45T-ICLU-FTFT-HTRH-62BF-YILC-EJNX-WGPA-PDY
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MACS-HJEL-VVLG-IF7N-CBIM-5YKP-XBYH
~~~~
