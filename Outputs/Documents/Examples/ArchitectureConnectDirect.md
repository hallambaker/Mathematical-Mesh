The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MCRS-WMA4-QV32-HPLQ-4L3R-MSYA-UJXZ
   Witness value = AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts it:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: HCG4-XSEY-PC7D-KLDI-OP6X-MEBD-TLWT
        Connection Request::
        MessageID: HCG4-XSEY-PC7D-KLDI-OP6X-MEBD-TLWT
        To:  From: 
        Device:  MARV-3CT2-H7RW-CPGM-ILRK-4C6V-QIYK
        Witness: HCG4-XSEY-PC7D-KLDI-OP6X-MEBD-TLWT
MessageID: AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4
        Connection Request::
        MessageID: AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4
        To:  From: 
        Device:  MCRS-WMA4-QV32-HPLQ-4L3R-MSYA-UJXZ
        Witness: AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4
<cmd>Alice> device accept AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

The new device will now synchronize automatically in response to any Mesh commands. For example, 
listing the password catalog:

**Missing Example***
