
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AC6L-KOKA-W62V-54R5-MU2D-KZVP-OA
 (Expires=2021-12-21T14:00:30Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AC6L-KOKA-W62V-54R5-MU2D-KZVP-OA
<rsp>   Device UDF = MDEH-DBMY-63NX-TNKW-NRWT-ON6M-EOMJ
   Witness value = 6PSU-AAB3-LGXS-E6ON-75LU-4LFP-YPNN
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: 6PSU-AAB3-LGXS-E6ON-75LU-4LFP-YPNN
        Connection Request::
        MessageID: 6PSU-AAB3-LGXS-E6ON-75LU-4LFP-YPNN
        To:  From: 
        Device:  MDEH-DBMY-63NX-TNKW-NRWT-ON6M-EOMJ
        Witness: 6PSU-AAB3-LGXS-E6ON-75LU-4LFP-YPNN
MessageID: NBLB-D3DX-6Z6Z-PQCS-4NEO-RQGQ-HQUL
        Group invitation::
        MessageID: NBLB-D3DX-6Z6Z-PQCS-4NEO-RQGQ-HQUL
        To: alice@example.com From: alice@example.com
MessageID: NDI6-772L-UUBU-RIFV-S5GM-3B3J-4LFV
        Confirmation Request::
        MessageID: NDI6-772L-UUBU-RIFV-S5GM-3B3J-4LFV
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NAHB-XJ7W-IEJY-NB4D-27UK-Y2HS-WPEA
        Contact Request::
        MessageID: NAHB-XJ7W-IEJY-NB4D-27UK-Y2HS-WPEA
        To: alice@example.com From: bob@example.com
        PIN: AA3C-HQL4-JNCZ-BJTD-IVOS-G5KU-2YIA
<cmd>Alice> meshman account sync /auto
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MDEH-DBMY-63NX-TNKW-NRWT-ON6M-EOMJ
   Account = alice@example.com
   Account UDF = MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ
<cmd>Alice3> meshman account sync
</div>
~~~~

The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/AC6L-KOKA-W62V-54R5-MU2D-KZVP-OA
~~~~


