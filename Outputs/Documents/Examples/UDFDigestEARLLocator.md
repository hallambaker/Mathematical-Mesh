The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EAGB-5GUQ-A7VV-X4M7-5L6V-GAT6-CATI-YA) =
MBZN-RAFJ-GCFE-FATS-Y2UH-2VJQ-RJOJ-KOV4-MKXM-OL52-XATJ-SY3J-3DIS-DYKP
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBZN-RAFJ-GCFE-FATS-Y2UH-2VJQ-RJOJ-KOV4-MKXM-OL52-XATJ-SY3J-3DIS-DYKP


