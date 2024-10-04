
Given the following Ed25519 public key:

~~~~

  98 44 9D 1C  44 78 B2 FC  08 6F F4 A2  BF B2 09 BC
  BF 0D EB FC  81 7D 03 DC  BD 95 E2 E9  33 AB 25 5A
~~~~

The equivalent DER encoding is:

~~~~

  30 2C 30 05  06 03 2B 65  70 03 23 00  04 20 98 44
  9D 1C 44 78  B2 FC 08 6F  F4 A2 BF B2  09 BC BF 0D
  EB FC 81 7D  03 DC BD 95  E2 E9 33 AB  25 5A
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-YMAF-AYBS-WZLQ-AMRQ-ABBA-TBCJ-2HCE-PCZP-YCDP-6SRL-7
        MQJ-XS7Q-3274-QF6Q-HXF5-SXRO-SM5L-EVNA
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MCXO-44WR-I6TO-4GHH-2HGF-YI5A-JKMT
~~~~
