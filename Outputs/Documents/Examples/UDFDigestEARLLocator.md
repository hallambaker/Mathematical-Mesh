The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EADM-4SSO-RFX4-BYUN-BC6I-UHGG-B73R-PY) =
MDJL-BDPC-ZNIG-QXGS-X26D-ETGV-JR63-7I2N-XTAO-P7XS-LW3V-V3GB-5X5U-CQJX
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MDJL-BDPC-ZNIG-QXGS-X26D-ETGV-JR63-7I2N-XTAO-P7XS-LW3V-V3GB-5X5U-CQJX


