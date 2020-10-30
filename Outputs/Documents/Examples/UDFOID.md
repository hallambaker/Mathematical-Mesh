
Given the following Ed25519 public key:

~~~~

  F0 E9 9B 02  85 8A A2 5A  24 13 2D B5  A4 E4 B7 A7
  BE A1 75 16  28 11 81 48  5C 79 48 85  2D CE EB D0
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  F0 E9 9B 02  85 8A A2 5A  24 13 2D B5  A4 E4 B7 A7
  BE A1 75 16  28 11 81 48  5C 79 48 85  2D CE EB D0
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQP-B2M3-AKCY-VIS2-EQJS-3NNE-4S32-PPVB-OULC-QEMB-JBOH-SSEF-FXHO-XUA
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MCTN-3YYT-CTOJ-Z6IE-EVLP-IZD2-SF6M
~~~~
