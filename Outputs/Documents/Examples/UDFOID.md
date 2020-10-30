
Given the following Ed25519 public key:

~~~~

  58 61 3C F8  49 01 AA D9  F7 32 8E 4D  E8 DA 1F 1A
  89 3A BF EA  C6 0F 9F B2  E6 23 47 B0  BE A4 3A 93
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  58 61 3C F8  49 01 AA D9  F7 32 8E 4D  E8 DA 1F 1A
  89 3A BF EA  C6 0F 9F B2  E6 23 47 B0  BE A4 3A 93
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQF-QYJ4-7BEQ-DKWZ-64ZI-4TPI-3IPR-VCJ2-X7VM-MD47-WLTC-GR5Q-X2SD-VEY
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MB4G-UPOY-EYZB-GYXV-4HHM-6XWO-4CLI
~~~~
