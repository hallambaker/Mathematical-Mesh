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
H( &lt;Data&gt; ) = 

  48 DA 47 CC  AB FE A4 5C  76 61 D3 21  BA 34 3E 58
  10 87 2A 03  B4 02 9D AB  84 7C CE D2  22 B6 9C AB
  02 38 D4 E9  1E 2F 6B 36  A0 9E ED 11  09 8A EA AC
  99 D9 E0 BD  EA 47 93 15  BD 7A E9 E1  2E AD C4 15

H (&lt;Content-ID&gt; + ‘:’ + H(&lt;Data&gt;))= 

  74 65 78 74  2F 70 6C 61  69 6E 3A 48  DA 47 CC AB
  FE A4 5C 76  61 D3 21 BA  34 3E 58 10  87 2A 03 B4
  02 9D AB 84  7C CE D2 22  B6 9C AB 02  38 D4 E9 1E
  2F 6B 36 A0  9E ED 11 09  8A EA AC 99  D9 E0 BD EA
  47 93 15 BD  7A E9 E1 2E  AD C4 15

H (&lt;Content-ID&gt; + ‘:’ + H(&lt;Data&gt;))= 

  C6 AF B7 C0  FE BE 04 E5  AE 94 E3 7B  AA 5F 1A 40
  5B A3 CE CC  97 4D 55 C0  9E 61 E4 B0  EF 9C AE F9
  EB 83 BB 9D  5F 0F 39 F6  5F AA 06 DC  67 2A 67 71
  4F FF 8F 83  C4 55 38 36  38 AE 42 7A  82 9C 85 BB
~~~~

<dl>

<dt>Text Presentation (100 bit)
<dd>MDDK7-N6A72-7AJZN-OSTR3
<dt>Text Presentation (125 bit)
<dd>MDDK7-N6A72-7AJZN-OSTRX-XKS72
<dt>Text Presentation (150 bit)
<dd>MDDK7-N6A72-7AJZN-OSTRX-XKS7D-JAFXD
<dt>Text Presentation (250 bit)
<dd>MDDK7-N6A72-7AJZN-OSTRX-XKS7D-JAFXI-6OZSL-U2VOA-TZQ6J-MHPTS
</dl>

