The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> meshman device request alice@example.com
<rsp>   Device UDF = MDBW-UTZZ-TUAC-H23Y-SYYS-YKX7-42OC
   Witness value = U6JZ-FWCE-KQVQ-JN7P-KU5W-VWRC-WCWI
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> meshman device pending
<rsp>MessageID: U6JZ-FWCE-KQVQ-JN7P-KU5W-VWRC-WCWI
        Connection Request::
        MessageID: U6JZ-FWCE-KQVQ-JN7P-KU5W-VWRC-WCWI
        To:  From: 
        Device:  MDBW-UTZZ-TUAC-H23Y-SYYS-YKX7-42OC
        Witness: U6JZ-FWCE-KQVQ-JN7P-KU5W-VWRC-WCWI
<cmd>Alice> meshman device accept U6JZ-FWCE-KQVQ-JN7P-KU5W-VWRC-WCWI ^
    /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> meshman device complete
<rsp>   Device UDF = MDBW-UTZZ-TUAC-H23Y-SYYS-YKX7-42OC
   Account = alice@example.com
   Account UDF = MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT
</div>
~~~~


