
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> account pin /threshold
<rsp>PIN=ABQR-GO5I-FPIE-TK5O-M4VU-DALE-WM
 (Expires=2021-10-26T15:49:02Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin ^
    ABQR-GO5I-FPIE-TK5O-M4VU-DALE-WM
<rsp>   Device UDF = MCVN-XLLT-LLNW-U4HR-BOMG-RA6Z-UWRR
   Witness value = 2WZP-KNZF-JMKO-RQSU-WYTH-UU35-NWXV
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: 2WZP-KNZF-JMKO-RQSU-WYTH-UU35-NWXV
        Connection Request::
        MessageID: 2WZP-KNZF-JMKO-RQSU-WYTH-UU35-NWXV
        To:  From: 
        Device:  MCVN-XLLT-LLNW-U4HR-BOMG-RA6Z-UWRR
        Witness: 2WZP-KNZF-JMKO-RQSU-WYTH-UU35-NWXV
MessageID: NCVP-LUEL-F3OI-QOAM-HND2-WG5Z-346D
        Group invitation::
        MessageID: NCVP-LUEL-F3OI-QOAM-HND2-WG5Z-346D
        To: alice@example.com From: alice@example.com
MessageID: NDAD-KLJY-C5JO-JGXL-VUWG-Y6PP-PSFJ
        Confirmation Request::
        MessageID: NDAD-KLJY-C5JO-JGXL-VUWG-Y6PP-PSFJ
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NAP7-MRKY-LGHV-W6C2-IDAX-ELNG-V5NT
        Contact Request::
        MessageID: NAP7-MRKY-LGHV-W6C2-IDAX-ELNG-V5NT
        To: alice@example.com From: bob@example.com
        PIN: AAIE-IVI5-54XO-5PHG-VE62-FFS7-62GQ
<cmd>Alice> account sync /auto
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> device complete
<rsp>   Device UDF = MCVN-XLLT-LLNW-U4HR-BOMG-RA6Z-UWRR
   Account = alice@example.com
   Account UDF = MB5I-R24M-QXJT-KDBF-XFOA-DGC3-U3AA
<cmd>Alice3> account sync
</div>
~~~~

The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/ABQR-GO5I-FPIE-TK5O-M4VU-DALE-WM
~~~~


