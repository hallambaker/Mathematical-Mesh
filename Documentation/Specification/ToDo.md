#To Do - Mathematical Mesh

##Documents

###RFCTool glitches

<ul>
<li>No captions on tables
<li>No support for cross references
<li>The MUST SHOULD, etc. markup is not happening
<li>Missing uris for some RFCs in references. URIs are not hypertexted.
<li>Make zipped files
<li>Sort references
<li>Write out comments / todo to a log file
</ul>

###Protogen glitches


Need to update to fix format issues


###hallambaker-json-web-service

Need to provide examples for use of authentication and encryption using mesh profile
keys.

###draft-hallambaker-udf


The examples need to be generated from running code using the udf library.



##Code

###Key Exchange Service

New service to provide 'first contact' services. These include key exchange and protocol
version, encoding, etc. negotiation.

This needs to be closely related to the SRV discovery scheme. Basically the SRV scheme is
for unauthanticated requests - anyone can see the policy. This is for cases where the
policy itself is protected.

###UDF Library

Need a proper test library including support for comparing UDFs for sufficiency
(i.e. if one is a prefix), use of the compressed modes, etc.

Examples using SHA3

###Crypto Library

Implement SHA3 properly and test.


