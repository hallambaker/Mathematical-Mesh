The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EAQN-IQUQ-PFIE-MARO-EGY4-575R-H45E-QG) =
MBUY-LRYF-5TW2-7TGP-IA5J-KZ6U-XRBN-4QVI-6N7U-RKVK-R3CG-HUKM-O4N7-RGJ4
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBUY-LRYF-5TW2-7TGP-IA5J-KZ6U-XRBN-4QVI-6N7U-RKVK-R3CG-HUKM-O4N7-RGJ4


