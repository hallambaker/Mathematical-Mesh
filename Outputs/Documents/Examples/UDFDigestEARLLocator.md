The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EA2L-PABQ-ZUIO-UR2U-KLMP-YFYK-XI5U-6Z) =
MBUC-DFHR-NRPA-ZLHR-CZRT-75CV-VWL2-OSIC-2YUH-QJ7C-3WWA-7CLC-W4X7-YNBO
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBUC-DFHR-NRPA-ZLHR-CZRT-75CV-VWL2-OSIC-2YUH-QJ7C-3WWA-7CLC-W4X7-YNBO


