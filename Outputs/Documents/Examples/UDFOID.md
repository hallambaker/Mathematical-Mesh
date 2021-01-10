
Given the following Ed25519 public key:

~~~~

  76 AE AF 16  40 88 03 0D  78 F6 E0 03  5F B1 B6 E5
  4C 46 55 07  C5 3A DF AA  38 7B 11 22  20 36 19 0D
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  76 AE AF 16  40 88 03 0D  78 F6 E0 03  5F B1 B6 E5
  4C 46 55 07  C5 3A DF AA  38 7B 11 22  20 36 19 0D
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQH-NLVP-CZAI-QAYN-PD3O-A
        A27-WG3O-KTCG-KUD4-KOW7-VI4H-WEJC-EA3B-SDI
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MBGK-26Q6-VWT7-DL7S-S7CX-4ET2-HJXH
~~~~
