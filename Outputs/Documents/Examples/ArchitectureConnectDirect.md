The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MDQJ-WIIP-CJXX-ZQ4D-L5UU-KGLH-EEVB
   Witness value = FRPG-UBLD-JKCN-HAWA-F4MU-KNMN-L2PG
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts it:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: OKYP-F5A2-MBT6-GV7X-MCZH-2K3T-4OHU
        Connection Request::
        MessageID: OKYP-F5A2-MBT6-GV7X-MCZH-2K3T-4OHU
        To:  From: 
        Device:  MDTY-B2DV-56KN-O6EG-XG5T-62NT-4UTE
        Witness: OKYP-F5A2-MBT6-GV7X-MCZH-2K3T-4OHU
MessageID: NBR3-D554-BQLH-FK5I-7YU3-T5B2-XGDS
        Confirmation Request::
        MessageID: NBR3-D554-BQLH-FK5I-7YU3-T5B2-XGDS
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDGZ-J52O-DPPK-JG7R-2YZQ-JUPS-3GJK
        Contact Request::
        MessageID: NDGZ-J52O-DPPK-JG7R-2YZQ-JUPS-3GJK
        To: alice@example.com From: bob@example.com
        PIN: ACJP-PFU2-2O4N-73XX-J3KN-E7K4-FV3A
<cmd>Alice> account sync /auto
<rsp>ERROR - Cannot access a closed file.
<cmd>Alice> device accept FRPG-UBLD-JKCN-HAWA-F4MU-KNMN-L2PG
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
</div>
~~~~


