The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> meshman device request alice@example.com
<rsp>   Device UDF = MC3X-2ZSG-VJDZ-2ZOT-RZQ6-FWP2-JWRI
   Witness value = NGPT-BMAK-4IGV-OXYV-257N-UGHC-THED
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> meshman device pending
<rsp>MessageID: NGPT-BMAK-4IGV-OXYV-257N-UGHC-THED
        Connection Request::
        MessageID: NGPT-BMAK-4IGV-OXYV-257N-UGHC-THED
        To:  From: 
        Device:  MC3X-2ZSG-VJDZ-2ZOT-RZQ6-FWP2-JWRI
        Witness: NGPT-BMAK-4IGV-OXYV-257N-UGHC-THED
<cmd>Alice> meshman device accept NGPT-BMAK-4IGV-OXYV-257N-UGHC-THED ^
    /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> meshman device complete
<rsp>   Device UDF = MC3X-2ZSG-VJDZ-2ZOT-RZQ6-FWP2-JWRI
   Account = alice@example.com
   Account UDF = MDMG-5KJT-SFQQ-EE3U-GZAK-CEGV-5GR2
</div>
~~~~


