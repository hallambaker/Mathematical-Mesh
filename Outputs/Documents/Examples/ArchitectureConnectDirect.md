The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MB5B-C5VN-3YU5-5ZX2-LP4M-MC7A-PWEG
   Witness value = J4OI-Z6UT-BUY5-MYOS-QBJU-QGMB-IGBO
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: J4OI-Z6UT-BUY5-MYOS-QBJU-QGMB-IGBO
        Connection Request::
        MessageID: J4OI-Z6UT-BUY5-MYOS-QBJU-QGMB-IGBO
        To:  From: 
        Device:  MB5B-C5VN-3YU5-5ZX2-LP4M-MC7A-PWEG
        Witness: J4OI-Z6UT-BUY5-MYOS-QBJU-QGMB-IGBO
<cmd>Alice> device accept J4OI-Z6UT-BUY5-MYOS-QBJU-QGMB-IGBO /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MB5B-C5VN-3YU5-5ZX2-LP4M-MC7A-PWEG
   Account = alice@example.com
   Account UDF = MD7M-NMJY-4SVX-PMOD-T6FN-2LTV-DUEL
</div>
~~~~


