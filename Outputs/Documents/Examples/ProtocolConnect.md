
### Phase 1:

There are no first phase actions.

### Phase 2:

Alice enters the connection request on the device to be connected. This specifies the 
address of the account to which she wishes to connect:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MC33-643H-BAE6-7LAN-GMWQ-HKQJ-JHHQ
   Witness value = 6UD6-ZAYD-4IQL-TMBR-MTQC-LVAQ-OPM2
</div>
~~~~


### Phase 3:

The user reviews their pending messages:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: 6UD6-ZAYD-4IQL-TMBR-MTQC-LVAQ-OPM2
        Connection Request::
        MessageID: 6UD6-ZAYD-4IQL-TMBR-MTQC-LVAQ-OPM2
        To:  From: 
        Device:  MC33-643H-BAE6-7LAN-GMWQ-HKQJ-JHHQ
        Witness: 6UD6-ZAYD-4IQL-TMBR-MTQC-LVAQ-OPM2
</div>
~~~~

The administration device receives the AcknowledgeConnection message from the service 
and verifies that the signature is valid and the witness value correctly computed.

The user verifies that the witness value presented in the AcknowledgeConnection message
matches the one presented on the device. Since they match, the request is accepted:


~~~~
<div="terminal">
<cmd>Alice> device accept 6UD6-ZAYD-4IQL-TMBR-MTQC-LVAQ-OPM2 /message /web
</div>
~~~~

### Phase 4

The device completes the connection as before:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MC33-643H-BAE6-7LAN-GMWQ-HKQJ-JHHQ
   Account = alice@example.com
   Account UDF = MC4H-QKW2-VZEE-MMJI-JFF2-FRFU-WYJA
</div>
~~~~

