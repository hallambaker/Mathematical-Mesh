The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (ECIH-NVWP-VO6J-A6YS-UATI-PQYT-FYMC-JL) =
MBP7-ZVOK-27O4-D2JV-5LQA-CWZA-GXT6-WBXG-56OD-ZHQO-6A4D-Y3T3-QB2C-YMVA
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBP7-ZVOK-27O4-D2JV-5LQA-CWZA-GXT6-WBXG-56OD-ZHQO-6A4D-Y3T3-QB2C-YMVA


