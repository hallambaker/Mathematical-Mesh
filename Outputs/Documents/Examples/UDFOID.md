
Given the following Ed25519 public key:

~~~~

  4E F8 D6 31  4A 80 97 62  07 09 1D F9  92 67 43 C5
  74 06 AC 28  E9 D8 49 02  0B 34 29 D1  E1 D0 77 AD
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  4E F8 D6 31  4A 80 97 62  07 09 1D F9  92 67 43 C5
  74 06 AC 28  E9 D8 49 02  0B 34 29 D1  E1 D0 77 AD
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQE-56GW-GFFI-BF3C-A4ER-3
        6MS-M5B4-K5AG-VQUO-TWCJ-AIFT-IKOR-4HIH-PLI
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MD2G-F7GR-7EAC-BIN6-UXD2-AZTB-X5GR
~~~~
