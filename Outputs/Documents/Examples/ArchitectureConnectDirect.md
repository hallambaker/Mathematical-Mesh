The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> meshman device request alice@example.com
<rsp>   Device UDF = MBQP-MYOA-LTSP-B5GX-A7HP-ZFJ5-4VQ6
   Witness value = IFC5-FUKU-3JVW-JZME-5DP2-XQEX-SV7B
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> meshman device pending
<rsp>MessageID: IFC5-FUKU-3JVW-JZME-5DP2-XQEX-SV7B
        Connection Request::
        MessageID: IFC5-FUKU-3JVW-JZME-5DP2-XQEX-SV7B
        To:  From: 
        Device:  MBQP-MYOA-LTSP-B5GX-A7HP-ZFJ5-4VQ6
        Witness: IFC5-FUKU-3JVW-JZME-5DP2-XQEX-SV7B
<cmd>Alice> meshman device accept IFC5-FUKU-3JVW-JZME-5DP2-XQEX-SV7B ^
    /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> meshman device complete
<rsp>   Device UDF = MBQP-MYOA-LTSP-B5GX-A7HP-ZFJ5-4VQ6
   Account = alice@example.com
   Account UDF = MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
</div>
~~~~


