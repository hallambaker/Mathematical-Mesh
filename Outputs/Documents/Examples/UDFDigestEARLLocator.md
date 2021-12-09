The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EA4R-KMFR-M7VS-RMYP-6I35-SKGB-TY7Y-FZ) =
MAWM-7UHO-FQOO-XQCG-GS2R-7E6C-4W6S-VS34-POOW-D26V-VWIF-O3MJ-I3BM-DANB
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MAWM-7UHO-FQOO-XQCG-GS2R-7E6C-4W6S-VS34-POOW-D26V-VWIF-O3MJ-I3BM-DANB


