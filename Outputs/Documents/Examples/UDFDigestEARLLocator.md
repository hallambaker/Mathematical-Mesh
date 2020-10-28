The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EDUR-E7DH-7ATX-T22Y-AVOM-PP7Q-Z3QO-T6) =
MAGY-7W7G-AWSR-VN7Z-CXKL-FTF3-BNP2-4A6F-B7YU-QQGQ-MES6-4LDK-QBK7-MGHP
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MAGY-7W7G-AWSR-VN7Z-CXKL-FTF3-BNP2-4A6F-B7YU-QQGQ-MES6-4LDK-QBK7-MGHP


