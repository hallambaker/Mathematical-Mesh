
Given the following Ed25519 public key:

~~~~

  5A 43 3E 39  F8 2A 55 89  A7 BE B4 CA  B5 6B F0 14
  C4 BD 68 83  65 D8 29 7D  C8 8A 33 AD  C5 48 5E 2A
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  5A 43 3E 39  F8 2A 55 89  A7 BE B4 CA  B5 6B F0 14
  C4 BD 68 83  65 D8 29 7D  C8 8A 33 AD  C5 48 5E 2A
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQF-UQZ6-HH4C-UVMJ-U67L-J
        SVV-NPYB-JRF5-NCBW-LWBJ-PXEI-UM5N-YVEF-4KQ
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MBDC-2ASL-FOOO-SG46-UP6X-K52D-D2VL
~~~~
