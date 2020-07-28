The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EDY3-ZHBJ-BK2W-TPPA-RBGW-P2TC-YFA6-3T) =
MBHV-HFTF-IEWP-DFME-BISL-FJG2-W4VP-3X2K-S42Z-5MOY-E37L-B33Q-WTMZ-G2PA
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBHV-HFTF-IEWP-DFME-BISL-FJG2-W4VP-3X2K-S42Z-5MOY-E37L-B33Q-WTMZ-G2PA


