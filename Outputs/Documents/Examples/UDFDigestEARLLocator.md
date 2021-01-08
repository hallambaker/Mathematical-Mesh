The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EBA5-UOHD-COCW-MCRE-2UOU-X5W4-MCI3-RE) =
MBNT-B4BY-RUKE-K2EV-U4N5-54SP-3KN3-TOUV-X6HE-56ZD-2DFJ-RDRZ-PCRB-IYG4
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBNT-B4BY-RUKE-K2EV-U4N5-54SP-3KN3-TOUV-X6HE-56ZD-2DFJ-RDRZ-PCRB-IYG4


