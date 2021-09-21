
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> account pin /threshold
<rsp>PIN=ABCA-P2J7-3NE5-EIWH-YUUP-F7PA-JM
 (Expires=2021-09-22T00:56:05Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin ^
    ABCA-P2J7-3NE5-EIWH-YUUP-F7PA-JM
<rsp>   Device UDF = MC65-WT7H-VJES-424R-T3P7-7MAK-MFEN
   Witness value = XAD2-CZH2-4PC7-LWAQ-4KYR-P64K-7E72
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: XAD2-CZH2-4PC7-LWAQ-4KYR-P64K-7E72
        Connection Request::
        MessageID: XAD2-CZH2-4PC7-LWAQ-4KYR-P64K-7E72
        To:  From: 
        Device:  MC65-WT7H-VJES-424R-T3P7-7MAK-MFEN
        Witness: XAD2-CZH2-4PC7-LWAQ-4KYR-P64K-7E72
MessageID: NAP5-4JUE-IQOI-4RBD-F6OY-2752-VOXB
        Group invitation::
        MessageID: NAP5-4JUE-IQOI-4RBD-F6OY-2752-VOXB
        To: alice@example.com From: alice@example.com
MessageID: NDHX-5YUA-2EG6-MBOH-CFA3-7ZZS-G7SI
        Confirmation Request::
        MessageID: NDHX-5YUA-2EG6-MBOH-CFA3-7ZZS-G7SI
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NC7T-SBTN-ZUL4-Z7LB-DMN4-LUFW-5MQF
        Contact Request::
        MessageID: NC7T-SBTN-ZUL4-Z7LB-DMN4-LUFW-5MQF
        To: alice@example.com From: bob@example.com
        PIN: AABR-4QTD-CQQK-A3T6-EVBJ-HVRS-FFSQ
<cmd>Alice> account sync /auto
<rsp>ERROR - An attempt was made to create an object with an existing obje
ct identifier
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> device complete
<rsp>   Device UDF = MC65-WT7H-VJES-424R-T3P7-7MAK-MFEN
   Account = alice@example.com
   Account UDF = MANR-I5NN-5ZQH-APAD-4XOK-HR3F-L2FR
<cmd>Alice3> account sync
</div>
~~~~

>>>> Unfinished ArchitectureConnectPin/Connect.ConnectPINComplete



The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/ABCA-P2J7-3NE5-EIWH-YUUP-F7PA-JM
~~~~


