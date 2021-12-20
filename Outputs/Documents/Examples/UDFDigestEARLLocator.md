The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EBM7-FGUF-DACT-23HL-4VU3-7O77-ZPPC-BK) =
MAKE-PENQ-QDLO-5ZTT-ZXJZ-5RCC-NVK4-DAQO-VURY-LYW5-HBOL-SZYZ-YL5I-HEJ7
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MAKE-PENQ-QDLO-5ZTT-ZXJZ-5RCC-NVK4-DAQO-VURY-LYW5-HBOL-SZYZ-YL5I-HEJ7


