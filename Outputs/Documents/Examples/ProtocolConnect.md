
### Phase 1:

There are no first phase actions.

### Phase 2:

Alice enters the connection request on the device to be connected. This specifies the 
address of the account to which she wishes to connect:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MD4F-HN4M-3GWS-F7U7-QSVM-S4HI-3E22
   Witness value = CDE3-EATC-6CNU-WJFU-44HI-464J-XSSS
</div>
~~~~


### Phase 3:

The user reviews their pending messages:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: CDE3-EATC-6CNU-WJFU-44HI-464J-XSSS
        Connection Request::
        MessageID: CDE3-EATC-6CNU-WJFU-44HI-464J-XSSS
        To:  From: 
        Device:  MD4F-HN4M-3GWS-F7U7-QSVM-S4HI-3E22
        Witness: CDE3-EATC-6CNU-WJFU-44HI-464J-XSSS
</div>
~~~~

The administration device receives the AcknowledgeConnection message from the service 
and verifies that the signature is valid and the witness value correctly computed.

The user verifies that the witness value presented in the AcknowledgeConnection message
matches the one presented on the device. Since they match, the request is accepted:


~~~~
<div="terminal">
<cmd>Alice> device accept CDE3-EATC-6CNU-WJFU-44HI-464J-XSSS /message /web
</div>
~~~~

### Phase 4

The device completes the connection as before:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MD4F-HN4M-3GWS-F7U7-QSVM-S4HI-3E22
   Account = alice@example.com
   Account UDF = MBY6-FNTT-WQ5K-KXN4-OCCK-XXHF-DU3O
</div>
~~~~

