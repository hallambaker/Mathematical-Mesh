

# dare

````
dare    
    decode   Decode a DARE Message.
    encode   Encode data as DARE Message.
    verify   Verify a DARE Message.
````


# dare encode

````
encode   Encode data as DARE Message.
       File or directory to encrypt
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /out   Filename for encrypted output.
    /sub   Process subdirectories recursively.
````
# dare decode

````
decode   Decode a DARE Message.
       Encrypted File
       Decrypted File
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````
# dare verify

````
verify   Verify a DARE Message.
       Encrypted File
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

