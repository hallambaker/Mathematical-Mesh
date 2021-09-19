The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EA7G-H5VQ-VRTT-FBTV-L5IN-V4QW-ASGX-DJ) =
MCXB-RJIA-DTYP-5LYG-FKOM-JMAO-A5CV-DTJG-EJML-QJ5F-GB37-3KT2-TAMZ-XO7K
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MCXB-RJIA-DTYP-5LYG-FKOM-JMAO-A5CV-DTJG-EJML-QJ5F-GB37-3KT2-TAMZ-XO7K


