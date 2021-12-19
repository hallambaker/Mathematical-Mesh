
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> meshman message contact alice@example.com
<rsp>Envelope ID: MBQD-DFIE-ZKB4-XGV2-G27M-TRGD-ARXU
Message ID: NDRW-AINC-CW2Z-REBY-UILU-O2EI-MZPK
Response ID: MAD7-BJYO-IJHS-FQ26-ENSJ-2M6C-KVP4
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<rsp>ERROR - The entry already exists in the store.
<cmd>Alice> meshman message pending
<rsp>MessageID: NDRW-AINC-CW2Z-REBY-UILU-O2EI-MZPK
        Contact Request::
        MessageID: NDRW-AINC-CW2Z-REBY-UILU-O2EI-MZPK
        To: alice@example.com From: bob@example.com
        PIN: ADXO-VQ4V-WNRY-WD65-PHYE-GK2E-TWZQ
<cmd>Alice> meshman message accept NDRW-AINC-CW2Z-REBY-UILU-O2EI-MZPK
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT
  Person MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT
  Anchor MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT
  Address alice@example.com

Entry<CatalogedContact>: NDF5-DIN6-FBRI-UI2D-XLQF-SKWC-TCB5
  Person 
  Anchor MDBR-EJYT-5KJY-Z73B-IG7E-WFSN-MRKH
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> meshman account sync /auto
<cmd>Bob> meshman contact list
<rsp>Entry<CatalogedContact>: MDBR-EJYT-5KJY-Z73B-IG7E-WFSN-MRKH
  Person MDBR-EJYT-5KJY-Z73B-IG7E-WFSN-MRKH
  Anchor MDBR-EJYT-5KJY-Z73B-IG7E-WFSN-MRKH
  Address bob@example.com

Entry<CatalogedContact>: ND6B-4YRG-5CTV-HCSL-BZVM-EPPC-UKBZ
  Person 
  Anchor MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT
  Address alice@example.com

</div>
~~~~

