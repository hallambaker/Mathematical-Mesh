The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MCBZ-J5MT-S5BZ-5JOW-QZW4-3USK-VMWG
   Witness value = ETAD-G4P3-UG4H-N3M6-27TY-MGSX-FDIM
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts it:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: LH27-DJJ7-KIYC-7UZJ-5BXY-V7GU-6RZ3
        Connection Request::
        MessageID: LH27-DJJ7-KIYC-7UZJ-5BXY-V7GU-6RZ3
        To:  From: 
        Device:  MBFE-KWS7-AC5S-LYJS-EJ2I-ZY37-HCI7
        Witness: LH27-DJJ7-KIYC-7UZJ-5BXY-V7GU-6RZ3
MessageID: NDDR-3DMR-QFGH-5NTT-W6V4-WAWM-ERSN
        Confirmation Request::
        MessageID: NDDR-3DMR-QFGH-5NTT-W6V4-WAWM-ERSN
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NB2L-XW4K-7HZ3-5UHJ-B46U-2ZUJ-KXWC
        Contact Request::
        MessageID: NB2L-XW4K-7HZ3-5UHJ-B46U-2ZUJ-KXWC
        To: alice@example.com From: bob@example.com
        PIN: ACQ6-HOEL-5EOQ-OKX4-XIX5-ZUSS-JGIA
<cmd>Alice> account sync /auto
<cmd>Alice> device accept ETAD-G4P3-UG4H-N3M6-27TY-MGSX-FDIM
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
</div>
~~~~


