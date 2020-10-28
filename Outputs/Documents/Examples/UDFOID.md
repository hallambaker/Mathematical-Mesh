
Given the following Ed25519 public key:

~~~~

  24 86 D4 46  79 E6 17 ED  16 50 C9 24  85 ED BA 4B
  29 D2 BF DA  0A DC 62 C4  43 3B 95 81  6A D9 7C E8
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  24 86 D4 46  79 E6 17 ED  16 50 C9 24  85 ED BA 4B
  29 D2 BF DA  0A DC 62 C4  43 3B 95 81  6A D9 7C E8
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQC-JBWU-IZ46-MF7N-CZIM-SJEF-5W5E-WKOS-X7NA-VXDC-YRBT-XFMB-NLMX-Z2A
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MB5A-HRRE-EL6H-AHOJ-FNHP-2WUT-GDBO
~~~~
