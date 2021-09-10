
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MATB-PHDI-GARK-UCDC-65RO-UVNC-XUXP
Message ID: NCZW-UFSX-UQMU-SW5X-TAFV-KWF4-XXDB
Response ID: MCQ3-6JO4-YZYF-ETDA-WXKH-AIDI-H2AJ
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NCZW-UFSX-UQMU-SW5X-TAFV-KWF4-XXDB
        Contact Request::
        MessageID: NCZW-UFSX-UQMU-SW5X-TAFV-KWF4-XXDB
        To: alice@example.com From: bob@example.com
        PIN: ABOJ-NTXJ-REOL-QJSE-4EHI-GKBM-Q6GQ
<cmd>Alice> message accept NCZW-UFSX-UQMU-SW5X-TAFV-KWF4-XXDB
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MC4H-QKW2-VZEE-MMJI-JFF2-FRFU-WYJA
  Person MC4H-QKW2-VZEE-MMJI-JFF2-FRFU-WYJA
  Anchor MC4H-QKW2-VZEE-MMJI-JFF2-FRFU-WYJA
  Address alice@example.com

Entry<CatalogedContact>: NAPK-TJ7N-D5NG-RGJK-Z4YU-YSTI-E4H5
  Person 
  Anchor MACS-YP3A-BO4N-53ZI-G7VT-WKBW-B3UP
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MACS-YP3A-BO4N-53ZI-G7VT-WKBW-B3UP
  Person MACS-YP3A-BO4N-53ZI-G7VT-WKBW-B3UP
  Anchor MACS-YP3A-BO4N-53ZI-G7VT-WKBW-B3UP
  Address bob@example.com

Entry<CatalogedContact>: NDES-25WZ-EGW5-COR2-OSUQ-XV2Y-F4BF
  Person 
  Anchor MC4H-QKW2-VZEE-MMJI-JFF2-FRFU-WYJA
  Address alice@example.com

</div>
~~~~

