
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=ABZQ-GFJC-V7RM-XIXD-DL7B-AVGD-54
 (Expires=2021-12-20T02:16:03Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ABZQ-GFJC-V7RM-XIXD-DL7B-AVGD-54
<rsp>   Device UDF = MCQT-B7NG-QZ7M-4LXE-5AZN-W4A5-5FSF
   Witness value = HTUH-LKSI-ZPI3-SQ3Y-PHUH-MJ53-RTL2
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: HTUH-LKSI-ZPI3-SQ3Y-PHUH-MJ53-RTL2
        Connection Request::
        MessageID: HTUH-LKSI-ZPI3-SQ3Y-PHUH-MJ53-RTL2
        To:  From: 
        Device:  MCQT-B7NG-QZ7M-4LXE-5AZN-W4A5-5FSF
        Witness: HTUH-LKSI-ZPI3-SQ3Y-PHUH-MJ53-RTL2
MessageID: NBKK-WDGA-Z36W-IOD6-HZBW-DSNB-2CR5
        Group invitation::
        MessageID: NBKK-WDGA-Z36W-IOD6-HZBW-DSNB-2CR5
        To: alice@example.com From: alice@example.com
MessageID: NBW3-QGBQ-U26Q-ECMH-3BAD-BYI5-7J4J
        Confirmation Request::
        MessageID: NBW3-QGBQ-U26Q-ECMH-3BAD-BYI5-7J4J
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDRW-AINC-CW2Z-REBY-UILU-O2EI-MZPK
        Contact Request::
        MessageID: NDRW-AINC-CW2Z-REBY-UILU-O2EI-MZPK
        To: alice@example.com From: bob@example.com
        PIN: ADXO-VQ4V-WNRY-WD65-PHYE-GK2E-TWZQ
<cmd>Alice> meshman account sync /auto
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MCQT-B7NG-QZ7M-4LXE-5AZN-W4A5-5FSF
   Account = alice@example.com
   Account UDF = MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT
<cmd>Alice3> meshman account sync
</div>
~~~~

The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/ABZQ-GFJC-V7RM-XIXD-DL7B-AVGD-54
~~~~


