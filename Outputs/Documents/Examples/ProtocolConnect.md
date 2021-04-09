
### Phase 1:

There are no first phase actions.

### Phase 2:

Alice enters the connection request on the device to be connected. This specifies the 
address of the account to which she wishes to connect:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MDF3-IT6U-NCYJ-RI52-FMTG-OVVJ-FYIW
   Witness value = BJLL-ZGN2-5B3S-G3UE-7QBZ-DKRW-F2RG
</div>
~~~~


### Phase 3:

The user reviews their pending messages:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: BJLL-ZGN2-5B3S-G3UE-7QBZ-DKRW-F2RG
        Connection Request::
        MessageID: BJLL-ZGN2-5B3S-G3UE-7QBZ-DKRW-F2RG
        To:  From: 
        Device:  MDF3-IT6U-NCYJ-RI52-FMTG-OVVJ-FYIW
        Witness: BJLL-ZGN2-5B3S-G3UE-7QBZ-DKRW-F2RG
</div>
~~~~

The administration device receives the AcknowledgeConnection message from the service 
and verifies that the signature is valid and the witness value correctly computed.

The user verifies that the witness value presented in the AcknowledgeConnection message
matches the one presented on the device. Since they match, the request is accepted:


~~~~
<div="terminal">
<cmd>Alice> device accept BJLL-ZGN2-5B3S-G3UE-7QBZ-DKRW-F2RG /message /web
</div>
~~~~

### Phase 4

The device completes the connection as before:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MDF3-IT6U-NCYJ-RI52-FMTG-OVVJ-FYIW
   Account = alice@example.com
   Account UDF = MCVL-63JV-H35G-USOR-72YS-YWVV-UHNF
</div>
~~~~

