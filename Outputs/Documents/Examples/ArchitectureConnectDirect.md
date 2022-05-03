The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> meshman device request alice@example.com
<rsp>   Device UDF = MCI6-2IJ3-PFLT-GVUQ-5PN7-B337-VWWQ
   Witness value = CI4K-GV7W-VRTX-QTNB-ZNBG-652H-GMWJ
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> meshman device pending
<rsp>MessageID: CI4K-GV7W-VRTX-QTNB-ZNBG-652H-GMWJ
        Connection Request::
        MessageID: CI4K-GV7W-VRTX-QTNB-ZNBG-652H-GMWJ
        To:  From: 
        Device:  MCI6-2IJ3-PFLT-GVUQ-5PN7-B337-VWWQ
        Witness: CI4K-GV7W-VRTX-QTNB-ZNBG-652H-GMWJ
<cmd>Alice> meshman device accept CI4K-GV7W-VRTX-QTNB-ZNBG-652H-GMWJ ^
    /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> meshman device complete
<rsp>   Device UDF = MCI6-2IJ3-PFLT-GVUQ-5PN7-B337-VWWQ
   Account = alice@example.com
   Account UDF = MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
</div>
~~~~


