The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EDTW-GWGP-7IVU-XF3P-LJGN-RSPO-K63R-6Y) =
MCXQ-KAN2-S3WC-TC7K-ZX66-SLRY-YKSA-3LJH-3DJC-5EQG-6EF4-G45K-RKDP-DNUU
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MCXQ-KAN2-S3WC-TC7K-ZX66-SLRY-YKSA-3LJH-3DJC-5EQG-6EF4-G45K-RKDP-DNUU


