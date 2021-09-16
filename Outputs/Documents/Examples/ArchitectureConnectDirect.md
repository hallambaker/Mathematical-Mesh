The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MC2E-CN5B-VD4E-WYKC-PRQJ-GYP7-3HJS
   Witness value = IGJR-LEIQ-QPS2-OOJJ-G3XS-VMD6-ZLWW
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: IGJR-LEIQ-QPS2-OOJJ-G3XS-VMD6-ZLWW
        Connection Request::
        MessageID: IGJR-LEIQ-QPS2-OOJJ-G3XS-VMD6-ZLWW
        To:  From: 
        Device:  MC2E-CN5B-VD4E-WYKC-PRQJ-GYP7-3HJS
        Witness: IGJR-LEIQ-QPS2-OOJJ-G3XS-VMD6-ZLWW
<cmd>Alice> device accept IGJR-LEIQ-QPS2-OOJJ-G3XS-VMD6-ZLWW /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MC2E-CN5B-VD4E-WYKC-PRQJ-GYP7-3HJS
   Account = alice@example.com
   Account UDF = MCWD-QCM6-5QUW-4NWK-J4T4-VOMT-6WF3
</div>
~~~~


