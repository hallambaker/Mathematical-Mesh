The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> meshman device request alice@example.com
<rsp>   Device UDF = MBL2-EMUT-CLYH-Q2QK-3FQQ-PXWO-UJN6
   Witness value = FCG4-72L5-Z7Z5-ABWZ-HS7N-TG27-W4WU
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> meshman device pending
<rsp>MessageID: FCG4-72L5-Z7Z5-ABWZ-HS7N-TG27-W4WU
        Connection Request::
        MessageID: FCG4-72L5-Z7Z5-ABWZ-HS7N-TG27-W4WU
        To:  From: 
        Device:  MBL2-EMUT-CLYH-Q2QK-3FQQ-PXWO-UJN6
        Witness: FCG4-72L5-Z7Z5-ABWZ-HS7N-TG27-W4WU
<cmd>Alice> meshman device accept FCG4-72L5-Z7Z5-ABWZ-HS7N-TG27-W4WU ^
    /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> meshman device complete
<rsp>   Device UDF = MBL2-EMUT-CLYH-Q2QK-3FQQ-PXWO-UJN6
   Account = alice@example.com
   Account UDF = MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
</div>
~~~~


