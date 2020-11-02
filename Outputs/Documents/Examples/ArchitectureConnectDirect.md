The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MAEE-NEXW-5GBZ-3H2D-AFVE-XDL4-TUN4
   Witness value = CVZQ-J4XJ-HYSI-MS54-ZH3E-R45I-PLLI
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts it:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: C7N6-Z265-WS5G-AI2J-OJNZ-TP4F-LTQ7
        Connection Request::
        MessageID: C7N6-Z265-WS5G-AI2J-OJNZ-TP4F-LTQ7
        To:  From: 
        Device:  MBNQ-OB5W-4QWM-5TQ7-7CFQ-6ZA3-EIDD
        Witness: C7N6-Z265-WS5G-AI2J-OJNZ-TP4F-LTQ7
MessageID: NB3R-KF4X-PLYG-VDF5-ZMLZ-OQG3-5COU
        Confirmation Request::
        MessageID: NB3R-KF4X-PLYG-VDF5-ZMLZ-OQG3-5COU
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NAJ2-5SHJ-3XAG-3G3H-KZFT-Z2H4-AO3F
        Contact Request::
        MessageID: NAJ2-5SHJ-3XAG-3G3H-KZFT-Z2H4-AO3F
        To: alice@example.com From: bob@example.com
        PIN: ADNS-6YJX-O75K-CKUJ-V5BA-SOCZ-A57Q
<cmd>Alice> account sync /auto
<rsp>ERROR - Cannot access a closed file.
<cmd>Alice> device accept CVZQ-J4XJ-HYSI-MS54-ZH3E-R45I-PLLI
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
</div>
~~~~


