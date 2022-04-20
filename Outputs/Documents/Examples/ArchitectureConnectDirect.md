The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> meshman device request alice@example.com
<rsp>   Device UDF = MA75-5N5Q-BPQF-5LMP-AN6X-NM4E-U4KS
   Witness value = 6WH6-YJIZ-OKA7-I54P-WZPA-VXTV-PHKJ
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> meshman device pending
<rsp>MessageID: 6WH6-YJIZ-OKA7-I54P-WZPA-VXTV-PHKJ
        Connection Request::
        MessageID: 6WH6-YJIZ-OKA7-I54P-WZPA-VXTV-PHKJ
        To:  From: 
        Device:  MA75-5N5Q-BPQF-5LMP-AN6X-NM4E-U4KS
        Witness: 6WH6-YJIZ-OKA7-I54P-WZPA-VXTV-PHKJ
<cmd>Alice> meshman device accept 6WH6-YJIZ-OKA7-I54P-WZPA-VXTV-PHKJ ^
    /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> meshman device complete
<rsp>   Device UDF = MA75-5N5Q-BPQF-5LMP-AN6X-NM4E-U4KS
   Account = alice@example.com
   Account UDF = MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
</div>
~~~~


