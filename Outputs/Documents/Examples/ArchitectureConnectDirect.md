The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MAUW-AFDM-RNWF-JWYN-R2PU-HFJT-QDYH
   Witness value = VQ5Q-M6MA-WNIW-VYXW-Y7HO-EKKR-CIVK
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: VQ5Q-M6MA-WNIW-VYXW-Y7HO-EKKR-CIVK
        Connection Request::
        MessageID: VQ5Q-M6MA-WNIW-VYXW-Y7HO-EKKR-CIVK
        To:  From: 
        Device:  MAUW-AFDM-RNWF-JWYN-R2PU-HFJT-QDYH
        Witness: VQ5Q-M6MA-WNIW-VYXW-Y7HO-EKKR-CIVK
<cmd>Alice> device accept VQ5Q-M6MA-WNIW-VYXW-Y7HO-EKKR-CIVK /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MAUW-AFDM-RNWF-JWYN-R2PU-HFJT-QDYH
   Account = alice@example.com
   Account UDF = MDMM-67AC-QTZJ-THVJ-XHCR-EO6U-QBHU
</div>
~~~~


