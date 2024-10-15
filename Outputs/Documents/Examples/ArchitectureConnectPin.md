
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=ADE7-U5DR-2YNJ-XKVX-4RUE-SVL5-5I
 (Expires=2024-10-15T13:10:56Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ADE7-U5DR-2YNJ-XKVX-4RUE-SVL5-5I
<rsp>   Device UDF = MBQD-CODE-XMWJ-QHE3-2KHZ-UKKF-TVVF
   Witness value = A6J3-EVU5-QGBM-WI4Z-HYUC-ONHP-O3VC
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: A6J3-EVU5-QGBM-WI4Z-HYUC-ONHP-O3VC
        Connection Request::
        MessageID: A6J3-EVU5-QGBM-WI4Z-HYUC-ONHP-O3VC
        To:  From: 
        Device:  MBQD-CODE-XMWJ-QHE3-2KHZ-UKKF-TVVF
        Witness: A6J3-EVU5-QGBM-WI4Z-HYUC-ONHP-O3VC
MessageID: NCX7-ADC5-L2CD-W5IY-SFT4-NX2U-XZQL
MessageID: NAZG-5KBV-D32X-O24L-XTYS-26GV-FC6Z
        Confirmation Request::
        MessageID: NAZG-5KBV-D32X-O24L-XTYS-26GV-FC6Z
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NANN-LZ5N-6AHO-AOBD-VD6I-X7C3-GJHY
MessageID: NBCN-N55H-QYZX-F2TB-U5R3-2T6B-5W47
MessageID: NDHA-E73C-WZUG-QCMR-5IPX-52JV-WYX6
<cmd>Alice> meshman account sync /auto
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MBQD-CODE-XMWJ-QHE3-2KHZ-UKKF-TVVF
   Account = alice@example.com
   Account UDF = MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
<cmd>Alice3> meshman account sync
</div>
~~~~

The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcd://alice@example.com/ADE7-U5DR-2YNJ-XKVX-4RUE-SVL5-5I
~~~~


