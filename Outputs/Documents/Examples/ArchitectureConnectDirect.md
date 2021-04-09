The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MDF3-IT6U-NCYJ-RI52-FMTG-OVVJ-FYIW
   Witness value = BJLL-ZGN2-5B3S-G3UE-7QBZ-DKRW-F2RG
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: BJLL-ZGN2-5B3S-G3UE-7QBZ-DKRW-F2RG
        Connection Request::
        MessageID: BJLL-ZGN2-5B3S-G3UE-7QBZ-DKRW-F2RG
        To:  From: 
        Device:  MDF3-IT6U-NCYJ-RI52-FMTG-OVVJ-FYIW
        Witness: BJLL-ZGN2-5B3S-G3UE-7QBZ-DKRW-F2RG
<cmd>Alice> device accept BJLL-ZGN2-5B3S-G3UE-7QBZ-DKRW-F2RG /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MDF3-IT6U-NCYJ-RI52-FMTG-OVVJ-FYIW
   Account = alice@example.com
   Account UDF = MCVL-63JV-H35G-USOR-72YS-YWVV-UHNF
</div>
~~~~


