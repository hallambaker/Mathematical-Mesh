The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MCGR-EVM3-RCA6-VXW5-RS3G-2AFW-BERB
   Witness value = ED5H-2CDI-GTTK-5VV2-H3PM-A7NJ-CI3B
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts it:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: 2OAQ-RZZ5-P3BL-DAGR-7XKG-P3YQ-MBZQ
        Connection Request::
        MessageID: 2OAQ-RZZ5-P3BL-DAGR-7XKG-P3YQ-MBZQ
        To:  From: 
        Device:  MDGU-U5T6-5SRZ-3S6H-KV5K-FQVE-SRBJ
        Witness: 2OAQ-RZZ5-P3BL-DAGR-7XKG-P3YQ-MBZQ
MessageID: NA3M-FCCF-P67J-CHXN-NUYJ-X267-RCH5
        Confirmation Request::
        MessageID: NA3M-FCCF-P67J-CHXN-NUYJ-X267-RCH5
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NAEZ-UOXO-KBH7-MT7I-KKA2-S37A-RGEZ
        Contact Request::
        MessageID: NAEZ-UOXO-KBH7-MT7I-KKA2-S37A-RGEZ
        To: alice@example.com From: bob@example.com
        PIN: AADZ-27RV-SGJA-5LIO-GHVA-2QPC-ORRA
<cmd>Alice> account sync /auto
<rsp>ERROR - Cannot access a closed file.
<cmd>Alice> device accept ED5H-2CDI-GTTK-5VV2-H3PM-A7NJ-CI3B
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
</div>
~~~~


