
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MBTY-PIFM-RJUU-3VHR-LXIC-5Y7W-SSBG
Message ID: NBPI-ULGE-MSPK-FUE2-CBDB-WTNY-NJDZ
Response ID: MA45-EX4L-C4TT-6NDI-MZLB-PFVT-XIWD
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NBPI-ULGE-MSPK-FUE2-CBDB-WTNY-NJDZ
        Contact Request::
        MessageID: NBPI-ULGE-MSPK-FUE2-CBDB-WTNY-NJDZ
        To: alice@example.com From: bob@example.com
        PIN: ADHF-R2A7-SV2S-XUBQ-C7CU-HA6Y-JBVA
<cmd>Alice> message accept NBPI-ULGE-MSPK-FUE2-CBDB-WTNY-NJDZ
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MAMU-5QXP-TWCD-7PKI-S4FC-IB76-XASH
  Person MAMU-5QXP-TWCD-7PKI-S4FC-IB76-XASH
  Anchor MAMU-5QXP-TWCD-7PKI-S4FC-IB76-XASH
  Address alice@example.com

Entry<CatalogedContact>: NCU6-4E2P-OWZA-FGNT-VNM3-5HCJ-BQ43
  Person 
  Anchor MBQT-IL32-SE7H-T7RZ-E52B-TQ2F-XVLE
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MBQT-IL32-SE7H-T7RZ-E52B-TQ2F-XVLE
  Person MBQT-IL32-SE7H-T7RZ-E52B-TQ2F-XVLE
  Anchor MBQT-IL32-SE7H-T7RZ-E52B-TQ2F-XVLE
  Address bob@example.com

Entry<CatalogedContact>: NARL-BULF-5F5W-ZN3K-F6ZN-LB5J-HWIW
  Person 
  Anchor MAMU-5QXP-TWCD-7PKI-S4FC-IB76-XASH
  Address alice@example.com

</div>
~~~~

