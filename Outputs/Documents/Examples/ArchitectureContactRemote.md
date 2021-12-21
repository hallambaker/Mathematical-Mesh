
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> meshman message contact alice@example.com
<rsp>Envelope ID: MBD3-HVVY-FCMJ-FPHW-AYJB-ZTDN-EV25
Message ID: NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
Response ID: MDFD-KXCY-SQMH-TIUS-QREA-UFJQ-TTI2
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<rsp>ERROR - The entry already exists in the store.
<cmd>Alice> meshman message pending
<rsp>MessageID: NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
        Contact Request::
        MessageID: NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
        To: alice@example.com From: bob@example.com
        PIN: ACPD-YENT-3EM4-PUHD-D4Q4-4TX5-C25A
<cmd>Alice> meshman message accept NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Person MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Anchor MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Address alice@example.com

Entry<CatalogedContact>: NAQN-NQDL-LKHW-DY3U-QAFS-N2LW-6DHS
  Person 
  Anchor MCKB-VDWV-FXBV-ZEQC-62VO-UWU7-RKYC
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> meshman account sync /auto
<cmd>Bob> meshman contact list
<rsp>Entry<CatalogedContact>: MCKB-VDWV-FXBV-ZEQC-62VO-UWU7-RKYC
  Person MCKB-VDWV-FXBV-ZEQC-62VO-UWU7-RKYC
  Anchor MCKB-VDWV-FXBV-ZEQC-62VO-UWU7-RKYC
  Address bob@example.com

Entry<CatalogedContact>: NC3T-S6WY-N6BC-ZSTR-64FV-BZPG-N73A
  Person 
  Anchor MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Address alice@example.com

</div>
~~~~

