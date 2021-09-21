The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MBWA-UVSH-42NP-7I5O-EVUD-S67G-4U67
   Witness value = FT32-MN72-Q7BY-OUUK-47MR-CMER-7USB
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: FT32-MN72-Q7BY-OUUK-47MR-CMER-7USB
        Connection Request::
        MessageID: FT32-MN72-Q7BY-OUUK-47MR-CMER-7USB
        To:  From: 
        Device:  MBWA-UVSH-42NP-7I5O-EVUD-S67G-4U67
        Witness: FT32-MN72-Q7BY-OUUK-47MR-CMER-7USB
<cmd>Alice> device accept FT32-MN72-Q7BY-OUUK-47MR-CMER-7USB /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MBWA-UVSH-42NP-7I5O-EVUD-S67G-4U67
   Account = alice@example.com
   Account UDF = MANR-I5NN-5ZQH-APAD-4XOK-HR3F-L2FR
</div>
~~~~


