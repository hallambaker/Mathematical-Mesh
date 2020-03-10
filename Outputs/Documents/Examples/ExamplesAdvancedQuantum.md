##Example: Creating a Quantum Resistant Signature Fingerprint

Alice decides to add a QRSF to her Mesh Profile. She creates
a 256 bit master secret.

~~~~
TBS: 
~~~~

To enable recovery of the master key, Alice creates five keyshares with a quorum of three:

~~~~
TBS: 
~~~~

Alice uses the master secret to derrive her private key values:

~~~~
TBS: 
~~~~

These values are used to generate the public key value:

~~~~
TBS: 
~~~~

The QRSF contains the UDF fingerprint of the public key
value plus the XMSS parameters:

~~~~
TBS: 
~~~~

Alice adds the QRSF to her profile and publishes it to a Mesh Service that is enrolled
in at least one multi-party notary scheme.


