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
<rsp>   Witness value = VHHK-22IB-74MU-JOLK-GJF7-SE6W-6TR7
   Personal Mesh = MA5E-Q7B3-SQ5O-6OS2-WBTJ-BFVE-I3S3
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
<rsp></div>
~~~~

Alice sees the request that she posted and approves it with the connect
`device accept` command:


~~~~
<div="terminal">
<cmd>Alice> device accept NCOR-5R5M-T3UO-56RL-6RGR-DRD5-IM4G
<rsp></div>
~~~~

There is a second request (from Mallet) that Alice doesn't recognize. Alice rejects this
request:


~~~~
<div="terminal">
<cmd>Alice> device reject NACG-VWPR-YKGR-WUSJ-RTWE-WVXS-RVZS
<rsp></div>
~~~~

The connection process is completed by synchronizing the new device. At this point,
all the applications that were available to the first device are available to the
second:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>ERROR - Object reference not set to an instance of an object.
<cmd>Alice2> account sync
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
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
<cmd>Alice> device delete NCOR-5R5M-T3UO-56RL-6RGR-DRD5-IM4G
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
<rsp>PIN=NDY3-ICHP-O2WD-PU24-L4 (Expires=2019-12-24T17:22:03Z)
</div>
~~~~

The pin code can now be used to authenticate the connection request:


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin=NDY3-ICHP-O2WD-PU24-L4
<rsp>   Witness value = 4XPU-C5T4-JA3H-GQ3M-44SC-2FRC-TAR2
   Personal Mesh = MA5E-Q7B3-SQ5O-6OS2-WBTJ-BFVE-I3S3
</div>
~~~~

Since the PIN code that was issued was set to be self-authorizing, the device
is connected automatically when the user synchronizes their account from an 
administrator device:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp></div>
~~~~


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


~~~~
<div="terminal">
<cmd>Alice4> device pre devices@example.com /key=udf://example.com/EABL-KTZW-DYTP-7GBS-P2MK-GJQ6-2XOB-74
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

The device can attempt to complete the connection whenever it is provided with power 
and network connectivity using the `profile sync` command.


~~~~
<div="terminal">
<cmd>Alice4> account sync
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

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


~~~~
<div="terminal">
<cmd>Alice> device earl udf://example.com/EABL-KTZW-DYTP-7GBS-P2MK-GJQ6-2XOB-74
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

The tool performs the tasks of resolving the EARL, decrypting the discovery record
and posting a connection response to both the hailing account and the profile account.
The next time the device polls the hailing account, it retrieves the connection data:


~~~~
<div="terminal">
<cmd>Alice4> account sync
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

Once connected to an account, a device does not attempt to poll the hailing account. 
Further attempts to make a connection are thus ignored unless the device is 
reset.


