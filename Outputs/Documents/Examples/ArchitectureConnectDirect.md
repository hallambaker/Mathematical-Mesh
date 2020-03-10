The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Witness value = M4J5-YPNB-2O3U-35FZ-PC6G-SP6R-4LBD
   Personal Mesh = MDKD-XTUR-GFP4-QD52-STNB-Q7GS-MEWW
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts it:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp><cmd>Alice> device accept NCGP-WWTX-4HDR-YR2I-N5DO-TYBJ-C4X7
<rsp></div>
~~~~

The new device will now synchronize automatically in response to any Mesh commands. For example, 
listing the password catalog:


~~~~
<div="terminal">
<cmd>Alice2> password list
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~
