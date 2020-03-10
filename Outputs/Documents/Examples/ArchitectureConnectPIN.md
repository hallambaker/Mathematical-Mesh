The PIN connection mechanism begins with the issue of the PIN:


~~~~
<div="terminal">
<cmd>Alice> account pin
<rsp>PIN=NCGD-ZOQL-JRVF-TALA-EY (Expires=2020-01-23T01:18:57Z)
</div>
~~~~

The PIN code is transmitted out of band to the device being connected:


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin=NCGD-ZOQL-JRVF-TALA-EY
<rsp>   Witness value = XNLM-MOF2-KNZS-3HCO-WOEO-BOTN-Y6G2
   Personal Mesh = MDKD-XTUR-GFP4-QD52-STNB-Q7GS-MEWW
</div>
~~~~

Since the request was pre-authorized, it is not necessary for Alice to explicitly
accept the connection request but the administration device is needed to create
the connection assertion:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp></div>
~~~~

We can check the device connection by attempting to synchronize to the profile account:


~~~~
<div="terminal">
<cmd>Alice3> account sync
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

Note that this connection mechanism could be adapted to allow a device with a 
camera affordance to connect by scanning a QR code on the administration device.
