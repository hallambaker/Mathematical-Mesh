The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EB63-3XRL-YIVD-KPNC-G7IG-ITHF-BN6K-NS) =
MAX6-TYGQ-KEC5-SC63-UNSG-W3JP-B6DI-OJXF-AAN7-CLZO-ZUU5-IUUS-BFW4-GOGB
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MAX6-TYGQ-KEC5-SC63-UNSG-W3JP-B6DI-OJXF-AAN7-CLZO-ZUU5-IUUS-BFW4-GOGB


