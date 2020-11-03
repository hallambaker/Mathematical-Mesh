The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EDQ3-IVHW-3KNE-YL3A-QURR-ADFI-PDYR-QV) =
MBGI-BV3F-66TC-AFJQ-STRJ-GPY4-MUFJ-5KOP-Y7K5-YWIH-5I4R-YT3Q-TKFT-RRIT
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBGI-BV3F-66TC-AFJQ-STRJ-GPY4-MUFJ-5KOP-Y7K5-YWIH-5I4R-YT3Q-TKFT-RRIT


