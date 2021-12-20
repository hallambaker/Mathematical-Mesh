
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> meshman message contact alice@example.com
<rsp>Envelope ID: MA3B-PQPI-JSKO-WF27-MZDL-S5U2-H2IQ
Message ID: NAHB-XJ7W-IEJY-NB4D-27UK-Y2HS-WPEA
Response ID: MDQQ-BUHB-2NZA-CB6U-KHQF-HFFT-43Y3
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<rsp>ERROR - The entry already exists in the store.
<cmd>Alice> meshman message pending
<rsp>MessageID: NAHB-XJ7W-IEJY-NB4D-27UK-Y2HS-WPEA
        Contact Request::
        MessageID: NAHB-XJ7W-IEJY-NB4D-27UK-Y2HS-WPEA
        To: alice@example.com From: bob@example.com
        PIN: AA3C-HQL4-JNCZ-BJTD-IVOS-G5KU-2YIA
<cmd>Alice> meshman message accept NAHB-XJ7W-IEJY-NB4D-27UK-Y2HS-WPEA
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ
  Person MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ
  Anchor MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ
  Address alice@example.com

Entry<CatalogedContact>: ND3C-FKIQ-OBU3-V4JR-DEKG-XMPY-TQMH
  Person 
  Anchor MCP6-3M76-EWWZ-BD3D-VAMF-HJ6X-H7A4
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> meshman account sync /auto
<cmd>Bob> meshman contact list
<rsp>Entry<CatalogedContact>: MCP6-3M76-EWWZ-BD3D-VAMF-HJ6X-H7A4
  Person MCP6-3M76-EWWZ-BD3D-VAMF-HJ6X-H7A4
  Anchor MCP6-3M76-EWWZ-BD3D-VAMF-HJ6X-H7A4
  Address bob@example.com

Entry<CatalogedContact>: NCOP-R344-ZFGL-KKVB-RRQD-FVQT-YDM6
  Person 
  Anchor MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ
  Address alice@example.com

</div>
~~~~

