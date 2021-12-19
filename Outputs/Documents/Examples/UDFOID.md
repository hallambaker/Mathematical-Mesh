
Given the following Ed25519 public key:

~~~~

  8B 8F 72 08  86 CA 3E A3  11 D7 71 B4  44 06 FA 98
  E8 71 4A 1C  AE FE 95 39  71 CE A8 9B  DF 57 E6 4D
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  8B 8F 72 08  86 CA 3E A3  11 D7 71 B4  44 06 FA 98
  E8 71 4A 1C  AE FE 95 39  71 CE A8 9B  DF 57 E6 4D
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQI-XD3S-BCDM-UPVD-CHLX-D
        NCE-A35J-R2DR-JIOK-57UV-HFY4-5KE3-35L6-MTI
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MDRE-C3JW-677W-AW5R-LQMO-AEQB-4S3I
~~~~
