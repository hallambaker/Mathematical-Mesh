The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EBLE-SBPF-7UTM-R3RT-INSP-MZ2P-NGDL-TD) =
MC77-SRQS-42MC-ONJO-TZSC-HZX4-DBRS-BULQ-ZCLO-MIFJ-7L6T-L7AW-JUE5-S77V
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MC77-SRQS-42MC-ONJO-TZSC-HZX4-DBRS-BULQ-ZCLO-MIFJ-7L6T-L7AW-JUE5-S77V


