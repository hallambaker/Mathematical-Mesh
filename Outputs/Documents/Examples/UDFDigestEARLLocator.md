The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EDNL-TJNU-T7P6-5FYA-O5ST-5NIS-DDCJ-XP) =
MD2A-BAUK-MTPT-CDTQ-M6MH-7U66-O3QL-4V5K-WKMO-SS6Y-FUSD-PCF5-LDNR-37RR
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MD2A-BAUK-MTPT-CDTQ-M6MH-7U66-O3QL-4V5K-WKMO-SS6Y-FUSD-PCF5-LDNR-37RR


