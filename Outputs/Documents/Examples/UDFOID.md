
Given the following Ed25519 public key:

~~~~

  3B 64 7C C9  BB 8B 6F 14  AF 48 58 2B  C6 15 8B D7
  CF 21 5F D4  9F 0E 01 78  58 61 FF 83  E9 28 74 00
~~~~

The equivalent DER encoding is:

~~~~

  30 2C 30 05  06 03 2B 65  70 03 23 00  04 20 3B 64
  7C C9 BB 8B  6F 14 AF 48  58 2B C6 15  8B D7 CF 21
  5F D4 9F 0E  01 78 58 61  FF 83 E9 28  74 00
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-YMAF-AYBS-WZLQ-AMRQ-ABBA-HNSH-ZSN3-RNXR-JL2I-LAV4-M
        FML-27HS-CX6U-T4HA-C6CY-MH7Y-H2JI-OQAA
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MB27-KHIJ-R24U-OILH-G4HI-XDOP-HSVT
~~~~
