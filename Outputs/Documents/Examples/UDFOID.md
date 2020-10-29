
Given the following Ed25519 public key:

~~~~

  19 30 4F 41  3B 62 82 D6  F7 8C 85 EB  B5 FA 09 EC
  51 AF 02 0F  B0 CB 4A C2  70 80 D6 6D  8E 53 ED 0B
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  19 30 4F 41  3B 62 82 D6  F7 8C 85 EB  B5 FA 09 EC
  51 AF 02 0F  B0 CB 4A C2  70 80 D6 6D  8E 53 ED 0B
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQB-SMCP-IE5W-FAWW-66GI-L25V-7IE6-YUNP-AIH3-BS2K-YJYI-BVTN-RZJ6-2CY
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MACE-AVGZ-EDRZ-PSEK-GGAP-CAI5-4D6X
~~~~
