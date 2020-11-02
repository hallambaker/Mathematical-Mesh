The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EASL-RRMJ-B5PI-MEGY-WNRC-GNLG-CZKQ-LA) =
MA4B-7WVY-6F2T-IZSF-46ZF-T3HE-OIL5-Q25M-DCTA-NZ6Z-M37N-GM7U-2ICT-O4JP
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MA4B-7WVY-6F2T-IZSF-46ZF-T3HE-OIL5-Q25M-DCTA-NZ6Z-M37N-GM7U-2ICT-O4JP


