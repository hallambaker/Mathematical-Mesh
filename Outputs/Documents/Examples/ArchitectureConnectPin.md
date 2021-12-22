
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AAGV-IFMG-7JH7-VLYL-3PEB-PU4S-4E
 (Expires=2021-12-23T01:13:18Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AAGV-IFMG-7JH7-VLYL-3PEB-PU4S-4E
<rsp>   Device UDF = MC3V-V6L6-YHCW-26I5-XFE3-6WGR-BKVP
   Witness value = Q7CA-IZV4-BB7C-7CNA-TQKW-W5HC-GJ6W
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: Q7CA-IZV4-BB7C-7CNA-TQKW-W5HC-GJ6W
        Connection Request::
        MessageID: Q7CA-IZV4-BB7C-7CNA-TQKW-W5HC-GJ6W
        To:  From: 
        Device:  MC3V-V6L6-YHCW-26I5-XFE3-6WGR-BKVP
        Witness: Q7CA-IZV4-BB7C-7CNA-TQKW-W5HC-GJ6W
MessageID: NBNO-T2AC-LSGA-MRRH-JN3O-V4YQ-RJLQ
        Group invitation::
        MessageID: NBNO-T2AC-LSGA-MRRH-JN3O-V4YQ-RJLQ
        To: alice@example.com From: alice@example.com
MessageID: NCQL-ONQW-YLJE-NZ5P-2ENL-K5YY-3I4K
        Confirmation Request::
        MessageID: NCQL-ONQW-YLJE-NZ5P-2ENL-K5YY-3I4K
        To: alice@example.com From: console@example.com
        Text: start
MessageID: ND4S-KDPC-PUNU-4X3I-PTRT-LJSO-XGHV
        Contact Request::
        MessageID: ND4S-KDPC-PUNU-4X3I-PTRT-LJSO-XGHV
        To: alice@example.com From: bob@example.com
        PIN: AARR-TR4W-I3P2-Y5OF-KVMP-7KEJ-RVIQ
<cmd>Alice> meshman account sync /auto
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MC3V-V6L6-YHCW-26I5-XFE3-6WGR-BKVP
   Account = alice@example.com
   Account UDF = MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
<cmd>Alice3> meshman account sync
</div>
~~~~

The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/AAGV-IFMG-7JH7-VLYL-3PEB-PU4S-4E
~~~~


