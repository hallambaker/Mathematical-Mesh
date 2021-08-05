The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EADA-YKC5-WSUK-AACN-WRRO-MJOQ-PVSK-SM) =
MDQK-2L7C-OD5I-QJNG-ZJ3Y-OHAH-GMTW-USRH-ENGL-SG23-APAP-YH7I-ZIFA-J3UQ
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MDQK-2L7C-OD5I-QJNG-ZJ3Y-OHAH-GMTW-USRH-ENGL-SG23-APAP-YH7I-ZIFA-J3UQ


