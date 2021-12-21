The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> meshman device request alice@example.com
<rsp>   Device UDF = MCM4-ZJWE-RSWW-D6VX-KZDN-J5PU-5GHA
   Witness value = YBUK-6XKN-2E3H-RXPT-SMKO-SF4O-STAS
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> meshman device pending
<rsp>MessageID: YBUK-6XKN-2E3H-RXPT-SMKO-SF4O-STAS
        Connection Request::
        MessageID: YBUK-6XKN-2E3H-RXPT-SMKO-SF4O-STAS
        To:  From: 
        Device:  MCM4-ZJWE-RSWW-D6VX-KZDN-J5PU-5GHA
        Witness: YBUK-6XKN-2E3H-RXPT-SMKO-SF4O-STAS
<cmd>Alice> meshman device accept YBUK-6XKN-2E3H-RXPT-SMKO-SF4O-STAS ^
    /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> meshman device complete
<rsp>   Device UDF = MCM4-ZJWE-RSWW-D6VX-KZDN-J5PU-5GHA
   Account = alice@example.com
   Account UDF = MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
</div>
~~~~


