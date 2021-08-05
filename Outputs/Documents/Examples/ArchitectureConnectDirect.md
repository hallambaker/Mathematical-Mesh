The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MCV4-LGJA-J6TI-ZJ4D-SXJW-BOK2-HCZL
   Witness value = BVVL-2ATV-2U2Q-V3AL-HU54-C55J-XZKU
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: BVVL-2ATV-2U2Q-V3AL-HU54-C55J-XZKU
        Connection Request::
        MessageID: BVVL-2ATV-2U2Q-V3AL-HU54-C55J-XZKU
        To:  From: 
        Device:  MCV4-LGJA-J6TI-ZJ4D-SXJW-BOK2-HCZL
        Witness: BVVL-2ATV-2U2Q-V3AL-HU54-C55J-XZKU
<cmd>Alice> device accept BVVL-2ATV-2U2Q-V3AL-HU54-C55J-XZKU /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MCV4-LGJA-J6TI-ZJ4D-SXJW-BOK2-HCZL
   Account = alice@example.com
   Account UDF = MC44-IZC3-IWZT-VCVZ-L2AG-HI4E-LOV2
</div>
~~~~


