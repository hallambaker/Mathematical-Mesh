
Given the following Ed25519 public key:

~~~~

  C0 2B C5 43  61 6A 59 9F  A3 04 D2 18  B0 17 20 52
  74 C5 B0 51  17 0C 57 2C  9B 21 E6 71  31 9B D9 9E
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  C0 2B C5 43  61 6A 59 9F  A3 04 D2 18  B0 17 20 52
  74 C5 B0 51  17 0C 57 2C  9B 21 E6 71  31 9B D9 9E
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQM-AK6F-INQW-UWM7-UMCN-EGFQ-C4QF-E5GF-WBIR-ODCX-FSNS-DZTR-GGN5-THQ
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MBGQ-6X3D-JGI7-XYPN-UV7O-VWP4-SV73
~~~~
