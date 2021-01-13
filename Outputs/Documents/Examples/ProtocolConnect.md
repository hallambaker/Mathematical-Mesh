
### Phase 1:

There are no first phase actions.

### Phase 2:

Alice enters the connection request on the device to be connected. This specifies the 
address of the account to which she wishes to connect:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MCDZ-IZFY-PWT3-36UP-4L6Q-5QMJ-YWWY
   Witness value = WGAZ-BX2A-7G72-J5U3-SGGT-UB3W-TV4L
</div>
~~~~


### Phase 3:

The user reviews their pending messages:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: WGAZ-BX2A-7G72-J5U3-SGGT-UB3W-TV4L
        Connection Request::
        MessageID: WGAZ-BX2A-7G72-J5U3-SGGT-UB3W-TV4L
        To:  From: 
        Device:  MCDZ-IZFY-PWT3-36UP-4L6Q-5QMJ-YWWY
        Witness: WGAZ-BX2A-7G72-J5U3-SGGT-UB3W-TV4L
</div>
~~~~

The administration device receives the AcknowledgeConnection message from the service 
and verifies that the signature is valid and the witness value correctly computed.

The user verifies that the witness value presented in the AcknowledgeConnection message
matches the one presented on the device. Since they match, the request is accepted:


~~~~
<div="terminal">
<cmd>Alice> device accept WGAZ-BX2A-7G72-J5U3-SGGT-UB3W-TV4L /message /web
</div>
~~~~

### Phase 4

The device completes the connection as before:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MCDZ-IZFY-PWT3-36UP-4L6Q-5QMJ-YWWY
   Account = alice@example.com
   Account UDF = MAMU-5QXP-TWCD-7PKI-S4FC-IB76-XASH
</div>
~~~~

