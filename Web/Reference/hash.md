

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


````
>hash udf TestFile1.txt
MDLI-GX2C-3OQB-BVWI-REXY-EB56-JG4R
````

Specifying the /json option returns a result of type ResultDigest:

````
>hash udf TestFile1.txt /json
{
  "ResultDigest": {
    "Success": true,
    "Digest": "MDLI-GX2C-3OQB-BVWI-REXY-EB56-JG4R"}}
````


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



````
>hash digest TestFile1.txt
A028D4F74B602BA45EB0A93C9A4677240DCF281A1A9322F183BD32F0BED82EC72DE9C3957B2F4C9A1CCF7ED14F85D73498DF38017E703D47EBB9F0B3BF116F69
````

Specifying the /json option returns a result of type ResultDigest:

````
>hash digest TestFile1.txt /json
{
  "ResultDigest": {
    "Success": true,
    "Digest": "A028D4F74B602BA45EB0A93C9A4677240DCF281A1A9322F183BD32F0BED82EC72DE9C3957B2F4C9A1CCF7ED14F85D73498DF38017E703D47EBB9F0B3BF116F69"}}
````

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


````
>hash mac TestFile1.txt
AAJY-THP5-CFZP-DPTX-3SLX-IAQD-YNS6
NCPP-RNDV-35TD-APXO-FKY5-CIVW-5GCH
````

Specifying the /json option returns a result of type ResultDigest:

````
>hash mac TestFile1.txt /json
{
  "ResultDigest": {
    "Success": true,
    "Digest": "AAJY-THP5-CFZP-DPTX-3SLX-IAQD-YNS6",
    "Key": "NCPP-RNDV-35TD-APXO-FKY5-CIVW-5GCH"}}
````

