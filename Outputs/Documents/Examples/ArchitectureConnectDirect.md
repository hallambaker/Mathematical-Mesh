The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MAQP-HB2X-RGPO-MKXO-B5DS-2JPE-SWRI
   Witness value = Z2WF-HACS-FSGQ-RCRD-O7CI-5OJX-ESD7
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: Z2WF-HACS-FSGQ-RCRD-O7CI-5OJX-ESD7
        Connection Request::
        MessageID: Z2WF-HACS-FSGQ-RCRD-O7CI-5OJX-ESD7
        To:  From: 
        Device:  MAQP-HB2X-RGPO-MKXO-B5DS-2JPE-SWRI
        Witness: Z2WF-HACS-FSGQ-RCRD-O7CI-5OJX-ESD7
<cmd>Alice> device accept Z2WF-HACS-FSGQ-RCRD-O7CI-5OJX-ESD7 /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MAQP-HB2X-RGPO-MKXO-B5DS-2JPE-SWRI
   Account = alice@example.com
   Account UDF = MB45-LKLC-XVV6-2KDX-UX3D-D6IR-6GNN
</div>
~~~~


