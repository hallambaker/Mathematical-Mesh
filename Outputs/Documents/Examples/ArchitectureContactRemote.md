
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> meshman message contact alice@example.com
<rsp>Envelope ID: MCF6-GIQS-7NEL-33NP-DQ26-JPS3-4FYC
Message ID: NDVI-PIPP-B7UB-SI6M-LGQR-TBSK-DLRR
Response ID: MDMH-QI6E-CPYZ-GNR2-IDFI-Y5PB-N6DY
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<rsp>ERROR - The entry already exists in the store.
<cmd>Alice> meshman message pending
<rsp>MessageID: NDVI-PIPP-B7UB-SI6M-LGQR-TBSK-DLRR
        Contact Request::
        MessageID: NDVI-PIPP-B7UB-SI6M-LGQR-TBSK-DLRR
        To: alice@example.com From: bob@example.com
        PIN: ABBR-7XTR-EMOF-HDSS-K34R-YQSW-VEJQ
<cmd>Alice> meshman message accept NDVI-PIPP-B7UB-SI6M-LGQR-TBSK-DLRR
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MDMG-5KJT-SFQQ-EE3U-GZAK-CEGV-5GR2
  Person MDMG-5KJT-SFQQ-EE3U-GZAK-CEGV-5GR2
  Anchor MDMG-5KJT-SFQQ-EE3U-GZAK-CEGV-5GR2
  Address alice@example.com

Entry<CatalogedContact>: NB7N-IA5V-3P3V-CEOT-CZ6A-6IBH-PBJX
  Person 
  Anchor MCUJ-WLPM-A36E-QJKH-DTE6-KLPP-MUVD
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> meshman account sync /auto
<cmd>Bob> meshman contact list
<rsp>Entry<CatalogedContact>: MCUJ-WLPM-A36E-QJKH-DTE6-KLPP-MUVD
  Person MCUJ-WLPM-A36E-QJKH-DTE6-KLPP-MUVD
  Anchor MCUJ-WLPM-A36E-QJKH-DTE6-KLPP-MUVD
  Address bob@example.com

Entry<CatalogedContact>: NBHU-YRMX-RWCL-J3NM-Y5B5-P3JV-JM45
  Person 
  Anchor MDMG-5KJT-SFQQ-EE3U-GZAK-CEGV-5GR2
  Address alice@example.com

</div>
~~~~

