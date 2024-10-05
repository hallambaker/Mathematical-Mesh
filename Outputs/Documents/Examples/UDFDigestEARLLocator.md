The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (ECR2-37YE-ABST-B4BK-RYM3-SVEO-WFO7-ID) =
MATE-W23J-KHUP-7TWS-LM4T-35U2-ZJV6-T2DD-S25D-U66G-3BB5-H6WP-PPHC-CPYV
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MATE-W23J-KHUP-7TWS-LM4T-35U2-ZJV6-T2DD-S25D-U66G-3BB5-H6WP-PPHC-CPYV


