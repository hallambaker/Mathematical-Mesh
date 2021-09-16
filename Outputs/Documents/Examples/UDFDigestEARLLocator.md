The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EDGQ-W7GZ-IVWD-CEO3-C6N6-WF2F-IELH-HK) =
MCQA-NOCP-EZQC-WRH3-NK2I-VUOO-2YHI-BE36-DWPX-U6XZ-G3AU-WS76-L5HG-3SET
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MCQA-NOCP-EZQC-WRH3-NK2I-VUOO-2YHI-BE36-DWPX-U6XZ-G3AU-WS76-L5HG-3SET


