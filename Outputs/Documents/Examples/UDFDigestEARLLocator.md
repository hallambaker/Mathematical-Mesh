The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EAYD-XWZT-KLWY-LAM5-65GD-II6N-MPZS-TP) =
MCLJ-LRVD-ZDWD-LHMF-34FB-5SIT-VUI4-XGOL-QKY6-VYDI-O4UI-MBGF-5YLU-HPJE
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MCLJ-LRVD-ZDWD-LHMF-34FB-5SIT-VUI4-XGOL-QKY6-VYDI-O4UI-MBGF-5YLU-HPJE


