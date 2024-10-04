The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> meshman device request alice@example.com
<rsp>   Device UDF = MBQB-RX7H-5QIR-V7MS-AN4W-JW7A-UXYV
   Witness value = L6YU-SEXF-YXRF-FVKG-EL2H-VJE4-LX7D
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> meshman device pending
<rsp>MessageID: L6YU-SEXF-YXRF-FVKG-EL2H-VJE4-LX7D
        Connection Request::
        MessageID: L6YU-SEXF-YXRF-FVKG-EL2H-VJE4-LX7D
        To:  From: 
        Device:  MBQB-RX7H-5QIR-V7MS-AN4W-JW7A-UXYV
        Witness: L6YU-SEXF-YXRF-FVKG-EL2H-VJE4-LX7D
<cmd>Alice> meshman device accept L6YU-SEXF-YXRF-FVKG-EL2H-VJE4-LX7D ^
    /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> meshman device complete
<rsp>   Device UDF = MBQB-RX7H-5QIR-V7MS-AN4W-JW7A-UXYV
   Account = alice@example.com
   Account UDF = MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
</div>
~~~~


