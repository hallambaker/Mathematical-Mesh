The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> meshman device request alice@example.com
<rsp>   Device UDF = MBQD-67IL-PJTR-EYFE-2ZGV-QLZF-QC6W
   Witness value = 5B3I-YIJU-2ACH-J6NE-K5YF-RJDF-PN25
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> meshman device pending
<rsp>MessageID: 5B3I-YIJU-2ACH-J6NE-K5YF-RJDF-PN25
        Connection Request::
        MessageID: 5B3I-YIJU-2ACH-J6NE-K5YF-RJDF-PN25
        To:  From: 
        Device:  MBQD-67IL-PJTR-EYFE-2ZGV-QLZF-QC6W
        Witness: 5B3I-YIJU-2ACH-J6NE-K5YF-RJDF-PN25
<cmd>Alice> meshman device accept 5B3I-YIJU-2ACH-J6NE-K5YF-RJDF-PN25 ^
    /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> meshman device complete
<rsp>   Device UDF = MBQD-67IL-PJTR-EYFE-2ZGV-QLZF-QC6W
   Account = alice@example.com
   Account UDF = MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA
</div>
~~~~


