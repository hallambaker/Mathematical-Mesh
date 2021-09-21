
Given the following Ed25519 public key:

~~~~

  55 0C 1F 3A  E0 05 96 FA  9E BB F1 5A  AD E3 63 80
  A7 5C 7D 7C  22 1B 8B 9B  E3 A4 8E 15  5B 13 3B AB
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  55 0C 1F 3A  E0 05 96 FA  9E BB F1 5A  AD E3 63 80
  A7 5C 7D 7C  22 1B 8B 9B  E3 A4 8E 15  5B 13 3B AB
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQF-KDA7-HLQA-LFX2-T257-C
        WVN-4NRY-BJ24-PV6C-EG4L-TPR2-JDQV-LMJT-XKY
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MDXF-BHXI-5B6R-TL7T-SNCE-IP6V-AJB3
~~~~
