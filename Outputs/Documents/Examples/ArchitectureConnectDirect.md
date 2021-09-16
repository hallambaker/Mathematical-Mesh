The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MDFM-UH3N-NGM3-UKTT-ZFBB-NB74-O55S
   Witness value = T2TX-R4DQ-NXJM-BHLL-SJ6K-5F67-VOZB
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: T2TX-R4DQ-NXJM-BHLL-SJ6K-5F67-VOZB
        Connection Request::
        MessageID: T2TX-R4DQ-NXJM-BHLL-SJ6K-5F67-VOZB
        To:  From: 
        Device:  MDFM-UH3N-NGM3-UKTT-ZFBB-NB74-O55S
        Witness: T2TX-R4DQ-NXJM-BHLL-SJ6K-5F67-VOZB
<cmd>Alice> device accept T2TX-R4DQ-NXJM-BHLL-SJ6K-5F67-VOZB /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MDFM-UH3N-NGM3-UKTT-ZFBB-NB74-O55S
   Account = alice@example.com
   Account UDF = MCK5-26MC-Q726-YY6I-AJJZ-Z2YA-IAIE
</div>
~~~~


