
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=ABHT-VP25-WUQY-ZNTF-CJ4F-5AWU-ZA
 (Expires=2021-12-20T19:21:17Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ABHT-VP25-WUQY-ZNTF-CJ4F-5AWU-ZA
<rsp>   Device UDF = MBJ4-APU2-QYGV-OPLC-TDDY-5SOJ-PUYN
   Witness value = FC4F-LTCQ-MEOC-NS22-2Q5U-CVI7-KHM7
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: FC4F-LTCQ-MEOC-NS22-2Q5U-CVI7-KHM7
        Connection Request::
        MessageID: FC4F-LTCQ-MEOC-NS22-2Q5U-CVI7-KHM7
        To:  From: 
        Device:  MBJ4-APU2-QYGV-OPLC-TDDY-5SOJ-PUYN
        Witness: FC4F-LTCQ-MEOC-NS22-2Q5U-CVI7-KHM7
MessageID: NDVT-POHA-PJWP-AABG-YXO2-JU2C-4LYT
        Group invitation::
        MessageID: NDVT-POHA-PJWP-AABG-YXO2-JU2C-4LYT
        To: alice@example.com From: alice@example.com
MessageID: NCM5-RFA7-MCBH-UTRQ-2DPH-RIUN-DZEE
        Confirmation Request::
        MessageID: NCM5-RFA7-MCBH-UTRQ-2DPH-RIUN-DZEE
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDA2-TF33-S2GI-CUQB-W7MD-7SUH-TMHU
        Contact Request::
        MessageID: NDA2-TF33-S2GI-CUQB-W7MD-7SUH-TMHU
        To: alice@example.com From: bob@example.com
        PIN: ABS6-M3HZ-3XC3-T2MP-5KAC-7UQW-M65A
<cmd>Alice> meshman account sync /auto
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MBJ4-APU2-QYGV-OPLC-TDDY-5SOJ-PUYN
   Account = alice@example.com
   Account UDF = MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
<cmd>Alice3> meshman account sync
</div>
~~~~

The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/ABHT-VP25-WUQY-ZNTF-CJ4F-5AWU-ZA
~~~~


