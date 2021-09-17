
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> account pin /threshold
<rsp>PIN=ABMQ-PEXV-4NWU-VZ6Y-GV7N-QESY-AI
 (Expires=2021-09-17T23:57:11Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin ^
    ABMQ-PEXV-4NWU-VZ6Y-GV7N-QESY-AI
<rsp>   Device UDF = MDJQ-HLMF-R7LA-YQJT-IA6C-C4BE-TBSP
   Witness value = YVKR-HTGJ-IS2M-LPJM-T7PS-ZUI4-7MR5
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: YVKR-HTGJ-IS2M-LPJM-T7PS-ZUI4-7MR5
        Connection Request::
        MessageID: YVKR-HTGJ-IS2M-LPJM-T7PS-ZUI4-7MR5
        To:  From: 
        Device:  MDJQ-HLMF-R7LA-YQJT-IA6C-C4BE-TBSP
        Witness: YVKR-HTGJ-IS2M-LPJM-T7PS-ZUI4-7MR5
MessageID: NDHR-66K2-Z7D6-VN7P-DZYK-B5QK-BP3O
        Group invitation::
        MessageID: NDHR-66K2-Z7D6-VN7P-DZYK-B5QK-BP3O
        To: alice@example.com From: alice@example.com
MessageID: NDN5-UX7M-5YHV-IZAK-DELS-YYMS-RNWD
        Confirmation Request::
        MessageID: NDN5-UX7M-5YHV-IZAK-DELS-YYMS-RNWD
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NA26-HGSS-F7RE-HYCI-C6Q6-QXH3-3F2Y
        Contact Request::
        MessageID: NA26-HGSS-F7RE-HYCI-C6Q6-QXH3-3F2Y
        To: alice@example.com From: bob@example.com
        PIN: ACV3-IW65-7QKN-PSNO-VKGG-OCY6-3GSQ
<cmd>Alice> account sync /auto
<rsp>ERROR - An attempt was made to create an object with an existing obje
ct identifier
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> device complete
<rsp>   Device UDF = MDJQ-HLMF-R7LA-YQJT-IA6C-C4BE-TBSP
   Account = alice@example.com
   Account UDF = MBRN-NNZS-FIXI-NTAZ-YPVO-HKTD-RJ5I
<cmd>Alice3> account sync
</div>
~~~~

>>>> Unfinished ArchitectureConnectPin/Connect.ConnectPINComplete



The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/ABMQ-PEXV-4NWU-VZ6Y-GV7N-QESY-AI
~~~~


