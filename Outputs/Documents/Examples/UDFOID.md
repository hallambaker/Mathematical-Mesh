
Given the following Ed25519 public key:

~~~~

  F9 6E 6B 95  F0 08 9C D3  1A 8B 6E 15  BA 5E 17 5C
  A6 46 AF 2D  53 7E 95 6C  63 A1 97 A1  D5 72 15 7B
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  F9 6E 6B 95  F0 08 9C D3  1A 8B 6E 15  BA 5E 17 5C
  A6 46 AF 2D  53 7E 95 6C  63 A1 97 A1  D5 72 15 7B
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQP-S3TL-SXYA-RHGT-DKFW-4
        FN2-LYLV-ZJSG-V4WV-G7UV-NRR2-DF5B-2VZB-K6Y
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MCTT-HDML-SBXB-O4AS-VYDN-GJHN-CGK3
~~~~
