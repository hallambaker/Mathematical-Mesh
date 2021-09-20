The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EA6K-62GR-VWQQ-BRVD-XA7Y-KYWK-P2ZE-EP) =
MAZ6-A6LM-Z354-TOUI-62YC-ITAE-BXFP-ZNX6-LWVE-7WZO-SKDM-SZVS-6X2N-UUUV
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MAZ6-A6LM-Z354-TOUI-62YC-ITAE-BXFP-ZNX6-LWVE-7WZO-SKDM-SZVS-6X2N-UUUV


