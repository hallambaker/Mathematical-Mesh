
Given the following Ed25519 public key:

~~~~

  41 85 9A 5E  22 E9 1A 05  BA EF 30 B7  E8 30 CB 80
  DC C6 0E E0  F2 D3 D9 F2  01 11 2A B3  A6 18 C3 65
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  41 85 9A 5E  22 E9 1A 05  BA EF 30 B7  E8 30 CB 80
  DC C6 0E E0  F2 D3 D9 F2  01 11 2A B3  A6 18 C3 65
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQE-DBM2-LYRO-SGQF-XLXT-B
        N7I-GDFY-BXGG-B3QP-FU6Z-6IAR-CKVT-UYMM-GZI
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MALH-7S3M-XFJA-KYLE-BO2M-HQ7Y-AX57
~~~~
