
Alice connects a watch to her account. Since the watch has a camera (to allow for 
video calls) she can use the dynamic QR code connection mechanism.

The watch reads the QR code generated on Alice's watch. This contains
the device connection URI.

~~~~
QR = {Connect.ConnectQRURI}
~~~~

The URI tells the device the Mesh account to connect to and the PIN Code to be
used to authenticate the request. The device requesting the connection adds its
Profile device to create a RequestConnection message that will be presented to
the service as a Connect transaction request.


~~~~
Missing example 21
~~~~

The service generates an AcknowledgeConnection message which is returned to the
device requesting the connection (via the Connect transaction response) and
adds it to the inbound spool of the account for Alice's approval (or not).


~~~~
Missing example 22
~~~~

Alice's administration device synchronizes to the service and receives the
connection request acknowledgement from the service. Since the request is 
authenticated by a PIN code that has been marked for automatic execution, the
service can generate the assertions the device to participate in the account
and appends the corresponding RespondConnection message to the local delivery 
spool.


~~~~
Missing example 23
~~~~


