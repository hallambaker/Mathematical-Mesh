The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EB26-A4RP-T5PC-DUHE-RV5K-IWTV-QLEM-HT) =
MAGB-4XY6-KEUZ-NG7C-MOHS-RWS2-UDDC-CKNL-WWIZ-ZYYK-PEMG-64W2-7B53-N6W3
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MAGB-4XY6-KEUZ-NG7C-MOHS-RWS2-UDDC-CKNL-WWIZ-ZYYK-PEMG-64W2-7B53-N6W3


