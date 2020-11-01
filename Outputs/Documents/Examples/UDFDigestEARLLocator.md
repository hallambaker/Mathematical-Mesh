The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (ECXY-D3MT-3EDF-JSWP-GFCN-UHTO-NNIS-SW) =
MAF2-4G3X-BZFJ-NXUQ-LP7Q-E35G-UY2U-ALX7-I3XO-PLKK-P4TR-CKKW-2MRG-TGIF
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MAF2-4G3X-BZFJ-NXUQ-LP7Q-E35G-UY2U-ALX7-I3XO-PLKK-P4TR-CKKW-2MRG-TGIF


