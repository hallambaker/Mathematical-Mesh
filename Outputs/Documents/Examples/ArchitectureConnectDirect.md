The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MCZJ-BSTU-OIMP-SRF3-WNGV-4JIV-56ZM
   Witness value = CGQR-COKS-K4UR-EPYB-2CBI-MB6Z-UQ4B
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: CGQR-COKS-K4UR-EPYB-2CBI-MB6Z-UQ4B
        Connection Request::
        MessageID: CGQR-COKS-K4UR-EPYB-2CBI-MB6Z-UQ4B
        To:  From: 
        Device:  MCZJ-BSTU-OIMP-SRF3-WNGV-4JIV-56ZM
        Witness: CGQR-COKS-K4UR-EPYB-2CBI-MB6Z-UQ4B
<cmd>Alice> device accept CGQR-COKS-K4UR-EPYB-2CBI-MB6Z-UQ4B /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MCZJ-BSTU-OIMP-SRF3-WNGV-4JIV-56ZM
   Account = alice@example.com
   Account UDF = MC76-AK7P-CEKP-ILKC-MEXU-EOIF-I6BF
</div>
~~~~


