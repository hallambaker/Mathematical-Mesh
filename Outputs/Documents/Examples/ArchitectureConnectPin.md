
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> account pin /threshold
<rsp>PIN=AC33-KDTU-XZML-MBR6-53CC-HTM2-RU
 (Expires=2021-09-19T18:46:57Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin ^
    AC33-KDTU-XZML-MBR6-53CC-HTM2-RU
<rsp>   Device UDF = MC57-OPK7-466V-HXX6-F3L6-WQTQ-ISY5
   Witness value = 54E4-BFWD-CBDK-2JAY-TSLY-2PIU-MW6O
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: 54E4-BFWD-CBDK-2JAY-TSLY-2PIU-MW6O
        Connection Request::
        MessageID: 54E4-BFWD-CBDK-2JAY-TSLY-2PIU-MW6O
        To:  From: 
        Device:  MC57-OPK7-466V-HXX6-F3L6-WQTQ-ISY5
        Witness: 54E4-BFWD-CBDK-2JAY-TSLY-2PIU-MW6O
MessageID: NCJY-LYGZ-3ICM-JESL-H77G-WL4K-KY3V
        Group invitation::
        MessageID: NCJY-LYGZ-3ICM-JESL-H77G-WL4K-KY3V
        To: alice@example.com From: alice@example.com
MessageID: NC5F-OQN2-OLFI-HL4E-LRUR-QCA5-KOHC
        Confirmation Request::
        MessageID: NC5F-OQN2-OLFI-HL4E-LRUR-QCA5-KOHC
        To: alice@example.com From: console@example.com
        Text: start
MessageID: ND3S-QR42-LWJ7-ORBD-3DMN-ZBTH-RMFI
        Contact Request::
        MessageID: ND3S-QR42-LWJ7-ORBD-3DMN-ZBTH-RMFI
        To: alice@example.com From: bob@example.com
        PIN: ADUQ-WHRC-BS2A-V4XK-TEFX-52VJ-JKYQ
<cmd>Alice> account sync /auto
<rsp>ERROR - An attempt was made to create an object with an existing obje
ct identifier
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> device complete
<rsp>   Device UDF = MC57-OPK7-466V-HXX6-F3L6-WQTQ-ISY5
   Account = alice@example.com
   Account UDF = MBMJ-7X6T-DWE7-6EGQ-2QGZ-RSYR-553Q
<cmd>Alice3> account sync
</div>
~~~~

>>>> Unfinished ArchitectureConnectPin/Connect.ConnectPINComplete



The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/AC33-KDTU-XZML-MBR6-53CC-HTM2-RU
~~~~


