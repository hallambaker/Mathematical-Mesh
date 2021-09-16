The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EB4P-W63R-G4RW-QVSD-3FMR-CPFU-XTPZ-ZI) =
MBKR-RGQ3-3EZJ-2ZP7-VAE2-J5EF-MDYP-JHWY-K5AP-PCFN-QKSO-Q3OC-OCW5-254G
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBKR-RGQ3-3EZJ-2ZP7-VAE2-J5EF-MDYP-JHWY-K5AP-PCFN-QKSO-Q3OC-OCW5-254G


