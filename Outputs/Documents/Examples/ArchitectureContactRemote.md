
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MDXG-SC5K-B2PX-Z3AH-QJUI-GXI7-S2NE
Message ID: NB7Z-24IW-YLG5-ZONC-GWT6-43K7-ZPFL
Response ID: MDCM-BBMD-MNW4-WMUG-DFTV-2LYH-D5PS
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NB7Z-24IW-YLG5-ZONC-GWT6-43K7-ZPFL
        Contact Request::
        MessageID: NB7Z-24IW-YLG5-ZONC-GWT6-43K7-ZPFL
        To: alice@example.com From: bob@example.com
        PIN: ADCF-LIYR-CTIO-2GOV-G54I-FZ7Q-AUPQ
<cmd>Alice> message accept NB7Z-24IW-YLG5-ZONC-GWT6-43K7-ZPFL
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MCK5-26MC-Q726-YY6I-AJJZ-Z2YA-IAIE
  Person MCK5-26MC-Q726-YY6I-AJJZ-Z2YA-IAIE
  Anchor MCK5-26MC-Q726-YY6I-AJJZ-Z2YA-IAIE
  Address alice@example.com

Entry<CatalogedContact>: NBOX-QDL7-OWRM-27UO-DVS5-K2R2-Z3F7
  Person 
  Anchor MDCG-AXYY-6WFD-VXUG-KIUZ-KJYD-WAMO
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MDCG-AXYY-6WFD-VXUG-KIUZ-KJYD-WAMO
  Person MDCG-AXYY-6WFD-VXUG-KIUZ-KJYD-WAMO
  Anchor MDCG-AXYY-6WFD-VXUG-KIUZ-KJYD-WAMO
  Address bob@example.com

Entry<CatalogedContact>: NA6F-5IM4-34WC-PENY-L4QR-DN6I-UJAT
  Person 
  Anchor MCK5-26MC-Q726-YY6I-AJJZ-Z2YA-IAIE
  Address alice@example.com

</div>
~~~~

