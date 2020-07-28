Bob requests Alice add him to her contacts catalog:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp></div>
~~~~

When Alice next checks her messages, she sees the pending contact request from Bob and accepts
it. Bob's contact details are added to her catalog and Bob receives a response containing
Alice's credentials:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: NDU7-QGJX-ICCX-UGCO-4CW2-5DLV-64YH
        Contact Request::
        MessageID: NDU7-QGJX-ICCX-UGCO-4CW2-5DLV-64YH
        To: alice@example.com From: bob@example.com
        PIN: ECAW-VTSJ-FYOI-TAQ6-U2JH-4JM3-UDEF
MessageID: 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV
        Connection Request::
        MessageID: 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV
        To:  From: 
        Device:  MDTJ-IEIN-4ST6-ZC3G-OUSP-PBNM-PHYK
        Witness: 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV
MessageID: 2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM
        Connection Request::
        MessageID: 2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM
        To:  From: 
        Device:  MBKR-2YPO-UOPU-2QTE-2YXK-J55K-QBWQ
        Witness: 2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM
<cmd>Alice> message accept tbs
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

