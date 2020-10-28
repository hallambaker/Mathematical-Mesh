<title>hash
# Using the hash Command Set

The `hash` command set contains commands that perform Content Digest and 
Message Authentication Code operations on the contents of a file.

## Calculating Content Digests

The `hash udf`  command calculates the UDF value of a file:


~~~~
Missing example 1
~~~~

In this case, the file `TestFile1.txt` contains the text `"This is a test 1"`.

By default, a SHA-2-512 digest is created and the IANA Media Type parameter is
determined from the file extension of the file being processed. These defaults
may be overriden using the `/cty` and `/alg` options:


~~~~
Missing example 2
~~~~

By default, UDF values are given to 140 bit precision. Higher precision may be
specified with the `/bits' option:


~~~~
Missing example 3
~~~~

If the expected digest value is specified, this is used to check the calculated value:


~~~~
Missing example 4
~~~~

The `hash digest`  command calculates the SHA-2-512 digest and
returns it in hexadecimal form:


~~~~
Missing example 5
~~~~

Additional digest algorithms may be specified using the `/alg` option:


~~~~
Missing example 6
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
Missing example 7
~~~~

A key may be specified using the `/key` option:


~~~~
Missing example 8
~~~~

If the expected digest value is specified, this is used to check the calculated value:



~~~~
Missing example 9
~~~~


