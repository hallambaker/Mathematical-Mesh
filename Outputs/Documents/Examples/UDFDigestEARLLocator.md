The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EAO2-VBSV-GOWL-3RO5-57B6-LD2Y-7F6S-JZ) =
MA27-GB6P-QGBY-TO2P-5JTF-B6MS-7JJG-PKVJ-COBH-E5IP-IMMD-K7BN-7Z5Y-P6E4
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MA27-GB6P-QGBY-TO2P-5JTF-B6MS-7JJG-PKVJ-COBH-E5IP-IMMD-K7BN-7Z5Y-P6E4


