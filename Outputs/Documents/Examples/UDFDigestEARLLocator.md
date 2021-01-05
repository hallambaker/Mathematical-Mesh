The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (ECBD-KSLB-BCTF-7WBY-NEUF-PW7A-RL4V-LN) =
MDS2-P4RE-4R2W-X6RN-7TOK-YU4E-SSLB-HFMS-4EVU-CPCK-5YI4-PVMF-OQOT-GQN6
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MDS2-P4RE-4R2W-X6RN-7TOK-YU4E-SSLB-HFMS-4EVU-CPCK-5YI4-PVMF-OQOT-GQN6


