The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EB5B-MNWR-XRYS-NKPP-UE7P-VDH6-BNAR-CS) =
MBIJ-5VSL-BB7R-NX7F-PUHN-UEXU-KJKM-LB4E-OG2R-EU6C-LKHV-4T4N-RRHW-3GIF
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBIJ-5VSL-BB7R-NX7F-PUHN-UEXU-KJKM-LB4E-OG2R-EU6C-LKHV-4T4N-RRHW-3GIF


