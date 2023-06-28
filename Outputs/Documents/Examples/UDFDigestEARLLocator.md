The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EDQB-6NYS-T57S-DVKF-4FHT-BHPO-ATC4-UL) =
MCU7-43LV-OH4V-5JPL-4GT4-5TPW-DJ33-5BDH-MQMP-UPHQ-3XLX-4GGO-U34N-FWJK
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MCU7-43LV-OH4V-5JPL-4GT4-5TPW-DJ33-5BDH-MQMP-UPHQ-3XLX-4GGO-U34N-FWJK


