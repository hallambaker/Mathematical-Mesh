
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MC3E-JGEX-72TG-D2JO-HOGP-VPWW-CAQ5
Message ID: NDLP-RO33-65BJ-3G7X-AOXN-JK2U-WUIE
Response ID: MAZW-HYH5-RVBT-NU2Z-LFKJ-GSUZ-UZC5
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NDLP-RO33-65BJ-3G7X-AOXN-JK2U-WUIE
        Contact Request::
        MessageID: NDLP-RO33-65BJ-3G7X-AOXN-JK2U-WUIE
        To: alice@example.com From: bob@example.com
        PIN: AAHV-O6T4-RDMH-UMSR-GMKP-KAQI-WASA
<cmd>Alice> message accept NDLP-RO33-65BJ-3G7X-AOXN-JK2U-WUIE
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MCVL-63JV-H35G-USOR-72YS-YWVV-UHNF
  Person MCVL-63JV-H35G-USOR-72YS-YWVV-UHNF
  Anchor MCVL-63JV-H35G-USOR-72YS-YWVV-UHNF
  Address alice@example.com

Entry<CatalogedContact>: NBPY-VZOJ-6GJU-XQ2O-M3PY-THU7-HFN7
  Person 
  Anchor MCZ4-PRGF-LNVF-FRQM-GB4I-OTVB-BXP6
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MCZ4-PRGF-LNVF-FRQM-GB4I-OTVB-BXP6
  Person MCZ4-PRGF-LNVF-FRQM-GB4I-OTVB-BXP6
  Anchor MCZ4-PRGF-LNVF-FRQM-GB4I-OTVB-BXP6
  Address bob@example.com

Entry<CatalogedContact>: NBGE-BSGS-QUWY-4SVT-EQIB-EJIG-L2SX
  Person 
  Anchor MCVL-63JV-H35G-USOR-72YS-YWVV-UHNF
  Address alice@example.com

</div>
~~~~

