The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EAB3-H323-NV5G-XZK7-2V3I-QES7-SZFY-UL) =
MA3Z-YEFC-WODL-KIBO-S2OZ-MJBF-LJ4O-2D4A-RFXU-UO37-QCWJ-KJRM-HRFR-WFXO
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MA3Z-YEFC-WODL-KIBO-S2OZ-MJBF-LJ4O-2D4A-RFXU-UO37-QCWJ-KJRM-HRFR-WFXO


