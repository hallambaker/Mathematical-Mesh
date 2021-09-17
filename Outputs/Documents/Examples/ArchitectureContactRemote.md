
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MCNE-VXJD-6MWE-M4PA-6B3Y-HCXL-JOOG
Message ID: NA26-HGSS-F7RE-HYCI-C6Q6-QXH3-3F2Y
Response ID: MBUJ-SEBG-2OQN-RMMA-7OZN-WZTX-PJGL
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NA26-HGSS-F7RE-HYCI-C6Q6-QXH3-3F2Y
        Contact Request::
        MessageID: NA26-HGSS-F7RE-HYCI-C6Q6-QXH3-3F2Y
        To: alice@example.com From: bob@example.com
        PIN: ACV3-IW65-7QKN-PSNO-VKGG-OCY6-3GSQ
<cmd>Alice> message accept NA26-HGSS-F7RE-HYCI-C6Q6-QXH3-3F2Y
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MBRN-NNZS-FIXI-NTAZ-YPVO-HKTD-RJ5I
  Person MBRN-NNZS-FIXI-NTAZ-YPVO-HKTD-RJ5I
  Anchor MBRN-NNZS-FIXI-NTAZ-YPVO-HKTD-RJ5I
  Address alice@example.com

Entry<CatalogedContact>: NALD-TUQX-H4CH-6NQO-DJOR-O5SC-M56I
  Person 
  Anchor MBQS-CUW3-IKDK-6OQI-24RL-RUNZ-NKPE
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MBQS-CUW3-IKDK-6OQI-24RL-RUNZ-NKPE
  Person MBQS-CUW3-IKDK-6OQI-24RL-RUNZ-NKPE
  Anchor MBQS-CUW3-IKDK-6OQI-24RL-RUNZ-NKPE
  Address bob@example.com

Entry<CatalogedContact>: NAUF-32L6-UMSI-X5ML-E24G-NEDX-FE2H
  Person 
  Anchor MBRN-NNZS-FIXI-NTAZ-YPVO-HKTD-RJ5I
  Address alice@example.com

</div>
~~~~

