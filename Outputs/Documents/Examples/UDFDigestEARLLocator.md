The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EAZD-R7YU-G3JY-LNIB-6OVH-IVV2-PLEL-EZ) =
MA4R-MFPI-7EAB-KAG6-T2FK-GSXM-EXSX-CUFU-YP7H-HIMO-VMFD-3K3M-FTG6-XQ7Y
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MA4R-MFPI-7EAB-KAG6-T2FK-GSXM-EXSX-CUFU-YP7H-HIMO-VMFD-3K3M-FTG6-XQ7Y


