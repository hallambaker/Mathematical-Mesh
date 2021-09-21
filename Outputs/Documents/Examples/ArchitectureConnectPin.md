
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> account pin /threshold
<rsp>PIN=ADCA-JUQP-AWFS-SDGL-6EUP-DCK6-HY
 (Expires=2021-09-22T00:58:53Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin ^
    ADCA-JUQP-AWFS-SDGL-6EUP-DCK6-HY
<rsp>   Device UDF = MATO-OK36-H76J-GLYM-QRPL-FXSV-CR32
   Witness value = IOJY-DGBZ-AEXG-IATI-6MQO-5U5W-QTWJ
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: IOJY-DGBZ-AEXG-IATI-6MQO-5U5W-QTWJ
        Connection Request::
        MessageID: IOJY-DGBZ-AEXG-IATI-6MQO-5U5W-QTWJ
        To:  From: 
        Device:  MATO-OK36-H76J-GLYM-QRPL-FXSV-CR32
        Witness: IOJY-DGBZ-AEXG-IATI-6MQO-5U5W-QTWJ
MessageID: NB2L-5YB3-24H6-YGRB-PX34-MUPC-FVSW
        Group invitation::
        MessageID: NB2L-5YB3-24H6-YGRB-PX34-MUPC-FVSW
        To: alice@example.com From: alice@example.com
MessageID: NBQB-3S4U-QIJU-A2YB-HDPL-SGGM-CPKY
        Confirmation Request::
        MessageID: NBQB-3S4U-QIJU-A2YB-HDPL-SGGM-CPKY
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NCKJ-A26T-F457-ZDUM-KCLY-DI3W-LICQ
        Contact Request::
        MessageID: NCKJ-A26T-F457-ZDUM-KCLY-DI3W-LICQ
        To: alice@example.com From: bob@example.com
        PIN: ADVA-25BJ-2FZG-LMV3-IUVO-QRF4-JHXA
<cmd>Alice> account sync /auto
<rsp>ERROR - An attempt was made to create an object with an existing obje
ct identifier
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> device complete
<rsp>   Device UDF = MATO-OK36-H76J-GLYM-QRPL-FXSV-CR32
   Account = alice@example.com
   Account UDF = MCST-2JUP-UNOG-O4A3-Q6KS-O2V5-HSQL
<cmd>Alice3> account sync
</div>
~~~~

>>>> Unfinished ArchitectureConnectPin/Connect.ConnectPINComplete



The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/ADCA-JUQP-AWFS-SDGL-6EUP-DCK6-HY
~~~~


