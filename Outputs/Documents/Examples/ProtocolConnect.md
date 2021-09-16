
### Phase 1:

There are no first phase actions.

### Phase 2:

Alice enters the connection request on the device to be connected. This specifies the 
address of the account to which she wishes to connect:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MAUW-AFDM-RNWF-JWYN-R2PU-HFJT-QDYH
   Witness value = VQ5Q-M6MA-WNIW-VYXW-Y7HO-EKKR-CIVK
</div>
~~~~


### Phase 3:

The user reviews their pending messages:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: VQ5Q-M6MA-WNIW-VYXW-Y7HO-EKKR-CIVK
        Connection Request::
        MessageID: VQ5Q-M6MA-WNIW-VYXW-Y7HO-EKKR-CIVK
        To:  From: 
        Device:  MAUW-AFDM-RNWF-JWYN-R2PU-HFJT-QDYH
        Witness: VQ5Q-M6MA-WNIW-VYXW-Y7HO-EKKR-CIVK
</div>
~~~~

The administration device receives the AcknowledgeConnection message from the service 
and verifies that the signature is valid and the witness value correctly computed.

The user verifies that the witness value presented in the AcknowledgeConnection message
matches the one presented on the device. Since they match, the request is accepted:


~~~~
<div="terminal">
<cmd>Alice> device accept VQ5Q-M6MA-WNIW-VYXW-Y7HO-EKKR-CIVK /message /web
</div>
~~~~

### Phase 4

The device completes the connection as before:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MAUW-AFDM-RNWF-JWYN-R2PU-HFJT-QDYH
   Account = alice@example.com
   Account UDF = MDMM-67AC-QTZJ-THVJ-XHCR-EO6U-QBHU
</div>
~~~~

