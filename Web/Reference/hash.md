

# hash

~~~~
<div="helptext">
<over>
hash    Content Digest and Message Authentication Code operations on files
    digest   Calculate the digest value of the input data
    mac   Calculate a commitment value for the input data
    udf   Calculate the Uniform Data Fingerprint of the input data
<over>
</div>
~~~~

The `hash` command set contains commands that perform Content Digest and 
Message Authentication Code operations on the contents of a file.




# hash digest

~~~~
<div="helptext">
<over>
digest   Calculate the digest value of the input data
       File to take digest of
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /alg   List of algorithm specifiers
<over>
</div>
~~~~

The `hash digest` command returns the Content digest of the specified input 
file according to the digest algorithm specifiedwith the `/alg` option.



~~~~
<div="terminal">
<cmd>Alice> meshman hash digest TestFile1.txt
<rsp>A028D4F74B602BA45EB0A93C9A4677240DCF281A1A9322F183BD32F0BED82EC72DE9C3957B2F4C9A1CCF7ED14F85D73498DF38017E703D47EBB9F0B3BF116F69
</div>
~~~~



The `/alg` option allows the digest algorithm to be specified.

# hash mac

~~~~
<div="helptext">
<over>
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
<over>
</div>
~~~~

The `hash mac` command returns the UDF Message Authentication Code of the specified 
input file according to the precision, IANA media type and digest algorithm specified
with the `/bits`, `/cty` and `/alg` options.

If a no key is specified, a new key is randomly generated, otherwise the specified 
key is used. 

If a MAC value is specified, it is compared to the calculated value and the value
true returned if and only if it matches the value specified.

The first value returned is the MAC value. The second value returned is the nonce
used as a key.


~~~~
<div="terminal">
<cmd>Alice> meshman hash mac TestFile1.txt
<rsp>ADWI-QPQ6-A6O6-6GKA-NUI3-CILB-HPQM
NAUL-ZACO-WCZG-LNHO-FG4Z-VTDE-G7BA
</div>
~~~~



# hash udf

~~~~
<div="helptext">
<over>
udf   Calculate the Uniform Data Fingerprint of the input data
       File to take digest of
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /alg   List of algorithm specifiers
    /bits   Secret size in bits
    /cty   Content Type
    /expect   Expected value
<over>
</div>
~~~~

The `hash udf` command returns the UDF Content digest of the specified input 
file according to the precision, IANA media type and digest algorithm specified
with the `/bits`, `/cty` and `/alg` options.


~~~~
<div="terminal">
<cmd>Alice> meshman hash udf TestFile1.txt
<rsp>MDLI-GX2C-3OQB-BVWI-REXY-EB56-JG4R
</div>
~~~~




