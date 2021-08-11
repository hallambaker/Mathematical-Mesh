
Given the following Ed25519 public key:

~~~~

  0D EC 2B 91  BA DB 44 93  BA 69 5E 12  04 12 11 26
  2F 6F 6F ED  A2 64 EB 6E  B8 05 31 78  82 DA EB 98
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  0D EC 2B 91  BA DB 44 93  BA 69 5E 12  04 12 11 26
  2F 6F 6F ED  A2 64 EB 6E  B8 05 31 78  82 DA EB 98
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQA-33BL-SG5N-WRET-XJUV-4
        EQE-CIIS-ML3P-N7W2-EZHL-N24A-KMLY-QLNO-XGA
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MDXI-R45I-Z4S5-T7TD-2YQZ-R644-MB3C
~~~~
