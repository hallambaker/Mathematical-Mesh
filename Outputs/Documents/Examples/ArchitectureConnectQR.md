To use the device QR code connection mechanism, we require a Web service that will host
the connection document example.com and a MeshService account that the device will attempt to 
complete the connection by requesting synchronization devices@example.com.

To begin the process we generate a new random key and combine it with the service
to create an EARL:

~~~~
udf://example.com/ECIM-PY67-TQ7Q-G6HT-OU5Y-B4GE-7SP3-W6
~~~~

Next a device profile is created and preregistered on with the Mesh Service that will
provide the hailing service. Since we are only preparing one device it is convenient to
do this on the device itself. In a manufacturing scenario, these steps would typically 
be performed offline in bulk.


~~~~
<div="terminal">
<cmd>Alice4> device pre devices@example.com /key=udf://example.com/ECIM-PY67-TQ7Q-G6HT-OU5Y-B4GE-7SP3-W6
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

Once initialized the device attempts to poll the service for a connection each time it
is powered on, when a connection button affordance on the device is pressed or at
other times as agreed with the Mesh Service Provider:


~~~~
<div="terminal">
<cmd>Alice4> account sync
<rsp>ERROR - Unspecified error
</div>
~~~~

To connect the device to her profile, Alice scans the device with her administration 
device to obtain the UDF. The administration device retrieves the connection description, 
decrypts it and then uses the information in the description to create the necessary
Device Connection Assertion and connect to the device hailing Mesh Service Account to 
complete the process:


~~~~
<div="terminal">
<cmd>Alice> device earl udf://example.com/ECIM-PY67-TQ7Q-G6HT-OU5Y-B4GE-7SP3-W6
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

When the device next attempts to connect to the hailing service, it receives the Device 
Connection Assertion:


~~~~
<div="terminal">
<cmd>Alice4> account sync
<rsp>ERROR - Unspecified error
</div>
~~~~
