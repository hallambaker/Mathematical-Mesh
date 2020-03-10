
In the following examples, &<Content-ID> is the UTF8 encoding of the string 
"text/plain" and &<Data> is the UTF8 encoding of the string "UDF Data Value"

~~~~
Data = 
  55 44 46 20  44 61 74 61  20 56 61 6C  75 65

ContentType = 
  74 65 78 74  2F 70 6C 61  69 6E
~~~~

###Using SHA-2-512 Digest


~~~~
H(&<Data>) = 
  48 DA 47 CC  AB FE A4 5C  76 61 D3 21  BA 34 3E 58
  10 87 2A 03  B4 02 9D AB  84 7C CE D2  22 B6 9C AB
  02 38 D4 E9  1E 2F 6B 36  A0 9E ED 11  09 8A EA AC
  99 D9 E0 BD  EA 47 93 15  BD 7A E9 E1  2E AD C4 15

&<Content-ID> + ‘:’ + H(&<Data>) =  
  74 65 78 74  2F 70 6C 61  69 6E 3A 48  DA 47 CC AB
  FE A4 5C 76  61 D3 21 BA  34 3E 58 10  87 2A 03 B4
  02 9D AB 84  7C CE D2 22  B6 9C AB 02  38 D4 E9 1E
  2F 6B 36 A0  9E ED 11 09  8A EA AC 99  D9 E0 BD EA
  47 93 15 BD  7A E9 E1 2E  AD C4 15

H(&<Content-ID> + ‘:’ + H(&<Data>)) =  
  C6 AF B7 C0  FE BE 04 E5  AE 94 E3 7B  AA 5F 1A 40
  5B A3 CE CC  97 4D 55 C0  9E 61 E4 B0  EF 9C AE F9
  EB 83 BB 9D  5F 0F 39 F6  5F AA 06 DC  67 2A 67 71
  4F FF 8F 83  C4 55 38 36  38 AE 42 7A  82 9C 85 BB

The prefixed Binary Data Sequence is thus
  60 C6 AF B7  C0 FE BE 04  E5 AE 94 E3  7B AA 5F 1A
  40 5B
~~~~

The 125 bit fingerprint value is MDDK-7N6A-727A-JZNO-STRX-XKS7-DJAF


This fingerprint MAY be specified with higher or lower precision as appropriate.

<dl>
<dt>100 bit precision
<dd>MDDK-7N6A-727A-JZNO-STRX
<dt>120 bit precision
<dd>MDDK-7N6A-727A-JZNO-STRX-XKS7
<dt>200 bit precision
<dd>MDDK-7N6A-727A-JZNO-STRX-XKS7-DJAF-XI6O-ZSLU-2VOA
<dt>260 bit precision
<dd>MDDK-7N6A-727A-JZNO-STRX-XKS7-DJAF-XI6O-ZSLU-2VOA-TZQ6-JMHP-TSXP
</dl>

###Using SHA-3-512 Digest


~~~~
H(&<Data>) = 
  6D 2E CF E6  93 5A 0C FC  F2 A9 1A 49  E0 0C D8 07
  A1 4E 70 AB  72 94 6E CC  BB 47 48 F1  8E 41 49 95
  07 1D F3 6E  0D 0C 8B 60  39 C1 8E B4  0F 6E C8 08
  65 B4 C4 45  9B A2 7E 97  74 7B BE 68  BC A8 C2 17

&<Content-ID> + ‘:’ + H(&<Data>) =  
  74 65 78 74  2F 70 6C 61  69 6E 3A 6D  2E CF E6 93
  5A 0C FC F2  A9 1A 49 E0  0C D8 07 A1  4E 70 AB 72
  94 6E CC BB  47 48 F1 8E  41 49 95 07  1D F3 6E 0D
  0C 8B 60 39  C1 8E B4 0F  6E C8 08 65  B4 C4 45 9B
  A2 7E 97 74  7B BE 68 BC  A8 C2 17

H(&<Content-ID> + ‘:’ + H(&<Data>)) =  
  8A 86 8A 06  1C 54 6E 7E  3F 75 5F 39  88 F9 FD 2F
  8E C8 45 93  1B 80 A8 2F  29 16 7B A3  BE 21 1F 8A
  75 61 88 A1  D5 7F 07 D5  9D 68 A4 2D  17 F4 4D 23
  F9 E4 0B B2  1A 8D B9 F5  8D FC EC BD  01 F4 37 7C

The prefixed Binary Data Sequence is thus
  50 8A 86 8A  06 1C 54 6E  7E 3F 75 5F  39 88 F9 FD
  2F 8E
~~~~

The 125 bit fingerprint value is KCFI-NCQG-DRKG-47R7-OVPT-TCHZ-7UXY


###Using SHA-2-512 Digest with Compression 

The content data "UDF Compressed Document 4187123" produces a UDF Content Digest SHA-2-512 binary value 
with 20 trailing zeros and is therefore presented using compressed presentation:

~~~~
Data = "
  55 44 46 20  43 6F 6D 70  72 65 73 73  65 64 20 44
  6F 63 75 6D  65 6E 74 20  34 31 38 37  31 32 33"
~~~~

The UTF8 Content Digest is given as:


~~~~
H(&<Data>) = 
  36 21 FA 2A  C5 D8 62 5C  2D 0B 45 FB  65 93 FC 69
  C1 ED F7 00  AE 6F E3 3D  38 13 FE AB  76 AA 74 13
  6D 5A 2B 20  DE D6 A5 CF  6C 04 E6 56  3F F3 C0 C7
  C4 1D 3F 43  DD DC F1 A5  67 A7 E0 67  9A B0 C6 B7

&<Content-ID> + ‘:’ + H(&<Data>) =  
  74 65 78 74  2F 70 6C 61  69 6E 3A 36  21 FA 2A C5
  D8 62 5C 2D  0B 45 FB 65  93 FC 69 C1  ED F7 00 AE
  6F E3 3D 38  13 FE AB 76  AA 74 13 6D  5A 2B 20 DE
  D6 A5 CF 6C  04 E6 56 3F  F3 C0 C7 C4  1D 3F 43 DD
  DC F1 A5 67  A7 E0 67 9A  B0 C6 B7

H(&<Content-ID> + ‘:’ + H(&<Data>)) =  
  8E 14 D9 19  4E D6 02 12  C3 30 A7 BB  5F C7 17 6D
  AE 9A 56 7C  A8 2A 23 1F  96 75 ED 53  10 EC E8 F2
  60 14 24 D0  C8 BC 55 3D  C0 70 F7 5E  86 38 1A 0B
  CB 55 9C B2  87 81 27 FF  3C EC E2 F0  90 A0 00 00

The prefixed Binary Data Sequence is thus
  61 8E 14 D9  19 4E D6 02  12 C3 30 A7  BB 5F C7 17
  6D AE
~~~~

The 125 bit fingerprint value is MGHB-JWIZ-J3LA-EEWD-GCT3-WX6H-C5W2


###Using SHA-3-512 Digest with Compression 

The content data "UDF Compressed Document 774665" produces a UDF Content Digest SHA-3-512 binary value 
with 20 trailing zeros and is therefore presented using compressed presentation:

~~~~
Data = 
  55 44 46 20  43 6F 6D 70  72 65 73 73  65 64 20 44
  6F 63 75 6D  65 6E 74 20  37 37 34 36  36 35
~~~~

The UTF8 SHA-3-512 Content Digest is
KEJI-Y225-BDUG-XX22-MXKE-5ITF-YVYM

