The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (ECU3-2LRD-2XNA-TLRQ-WOHH-KGVP-BENI-H4) =
MBSQ-HC37-PRSY-GNQF-7OND-JBIN-LR2H-UPZH-6UGC-GO3X-VSCB-I3FJ-V54V-6XVI
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBSQ-HC37-PRSY-GNQF-7OND-JBIN-LR2H-UPZH-6UGC-GO3X-VSCB-I3FJ-V54V-6XVI


