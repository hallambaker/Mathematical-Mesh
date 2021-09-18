
### Phase 1

The manufacturer preconfigures the device


~~~~
<div="terminal">
<cmd>Maker> device preconfig
<rsp>Device Profile UDF=
</div>
~~~~

This results in the creation of

>> device config 

[To be installed in the device firmware.]

>> Connection EARL

[To be converted to a QR code and printed on the device]

>> device publication 

[To be published to the service]


### Phase 2 & 3

The administration device scans the QR code and obtains the Device Description using
the Claim operation as shown in section $$$$. The administration device creates the ActivationDevice and CatalogedDevice records
and populates the service as before.


~~~~
<div="terminal">
<cmd>Alice> account connect ^
    mcu://maker@example.com/EC2H-AZKL-3EF7-YHPE-HT7G-HV2D-6U /web
</div>
~~~~

### Phase 4

The device polls the publication service until a claim message is returned.


~~~~
<div="terminal">
<cmd>Alice4> device complete
<rsp>   Device UDF = MCVU-WDTJ-3L4D-RM6N-C5GT-HXWW-OWDI
   Account = alice@example.com
   Account UDF = MBMJ-7X6T-DWE7-6EGQ-2QGZ-RSYR-553Q
</div>
~~~~

>> The poll claim result.

### Phase 5

Completion of the device is the same as before.

