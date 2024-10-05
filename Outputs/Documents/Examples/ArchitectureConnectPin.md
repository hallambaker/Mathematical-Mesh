
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AA34-4UB6-2FPH-KPT6-JNTU-PNWR-MU
 (Expires=2024-10-06T00:49:11Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AA34-4UB6-2FPH-KPT6-JNTU-PNWR-MU
<rsp>   Device UDF = MBQB-VIJP-5XSD-4LQL-R6VP-DRGB-T2TU
   Witness value = F7X6-DDMV-2X7D-3KQ7-GW55-ES6F-WZAC
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: F7X6-DDMV-2X7D-3KQ7-GW55-ES6F-WZAC
        Connection Request::
        MessageID: F7X6-DDMV-2X7D-3KQ7-GW55-ES6F-WZAC
        To:  From: 
        Device:  MBQB-VIJP-5XSD-4LQL-R6VP-DRGB-T2TU
        Witness: F7X6-DDMV-2X7D-3KQ7-GW55-ES6F-WZAC
MessageID: NDW4-S5EU-3BER-BTL2-EA2D-C4LL-TKLA
MessageID: NBUX-DOPM-JJKG-NKMV-K24G-MX24-4QNW
        Confirmation Request::
        MessageID: NBUX-DOPM-JJKG-NKMV-K24G-MX24-4QNW
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NA2W-XWGB-F4LB-MUSW-MC4I-YK2G-GAJT
MessageID: NBTZ-WSA2-2OFC-QMTP-LA2D-FMRE-P4N5
MessageID: ND2F-I3BZ-645E-OSBR-Z5NI-MIUG-4IRN
<cmd>Alice> meshman account sync /auto
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MBQB-VIJP-5XSD-4LQL-R6VP-DRGB-T2TU
   Account = alice@example.com
   Account UDF = MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
<cmd>Alice3> meshman account sync
</div>
~~~~

The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcd://alice@example.com/AA34-4UB6-2FPH-KPT6-JNTU-PNWR-MU
~~~~


