
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AASP-5A76-VKQO-CZZF-SQ6R-DQUU-2A
 (Expires=2024-10-04T14:57:13Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AASP-5A76-VKQO-CZZF-SQ6R-DQUU-2A
<rsp>   Device UDF = MBQN-RX3S-JAXD-GPDP-U3HD-PAOR-7ZVF
   Witness value = FIFD-IQCW-5UHI-F2H6-XMWU-ECYP-OOTA
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: FIFD-IQCW-5UHI-F2H6-XMWU-ECYP-OOTA
        Connection Request::
        MessageID: FIFD-IQCW-5UHI-F2H6-XMWU-ECYP-OOTA
        To:  From: 
        Device:  MBQN-RX3S-JAXD-GPDP-U3HD-PAOR-7ZVF
        Witness: FIFD-IQCW-5UHI-F2H6-XMWU-ECYP-OOTA
MessageID: NBHK-3QNB-UGZT-H5XN-2CXU-RIL7-XJZY
MessageID: NC75-ZYCL-N3BL-FVYI-TFSW-FFJV-DZHW
        Confirmation Request::
        MessageID: NC75-ZYCL-N3BL-FVYI-TFSW-FFJV-DZHW
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDYX-HZYP-X7E3-4UR4-LH7A-BQMT-PQXJ
MessageID: NDXB-RN25-2RVC-F3FL-FULX-GQNG-TAYB
MessageID: NCDS-JZQ5-N633-ZKWA-7U5I-6LNU-PFT5
<cmd>Alice> meshman account sync /auto
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MBQN-RX3S-JAXD-GPDP-U3HD-PAOR-7ZVF
   Account = alice@example.com
   Account UDF = MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
<cmd>Alice3> meshman account sync
</div>
~~~~

The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcd://alice@example.com/AASP-5A76-VKQO-CZZF-SQ6R-DQUU-2A
~~~~


