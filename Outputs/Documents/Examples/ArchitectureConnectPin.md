
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AA6O-HPNP-PHTZ-7VF7-XTNB-HK3C-3M
 (Expires=2021-12-19T01:57:23Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AA6O-HPNP-PHTZ-7VF7-XTNB-HK3C-3M
<rsp>   Device UDF = MBVU-4YRX-NVFN-MH2G-QN7O-7ZYF-ARRH
   Witness value = IDQO-ZPKU-CPW3-4CBQ-TIQJ-CTAZ-E6MO
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: IDQO-ZPKU-CPW3-4CBQ-TIQJ-CTAZ-E6MO
        Connection Request::
        MessageID: IDQO-ZPKU-CPW3-4CBQ-TIQJ-CTAZ-E6MO
        To:  From: 
        Device:  MBVU-4YRX-NVFN-MH2G-QN7O-7ZYF-ARRH
        Witness: IDQO-ZPKU-CPW3-4CBQ-TIQJ-CTAZ-E6MO
MessageID: NDZE-G3GP-G45D-WAOM-SXOH-24EC-JED2
        Group invitation::
        MessageID: NDZE-G3GP-G45D-WAOM-SXOH-24EC-JED2
        To: alice@example.com From: alice@example.com
MessageID: NDLR-BUDO-M7WU-JBTA-W4G2-AAOU-4NJB
        Confirmation Request::
        MessageID: NDLR-BUDO-M7WU-JBTA-W4G2-AAOU-4NJB
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDCL-O2LD-ODCU-MB2I-6EY3-RXRR-OSSK
        Contact Request::
        MessageID: NDCL-O2LD-ODCU-MB2I-6EY3-RXRR-OSSK
        To: alice@example.com From: bob@example.com
        PIN: AB3F-U7X5-Q2PE-ESFS-S2PH-7AGC-TKBA
<cmd>Alice> meshman account sync /auto
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MBVU-4YRX-NVFN-MH2G-QN7O-7ZYF-ARRH
   Account = alice@example.com
   Account UDF = MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
<cmd>Alice3> meshman account sync
</div>
~~~~

The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/AA6O-HPNP-PHTZ-7VF7-XTNB-HK3C-3M
~~~~


