The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (ED4A-K4VR-MJV7-2HZT-VABB-X7WV-5HJK-CD) =
MBPN-U4H2-XDRQ-3OJ2-NUHH-ERBH-TAYR-6VUP-X535-IJAH-CYCK-ZM74-FEMF-5BBO
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBPN-U4H2-XDRQ-3OJ2-NUHH-ERBH-TAYR-6VUP-X535-IJAH-CYCK-ZM74-FEMF-5BBO


