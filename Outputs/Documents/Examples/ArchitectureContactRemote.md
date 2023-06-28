
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> meshman contact request alice@example.com
<rsp>Envelope ID: MAE2-VMU3-PDAH-HZX7-CGYV-75XQ-Z4EA
Message ID: NAQL-6SJP-VLQD-7BNN-EB6L-DLQQ-K2ZE
Response ID: MDNG-ME2U-6X4T-FEVR-46MH-2RLM-WCOP
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: ND2G-PHUE-PLPY-QAPP-UU6P-BAXW-EOBS
        Contact Request::
        MessageID: ND2G-PHUE-PLPY-QAPP-UU6P-BAXW-EOBS
        To: alice@example.com From: mallet@example.com
        PIN: ACGN-LZXP-H2WB-R5UE-VGMF-VGQD-AR5Q
MessageID: NAQL-6SJP-VLQD-7BNN-EB6L-DLQQ-K2ZE
        Contact Request::
        MessageID: NAQL-6SJP-VLQD-7BNN-EB6L-DLQQ-K2ZE
        To: alice@example.com From: bob@example.com
        PIN: AAAZ-RZSW-ZMBI-A6R6-WTPY-INAA-OZLQ
MessageID: NA7V-2XT2-2ZJO-IDUY-GK6W-CTVX-HDDM
<cmd>Alice> meshman message accept NAQL-6SJP-VLQD-7BNN-EB6L-DLQQ-K2ZE
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Person MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Anchor MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Address alice@example.com

Entry<CatalogedContact>: NCIO-3ZRE-NYUC-XRNS-CDLI-HL42-EDBR
  Person 
  Anchor MDCR-A2UE-SKQA-3HBF-YFO6-VQ6H-E72X
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> meshman account sync /auto
<cmd>Bob> meshman contact list
<rsp>Entry<CatalogedContact>: MDCR-A2UE-SKQA-3HBF-YFO6-VQ6H-E72X
  Person MDCR-A2UE-SKQA-3HBF-YFO6-VQ6H-E72X
  Anchor MDCR-A2UE-SKQA-3HBF-YFO6-VQ6H-E72X
  Address bob@example.com

Entry<CatalogedContact>: ND4G-SEV3-KQ5B-U4F4-YXHC-JUVK-EO73
  Person 
  Anchor MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Address alice@example.com

</div>
~~~~

