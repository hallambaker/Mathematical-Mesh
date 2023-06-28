
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AAKI-IIAD-GQ3H-JUY3-SXZN-PENW-PQ
 (Expires=2023-06-29T17:00:45Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AAKI-IIAD-GQ3H-JUY3-SXZN-PENW-PQ
<rsp>   Device UDF = MBXV-SIBF-4XEW-4EVE-7URW-F6VT-NTX3
   Witness value = GSJR-OHU5-HHXO-KURY-ST4B-HVBA-7PV5
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: GSJR-OHU5-HHXO-KURY-ST4B-HVBA-7PV5
        Connection Request::
        MessageID: GSJR-OHU5-HHXO-KURY-ST4B-HVBA-7PV5
        To:  From: 
        Device:  MBXV-SIBF-4XEW-4EVE-7URW-F6VT-NTX3
        Witness: GSJR-OHU5-HHXO-KURY-ST4B-HVBA-7PV5
MessageID: NCUD-3ROZ-X7UK-MMRA-CTYI-YHOE-UJCM
MessageID: NDTU-IIPR-L5SK-L6CZ-JJGF-XA6L-565H
        Confirmation Request::
        MessageID: NDTU-IIPR-L5SK-L6CZ-JJGF-XA6L-565H
        To: alice@example.com From: console@example.com
        Text: start
MessageID: ND4Y-TGCW-2QO3-KIQM-N3AN-DMIO-2CFT
MessageID: NCVI-FDFU-ZYPN-5274-YBHY-V6WI-FTEJ
MessageID: NA7V-2XT2-2ZJO-IDUY-GK6W-CTVX-HDDM
<cmd>Alice> meshman account sync /auto
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MBXV-SIBF-4XEW-4EVE-7URW-F6VT-NTX3
   Account = alice@example.com
   Account UDF = MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
<cmd>Alice3> meshman account sync
</div>
~~~~

The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/AAKI-IIAD-GQ3H-JUY3-SXZN-PENW-PQ
~~~~


