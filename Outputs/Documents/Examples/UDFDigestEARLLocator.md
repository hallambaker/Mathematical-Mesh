The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EA2V-BHP5-BEGW-TE2X-DJKC-45AC-U5ZT-SZ) =
MA3A-K6T5-UFBH-7IST-YCHV-VKOZ-DRK7-B2O6-4WTK-OBRT-UQGB-6N67-PQOR-PMFM
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MA3A-K6T5-UFBH-7IST-YCHV-VKOZ-DRK7-B2O6-4WTK-OBRT-UQGB-6N67-PQOR-PMFM


