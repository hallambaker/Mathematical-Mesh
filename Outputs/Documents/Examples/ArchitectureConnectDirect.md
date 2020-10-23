The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MBSW-5TDC-4JNH-DP7U-YRYH-336S-XS7X
   Witness value = JAIU-EMU6-PRO7-DPWT-JWFX-NJE4-S6Y2
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts it:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: PF33-UK76-TZDH-UBFZ-4JSM-YRZB-YKPS
        Connection Request::
        MessageID: PF33-UK76-TZDH-UBFZ-4JSM-YRZB-YKPS
        To:  From: 
        Device:  MCIA-7IZ5-KGO3-U3CW-Y6Q2-5NMS-ZPXG
        Witness: PF33-UK76-TZDH-UBFZ-4JSM-YRZB-YKPS
MessageID: JAIU-EMU6-PRO7-DPWT-JWFX-NJE4-S6Y2
        Connection Request::
        MessageID: JAIU-EMU6-PRO7-DPWT-JWFX-NJE4-S6Y2
        To:  From: 
        Device:  MBSW-5TDC-4JNH-DP7U-YRYH-336S-XS7X
        Witness: JAIU-EMU6-PRO7-DPWT-JWFX-NJE4-S6Y2
<cmd>Alice> device accept JAIU-EMU6-PRO7-DPWT-JWFX-NJE4-S6Y2
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

The new device will now synchronize automatically in response to any Mesh commands. For example, 
listing the password catalog:

**Missing Example***
