
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=ADPP-WZ47-R74B-4IJV-G7QF-KLLQ-N4
 (Expires=2024-10-05T01:04:39Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ADPP-WZ47-R74B-4IJV-G7QF-KLLQ-N4
<rsp>   Device UDF = MBQJ-ZMG4-QN7C-E4AL-HPH6-FW26-JJVF
   Witness value = 7OEH-LCAH-B226-XXBQ-QDIQ-C35C-L4UV
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: 7OEH-LCAH-B226-XXBQ-QDIQ-C35C-L4UV
        Connection Request::
        MessageID: 7OEH-LCAH-B226-XXBQ-QDIQ-C35C-L4UV
        To:  From: 
        Device:  MBQJ-ZMG4-QN7C-E4AL-HPH6-FW26-JJVF
        Witness: 7OEH-LCAH-B226-XXBQ-QDIQ-C35C-L4UV
MessageID: NDN7-5NYH-LD43-4TCU-YJWW-Z37V-GYTG
MessageID: NDQ7-UANN-QSPT-CRYP-B4YY-4PNG-N2Z7
        Confirmation Request::
        MessageID: NDQ7-UANN-QSPT-CRYP-B4YY-4PNG-N2Z7
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NBJL-SNE5-XPQV-PO5I-RN52-SZHY-E4DZ
MessageID: NDCJ-UV2Z-2FNH-WOK3-46NP-M4PY-MMTJ
MessageID: NDIR-FXO6-NGSV-7UJL-5TOG-V3ON-2VPX
<cmd>Alice> meshman account sync /auto
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MBQJ-ZMG4-QN7C-E4AL-HPH6-FW26-JJVF
   Account = alice@example.com
   Account UDF = MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
<cmd>Alice3> meshman account sync
</div>
~~~~

The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcd://alice@example.com/ADPP-WZ47-R74B-4IJV-G7QF-KLLQ-N4
~~~~


