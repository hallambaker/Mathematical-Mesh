
Given the following Ed25519 public key:

~~~~

  18 74 43 2C  60 71 67 C5  14 B9 C2 2A  B0 93 31 AB
  66 88 81 C0  61 A0 A8 D6  AC 71 EF C3  5D 83 1F 22
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  18 74 43 2C  60 71 67 C5  14 B9 C2 2A  B0 93 31 AB
  66 88 81 C0  61 A0 A8 D6  AC 71 EF C3  5D 83 1F 22
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQB-Q5CD-FRQH-CZ6F-CS44-E
        KVQ-SMY2-WZUI-QHAG-DIFI-22WH-D36D-LWBR-6IQ
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MCDH-2ASN-FMW6-AAFX-YD73-FOBE-ABKY
~~~~
