
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=ADFR-TEQU-3HJD-IRND-P4TS-CRBD-NI
 (Expires=2022-04-21T16:17:50Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ADFR-TEQU-3HJD-IRND-P4TS-CRBD-NI
<rsp>   Device UDF = MAA3-BQPZ-WWO4-7Q5B-P7AH-FY5C-ATMD
   Witness value = HS22-VO5M-JAG4-RQT4-ROHX-PERK-YYCW
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: HS22-VO5M-JAG4-RQT4-ROHX-PERK-YYCW
        Connection Request::
        MessageID: HS22-VO5M-JAG4-RQT4-ROHX-PERK-YYCW
        To:  From: 
        Device:  MAA3-BQPZ-WWO4-7Q5B-P7AH-FY5C-ATMD
        Witness: HS22-VO5M-JAG4-RQT4-ROHX-PERK-YYCW
MessageID: NDBB-CHFG-OWNI-2WWK-RJI2-KMF7-6AW7
        Confirmation Request::
        MessageID: NDBB-CHFG-OWNI-2WWK-RJI2-KMF7-6AW7
        To: alice@example.com From: console@example.com
        Text: start
<cmd>Alice> meshman account sync /auto
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MAA3-BQPZ-WWO4-7Q5B-P7AH-FY5C-ATMD
   Account = alice@example.com
   Account UDF = MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
<cmd>Alice3> meshman account sync
</div>
~~~~

The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/ADFR-TEQU-3HJD-IRND-P4TS-CRBD-NI
~~~~


