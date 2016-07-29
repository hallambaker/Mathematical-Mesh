

#Protocol Overview

Here we put a description of the basic protocol 

##Connection Establishment

This part of the specification should be separated into a generic 
building block for reuse in other protocols.

The service discovery mechanism described in 
[!draft-hallambaker-json-web-service-02] is used.

The Hello transaction MAY be used to determine specific 
features of the particular Web Service.

The client request is:

~~~~

~~~~
POST /.well-known/meshrecrypt/HTTP/1.1
Host: example.com
Content-Length: 23

{
  "HelloRequest": {}}
~~~~

~~~~

The service responds with a description of the service. This 
description MUST specify at least one supported protocol
version.

A typical client response is:

~~~~

~~~~
HTTP/1.1 200 OK
Date: Wed 27 Jul 2016 05:53:27
Content-Length: 219

{
  "HelloResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully",
    "Version": {
      "Major": 0,
      "Minor": 7,
      "Encodings": [{
          "ID": ["application/json"]}]}}}
~~~~

~~~~

All versions of the protocol SHALL support the Hello transaction.
A service MUST support the use of JSON encoding for the 
Hello transaction regardless of version. 

The set of encodings supportted by a protocol version is 
specified in the Encodings field. The encodings field MAY 
be omitted if only JSON is supported.

A service SHOULD support at least one protocol version with 
JSON encoding.


[Note that for the sake of concise presentation, the HTTP binding
information is omitted from future examples.]


