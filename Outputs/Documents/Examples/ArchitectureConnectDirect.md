The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MD6D-L47C-3AOH-O5CI-FEFK-HQXY-PSFX
   Witness value = JE7U-3XLE-JAZF-KEFD-NXU3-R44T-BWX7
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: JE7U-3XLE-JAZF-KEFD-NXU3-R44T-BWX7
        Connection Request::
        MessageID: JE7U-3XLE-JAZF-KEFD-NXU3-R44T-BWX7
        To:  From: 
        Device:  MD6D-L47C-3AOH-O5CI-FEFK-HQXY-PSFX
        Witness: JE7U-3XLE-JAZF-KEFD-NXU3-R44T-BWX7
<cmd>Alice> device accept JE7U-3XLE-JAZF-KEFD-NXU3-R44T-BWX7 /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MD6D-L47C-3AOH-O5CI-FEFK-HQXY-PSFX
   Account = alice@example.com
   Account UDF = MBRN-NNZS-FIXI-NTAZ-YPVO-HKTD-RJ5I
</div>
~~~~


