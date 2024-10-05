The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> meshman device request alice@example.com
<rsp>   Device UDF = MBQC-IDY4-CZUY-G67R-2TLC-2C5Z-DQRB
   Witness value = WSUK-ELAN-TR7B-AYXK-MO6C-WPWZ-CLJN
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> meshman device pending
<rsp>MessageID: WSUK-ELAN-TR7B-AYXK-MO6C-WPWZ-CLJN
        Connection Request::
        MessageID: WSUK-ELAN-TR7B-AYXK-MO6C-WPWZ-CLJN
        To:  From: 
        Device:  MBQC-IDY4-CZUY-G67R-2TLC-2C5Z-DQRB
        Witness: WSUK-ELAN-TR7B-AYXK-MO6C-WPWZ-CLJN
<cmd>Alice> meshman device accept WSUK-ELAN-TR7B-AYXK-MO6C-WPWZ-CLJN ^
    /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> meshman device complete
<rsp>   Device UDF = MBQC-IDY4-CZUY-G67R-2TLC-2C5Z-DQRB
   Account = alice@example.com
   Account UDF = MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
</div>
~~~~


