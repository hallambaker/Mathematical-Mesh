The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EDDD-RSZL-QLB5-XJQE-FBLF-3MSF-NHMQ-3M) =
MDLO-2GCA-WE2S-7Q52-FJT5-PWML-RUD7-72QM-4MDM-MGKD-WMS3-QUF4-2CI2-PBD6
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MDLO-2GCA-WE2S-7Q52-FJT5-PWML-RUD7-72QM-4MDM-MGKD-WMS3-QUF4-2CI2-PBD6


