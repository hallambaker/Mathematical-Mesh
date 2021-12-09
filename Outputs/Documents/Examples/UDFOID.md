
Given the following Ed25519 public key:

~~~~

  75 07 DD 2D  44 D3 C3 DE  A6 EC A2 1A  2D CA B4 3E
  BA A5 EE 29  6B FA EB 24  C1 4A 32 FC  35 F2 3E 4B
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  75 07 DD 2D  44 D3 C3 DE  A6 EC A2 1A  2D CA B4 3E
  BA A5 EE 29  6B FA EB 24  C1 4A 32 FC  35 F2 3E 4B
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQH-KB65-FVCN-HQ66-U3WK-E
        GRN-ZK2D-5OVF-5YUW-X6XL-ETAU-UMX4-GXZD-4SY
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MA4W-FXC4-YKZ2-VYWU-CY7M-BWZS-3QTY
~~~~
