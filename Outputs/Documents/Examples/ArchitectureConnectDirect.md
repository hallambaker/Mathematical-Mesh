The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MA4M-VAQE-AMR3-OPXI-JIX5-YZQM-UZSF
   Witness value = 3LXA-LK2V-6CV4-EQQM-7D36-SCFN-T2FJ
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts it:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: SHND-CD5R-WRWY-RZH7-KFUS-7ODR-BZU3
        Connection Request::
        MessageID: SHND-CD5R-WRWY-RZH7-KFUS-7ODR-BZU3
        To:  From: 
        Device:  MC2J-FUUG-XWLF-CNWI-DHW3-TQBX-LXND
        Witness: SHND-CD5R-WRWY-RZH7-KFUS-7ODR-BZU3
MessageID: NBF2-RKIJ-G3MT-RCSA-JDCT-UGVT-XYSR
        Confirmation Request::
        MessageID: NBF2-RKIJ-G3MT-RCSA-JDCT-UGVT-XYSR
        To: alice@example.com From: console@example.com
        Text: start
MessageID: ND4E-AZFT-VO2I-T2EM-EMJH-ORID-PX76
        Contact Request::
        MessageID: ND4E-AZFT-VO2I-T2EM-EMJH-ORID-PX76
        To: alice@example.com From: bob@example.com
        PIN: ABJG-3RTO-7KLS-ZEW3-UF64-RPQ3-NS5A
<cmd>Alice> account sync /auto
<cmd>Alice> device accept 3LXA-LK2V-6CV4-EQQM-7D36-SCFN-T2FJ /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
</div>
~~~~


