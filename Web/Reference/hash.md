

# hash

````
hash    Content Digest and Message Authentication Code operations on files
    digest   Calculate the digest value of the input data
    mac   Calculate a commitment value for the input data
    udf   Calculate the Uniform Data Fingerprint of the input data
````

The `hash` command set contains commands that perform Content Digest and 
Message Authentication Code operations on the contents of a file.

# hash udf

````
udf   Calculate the Uniform Data Fingerprint of the input data
       File to take digest of
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /alg   List of algorithm specifiers
    /bits   Secret size in bits
    /cty   Content Type
    /expect   Expected value
````

The `hash udf` command returns the UDF Content digest of the specified input 
file according to the precision, IANA media type and digest algorithm specified
with the `/bits`, `/cty` and `/alg` options.

**Missing Example***


# hash digest

````
digest   Calculate the digest value of the input data
       File to take digest of
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /alg   List of algorithm specifiers
````

The `hash digest` command returns the Content digest of the specified input 
file according to the digest algorithm specifiedwith the `/alg` option.


**Missing Example***

The `/alg` option allows the digest algorithm to be specified.

# hash mac

````
mac   Calculate a commitment value for the input data
       File to create commitment of
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /alg   List of algorithm specifiers
    /bits   Secret size in bits
    /cty   Content Type
    /key   Specifies the value of the key
    /expect   Expected value
````

The `hash mac` command returns the UDF Message Authentication Code of the specified 
input file according to the precision, IANA media type and digest algorithm specified
with the `/bits`, `/cty` and `/alg` options.

If a no key is specified, a new key is randomly generated, otherwise the specified 
key is used. 

If a MAC value is specified, it is compared to the calculated value and the value
true returned if and only if it matches the value specified.

**Missing Example***

