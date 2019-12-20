<title>hash
# Using the hash Command Set

The `hash` command set contains commands that perform Content Digest and 
Message Authentication Code operations on the contents of a file.

## Calculating Content Digests

The `hash udf`  command calculates the UDF value of a file:


~~~~
<div="terminal">
<cmd>Alice> hash udf TestFile1.txt
<rsp>MDLI-GX2C-3OQB-BVWI-REXY-EB56-JG4R
</div>
~~~~

In this case, the file `TestFile1.txt` contains the text `"This is a test"`.

By default, a SHA-2-512 digest is created and the IANA Media Type parameter is
determined from the file extension of the file being processed. These defaults
may be overriden using the `/cty` and `/alg` options:


~~~~
<div="terminal">
<cmd>Alice> hash udf TestFile1.txt /cty=application/binary
<rsp>MDBI-EE4Z-7NSH-SYBU-JHYL-JTGH-QQEZ
<cmd>Alice> hash udf TestFile1.txt /alg=sha3
<rsp>KCYH-QB5Y-XZ6U-SXN2-WV63-AM4U-ZZIT
</div>
~~~~

By default, UDF values are given to 140 bit precision. Higher precision may be
specified with the `/bits' option:


~~~~
<div="terminal">
<cmd>Alice> hash udf TestFile1.txt /bits=200
<rsp>MDLI-GX2C-3OQB-BVWI-REXY-EB56-JG4R-NYJQ-SWWT-UNJM
</div>
~~~~

If the expected digest value is specified, this is used to check the calculated value:


~~~~
<div="terminal">
<cmd>Alice> hash udf TestFile1.txt /expect=MDLI-GX2C-3OQB-BVWI-REXY-EB56-JG4R
<rsp>True
<cmd>Alice> hash udf TestFile1.txt /expect=MDBI-EE4Z-7NSH-SYBU-JHYL-JTGH-QQEZ
<rsp>ERROR - The calculated fingerprint did not match the expected value.
</div>
~~~~

The `hash digest`  command calculates the SHA-2-512 digest and
returns it in hexadecimal form:


~~~~
<div="terminal">
<cmd>Alice> hash digest TestFile1.txt
<rsp>A028D4F74B602BA45EB0A93C9A4677240DCF281A1A9322F183BD32F0BED82EC72DE9C3957B2F4C9A1CCF7ED14F85D73498DF38017E703D47EBB9F0B3BF116F69
</div>
~~~~

Additional digest algorithms may be specified using the `/alg` option:


~~~~
<div="terminal">
<cmd>Alice> hash digest TestFile1.txt /alg=sha256
<rsp>C7BE1ED902FB8DD4D48997C6452F5D7E509FBCDBE2808B16BCF4EDCE4C07D14E
<cmd>Alice> hash digest TestFile1.txt /alg=sha3256
<rsp>3C3B66EDCFE51F5B15BF372F61E25710FFC1AD3C0E3C60D832B42053A96772CF
<cmd>Alice> hash digest TestFile1.txt /alg=sha3
<rsp>CE548503582D94B17898E45B1B641E97BE64DC23947890E8F5199E474819E7F94B5A0D55B41D2CCC01D0C37C978F1F2523BD294B7E282E36E20C39C84CC2730E
</div>
~~~~

## Calculating UDF Message Authentication Codes

The `hash mac` command calculates a Message Authentication Code (MAC)
over the file contents and presents it in UDF format:

A MAC may be used to create a keyed commitment value that can be used to provide
proof that a document existed at a particular time without revealing information 
that might allow disclosure of a short or otherwise predictable document by a 
brute force attack.

If no key is specified, a random secret is generated:


~~~~
<div="terminal">
<cmd>Alice> hash mac TestFile1.txt
<rsp>ACPD-YVPX-VMBP-7VAM-RCUP-NAG6-LLYV
NDXX-MFCD-5YYF-VHJF-JTIG-SJY5-HMBU
</div>
~~~~

A key may be specified using the `/key` option:


~~~~
<div="terminal">
<cmd>Alice> hash mac TestFile1.txt /key=NDXX-MFCD-5YYF-VHJF-JTIG-SJY5-HMBU
<rsp>ACPD-YVPX-VMBP-7VAM-RCUP-NAG6-LLYV
NDXX-MFCD-5YYF-VHJF-JTIG-SJY5-HMBU
</div>
~~~~

If the expected digest value is specified, this is used to check the calculated value:



~~~~
<div="terminal">
<cmd>Alice> hash mac TestFile1.txt /key=NDXX-MFCD-5YYF-VHJF-JTIG-SJY5-HMBU /expect=ACPD-YVPX-VMBP-7VAM-RCUP-NAG6-LLYV
<rsp>True
<cmd>Alice> hash mac TestFile1.txt /key=NDXX-MFCD-5YYF-VHJF-JTIG-SJY5-HMBU /expect=MDLI-GX2C-3OQB-BVWI-REXY-EB56-JG4R
<rsp>ERROR - The calculated fingerprint did not match the expected value.
</div>
~~~~


