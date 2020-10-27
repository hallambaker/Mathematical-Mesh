
Given the following Ed25519 public key:

~~~~

  BE 6E 8A 29  82 E9 A8 DD  62 B9 6B 3A  47 F0 B5 FB
  A2 21 72 D8  27 33 75 FC  CC EC E9 F9  4B AD BB 8A
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  BE 6E 8A 29  82 E9 A8 DD  62 B9 6B 3A  47 F0 B5 FB
  A2 21 72 D8  27 33 75 FC  CC EC E9 F9  4B AD BB 8A
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQL-43UK-FGBO-TKG5-MK4W-WOSH-6C27-XIRB-OLMC-OM3V-7TGO-Z2PZ-JOW3-XCQ
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MCHW-TLXU-2E63-7NNA-W2OF-GBNR-R6HC
~~~~
