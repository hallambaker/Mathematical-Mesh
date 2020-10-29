The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MBJ2-BSQX-LXIM-3UP2-KZ34-IPHS-RGJ6
   Witness value = 5IMG-XHYT-AO4R-3MTT-QGSZ-4KNH-RXSR
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts it:


~~~~
<div="terminal">
<cmd>Alice> account sync /auto
<rsp><cmd>Alice> device accept 5IMG-XHYT-AO4R-3MTT-QGSZ-4KNH-RXSR
<rsp></div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp></div>
~~~~


