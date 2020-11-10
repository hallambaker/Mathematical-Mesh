The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EAOS-B2BJ-O2O3-ZJEB-232G-KS57-F7TU-7P) =
MCPC-EIPG-GKKD-4ODH-ECWE-TN6O-ZDR3-6ALK-25JZ-RWZH-6RXX-V7DN-6EQ6-AA75
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MCPC-EIPG-GKKD-4ODH-ECWE-TN6O-ZDR3-6ALK-25JZ-RWZH-6RXX-V7DN-6EQ6-AA75


