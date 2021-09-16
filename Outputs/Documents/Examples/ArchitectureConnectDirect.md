The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MAPJ-QDLN-MD65-34DP-WAQL-UV55-HUPP
   Witness value = AXNN-LBLC-NYQK-PMNE-UFRC-6ANC-DXIS
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: AXNN-LBLC-NYQK-PMNE-UFRC-6ANC-DXIS
        Connection Request::
        MessageID: AXNN-LBLC-NYQK-PMNE-UFRC-6ANC-DXIS
        To:  From: 
        Device:  MAPJ-QDLN-MD65-34DP-WAQL-UV55-HUPP
        Witness: AXNN-LBLC-NYQK-PMNE-UFRC-6ANC-DXIS
<cmd>Alice> device accept AXNN-LBLC-NYQK-PMNE-UFRC-6ANC-DXIS /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MAPJ-QDLN-MD65-34DP-WAQL-UV55-HUPP
   Account = alice@example.com
   Account UDF = MA7Z-J7ZZ-47XH-ULST-GS66-737D-OGXC
</div>
~~~~


