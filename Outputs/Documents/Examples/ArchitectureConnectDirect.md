The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MDWJ-NKCM-Z2RV-6IFX-53V6-FZBZ-JQGP
   Witness value = F2SX-YPEF-MTTJ-ETZO-JLVN-76Z4-ZWRF
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: F2SX-YPEF-MTTJ-ETZO-JLVN-76Z4-ZWRF
        Connection Request::
        MessageID: F2SX-YPEF-MTTJ-ETZO-JLVN-76Z4-ZWRF
        To:  From: 
        Device:  MDWJ-NKCM-Z2RV-6IFX-53V6-FZBZ-JQGP
        Witness: F2SX-YPEF-MTTJ-ETZO-JLVN-76Z4-ZWRF
<cmd>Alice> device accept F2SX-YPEF-MTTJ-ETZO-JLVN-76Z4-ZWRF /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MDWJ-NKCM-Z2RV-6IFX-53V6-FZBZ-JQGP
   Account = alice@example.com
   Account UDF = MCST-2JUP-UNOG-O4A3-Q6KS-O2V5-HSQL
</div>
~~~~


