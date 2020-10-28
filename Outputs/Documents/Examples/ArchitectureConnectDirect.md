The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MBMK-W6JV-6V4E-M7SB-FRHA-756D-XZYG
   Witness value = 4AIX-TNS7-LOHF-RDMW-FHP5-GSJ7-NBFP
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts it:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: 4AIX-TNS7-LOHF-RDMW-FHP5-GSJ7-NBFP
        Connection Request::
        MessageID: 4AIX-TNS7-LOHF-RDMW-FHP5-GSJ7-NBFP
        To:  From: 
        Device:  MBMK-W6JV-6V4E-M7SB-FRHA-756D-XZYG
        Witness: 4AIX-TNS7-LOHF-RDMW-FHP5-GSJ7-NBFP
<cmd>Alice> device accept 4AIX-TNS7-LOHF-RDMW-FHP5-GSJ7-NBFP
<rsp></div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp></div>
~~~~


