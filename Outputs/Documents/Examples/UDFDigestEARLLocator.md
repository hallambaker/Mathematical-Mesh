The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EATD-S63T-MGL2-7GUB-KYPW-DQ6F-LTUT-LS) =
MBQ7-QH4O-4MLA-J76X-54SL-TV4X-3ZJ4-VHRM-TTX3-3SX3-NRJ4-RGCZ-P75T-AAVZ
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBQ7-QH4O-4MLA-J76X-54SL-TV4X-3ZJ4-VHRM-TTX3-3SX3-NRJ4-RGCZ-P75T-AAVZ


