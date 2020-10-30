The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (ECKV-REGX-SWZP-5UUD-BHZB-YWTC-55BA-PW) =
MAI3-2425-Z3DX-V7BU-Y4BU-GION-JALZ-H4JL-GUU4-6AQE-O6KJ-SAKT-GJSM-I4XC
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MAI3-2425-Z3DX-V7BU-Y4BU-GION-JALZ-H4JL-GUU4-6AQE-O6KJ-SAKT-GJSM-I4XC


