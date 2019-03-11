# Using the `hash` Command Set

The `hash` command set contains commands that perform Content Digest and 
Message Authentication Code operations on the contents of a file.

## Calculating Content Digests

The `hash udf`  command calculates the UDF value of a file:


````
>hash udf TestFile1.txt
MDLI-GX2C-3OQB-BVWI-REXY-EB56-JG4R````

In this case, the file `TestFile1.txt` contains the text `This is a test`.

By default, a SHA-2-512 digest is created and the IANA Media Type parameter is
determined from the file extension of the file being processed. These defaults
may be overriden using the `/cty` and `/alg` options:


````
>hash udf TestFile1.txt /alg=sha3 /cty=application/binary
KDTG-XEIH-6LJ2-BDO6-6EPH-G65G-6DN5````

By default, UDF values are given to 140 bit precision. Higher precision may be
specified with the `/bits' option:


````
>hash udf TestFile1.txt /bits=200
KCYH-QB5Y-XZ6U-SXN2-WV63-AM4U-ZZIT````

If the expected digest value is specified, this is used to check the calculated value:


````
>hash udf TestFile1.txt /expect=MDLI-GX2C-3OQB-BVWI-REXY-EB56-JG4R
KCYH-QB5Y-XZ6U-SXN2-WV63-AM4U-ZZIT````

The `hash digest`  command calculates SHA-2 and SHA-3 digests and
returns them in hexadecimal form:


````
>hash digest TestFile1.txt
A028D4F74B602BA45EB0A93C9A4677240DCF281A1A9322F183BD32F0BED82EC72DE9C3957B2F4C9A1CCF7ED14F85D73498DF38017E703D47EBB9F0B3BF116F69````

Additional digest algorithms may be specified using the `/alg` option:


````
>hash digest TestFile1.txt /alg=sha256
A028D4F74B602BA45EB0A93C9A4677240DCF281A1A9322F183BD32F0BED82EC72DE9C3957B2F4C9A1CCF7ED14F85D73498DF38017E703D47EBB9F0B3BF116F69>hash digest TestFile1.txt /alg=sha3
A028D4F74B602BA45EB0A93C9A4677240DCF281A1A9322F183BD32F0BED82EC72DE9C3957B2F4C9A1CCF7ED14F85D73498DF38017E703D47EBB9F0B3BF116F69````

## Calculating UDF Message Authentication Codes

The `hash mac` command calculates a Message Authentication Code (MAC)
over the file contents and presents it in UDF format:

A MAC may be used to create a keyed commitment value that can be used to provide
proof that a document existed at a particular time without revealing information 
that might allow disclosure of a short or otherwise predictable document by a 
brute force attack.

If no key is specified, a random secret is generated:


````
>hash mac TestFile1.txt
ADVQ-LTYK-JVYA-J7WO-NS6S-2MIT-JEPR````

A key may be specified using the `/key` option:


````
>hash mac TestFile1.txt /key=NAKE-H755-YZQS-EGT5-JSP2-2EGA-ZKKZ
ADVQ-LTYK-JVYA-J7WO-NS6S-2MIT-JEPR````

If the expected digest value is specified, this is used to check the calculated value:



````
>hash mac TestFile1.txt /key=NAKE-H755-YZQS-EGT5-JSP2-2EGA-ZKKZ /expect=ADVQ-LTYK-JVYA-J7WO-NS6S-2MIT-JEPR
ADVQ-LTYK-JVYA-J7WO-NS6S-2MIT-JEPR````


