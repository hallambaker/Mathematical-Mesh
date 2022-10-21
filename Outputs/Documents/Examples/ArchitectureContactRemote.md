
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> meshman contact request alice@example.com
<rsp>Envelope ID: MA6Z-6YGY-7TJB-CADG-SZN3-Q6IS-6BHF
Message ID: NDRX-MOGE-HQ5D-FZHD-R42W-2U6V-OTKD
Response ID: MCN2-CAZY-X3PZ-673C-QCYR-MIQ5-TAHN
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: NBDK-G2OV-7H3S-BO6N-NXUZ-3PE6-ZNE4
        Contact Request::
        MessageID: NBDK-G2OV-7H3S-BO6N-NXUZ-3PE6-ZNE4
        To: alice@example.com From: mallet@example.com
        PIN: ACRO-GLXA-VJ3P-4CZ2-KQRO-J3LU-TESA
MessageID: NDRX-MOGE-HQ5D-FZHD-R42W-2U6V-OTKD
        Contact Request::
        MessageID: NDRX-MOGE-HQ5D-FZHD-R42W-2U6V-OTKD
        To: alice@example.com From: bob@example.com
        PIN: ABMH-MBQP-GX34-A7AG-ZEOL-R4XO-VGYQ
<cmd>Alice> meshman message accept NDRX-MOGE-HQ5D-FZHD-R42W-2U6V-OTKD
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
  Person MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
  Anchor MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
  Address alice@example.com

Entry<CatalogedContact>: NBL7-CLVR-MT2M-EWR5-U2NY-NWEN-IF7S
  Person 
  Anchor MDLP-RRZJ-ZASG-GUBZ-PP2K-5YDH-EMGE
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> meshman account sync /auto
<cmd>Bob> meshman contact list
<rsp>Entry<CatalogedContact>: MDLP-RRZJ-ZASG-GUBZ-PP2K-5YDH-EMGE
  Person MDLP-RRZJ-ZASG-GUBZ-PP2K-5YDH-EMGE
  Anchor MDLP-RRZJ-ZASG-GUBZ-PP2K-5YDH-EMGE
  Address bob@example.com

Entry<CatalogedContact>: NCCQ-N3CB-4ZV2-M2DT-QQ7P-P3EF-65PM
  Person 
  Anchor MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
  Address alice@example.com

</div>
~~~~

