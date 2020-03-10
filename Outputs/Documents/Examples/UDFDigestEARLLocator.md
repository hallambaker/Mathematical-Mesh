The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EBBB-OEZG-RPME-VNML-ETB6-2UK4-AGQM-YS) =
MD67-MCGX-M75F-PUVG-HXZO-MA5Q-4ZQQ-QD5G-VVPR-TRZW-Z2BX-NY6V-B75Z-PGKH
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MD67-MCGX-M75F-PUVG-HXZO-MA5Q-4ZQQ-QD5G-VVPR-TRZW-Z2BX-NY6V-B75Z-PGKH


