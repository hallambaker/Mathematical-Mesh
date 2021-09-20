
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> account pin /threshold
<rsp>PIN=ABYY-TYLH-XENK-57RH-6PMF-MAE2-JU
 (Expires=2021-09-21T18:16:18Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin ^
    ABYY-TYLH-XENK-57RH-6PMF-MAE2-JU
<rsp>   Device UDF = MBJ4-CDEK-6JA2-WGKY-4C2Z-VSYP-KOFM
   Witness value = CC5N-J27O-DR3W-WTQI-R3JB-NJZP-745V
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: CC5N-J27O-DR3W-WTQI-R3JB-NJZP-745V
        Connection Request::
        MessageID: CC5N-J27O-DR3W-WTQI-R3JB-NJZP-745V
        To:  From: 
        Device:  MBJ4-CDEK-6JA2-WGKY-4C2Z-VSYP-KOFM
        Witness: CC5N-J27O-DR3W-WTQI-R3JB-NJZP-745V
MessageID: NCJD-SJE7-VPY7-REZL-HCYI-2QWC-W2ZK
        Group invitation::
        MessageID: NCJD-SJE7-VPY7-REZL-HCYI-2QWC-W2ZK
        To: alice@example.com From: alice@example.com
MessageID: NAFH-QPYP-5OAV-WXPX-RCKO-KIKS-RYJG
        Confirmation Request::
        MessageID: NAFH-QPYP-5OAV-WXPX-RCKO-KIKS-RYJG
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDAP-F3KS-HNFO-7I3L-2ZHA-IGKR-3RGZ
        Contact Request::
        MessageID: NDAP-F3KS-HNFO-7I3L-2ZHA-IGKR-3RGZ
        To: alice@example.com From: bob@example.com
        PIN: ADN6-CJ3X-KEFJ-BMMU-TKN3-J3JS-73ZA
<cmd>Alice> account sync /auto
<rsp>ERROR - An attempt was made to create an object with an existing obje
ct identifier
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> device complete
<rsp>   Device UDF = MBJ4-CDEK-6JA2-WGKY-4C2Z-VSYP-KOFM
   Account = alice@example.com
   Account UDF = MC6L-GFYJ-7EOP-2OWN-24ZJ-4RC7-EXTW
<cmd>Alice3> account sync
</div>
~~~~

>>>> Unfinished ArchitectureConnectPin/Connect.ConnectPINComplete



The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/ABYY-TYLH-XENK-57RH-6PMF-MAE2-JU
~~~~


