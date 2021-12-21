
Given the following Ed25519 public key:

~~~~

  BA 18 F5 D1  43 ED 45 7F  D2 8C D6 C3  23 16 4E E7
  37 65 8B 2F  2E F2 BB 5F  4A 8B 44 1F  38 7A 4E 20
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  BA 18 F5 D1  43 ED 45 7F  D2 8C D6 C3  23 16 4E E7
  37 65 8B 2F  2E F2 BB 5F  4A 8B 44 1F  38 7A 4E 20
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQL-UGHV-2FB6-2RL7-2KGN-N
        QZD-CZHO-ON3F-RMXS-54V3-L5FI-WRA7-HB5E-4IA
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MCRD-DAFP-VGP2-VKA3-KS62-MATV-2CVE
~~~~
