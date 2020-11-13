The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EDQK-7BC3-GPFV-KCGZ-D3RP-4AIK-TPIF-QF) =
MAXG-JGJQ-PFNI-ZFJY-FGPX-4C5X-BKWB-PTBL-HEXQ-2MBR-N6OK-5XWX-BQKW-65KL
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MAXG-JGJQ-PFNI-ZFJY-FGPX-4C5X-BKWB-PTBL-HEXQ-2MBR-N6OK-5XWX-BQKW-65KL


