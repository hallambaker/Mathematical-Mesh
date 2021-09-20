The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MDQ4-QILF-7NND-WB5K-4UPU-QDN6-NDRU
   Witness value = HFAR-Y5J4-ZK7C-XZAG-ECVL-WRZJ-34IK
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: HFAR-Y5J4-ZK7C-XZAG-ECVL-WRZJ-34IK
        Connection Request::
        MessageID: HFAR-Y5J4-ZK7C-XZAG-ECVL-WRZJ-34IK
        To:  From: 
        Device:  MDQ4-QILF-7NND-WB5K-4UPU-QDN6-NDRU
        Witness: HFAR-Y5J4-ZK7C-XZAG-ECVL-WRZJ-34IK
<cmd>Alice> device accept HFAR-Y5J4-ZK7C-XZAG-ECVL-WRZJ-34IK /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MDQ4-QILF-7NND-WB5K-4UPU-QDN6-NDRU
   Account = alice@example.com
   Account UDF = MC6L-GFYJ-7EOP-2OWN-24ZJ-4RC7-EXTW
</div>
~~~~


