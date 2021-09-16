The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (ECTA-PSV6-ZORN-MQ4U-XBT5-DUSU-EIWW-24) =
MBQW-FDHR-2NTX-LOKZ-VLDN-A32K-NGLX-XFPI-Q2RJ-7TTF-H3BP-LVAU-KKSB-EL5P
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBQW-FDHR-2NTX-LOKZ-VLDN-A32K-NGLX-XFPI-Q2RJ-7TTF-H3BP-LVAU-KKSB-EL5P


