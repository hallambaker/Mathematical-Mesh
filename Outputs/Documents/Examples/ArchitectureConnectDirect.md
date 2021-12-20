The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> meshman device request alice@example.com
<rsp>   Device UDF = MAT6-VBWS-466P-GHDQ-RLHL-S2IJ-PXY5
   Witness value = UPXY-SS6S-L4AS-AKOW-6WSR-77J5-OGY6
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> meshman device pending
<rsp>MessageID: UPXY-SS6S-L4AS-AKOW-6WSR-77J5-OGY6
        Connection Request::
        MessageID: UPXY-SS6S-L4AS-AKOW-6WSR-77J5-OGY6
        To:  From: 
        Device:  MAT6-VBWS-466P-GHDQ-RLHL-S2IJ-PXY5
        Witness: UPXY-SS6S-L4AS-AKOW-6WSR-77J5-OGY6
<cmd>Alice> meshman device accept UPXY-SS6S-L4AS-AKOW-6WSR-77J5-OGY6 ^
    /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> meshman device complete
<rsp>   Device UDF = MAT6-VBWS-466P-GHDQ-RLHL-S2IJ-PXY5
   Account = alice@example.com
   Account UDF = MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ
</div>
~~~~


