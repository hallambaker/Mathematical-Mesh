
Given the following Ed25519 public key:

~~~~

  88 EE 84 C2  09 A1 04 2C  A5 08 72 D4  C7 A6 2C 5C
  E6 A1 61 F4  5E 9B 8C 90  E9 BB 5B F0  42 57 C3 57
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  88 EE 84 C2  09 A1 04 2C  A5 08 72 D4  C7 A6 2C 5C
  E6 A1 61 F4  5E 9B 8C 90  E9 BB 5B F0  42 57 C3 57
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQI-R3UE-YIE2-CBBM-UUEH-FVGH-UYWF-ZZVB-MH2F-5G4M-SDU3-WW7Q-IJL4-GVY
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MB4U-5UIO-KFFA-W4IZ-F6EZ-Y23Z-WGSR
~~~~
