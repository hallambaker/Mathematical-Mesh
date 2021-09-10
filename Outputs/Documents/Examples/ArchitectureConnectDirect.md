The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MC33-643H-BAE6-7LAN-GMWQ-HKQJ-JHHQ
   Witness value = 6UD6-ZAYD-4IQL-TMBR-MTQC-LVAQ-OPM2
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: 6UD6-ZAYD-4IQL-TMBR-MTQC-LVAQ-OPM2
        Connection Request::
        MessageID: 6UD6-ZAYD-4IQL-TMBR-MTQC-LVAQ-OPM2
        To:  From: 
        Device:  MC33-643H-BAE6-7LAN-GMWQ-HKQJ-JHHQ
        Witness: 6UD6-ZAYD-4IQL-TMBR-MTQC-LVAQ-OPM2
<cmd>Alice> device accept 6UD6-ZAYD-4IQL-TMBR-MTQC-LVAQ-OPM2 /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MC33-643H-BAE6-7LAN-GMWQ-HKQJ-JHHQ
   Account = alice@example.com
   Account UDF = MC4H-QKW2-VZEE-MMJI-JFF2-FRFU-WYJA
</div>
~~~~


