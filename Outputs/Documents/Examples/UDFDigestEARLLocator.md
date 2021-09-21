The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EBEB-NH6I-SRXY-XMF6-3YPA-623Q-7LJ7-ES) =
MCDM-LUFP-DD6H-5PNV-23TM-4EOK-LOQB-IFHS-DNTQ-KDUN-S3MZ-WIXZ-G7YS-YYBZ
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MCDM-LUFP-DD6H-5PNV-23TM-4EOK-LOQB-IFHS-DNTQ-KDUN-S3MZ-WIXZ-G7YS-YYBZ


