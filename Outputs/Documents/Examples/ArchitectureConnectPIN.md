The PIN connection mechanism begins with the issue of the PIN:


~~~~
<div="terminal">
<cmd>Alice> account pin
<rsp>PIN=ABC6-I3XB-KBEG-CEW2-XZOH-VSFH-KGNQ (Expires=2020-09-23T13:13:00Z)
</div>
~~~~

The PIN code is transmitted out of band to the device being connected:


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin=ABC6-I3XB-KBEG-CEW2-XZOH-VSFH-KGNQ
<rsp>ERROR - The requested cryptographic operation is not supported
</div>
~~~~

Since the request was pre-authorized, it is not necessary for Alice to explicitly
accept the connection request but the administration device is needed to create
the connection assertion:

**Missing Example***

We can check the device connection by attempting to synchronize to the profile account:

**Missing Example***

Note that this connection mechanism could be adapted to allow a device with a 
camera affordance to connect by scanning a QR code on the administration device.
