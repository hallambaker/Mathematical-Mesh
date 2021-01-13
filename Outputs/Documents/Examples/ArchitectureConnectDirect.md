The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MCDZ-IZFY-PWT3-36UP-4L6Q-5QMJ-YWWY
   Witness value = WGAZ-BX2A-7G72-J5U3-SGGT-UB3W-TV4L
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: WGAZ-BX2A-7G72-J5U3-SGGT-UB3W-TV4L
        Connection Request::
        MessageID: WGAZ-BX2A-7G72-J5U3-SGGT-UB3W-TV4L
        To:  From: 
        Device:  MCDZ-IZFY-PWT3-36UP-4L6Q-5QMJ-YWWY
        Witness: WGAZ-BX2A-7G72-J5U3-SGGT-UB3W-TV4L
<cmd>Alice> device accept WGAZ-BX2A-7G72-J5U3-SGGT-UB3W-TV4L /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MCDZ-IZFY-PWT3-36UP-4L6Q-5QMJ-YWWY
   Account = alice@example.com
   Account UDF = MAMU-5QXP-TWCD-7PKI-S4FC-IB76-XASH
</div>
~~~~


