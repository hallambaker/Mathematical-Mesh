
Given the following Ed25519 public key:

~~~~

  57 0A 46 ED  5F 46 49 03  EB 3C 50 57  A3 BA 1E FC
  D9 35 E9 AC  61 A7 70 D1  D7 42 C4 BC  D1 4D FB F9
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  57 0A 46 ED  5F 46 49 03  EB 3C 50 57  A3 BA 1E FC
  D9 35 E9 AC  61 A7 70 D1  D7 42 C4 BC  D1 4D FB F9
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQF-OCSG-5VPU-MSID-5M6F-A
        V5D-XIPP-ZWJV-5GWG-DJ3Q-2HLU-FRF4-2FG7-X6I
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MAXR-MH7T-QCRG-ORPE-PBFE-X7LL-GPJD
~~~~
