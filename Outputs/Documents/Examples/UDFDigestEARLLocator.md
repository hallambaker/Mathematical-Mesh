The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EBPW-CXJX-TSFV-WV3V-V24H-G5ZP-VHOO-R5) =
MBOJ-XT4N-J5EQ-DOGK-CFWD-THGA-HU3X-3R5A-3256-ZMMN-HQIC-F7QD-YU4R-RIQU
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBOJ-XT4N-J5EQ-DOGK-CFWD-THGA-HU3X-3R5A-3256-ZMMN-HQIC-F7QD-YU4R-RIQU


