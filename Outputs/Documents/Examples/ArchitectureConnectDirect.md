The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> meshman device request alice@example.com
<rsp>   Device UDF = MDF6-V33U-HPP4-FDY2-IH4G-BVCE-PTOS
   Witness value = JFX3-4WGT-BQCQ-CXTW-SEJJ-YC6D-OBGJ
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> meshman device pending
<rsp>MessageID: JFX3-4WGT-BQCQ-CXTW-SEJJ-YC6D-OBGJ
        Connection Request::
        MessageID: JFX3-4WGT-BQCQ-CXTW-SEJJ-YC6D-OBGJ
        To:  From: 
        Device:  MDF6-V33U-HPP4-FDY2-IH4G-BVCE-PTOS
        Witness: JFX3-4WGT-BQCQ-CXTW-SEJJ-YC6D-OBGJ
<cmd>Alice> meshman device accept JFX3-4WGT-BQCQ-CXTW-SEJJ-YC6D-OBGJ ^
    /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> meshman device complete
<rsp>   Device UDF = MDF6-V33U-HPP4-FDY2-IH4G-BVCE-PTOS
   Account = alice@example.com
   Account UDF = MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
</div>
~~~~


