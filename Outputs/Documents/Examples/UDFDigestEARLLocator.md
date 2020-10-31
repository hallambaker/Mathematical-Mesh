The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (ECSU-7GQV-KOSC-N7CU-72TC-4QHA-5W2O-VC) =
MBCA-MPM4-7GAJ-FJDE-5UF3-OHUP-SLXL-I56T-BJ53-UIWZ-EIWN-KXGK-EEJB-CD7G
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBCA-MPM4-7GAJ-FJDE-5UF3-OHUP-SLXL-I56T-BJ53-UIWZ-EIWN-KXGK-EEJB-CD7G


