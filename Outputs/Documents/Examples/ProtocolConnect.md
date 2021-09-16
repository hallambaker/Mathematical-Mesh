
### Phase 1:

There are no first phase actions.

### Phase 2:

Alice enters the connection request on the device to be connected. This specifies the 
address of the account to which she wishes to connect:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MDFM-UH3N-NGM3-UKTT-ZFBB-NB74-O55S
   Witness value = T2TX-R4DQ-NXJM-BHLL-SJ6K-5F67-VOZB
</div>
~~~~


### Phase 3:

The user reviews their pending messages:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: T2TX-R4DQ-NXJM-BHLL-SJ6K-5F67-VOZB
        Connection Request::
        MessageID: T2TX-R4DQ-NXJM-BHLL-SJ6K-5F67-VOZB
        To:  From: 
        Device:  MDFM-UH3N-NGM3-UKTT-ZFBB-NB74-O55S
        Witness: T2TX-R4DQ-NXJM-BHLL-SJ6K-5F67-VOZB
</div>
~~~~

The administration device receives the AcknowledgeConnection message from the service 
and verifies that the signature is valid and the witness value correctly computed.

The user verifies that the witness value presented in the AcknowledgeConnection message
matches the one presented on the device. Since they match, the request is accepted:


~~~~
<div="terminal">
<cmd>Alice> device accept T2TX-R4DQ-NXJM-BHLL-SJ6K-5F67-VOZB /message /web
</div>
~~~~

### Phase 4

The device completes the connection as before:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MDFM-UH3N-NGM3-UKTT-ZFBB-NB74-O55S
   Account = alice@example.com
   Account UDF = MCK5-26MC-Q726-YY6I-AJJZ-Z2YA-IAIE
</div>
~~~~

