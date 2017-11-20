=Goedel.Protocol

Contains a set of classes for

* Reading and writing JSON data objects in various encodings
* Binding JSON interactions to Web Services.
* Base classes for JSON objects and services.

At present the functionality required to implement a Web Service using ProtoGen
is divided between Goedel.Protocol which contains the portable part and 
Goedel.Protocol.Extended which makes use of features only supported in 
.NET framework and Mono.

All objects created by ProtoGen are subclasses of JSONObject. This contains
base methods for JSON encoding and decoding.

In future, these should be static methods on the encoders that take a 
JSONObject and produce the corresponding encoder or vice versa.

