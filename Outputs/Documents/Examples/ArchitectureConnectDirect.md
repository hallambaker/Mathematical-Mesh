The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MBKX-6K5R-7JSR-S6XX-RFRG-B5RO-ZR2Y
   Witness value = UQH3-OOVC-4JWQ-2GLO-WQWW-ZOYU-NF77
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: CHY5-7CBJ-L6XY-FW63-A2YC-NURI-A34L
        Connection Request::
        MessageID: CHY5-7CBJ-L6XY-FW63-A2YC-NURI-A34L
        To:  From: 
        Device:  MCYV-ZZRZ-SGRS-JYLT-PGRM-375G-UZDM
        Witness: CHY5-7CBJ-L6XY-FW63-A2YC-NURI-A34L
MessageID: NAB2-XQHR-3J7X-4BZG-D25P-6J3E-B5XL
        Group invitation::
        MessageID: NAB2-XQHR-3J7X-4BZG-D25P-6J3E-B5XL
        To: alice@example.com From: alice@example.com
MessageID: NDAZ-JLVP-HE53-RYKS-M2Q2-3QO6-JC75
        Confirmation Request::
        MessageID: NDAZ-JLVP-HE53-RYKS-M2Q2-3QO6-JC75
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NAYL-CPBL-XTBK-HFVR-IKAS-GH3A-TA2V
        Contact Request::
        MessageID: NAYL-CPBL-XTBK-HFVR-IKAS-GH3A-TA2V
        To: alice@example.com From: bob@example.com
        PIN: AA2V-M76R-UA6A-7TZF-SLNV-GLLN-JIEA
<cmd>Alice> account sync /auto
<rsp>ERROR - An attempt was made to create an object with an existing obje
ct identifier
<cmd>Alice> device accept UQH3-OOVC-4JWQ-2GLO-WQWW-ZOYU-NF77 /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
</div>
~~~~


