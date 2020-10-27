The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EAIW-OYDV-24MX-IMEO-SQTX-MJDU-EBBA-M2) =
MBHD-QBZZ-QEJL-I4QD-TRS6-PASI-24ME-IY6S-VZXU-LBE7-BHHC-7X52-XP73-S2MC
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBHD-QBZZ-QEJL-I4QD-TRS6-PASI-24ME-IY6S-VZXU-LBE7-BHHC-7X52-XP73-S2MC


