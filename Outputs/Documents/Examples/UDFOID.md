
Given the following Ed25519 public key:

~~~~

  32 88 59 99  41 D2 D4 E7  9C CF 9E 26  07 38 F9 B9
  1E 21 C7 6C  00 71 DD 42  09 D9 90 B6  4C DF 82 0D
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  32 88 59 99  41 D2 D4 E7  9C CF 9E 26  07 38 F9 B9
  1E 21 C7 6C  00 71 DD 42  09 D9 90 B6  4C DF 82 0D
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQD-FCCZ-TFA5-FVHH-TTHZ-4JQH-HD43-SHRB-Y5WA-A4O5-IIE5-TEFW-JTPY-EDI
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MABG-IFIZ-EOYV-7EF6-FC54-JOAW-M3GT
~~~~
