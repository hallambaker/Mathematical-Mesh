
In the following example, &<Content-ID> is the UTF8 encoding of the string 
"text/plain" and &<Data> is the UTF8 encoding of the string "Konrad is the traitor".
The randomly chosen key is NDD7-6CMX-H2FW-ISAL-K4VB-DQ3E-PEDM.

~~~~
Data = 
  4B 6F 6E 72  61 64 20 69  73 20 74 68  65 20 74 72
  61 69 74 6F  72

ContentType = 
  74 65 78 74  2F 70 6C 61  69 6E

Key =  
  4E 44 44 37  2D 36 43 4D  58 2D 48 32  46 57 2D 49
  53 41 4C 2D  4B 34 56 42  2D 44 51 33  45 2D 50 45
  44 4D
~~~~

Processing is performed in the same manner as an unkeyed fingerprint except that
compression is never used:


~~~~
H(&<Data>) = 
  93 FC DA F9  FA FD 1E 26  50 26 C3 C1  28 43 40 73
  D8 BC 3D 62  87 73 2B 73  B8 EC 93 B6  DE 80 FF DA
  70 0A D1 CE  E8 F4 36 68  EF 4E 71 63  41 53 91 5C
  CE 8C 5C CE  C7 9A 46 94  6A 35 79 F9  33 70 85 01

&<Content-ID> + ‘:’ + H(&<Data>) =  
  74 65 78 74  2F 70 6C 61  69 6E 3A 93  FC DA F9 FA
  FD 1E 26 50  26 C3 C1 28  43 40 73 D8  BC 3D 62 87
  73 2B 73 B8  EC 93 B6 DE  80 FF DA 70  0A D1 CE E8
  F4 36 68 EF  4E 71 63 41  53 91 5C CE  8C 5C CE C7
  9A 46 94 6A  35 79 F9 33  70 85 01

PRK(Key) =  
  77 D3 0A 08  39 BD 9D C0  97 44 DA 33  15 0A 42 5E
  CD 17 80 03  B3 CF CC 89  7A C7 84 12  B4 51 5B 25
  DC 26 F5 E1  1B 20 F3 89  2E 9A 1A 7B  0E 73 23 39
  0E C3 4C EF  2D 40 DA 05  B4 70 C6 1C  82 C1 49 33

HKDF(Key) =  
  BF A9 B4 58  9C 1D 68 D7  9A B7 11 F6  C8 98 59 14
  20 D7 82 67  C5 84 22 E5  A0 F9 93 52  B1 C3 87 EB
  05 06 CB C4  E4 D6 E6 EE  1F F0 D4 7A  97 68 5E CE
  28 1C CA AF  D8 B5 D1 24  4A 71 EC E3  AC B5 D2 04

MAC(&<key>, &<Content-ID> + ‘:’ + H(&<Data>)) =  
  4C C3 7F D3  F9 9E 52 CF  07 90 74 53  84 65 95 BC
  1A 2B A5 D1  68 9D 05 6D  06 C5 CA BF  17 CB E0 49
  95 39 57 08  79 C4 E5 49  D3 3A 59 A3  32 05 45 A6
  30 26 25 AE  8A F4 47 C6  1F B5 33 7F  AD 69 A6 30

The prefixed Binary Data Sequence is thus
  00 4C C3 7F  D3 F9 9E 52  CF 07 90 74  53 84 65 95
  BC 1A
~~~~

The 125 bit fingerprint value is ABGM-G76T-7GPF-FTYH-SB2F-HBDF-SW6B

