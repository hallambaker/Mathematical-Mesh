The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MCEJ-NN5Q-IMQZ-CHPG-ES7T-BNJU-SFF3
   Witness value = UVJB-B24O-Q4CV-RV3A-7WE3-HV27-P5CE
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts it:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: 4OG3-O4XT-2KQK-CSU7-OOA2-XZXN-PJV2
        Connection Request::
        MessageID: 4OG3-O4XT-2KQK-CSU7-OOA2-XZXN-PJV2
        To:  From: 
        Device:  MCA3-KBIK-PYOF-DUQA-BXTZ-FS6S-36QE
        Witness: 4OG3-O4XT-2KQK-CSU7-OOA2-XZXN-PJV2
MessageID: NBOH-OUSA-BRZ5-LSSJ-QUCH-ED2L-IFJV
        Confirmation Request::
        MessageID: NBOH-OUSA-BRZ5-LSSJ-QUCH-ED2L-IFJV
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NANV-6BQI-F7VF-DATH-IA46-XNTZ-7NX2
        Contact Request::
        MessageID: NANV-6BQI-F7VF-DATH-IA46-XNTZ-7NX2
        To: alice@example.com From: bob@example.com
        PIN: ABUZ-THFJ-NAPN-HWGX-LB5H-PPG5-G5VQ
<cmd>Alice> account sync /auto
<rsp>ERROR - Cannot access a closed file.
<cmd>Alice> device accept UVJB-B24O-Q4CV-RV3A-7WE3-HV27-P5CE
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
</div>
~~~~


