

#Web Network Application Profile Objects

###Structure: NetworkProfile

* Inherits: ApplicationProfile

Describes the network profile to follow

[None]

###Structure: NetworkProfilePrivate

* Inherits: ApplicationProfilePrivate

Describes the network profile to follow


<dl><dt>Sites: 
<dd>String [0..Many]


DNS name of sites to which profile applies *.example.com matches www.example.com
etc.		

<dl><dt>DNS: 
<dd>Connection [0..Many]


DNS Resolution Services

<dl><dt>Prefix: 
<dd>String [0..Many]


DNS prefixes to search

<dl><dt>CTL: 
<dd>Binary (Optional)


Certificate Trust List giving WebPKI roots to trust

<dl><dt>WebPKI: 
<dd>String [0..Many]


List of UDF fingerprints of keys making up the trust roots
to be accepted for Web PKI purposes.

