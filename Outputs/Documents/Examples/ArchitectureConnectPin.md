
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=ADKW-K2ZB-PPZM-ECG4-P3NQ-UN4K-XI
 (Expires=2022-05-04T16:47:51Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ADKW-K2ZB-PPZM-ECG4-P3NQ-UN4K-XI
<rsp>   Device UDF = MAWL-JZU3-BV3H-JBT4-KPLE-OU4A-UNSY
   Witness value = YDLF-TRCY-GPUF-HGY3-7NRH-IIIG-DTGX
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: YDLF-TRCY-GPUF-HGY3-7NRH-IIIG-DTGX
        Connection Request::
        MessageID: YDLF-TRCY-GPUF-HGY3-7NRH-IIIG-DTGX
        To:  From: 
        Device:  MAWL-JZU3-BV3H-JBT4-KPLE-OU4A-UNSY
        Witness: YDLF-TRCY-GPUF-HGY3-7NRH-IIIG-DTGX
MessageID: NAJ7-2JAE-5VND-GLM3-YYHF-FQX2-TCF7
        Confirmation Request::
        MessageID: NAJ7-2JAE-5VND-GLM3-YYHF-FQX2-TCF7
        To: alice@example.com From: console@example.com
        Text: start
<cmd>Alice> meshman account sync /auto
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MAWL-JZU3-BV3H-JBT4-KPLE-OU4A-UNSY
   Account = alice@example.com
   Account UDF = MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
<cmd>Alice3> meshman account sync
</div>
~~~~

The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/ADKW-K2ZB-PPZM-ECG4-P3NQ-UN4K-XI
~~~~


