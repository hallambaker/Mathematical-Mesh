The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MD5Q-4FO3-FMYD-YYQU-QBSJ-GWPN-OQWZ
   Witness value = JUZG-5VZE-QWEL-VCTH-2T2G-YDGX-IU6D
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: JUZG-5VZE-QWEL-VCTH-2T2G-YDGX-IU6D
        Connection Request::
        MessageID: JUZG-5VZE-QWEL-VCTH-2T2G-YDGX-IU6D
        To:  From: 
        Device:  MD5Q-4FO3-FMYD-YYQU-QBSJ-GWPN-OQWZ
        Witness: JUZG-5VZE-QWEL-VCTH-2T2G-YDGX-IU6D
<cmd>Alice> device accept JUZG-5VZE-QWEL-VCTH-2T2G-YDGX-IU6D /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MD5Q-4FO3-FMYD-YYQU-QBSJ-GWPN-OQWZ
   Account = alice@example.com
   Account UDF = MCHZ-TWR3-D4HY-EDKL-XI6S-PEWG-TSOJ
</div>
~~~~


