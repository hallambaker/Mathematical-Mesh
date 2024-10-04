The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EDXZ-OM4Z-7GJ7-WWAW-VVG4-3MD5-IFNU-NR) =
MDE7-JTHK-RSGB-22NL-XL6E-4HM3-HQVY-VTP3-4MMQ-RRL3-4NVN-YDOM-L4ZM-3QPW
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MDE7-JTHK-RSGB-22NL-XL6E-4HM3-HQVY-VTP3-4MMQ-RRL3-4NVN-YDOM-L4ZM-3QPW


