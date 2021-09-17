
Given the following Ed25519 public key:

~~~~

  61 B2 CC 69  83 CC 32 E4  B1 47 12 2B  9B BE 23 66
  D3 AB D9 7F  09 A0 E9 2A  FE C1 3E 0B  E1 89 07 CB
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  61 B2 CC 69  83 CC 32 E4  B1 47 12 2B  9B BE 23 66
  D3 AB D9 7F  09 A0 E9 2A  FE C1 3E 0B  E1 89 07 CB
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQG-DMWM-NGB4-YMXE-WFDR-E
        K43-XYRW-NU5L-3F7Q-TIHJ-FL7M-CPQL-4GEQ-PSY
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MCP7-ZHOL-IZ3M-NJ4V-IME4-MFPX-PP5T
~~~~
