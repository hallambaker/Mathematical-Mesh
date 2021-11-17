The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MB33-ROBH-6WWL-J3IZ-N76K-FUMY-HLHD
   Witness value = YOTP-W6OL-JBGR-V4IN-GFC2-KSKL-E35X
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: YOTP-W6OL-JBGR-V4IN-GFC2-KSKL-E35X
        Connection Request::
        MessageID: YOTP-W6OL-JBGR-V4IN-GFC2-KSKL-E35X
        To:  From: 
        Device:  MB33-ROBH-6WWL-J3IZ-N76K-FUMY-HLHD
        Witness: YOTP-W6OL-JBGR-V4IN-GFC2-KSKL-E35X
<cmd>Alice> device accept YOTP-W6OL-JBGR-V4IN-GFC2-KSKL-E35X /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MB33-ROBH-6WWL-J3IZ-N76K-FUMY-HLHD
   Account = alice@example.com
   Account UDF = MB5I-R24M-QXJT-KDBF-XFOA-DGC3-U3AA
</div>
~~~~


