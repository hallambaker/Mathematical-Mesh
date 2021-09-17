
### Phase 1:

There are no first phase actions.

### Phase 2:

Alice enters the connection request on the device to be connected. This specifies the 
address of the account to which she wishes to connect:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MCZJ-BSTU-OIMP-SRF3-WNGV-4JIV-56ZM
   Witness value = CGQR-COKS-K4UR-EPYB-2CBI-MB6Z-UQ4B
</div>
~~~~


### Phase 3:

The user reviews their pending messages:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: CGQR-COKS-K4UR-EPYB-2CBI-MB6Z-UQ4B
        Connection Request::
        MessageID: CGQR-COKS-K4UR-EPYB-2CBI-MB6Z-UQ4B
        To:  From: 
        Device:  MCZJ-BSTU-OIMP-SRF3-WNGV-4JIV-56ZM
        Witness: CGQR-COKS-K4UR-EPYB-2CBI-MB6Z-UQ4B
</div>
~~~~

The administration device receives the AcknowledgeConnection message from the service 
and verifies that the signature is valid and the witness value correctly computed.

The user verifies that the witness value presented in the AcknowledgeConnection message
matches the one presented on the device. Since they match, the request is accepted:


~~~~
<div="terminal">
<cmd>Alice> device accept CGQR-COKS-K4UR-EPYB-2CBI-MB6Z-UQ4B /message /web
</div>
~~~~

### Phase 4

The device completes the connection as before:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MCZJ-BSTU-OIMP-SRF3-WNGV-4JIV-56ZM
   Account = alice@example.com
   Account UDF = MC76-AK7P-CEKP-ILKC-MEXU-EOIF-I6BF
</div>
~~~~

