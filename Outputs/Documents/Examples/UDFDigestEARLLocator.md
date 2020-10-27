The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EDSR-JRYR-UJJ7-2LGL-ATZS-MFMQ-XW7S-5V) =
MA6Q-74IR-XIAM-UL2I-A75V-NVE7-UHM6-OKLB-EMLQ-PBBL-F5O7-67IQ-PUIS-5R2M
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MA6Q-74IR-XIAM-UL2I-A75V-NVE7-UHM6-OKLB-EMLQ-PBBL-F5O7-67IQ-PUIS-5R2M


