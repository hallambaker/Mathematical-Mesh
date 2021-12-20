
Given the following Ed25519 public key:

~~~~

  D4 DD 1E BA  98 C3 32 8E  A9 A5 8A 8A  F3 1E 4B C9
  19 19 64 A5  ED 3F 8E 26  A7 57 3D FD  44 D3 A7 38
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  D4 DD 1E BA  98 C3 32 8E  A9 A5 8A 8A  F3 1E 4B C9
  19 19 64 A5  ED 3F 8E 26  A7 57 3D FD  44 D3 A7 38
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQN-JXI6-XKMM-GMUO-VGSY-V
        CXT-DZF4-SGIZ-MSS6-2P4O-E2TV-OPP5-ITJ2-OOA
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MBNF-DVXY-6QWY-DUVR-ZUOH-CZZV-DHHX
~~~~
