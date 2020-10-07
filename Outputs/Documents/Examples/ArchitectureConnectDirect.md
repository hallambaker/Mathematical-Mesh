The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MDYN-U7RH-NCK4-NLPY-VMMT-OIRY-BHH4
   Witness value = AMLN-OTR2-SYCF-KZGL-IOIZ-SPQL-TJX6
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts it:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: DVHM-4XCL-BA55-ZW2F-GYO2-JWYN-OGH5
        Connection Request::
        MessageID: DVHM-4XCL-BA55-ZW2F-GYO2-JWYN-OGH5
        To:  From: 
        Device:  MAWT-SA4U-LLRU-GJ26-BYRC-ZUBL-YYI3
        Witness: DVHM-4XCL-BA55-ZW2F-GYO2-JWYN-OGH5
MessageID: AMLN-OTR2-SYCF-KZGL-IOIZ-SPQL-TJX6
        Connection Request::
        MessageID: AMLN-OTR2-SYCF-KZGL-IOIZ-SPQL-TJX6
        To:  From: 
        Device:  MDYN-U7RH-NCK4-NLPY-VMMT-OIRY-BHH4
        Witness: AMLN-OTR2-SYCF-KZGL-IOIZ-SPQL-TJX6
<cmd>Alice> device accept AMLN-OTR2-SYCF-KZGL-IOIZ-SPQL-TJX6
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

The new device will now synchronize automatically in response to any Mesh commands. For example, 
listing the password catalog:


~~~~
<div="terminal">
<cmd>Alice2> password list
<rsp>ERROR - The entry already exists in the store.
</div>
~~~~
