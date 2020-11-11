The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EDDP-A4O5-2UNJ-RUPS-7LAO-SI5C-IH3H-IA) =
MBKU-PAZA-W2NN-ON2C-HG4N-JGXK-SVBP-SGDK-QV5Q-PEEG-LRDZ-IYSN-WWGT-KCE3
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBKU-PAZA-W2NN-ON2C-HG4N-JGXK-SVBP-SGDK-QV5Q-PEEG-LRDZ-IYSN-WWGT-KCE3


