The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MAMZ-AVQJ-U5VG-ONAI-7FEK-F7BJ-XYXF
   Witness value = UJ2C-DSDE-NXZM-FATY-RZSL-5CMD-LTGW
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: UJ2C-DSDE-NXZM-FATY-RZSL-5CMD-LTGW
        Connection Request::
        MessageID: UJ2C-DSDE-NXZM-FATY-RZSL-5CMD-LTGW
        To:  From: 
        Device:  MAMZ-AVQJ-U5VG-ONAI-7FEK-F7BJ-XYXF
        Witness: UJ2C-DSDE-NXZM-FATY-RZSL-5CMD-LTGW
<cmd>Alice> device accept UJ2C-DSDE-NXZM-FATY-RZSL-5CMD-LTGW /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MAMZ-AVQJ-U5VG-ONAI-7FEK-F7BJ-XYXF
   Account = alice@example.com
   Account UDF = MAQT-OUN5-5QSY-7ST3-BLD3-XVWV-NEID
</div>
~~~~


