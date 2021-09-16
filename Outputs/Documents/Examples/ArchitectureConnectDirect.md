The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MAF2-7KXX-JCZD-PWUH-NLBP-IWGQ-3E43
   Witness value = 4T6D-MWAA-GS5Q-QLQ6-SZIG-XPHO-54IG
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: 4T6D-MWAA-GS5Q-QLQ6-SZIG-XPHO-54IG
        Connection Request::
        MessageID: 4T6D-MWAA-GS5Q-QLQ6-SZIG-XPHO-54IG
        To:  From: 
        Device:  MAF2-7KXX-JCZD-PWUH-NLBP-IWGQ-3E43
        Witness: 4T6D-MWAA-GS5Q-QLQ6-SZIG-XPHO-54IG
<cmd>Alice> device accept 4T6D-MWAA-GS5Q-QLQ6-SZIG-XPHO-54IG /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MAF2-7KXX-JCZD-PWUH-NLBP-IWGQ-3E43
   Account = alice@example.com
   Account UDF = MALV-QFP7-3VYX-IGEC-O5EN-QI5L-QZLC
</div>
~~~~


