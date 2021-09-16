
### Phase 1:

There are no first phase actions.

### Phase 2:

Alice enters the connection request on the device to be connected. This specifies the 
address of the account to which she wishes to connect:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MC2E-CN5B-VD4E-WYKC-PRQJ-GYP7-3HJS
   Witness value = IGJR-LEIQ-QPS2-OOJJ-G3XS-VMD6-ZLWW
</div>
~~~~


### Phase 3:

The user reviews their pending messages:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: IGJR-LEIQ-QPS2-OOJJ-G3XS-VMD6-ZLWW
        Connection Request::
        MessageID: IGJR-LEIQ-QPS2-OOJJ-G3XS-VMD6-ZLWW
        To:  From: 
        Device:  MC2E-CN5B-VD4E-WYKC-PRQJ-GYP7-3HJS
        Witness: IGJR-LEIQ-QPS2-OOJJ-G3XS-VMD6-ZLWW
</div>
~~~~

The administration device receives the AcknowledgeConnection message from the service 
and verifies that the signature is valid and the witness value correctly computed.

The user verifies that the witness value presented in the AcknowledgeConnection message
matches the one presented on the device. Since they match, the request is accepted:


~~~~
<div="terminal">
<cmd>Alice> device accept IGJR-LEIQ-QPS2-OOJJ-G3XS-VMD6-ZLWW /message /web
</div>
~~~~

### Phase 4

The device completes the connection as before:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MC2E-CN5B-VD4E-WYKC-PRQJ-GYP7-3HJS
   Account = alice@example.com
   Account UDF = MCWD-QCM6-5QUW-4NWK-J4T4-VOMT-6WF3
</div>
~~~~

