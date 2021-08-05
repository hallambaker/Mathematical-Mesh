
### Phase 1:

There are no first phase actions.

### Phase 2:

Alice enters the connection request on the device to be connected. This specifies the 
address of the account to which she wishes to connect:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MCV4-LGJA-J6TI-ZJ4D-SXJW-BOK2-HCZL
   Witness value = BVVL-2ATV-2U2Q-V3AL-HU54-C55J-XZKU
</div>
~~~~


### Phase 3:

The user reviews their pending messages:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: BVVL-2ATV-2U2Q-V3AL-HU54-C55J-XZKU
        Connection Request::
        MessageID: BVVL-2ATV-2U2Q-V3AL-HU54-C55J-XZKU
        To:  From: 
        Device:  MCV4-LGJA-J6TI-ZJ4D-SXJW-BOK2-HCZL
        Witness: BVVL-2ATV-2U2Q-V3AL-HU54-C55J-XZKU
</div>
~~~~

The administration device receives the AcknowledgeConnection message from the service 
and verifies that the signature is valid and the witness value correctly computed.

The user verifies that the witness value presented in the AcknowledgeConnection message
matches the one presented on the device. Since they match, the request is accepted:


~~~~
<div="terminal">
<cmd>Alice> device accept BVVL-2ATV-2U2Q-V3AL-HU54-C55J-XZKU /message /web
</div>
~~~~

### Phase 4

The device completes the connection as before:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MCV4-LGJA-J6TI-ZJ4D-SXJW-BOK2-HCZL
   Account = alice@example.com
   Account UDF = MC44-IZC3-IWZT-VCVZ-L2AG-HI4E-LOV2
</div>
~~~~

