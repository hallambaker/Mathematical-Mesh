The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (ECNA-VVZI-TBD6-VRIO-6TAR-DRZC-5HXC-FK) =
MDZ3-E6YT-BMYS-DOSB-EVNE-E3YB-C7H5-OUCZ-L3PV-UJJE-EDHE-RRJE-TSBX-VEI7
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MDZ3-E6YT-BMYS-DOSB-EVNE-E3YB-C7H5-OUCZ-L3PV-UJJE-EDHE-RRJE-TSBX-VEI7


