The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (ECF4-U6VH-AZFS-NG55-X2MF-THGG-EQUP-XQ) =
MDL7-FRJ6-TUFK-6R5F-4Y2E-GPTW-33NY-KG54-V6WN-JJ2S-SJ44-6NYS-QIUM-PQEH
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MDL7-FRJ6-TUFK-6R5F-4Y2E-GPTW-33NY-KG54-V6WN-JJ2S-SJ44-6NYS-QIUM-PQEH


