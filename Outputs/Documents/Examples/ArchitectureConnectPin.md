
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> account pin /threshold
<rsp>PIN=ABUT-CB72-7OD7-RCTA-ZKQK-HTBK-QI
 (Expires=2021-09-18T13:08:46Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin ^
    ABUT-CB72-7OD7-RCTA-ZKQK-HTBK-QI
<rsp>   Device UDF = MAM5-JIA7-DSS2-HXXB-63TD-RDS5-U4XN
   Witness value = AILH-UMHP-NS7S-CS5X-TOEK-RR3C-WYBS
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: AILH-UMHP-NS7S-CS5X-TOEK-RR3C-WYBS
        Connection Request::
        MessageID: AILH-UMHP-NS7S-CS5X-TOEK-RR3C-WYBS
        To:  From: 
        Device:  MAM5-JIA7-DSS2-HXXB-63TD-RDS5-U4XN
        Witness: AILH-UMHP-NS7S-CS5X-TOEK-RR3C-WYBS
MessageID: NDRJ-MUA4-ZHUD-3PHK-MLJJ-EPLX-46FD
        Group invitation::
        MessageID: NDRJ-MUA4-ZHUD-3PHK-MLJJ-EPLX-46FD
        To: alice@example.com From: alice@example.com
MessageID: NA4W-P4SA-YCM2-VPZO-NGVS-MKNS-S7VM
        Confirmation Request::
        MessageID: NA4W-P4SA-YCM2-VPZO-NGVS-MKNS-S7VM
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDUB-2UQF-ABWX-FVM3-5BX6-XFEG-WNEB
        Contact Request::
        MessageID: NDUB-2UQF-ABWX-FVM3-5BX6-XFEG-WNEB
        To: alice@example.com From: bob@example.com
        PIN: ADTM-XGIY-KTVA-CXXP-T64M-NUXC-A2OQ
<cmd>Alice> account sync /auto
<rsp>ERROR - An attempt was made to create an object with an existing obje
ct identifier
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> device complete
<rsp>   Device UDF = MAM5-JIA7-DSS2-HXXB-63TD-RDS5-U4XN
   Account = alice@example.com
   Account UDF = MC76-AK7P-CEKP-ILKC-MEXU-EOIF-I6BF
<cmd>Alice3> account sync
</div>
~~~~

>>>> Unfinished ArchitectureConnectPin/Connect.ConnectPINComplete



The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/ABUT-CB72-7OD7-RCTA-ZKQK-HTBK-QI
~~~~


