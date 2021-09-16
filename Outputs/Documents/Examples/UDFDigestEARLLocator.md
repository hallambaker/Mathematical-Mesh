The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EA6N-IPHV-TP3R-4FTZ-YYHZ-CRHX-XKDZ-OD) =
MBZ3-ZRBJ-HR6E-RMCU-DFBB-CMOY-Z6SJ-75PA-XDEV-TESI-F2TW-6B6S-QK4T-EXSP
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBZ3-ZRBJ-HR6E-RMCU-DFBB-CMOY-Z6SJ-75PA-XDEV-TESI-F2TW-6B6S-QK4T-EXSP


