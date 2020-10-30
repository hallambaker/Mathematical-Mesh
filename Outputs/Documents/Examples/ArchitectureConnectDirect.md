The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MALK-ULVB-SR7D-ZOYG-ESI6-RU66-P67T
   Witness value = MXDW-JQRU-TDYN-AJHK-XHF7-XQCW-EWNJ
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts it:


~~~~
<div="terminal">
<cmd>Alice> account sync /auto
<cmd>Alice> device accept MXDW-JQRU-TDYN-AJHK-XHF7-XQCW-EWNJ
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
</div>
~~~~


