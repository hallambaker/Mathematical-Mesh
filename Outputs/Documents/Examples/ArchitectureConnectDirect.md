The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> meshman device request alice@example.com
<rsp>   Device UDF = MAXM-R5FC-HCN2-VPVJ-L7LS-5EKA-HUVI
   Witness value = 5OII-G3NN-GOND-ZHBV-DYO4-4T35-UVY5
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> meshman device pending
<rsp>MessageID: 5OII-G3NN-GOND-ZHBV-DYO4-4T35-UVY5
        Connection Request::
        MessageID: 5OII-G3NN-GOND-ZHBV-DYO4-4T35-UVY5
        To:  From: 
        Device:  MAXM-R5FC-HCN2-VPVJ-L7LS-5EKA-HUVI
        Witness: 5OII-G3NN-GOND-ZHBV-DYO4-4T35-UVY5
<cmd>Alice> meshman device accept 5OII-G3NN-GOND-ZHBV-DYO4-4T35-UVY5 ^
    /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> meshman device complete
<rsp>   Device UDF = MAXM-R5FC-HCN2-VPVJ-L7LS-5EKA-HUVI
   Account = alice@example.com
   Account UDF = MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
</div>
~~~~


