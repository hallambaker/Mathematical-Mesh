<title>device
# Using the device Command Set

The `device` command set contains commands used to connect devices to a 
profile.

## Requesting a connection

The `device request` command is used on the new device 
to request connection to the user's profile. Alice need only specify 
the mesh service account alice@example.com to which connection is requested:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MCRS-WMA4-QV32-HPLQ-4L3R-MSYA-UJXZ
   Witness value = AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4
</div>
~~~~

In this case there is no existing device profile and so a new profile is
created and used to create a registration request which is posted to the user's 
account.

The tool reports the connection request authenticator, a UDF fingerprint which
authenticates this particular request.

Alice must use a device already connected to her account to
complete the connection process.

The `device pending` command gives a list of pending connection
messages.


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: HCG4-XSEY-PC7D-KLDI-OP6X-MEBD-TLWT
        Connection Request::
        MessageID: HCG4-XSEY-PC7D-KLDI-OP6X-MEBD-TLWT
        To:  From: 
        Device:  MARV-3CT2-H7RW-CPGM-ILRK-4C6V-QIYK
        Witness: HCG4-XSEY-PC7D-KLDI-OP6X-MEBD-TLWT
MessageID: AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4
        Connection Request::
        MessageID: AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4
        To:  From: 
        Device:  MCRS-WMA4-QV32-HPLQ-4L3R-MSYA-UJXZ
        Witness: AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4
</div>
~~~~

Alice sees the request that she posted and approves it with the connect
`device accept` command:


~~~~
<div="terminal">
<cmd>Alice> device accept AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

There is a second request (from Mallet) that Alice doesn't recognize. Alice rejects this
request:


~~~~
<div="terminal">
<cmd>Alice> device reject HCG4-XSEY-PC7D-KLDI-OP6X-MEBD-TLWT
<rsp></div>
~~~~

The connection process is completed by synchronizing the new device. At this point,
all the applications that were available to the first device are available to the
second:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp></div>
~~~~

##Managing connected devices

The `device list` command gives a list of devices in the device 
catalog:


~~~~
<div="terminal">
<cmd>Alice> device list
<rsp></div>
~~~~

The `device delete` command removes a device from the catalog:


~~~~
<div="terminal">
<cmd>Alice> device delete AZQV-NA3W-DTL6-6F6Z-Z2KX-UU4I-OPC4
<rsp>ERROR - The feature has not been implemented
<cmd>Alice> device list
<rsp></div>
~~~~


## Requesting a connection using a PIN

The simple connection mechanism is straightforward but relies on the user who is
processing the connection requests recognizing the correct fingerprint. While this
is approach has proved practical when it is the same user who is making and 
approving the connection request, it is less satisfactory when this is done
by two different people or by the same person at different times.

Connection requests may be authenticated by means of a PIN created on an 
administration device. The `device pin` command generates
a new PIN code:


~~~~
<div="terminal">
<cmd>Alice> account pin
<rsp>PIN=ACST-XYBV-X2WN-ZPJA-T54M-A42R-M36O (Expires=2020-10-24T15:18:55Z)
</div>
~~~~

The pin code can now be used to authenticate the connection request:


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin=ACST-XYBV-X2WN-ZPJA-T54M-A42R-M36O
<rsp>   Device UDF = MBKV-OELR-CWSM-V3PQ-QMKV-YMIV-BDKJ
   Witness value = ZWZR-NOJQ-CE6U-4WG4-CFA5-5JO4-6KBL
</div>
~~~~

Since the PIN code that was issued was set to be self-authorizing, the device
is connected automatically when the user synchronizes their account from an 
administrator device:

**Missing Example***


### Requesting a connection using an EARL

Encrypted Authenticated Resource Locators provide one means of preconfiguring
a device to enable simple and straightforward connection to a Mesh profile.

The EARL itself is typically presented by means of a barcode on the device
or its packaging. To connect the device, the user simply scans the QR code using
a Mesh enabled application on an administion device and applies power.
configuration then proceeds automatically.

Alternatively, the EARL may be transfered wirelessly by a near field 
communications link or by cycling an LED.

To enable this connection mode, the manufacturer performs the steps of

* Generating a device profile and open connection request

* Encrypting the open connection request under a randomly chosen key

* Provisioning the encrypted device profile to a Web site

* Creating UDF EARL of the key

* Converting the EARL to a QR code which is printed on the device or its packaging.

These steps may be performed on the device to be connected using the 
`device request` command with the `/earl` option. Instead of requesting
connection to a user account, the device requests connection to a special purpose
account established for the purpose of providing a hailing account for enabling
this type of device connection.


The device can attempt to complete the connection whenever it is provided with power 
and network connectivity using the `profile sync` command.


The key specified in the '/earl' option is used to create a UDF EARL specifying a 
location from which a device description document may be obtained. Note that 
it is not necessary for the device description document to be on the same service 
or even in the same domain as the service used to resolve the UDF.

The UDF is typically presented to the user as a QR code either on the device itself 
or its packaging. Alternatively, a device might transmit the UDF by blinking its 
activity LED at a rate suitable to allow transmission of a short message to a 
smart phone camera.

A QR code or other scanning application can use the meshman tool to resolve the EARL 
and retrieve the data using the `device earl` command:


The tool performs the tasks of resolving the EARL, decrypting the discovery record
and posting a connection response to both the hailing account and the profile account.
The next time the device polls the hailing account, it retrieves the connection data:


Once connected to an account, a device does not attempt to poll the hailing account. 
Further attempts to make a connection are thus ignored unless the device is 
reset.


