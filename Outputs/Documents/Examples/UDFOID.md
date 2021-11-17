
Given the following Ed25519 public key:

~~~~

  4B BD 78 43  84 07 A0 22  F0 2F F0 5A  92 C2 7A 45
  EA 2A 99 39  B7 6E 9F 79  59 AC 7F FA  54 E8 CD F6
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  4B BD 78 43  84 07 A0 22  F0 2F F0 5A  92 C2 7A 45
  EA 2A 99 39  B7 6E 9F 79  59 AC 7F FA  54 E8 CD F6
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQE-XPLY-IOCA-PIBC-6AX7-A
        WUS-YJ5E-L2RK-TE43-O3U7-PFM2-Y772-KTUM-35Q
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MADP-R3WX-EKZF-35VX-3GFM-V5MI-IS6J
~~~~
