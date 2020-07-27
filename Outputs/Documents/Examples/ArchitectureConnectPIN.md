The PIN connection mechanism begins with the issue of the PIN:


~~~~
<div="terminal">
<cmd>Alice> account pin
<rsp>PIN=ADDA-NJ7O-ZQS3-4KR6-N7OA-CEZR-FRUR (Expires=2020-07-28T09:45:24Z)
</div>
~~~~

The PIN code is transmitted out of band to the device being connected:


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin=ADDA-NJ7O-ZQS3-4KR6-N7OA-CEZR-FRUR
<rsp>ERROR - The requested cryptographic operation is not supported
</div>
~~~~

Since the request was pre-authorized, it is not necessary for Alice to explicitly
accept the connection request but the administration device is needed to create
the connection assertion:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z
        Connection Request::
        MessageID: CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z
        To:  From: 
        Device:  MD7W-S6XF-V4EL-7QEO-MUPK-B5JL-MLPY
        Witness: CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z
MessageID: XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED
        Connection Request::
        MessageID: XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED
        To:  From: 
        Device:  MC6T-FX77-ABC5-BVJ5-U3C4-MYCH-PQVR
        Witness: XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED
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
