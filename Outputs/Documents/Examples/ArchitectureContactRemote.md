
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> meshman contact request alice@example.com
<rsp>Envelope ID: MDN4-KZU4-YSH5-HFIZ-7Y5K-TKXM-TLRE
Message ID: NAJJ-X5FX-POHN-TTR4-3TXK-KTE7-3KKM
Response ID: MANS-AVVY-VD36-MFEX-3XUR-PPTU-KSPD
</div>
~~~~

Alice checks her Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: ND6M-OIPE-KYSW-HJCU-C6VY-XXBC-BCKU
        Contact Request::
        MessageID: ND6M-OIPE-KYSW-HJCU-C6VY-XXBC-BCKU
        To: alice@example.com From: mallet@example.com
        PIN: AB5G-ONJA-7REW-O3HH-XGTD-N47M-TPQQ
MessageID: NAJJ-X5FX-POHN-TTR4-3TXK-KTE7-3KKM
        Contact Request::
        MessageID: NAJJ-X5FX-POHN-TTR4-3TXK-KTE7-3KKM
        To: alice@example.com From: bob@example.com
        PIN: AB3A-ETHW-4RGL-GEYG-KEAP-TLEM-UKDQ
MessageID: NDHA-E73C-WZUG-QCMR-5IPX-52JV-WYX6
<cmd>Alice> meshman message accept NAJJ-X5FX-POHN-TTR4-3TXK-KTE7-3KKM
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
  Person MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
  Anchor MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
  Address alice@example.com

Entry<CatalogedContact>: NCUE-TSMR-TL3E-7MV6-N3KA-YQX3-UTZ4
  Person 
  Anchor MBQM-MRAS-TBEC-OOLM-NPQY-XF7O-KQME
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> meshman account sync /auto
<cmd>Bob> meshman contact list
<rsp>Entry<CatalogedContact>: MBQM-MRAS-TBEC-OOLM-NPQY-XF7O-KQME
  Person MBQM-MRAS-TBEC-OOLM-NPQY-XF7O-KQME
  Anchor MBQM-MRAS-TBEC-OOLM-NPQY-XF7O-KQME
  Address bob@example.com

Entry<CatalogedContact>: NCSB-DVZI-I7SI-A5WV-ORSG-XNQX-43WZ
  Person 
  Anchor MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
  Address alice@example.com

</div>
~~~~

