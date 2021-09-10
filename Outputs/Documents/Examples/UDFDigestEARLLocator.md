The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EB5N-LFI7-4H7C-3OCZ-R3Z6-UGOO-GV4H-35) =
MD22-PS3Z-K7IW-UBIS-3XTK-GAM6-RLRO-SLKH-VNC3-ZFXG-BEES-CZGO-DBWE-6FZL
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MD22-PS3Z-K7IW-UBIS-3XTK-GAM6-RLRO-SLKH-VNC3-ZFXG-BEES-CZGO-DBWE-6FZL


