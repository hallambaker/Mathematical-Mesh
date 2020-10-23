The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (ECRG-YYR4-F3IQ-LKYJ-5WPU-Q2VD-VACO-CX) =
MA4T-5JI3-464H-CIEO-CIT3-PNOC-KAG2-BJHG-OVJM-7SYC-MTLB-FMFI-CAYE-SE4S
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MA4T-5JI3-464H-CIEO-CIT3-PNOC-KAG2-BJHG-OVJM-7SYC-MTLB-FMFI-CAYE-SE4S


