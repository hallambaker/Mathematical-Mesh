The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EBP5-5TIR-5GDM-VMLF-3XUL-556K-4Q4Q-F6) =
MCIH-QQUH-FFU7-26P3-FUEX-37KY-P5U4-JV47-IW3F-35EO-OCUR-NXIW-PLZW-RVO4
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MCIH-QQUH-FFU7-26P3-FUEX-37KY-P5U4-JV47-IW3F-35EO-OCUR-NXIW-PLZW-RVO4


