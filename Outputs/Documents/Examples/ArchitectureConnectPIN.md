The PIN connection mechanism begins with the issue of the PIN:


~~~~
<div="terminal">
<cmd>Alice> account pin
<rsp>PIN=ABR4-YOVV-74YV-FW3W-G4MB-H4YZ-QEFP (Expires=2020-07-29T15:49:05Z)
</div>
~~~~

The PIN code is transmitted out of band to the device being connected:


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin=ABR4-YOVV-74YV-FW3W-G4MB-H4YZ-QEFP
<rsp>ERROR - The requested cryptographic operation is not supported
</div>
~~~~

Since the request was pre-authorized, it is not necessary for Alice to explicitly
accept the connection request but the administration device is needed to create
the connection assertion:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV
        Connection Request::
        MessageID: 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV
        To:  From: 
        Device:  MDTJ-IEIN-4ST6-ZC3G-OUSP-PBNM-PHYK
        Witness: 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV
MessageID: 2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM
        Connection Request::
        MessageID: 2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM
        To:  From: 
        Device:  MBKR-2YPO-UOPU-2QTE-2YXK-J55K-QBWQ
        Witness: 2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM
</div>
~~~~

We can check the device connection by attempting to synchronize to the profile account:


~~~~
<div="terminal">
<cmd>Alice3> account sync
<rsp>ERROR - Unspecified error
</div>
~~~~

Note that this connection mechanism could be adapted to allow a device with a 
camera affordance to connect by scanning a QR code on the administration device.
