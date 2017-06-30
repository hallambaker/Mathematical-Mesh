

#Web Network Application Profile Objects

###Structure: NetworkProfile

* Inherits: ApplicationProfile

Describes the network profile to follow

[None]

###Structure: NetworkProfilePrivate

* Inherits: ApplicationProfilePrivate

Describes the network profile to follow


Sites: String [0..Many]

:DNS name of sites to which profile applies *.example.com matches www.example.com
etc.		

DNS: Connection [0..Many]

:DNS Resolution Services

Prefix: String [0..Many]

:DNS prefixes to search

CTL: Binary (Optional)

:Certificate Trust List giving WebPKI roots to trust

WebPKI: String [0..Many]

:List of UDF fingerprints of keys making up the trust roots
to be accepted for Web PKI purposes.

