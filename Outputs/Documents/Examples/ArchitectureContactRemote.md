
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MD3I-U2Q6-HG36-N4X2-WILG-MYQN-XONJ
Message ID: NB6T-VKNE-QYGF-J64L-26G5-7V3U-AD4K
Response ID: MD22-USLB-AFWU-SVAV-EYLU-J7WW-2K3Z
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NB6T-VKNE-QYGF-J64L-26G5-7V3U-AD4K
        Contact Request::
        MessageID: NB6T-VKNE-QYGF-J64L-26G5-7V3U-AD4K
        To: alice@example.com From: bob@example.com
        PIN: AAJA-GHQJ-OUO2-PNIC-XNGR-J3WH-G6MQ
<cmd>Alice> message accept NB6T-VKNE-QYGF-J64L-26G5-7V3U-AD4K
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MALV-QFP7-3VYX-IGEC-O5EN-QI5L-QZLC
  Person MALV-QFP7-3VYX-IGEC-O5EN-QI5L-QZLC
  Anchor MALV-QFP7-3VYX-IGEC-O5EN-QI5L-QZLC
  Address alice@example.com

Entry<CatalogedContact>: NDWR-HWEY-HTYS-OQTB-U3QU-B3RW-E7LK
  Person 
  Anchor MAYV-FBIH-7PDU-ROQB-FCJJ-CAV7-3YTC
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MAYV-FBIH-7PDU-ROQB-FCJJ-CAV7-3YTC
  Person MAYV-FBIH-7PDU-ROQB-FCJJ-CAV7-3YTC
  Anchor MAYV-FBIH-7PDU-ROQB-FCJJ-CAV7-3YTC
  Address bob@example.com

Entry<CatalogedContact>: NC5N-KFFS-FMMS-TQVV-LFTL-RYFU-S3IF
  Person 
  Anchor MALV-QFP7-3VYX-IGEC-O5EN-QI5L-QZLC
  Address alice@example.com

</div>
~~~~

