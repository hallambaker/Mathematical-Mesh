The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MAHU-SPG5-UC6W-LP2E-WUZY-PVB4-TEDI
   Witness value = VSJT-A2SA-K6GN-ZITJ-MZC2-5BZJ-YCQO
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: VSJT-A2SA-K6GN-ZITJ-MZC2-5BZJ-YCQO
        Connection Request::
        MessageID: VSJT-A2SA-K6GN-ZITJ-MZC2-5BZJ-YCQO
        To:  From: 
        Device:  MAHU-SPG5-UC6W-LP2E-WUZY-PVB4-TEDI
        Witness: VSJT-A2SA-K6GN-ZITJ-MZC2-5BZJ-YCQO
<cmd>Alice> device accept VSJT-A2SA-K6GN-ZITJ-MZC2-5BZJ-YCQO /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MAHU-SPG5-UC6W-LP2E-WUZY-PVB4-TEDI
   Account = alice@example.com
   Account UDF = MDT2-CV27-KXQC-UNRX-NUEQ-USYA-UYN4
</div>
~~~~


