
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MBWV-RDDF-KQB6-JSM6-DMUK-BB6V-TLX3
Message ID: NDUB-2UQF-ABWX-FVM3-5BX6-XFEG-WNEB
Response ID: MCTT-4ZT7-ZHWF-P353-GWI2-K6UR-BESC
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NDUB-2UQF-ABWX-FVM3-5BX6-XFEG-WNEB
        Contact Request::
        MessageID: NDUB-2UQF-ABWX-FVM3-5BX6-XFEG-WNEB
        To: alice@example.com From: bob@example.com
        PIN: ADTM-XGIY-KTVA-CXXP-T64M-NUXC-A2OQ
<cmd>Alice> message accept NDUB-2UQF-ABWX-FVM3-5BX6-XFEG-WNEB
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MC76-AK7P-CEKP-ILKC-MEXU-EOIF-I6BF
  Person MC76-AK7P-CEKP-ILKC-MEXU-EOIF-I6BF
  Anchor MC76-AK7P-CEKP-ILKC-MEXU-EOIF-I6BF
  Address alice@example.com

Entry<CatalogedContact>: NDG3-OZI7-MBPS-732Y-6TFI-JXBL-XKNL
  Person 
  Anchor MDW6-RGRQ-BA3L-HTF4-55FK-Y65K-7QU6
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MDW6-RGRQ-BA3L-HTF4-55FK-Y65K-7QU6
  Person MDW6-RGRQ-BA3L-HTF4-55FK-Y65K-7QU6
  Anchor MDW6-RGRQ-BA3L-HTF4-55FK-Y65K-7QU6
  Address bob@example.com

Entry<CatalogedContact>: NDQ4-IISX-NLIW-534U-PZ54-2YAO-5DWZ
  Person 
  Anchor MC76-AK7P-CEKP-ILKC-MEXU-EOIF-I6BF
  Address alice@example.com

</div>
~~~~

