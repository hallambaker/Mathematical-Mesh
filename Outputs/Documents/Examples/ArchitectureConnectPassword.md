The PIN connection mechanism begins with the issue of the PIN:


~~~~
<div="terminal">
<cmd>Alice> account pin
<rsp>PIN=AALX-QHTR-6PES-ETQG-6DRX-GRZD-OMXP (Expires=2020-10-22T13:01:08Z)
</div>
~~~~

The PIN code is transmitted out of band to the device being connected:


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin=AALX-QHTR-6PES-ETQG-6DRX-GRZD-OMXP
<rsp>   Device UDF = MDT6-A7UT-XV63-4BH6-4733-5FNK-KLL4
   Witness value = GXMK-KTQ7-BBGB-TXSP-A5YE-WHGH-UKMC
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
