The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EBX2-6RAI-XGVX-UC5O-3VD5-ABIH-CS2L-FW) =
MAQN-ZTTP-X5SD-ZYL7-7CEB-CJ5N-V55Z-2HCS-PMR6-L673-3ZS5-3BDZ-Q2VB-NDRQ
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MAQN-ZTTP-X5SD-ZYL7-7CEB-CJ5N-V55Z-2HCS-PMR6-L673-3ZS5-3BDZ-Q2VB-NDRQ


