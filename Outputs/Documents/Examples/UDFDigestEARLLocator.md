The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EC2V-CMA4-4NGZ-JLZP-R2VY-Y6DP-3AKP-3R) =
MAT5-O6RC-NZ3E-OZCD-CTFV-M3IU-QVPW-GKCJ-KTFJ-5C3P-F5UH-DDKN-47TL-4CRW
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MAT5-O6RC-NZ3E-OZCD-CTFV-M3IU-QVPW-GKCJ-KTFJ-5C3P-F5UH-DDKN-47TL-4CRW


