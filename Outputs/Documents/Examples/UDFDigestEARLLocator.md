The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EBXI-SDDC-QJME-B3DV-DSSR-PP7V-QBVF-EG) =
MA7I-5WGZ-NT4U-2UXI-KEP7-LYNV-JJUP-YJJB-D5UM-PYA6-PQW5-WTHS-2WD4-BZFN
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MA7I-5WGZ-NT4U-2UXI-KEP7-LYNV-JJUP-YJJB-D5UM-PYA6-PQW5-WTHS-2WD4-BZFN


