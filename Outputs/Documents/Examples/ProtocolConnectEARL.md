
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
    mcu://maker@example.com/ED67-6E3S-GEKS-KYF7-26NQ-WWU4-RQ /web
</div>
~~~~

### Phase 4

The device polls the publication service until a claim message is returned.


~~~~
<div="terminal">
<cmd>Alice4> device complete
<rsp>   Device UDF = MBVV-VUAI-XXNN-ERS5-G4GT-CWRA-BVMF
   Account = alice@example.com
   Account UDF = MA62-NMPL-3OBH-KM2M-LPOO-RUZC-HUH3
</div>
~~~~

>> The poll claim result.

### Phase 5

Completion of the device is the same as before.

