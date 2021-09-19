The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MDWS-IM2S-B74G-PP6P-ACOD-LIIX-CIZV
   Witness value = G5QR-44FP-S2PL-LFDL-T52T-LLJ7-YFYG
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: G5QR-44FP-S2PL-LFDL-T52T-LLJ7-YFYG
        Connection Request::
        MessageID: G5QR-44FP-S2PL-LFDL-T52T-LLJ7-YFYG
        To:  From: 
        Device:  MDWS-IM2S-B74G-PP6P-ACOD-LIIX-CIZV
        Witness: G5QR-44FP-S2PL-LFDL-T52T-LLJ7-YFYG
<cmd>Alice> device accept G5QR-44FP-S2PL-LFDL-T52T-LLJ7-YFYG /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MDWS-IM2S-B74G-PP6P-ACOD-LIIX-CIZV
   Account = alice@example.com
   Account UDF = MA62-NMPL-3OBH-KM2M-LPOO-RUZC-HUH3
</div>
~~~~


