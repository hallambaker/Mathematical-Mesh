
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AD5M-D6JD-5QGC-YLLU-UM65-2NQX-4M
 (Expires=2021-12-22T13:28:30Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AD5M-D6JD-5QGC-YLLU-UM65-2NQX-4M
<rsp>   Device UDF = MBUY-BN5A-736O-WRRZ-LJCK-UPZZ-CZ52
   Witness value = TGCH-QM7T-2PRP-44HQ-YAZ6-HMR7-73LC
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: TGCH-QM7T-2PRP-44HQ-YAZ6-HMR7-73LC
        Connection Request::
        MessageID: TGCH-QM7T-2PRP-44HQ-YAZ6-HMR7-73LC
        To:  From: 
        Device:  MBUY-BN5A-736O-WRRZ-LJCK-UPZZ-CZ52
        Witness: TGCH-QM7T-2PRP-44HQ-YAZ6-HMR7-73LC
MessageID: NCUH-QEYI-3V6A-IQ7Z-6RHR-IPLZ-4MMK
        Group invitation::
        MessageID: NCUH-QEYI-3V6A-IQ7Z-6RHR-IPLZ-4MMK
        To: alice@example.com From: alice@example.com
MessageID: NDSA-RD52-JIV2-RVRU-BY4U-3SAN-HZWQ
        Confirmation Request::
        MessageID: NDSA-RD52-JIV2-RVRU-BY4U-3SAN-HZWQ
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
        Contact Request::
        MessageID: NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
        To: alice@example.com From: bob@example.com
        PIN: ACPD-YENT-3EM4-PUHD-D4Q4-4TX5-C25A
<cmd>Alice> meshman account sync /auto
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MBUY-BN5A-736O-WRRZ-LJCK-UPZZ-CZ52
   Account = alice@example.com
   Account UDF = MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
<cmd>Alice3> meshman account sync
</div>
~~~~

The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/AD5M-D6JD-5QGC-YLLU-UM65-2NQX-4M
~~~~


