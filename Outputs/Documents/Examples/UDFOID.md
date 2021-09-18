
Given the following Ed25519 public key:

~~~~

  C8 CB 7B 8C  F8 90 80 0C  FA DF A8 9F  1F D4 F8 F7
  EB 04 DA BD  64 F0 F2 DB  0B 8D 0E C1  90 2D 32 F0
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  C8 CB 7B 8C  F8 90 80 0C  FA DF A8 9F  1F D4 F8 F7
  EB 04 DA BD  64 F0 F2 DB  0B 8D 0E C1  90 2D 32 F0
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQM-RS33-RT4J-BAAM-7LP2-R
        HY7-2T4P-P2YE-3K6W-J4HS-3MFY-2DWB-SAWT-F4A
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MCAY-U367-VSP2-XSNB-ZR65-RQTY-57OW
~~~~
