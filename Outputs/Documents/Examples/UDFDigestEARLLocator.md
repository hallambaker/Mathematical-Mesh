The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EBDN-46FJ-L26P-PNHS-OLMJ-HQ6O-4AJ2-3O) =
MASA-DX3E-GWQK-44RP-AUKL-L7NF-LTQ7-NVAR-FQNJ-DCQA-3267-OQMX-LHDJ-KEAJ
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MASA-DX3E-GWQK-44RP-AUKL-L7NF-LTQ7-NVAR-FQNJ-DCQA-3267-OQMX-LHDJ-KEAJ


