
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> account pin /threshold
<rsp>PIN=AB2H-VRFJ-XANZ-JPXG-UIBC-5CGN-3Q
 (Expires=2021-09-20T17:52:42Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin ^
    AB2H-VRFJ-XANZ-JPXG-UIBC-5CGN-3Q
<rsp>   Device UDF = MD73-BYDQ-RHKR-XGQ6-MLM2-36E7-ZHSI
   Witness value = EFYA-IUMT-UW42-WY4C-LV5O-XY6V-HIQK
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: EFYA-IUMT-UW42-WY4C-LV5O-XY6V-HIQK
        Connection Request::
        MessageID: EFYA-IUMT-UW42-WY4C-LV5O-XY6V-HIQK
        To:  From: 
        Device:  MD73-BYDQ-RHKR-XGQ6-MLM2-36E7-ZHSI
        Witness: EFYA-IUMT-UW42-WY4C-LV5O-XY6V-HIQK
MessageID: NA7M-DPDT-X2EB-SMF3-4GYN-W4QG-K4P4
        Group invitation::
        MessageID: NA7M-DPDT-X2EB-SMF3-4GYN-W4QG-K4P4
        To: alice@example.com From: alice@example.com
MessageID: NC5O-E23U-BF3F-VDVE-O3GU-WJB7-OWBW
        Confirmation Request::
        MessageID: NC5O-E23U-BF3F-VDVE-O3GU-WJB7-OWBW
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NC73-FK3T-VLKH-TVJG-AUNW-NIXV-5JEW
        Contact Request::
        MessageID: NC73-FK3T-VLKH-TVJG-AUNW-NIXV-5JEW
        To: alice@example.com From: bob@example.com
        PIN: ADMA-QBVV-7O32-EYN5-QMI2-H74W-3YCQ
<cmd>Alice> account sync /auto
<rsp>ERROR - An attempt was made to create an object with an existing obje
ct identifier
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> device complete
<rsp>   Device UDF = MD73-BYDQ-RHKR-XGQ6-MLM2-36E7-ZHSI
   Account = alice@example.com
   Account UDF = MA62-NMPL-3OBH-KM2M-LPOO-RUZC-HUH3
<cmd>Alice3> account sync
</div>
~~~~

>>>> Unfinished ArchitectureConnectPin/Connect.ConnectPINComplete



The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/AB2H-VRFJ-XANZ-JPXG-UIBC-5CGN-3Q
~~~~


