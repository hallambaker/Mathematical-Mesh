The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MCXT-GUKN-732Q-H7M2-DMWR-TC7Q-MV5W
   Witness value = VKKR-APMX-XGSX-GQYZ-MDK2-FG37-23YG
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts it:


~~~~
<div="terminal">
<cmd>Alice> account sync /auto
<rsp>ERROR - Cannot access a closed file.
<cmd>Alice> device accept VKKR-APMX-XGSX-GQYZ-MDK2-FG37-23YG
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
</div>
~~~~


