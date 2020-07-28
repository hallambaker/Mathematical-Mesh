The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MBKR-2YPO-UOPU-2QTE-2YXK-J55K-QBWQ
   Witness value = 2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM
   Personal Mesh = MCOZ-GIZ3-34VQ-GQ6J-FCS7-BJIU-JCOY
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts it:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV
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
<cmd>Alice> device accept 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV
<rsp>Result: Accept
Added device: MDTJ-IEIN-4ST6-ZC3G-OUSP-PBNM-PHYK
</div>
~~~~

The new device will now synchronize automatically in response to any Mesh commands. For example, 
listing the password catalog:


~~~~
<div="terminal">
<cmd>Alice2> password list
<rsp>ERROR - Unspecified error
</div>
~~~~
