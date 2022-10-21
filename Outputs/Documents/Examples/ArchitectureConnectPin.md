
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AAIT-WXRD-BVB7-3BBT-D6JS-44GE-B4
 (Expires=2022-10-19T12:48:11Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AAIT-WXRD-BVB7-3BBT-D6JS-44GE-B4
<rsp>   Device UDF = MDVU-AOST-TDIH-AXGE-WUJS-I56V-WJP3
   Witness value = AI7W-YKPK-MR3U-CZW7-GAVQ-24LZ-MSFA
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: AI7W-YKPK-MR3U-CZW7-GAVQ-24LZ-MSFA
        Connection Request::
        MessageID: AI7W-YKPK-MR3U-CZW7-GAVQ-24LZ-MSFA
        To:  From: 
        Device:  MDVU-AOST-TDIH-AXGE-WUJS-I56V-WJP3
        Witness: AI7W-YKPK-MR3U-CZW7-GAVQ-24LZ-MSFA
MessageID: NBGK-6BGU-5C5H-4WUR-OGDF-NZTH-ZLCW
        Confirmation Request::
        MessageID: NBGK-6BGU-5C5H-4WUR-OGDF-NZTH-ZLCW
        To: alice@example.com From: console@example.com
        Text: start
<cmd>Alice> meshman account sync /auto
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MDVU-AOST-TDIH-AXGE-WUJS-I56V-WJP3
   Account = alice@example.com
   Account UDF = MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
<cmd>Alice3> meshman account sync
</div>
~~~~

The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/AAIT-WXRD-BVB7-3BBT-D6JS-44GE-B4
~~~~


