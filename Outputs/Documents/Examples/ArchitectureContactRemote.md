
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MAZX-PGH6-XAE7-CQDC-LALO-KXRY-76VD
Message ID: NB4I-C26A-FD2I-D4ZE-I4A7-M7Z6-PKYZ
Response ID: MDIC-JAJT-EDME-F7K6-PFMH-VM26-LGIG
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NB4I-C26A-FD2I-D4ZE-I4A7-M7Z6-PKYZ
        Contact Request::
        MessageID: NB4I-C26A-FD2I-D4ZE-I4A7-M7Z6-PKYZ
        To: alice@example.com From: bob@example.com
        PIN: ABJX-H7QL-VGNH-XG6C-VMPZ-TVUP-HN3Q
<cmd>Alice> message accept NB4I-C26A-FD2I-D4ZE-I4A7-M7Z6-PKYZ
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MD7M-NMJY-4SVX-PMOD-T6FN-2LTV-DUEL
  Person MD7M-NMJY-4SVX-PMOD-T6FN-2LTV-DUEL
  Anchor MD7M-NMJY-4SVX-PMOD-T6FN-2LTV-DUEL
  Address alice@example.com

Entry<CatalogedContact>: NDOU-LZKM-Q2EA-6MTB-JXLG-4X4W-7VLE
  Person 
  Anchor MB3W-WRGO-CXQU-UQRZ-Z74H-XBMY-DIZ2
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MB3W-WRGO-CXQU-UQRZ-Z74H-XBMY-DIZ2
  Person MB3W-WRGO-CXQU-UQRZ-Z74H-XBMY-DIZ2
  Anchor MB3W-WRGO-CXQU-UQRZ-Z74H-XBMY-DIZ2
  Address bob@example.com

Entry<CatalogedContact>: NC37-JDVR-4B4Y-2AP4-MBZR-AG25-KDDE
  Person 
  Anchor MD7M-NMJY-4SVX-PMOD-T6FN-2LTV-DUEL
  Address alice@example.com

</div>
~~~~

