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
<cmd>Alice2> meshman device request alice@example.com
<rsp>   Device UDF = MAT6-VBWS-466P-GHDQ-RLHL-S2IJ-PXY5
   Witness value = UPXY-SS6S-L4AS-AKOW-6WSR-77J5-OGY6
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
<cmd>Alice> meshman device pending
<rsp>MessageID: UPXY-SS6S-L4AS-AKOW-6WSR-77J5-OGY6
        Connection Request::
        MessageID: UPXY-SS6S-L4AS-AKOW-6WSR-77J5-OGY6
        To:  From: 
        Device:  MAT6-VBWS-466P-GHDQ-RLHL-S2IJ-PXY5
        Witness: UPXY-SS6S-L4AS-AKOW-6WSR-77J5-OGY6
</div>
~~~~

Alice sees the request that she posted and approves it with the connect
`device accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman device accept UPXY-SS6S-L4AS-AKOW-6WSR-77J5-OGY6 ^
    /message /web
</div>
~~~~

There is a second request (from Mallet) that Alice doesn't recognize. Alice rejects this
request:


~~~~
Missing example 1
~~~~

The connection process is completed by synchronizing the new device. At this point,
all the applications that were available to the first device are available to the
second:


~~~~
<div="terminal">
<cmd>Alice2> meshman account sync
</div>
~~~~

##Managing connected devices

The `device list` command gives a list of devices in the device 
catalog:


~~~~
Missing example 2
~~~~

The `device delete` command removes a device from the catalog:


~~~~
Missing example 3
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
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AC6L-KOKA-W62V-54R5-MU2D-KZVP-OA
 (Expires=2021-12-21T14:00:30Z)
</div>
~~~~

The pin code can now be used to authenticate the connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AC6L-KOKA-W62V-54R5-MU2D-KZVP-OA
<rsp>   Device UDF = MDEH-DBMY-63NX-TNKW-NRWT-ON6M-EOMJ
   Witness value = 6PSU-AAB3-LGXS-E6ON-75LU-4LFP-YPNN
</div>
~~~~

Since the PIN code that was issued was set to be self-authorizing, the device
is connected automatically when the user synchronizes their account from an 
administrator device:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: 6PSU-AAB3-LGXS-E6ON-75LU-4LFP-YPNN
        Connection Request::
        MessageID: 6PSU-AAB3-LGXS-E6ON-75LU-4LFP-YPNN
        To:  From: 
        Device:  MDEH-DBMY-63NX-TNKW-NRWT-ON6M-EOMJ
        Witness: 6PSU-AAB3-LGXS-E6ON-75LU-4LFP-YPNN
MessageID: NBLB-D3DX-6Z6Z-PQCS-4NEO-RQGQ-HQUL
        Group invitation::
        MessageID: NBLB-D3DX-6Z6Z-PQCS-4NEO-RQGQ-HQUL
        To: alice@example.com From: alice@example.com
MessageID: NDI6-772L-UUBU-RIFV-S5GM-3B3J-4LFV
        Confirmation Request::
        MessageID: NDI6-772L-UUBU-RIFV-S5GM-3B3J-4LFV
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NAHB-XJ7W-IEJY-NB4D-27UK-Y2HS-WPEA
        Contact Request::
        MessageID: NAHB-XJ7W-IEJY-NB4D-27UK-Y2HS-WPEA
        To: alice@example.com From: bob@example.com
        PIN: AA3C-HQL4-JNCZ-BJTD-IVOS-G5KU-2YIA
<cmd>Alice> meshman account sync /auto
</div>
~~~~


### Static Device Connection Mechanism

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

These steps are performed by executing the `device preconfig` command
on an administration device at the manufacturer facility:


~~~~
<div="terminal">
<cmd>Maker> meshman device preconfig
<rsp>Device UDF: MAW6-O4D3-KIXK-YWBJ-QQNW-ICMT-QTGB
File: EBBQ-LEUY-XIMX-I7QJ-IP7R-XQFR-EY.medk
</div>
~~~~

This creates a configuration file that is installed on the device by executing the
`device install` command on the device itself:


~~~~
<div="terminal">
<cmd>Alice4> meshman device install EBBQ-LEUY-XIMX-I7QJ-IP7R-XQFR-EY.medk
</div>
~~~~

The device can attempt to complete the connection whenever it is provided with power 
and network connectivity using the `device complete` command. Attempts to
connect before there has been a connection request posted will fail of course.


~~~~
Missing example 4
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
and retrieve the data using the `account connect` command:


~~~~
<div="terminal">
<cmd>Alice> meshman account connect ^
    mcu://maker@example.com/EBBQ-LEUY-XIMX-I7QJ-IP7R-XQFR-EY /web
</div>
~~~~

The tool performs the tasks of resolving the EARL, decrypting the discovery record
and posting a connection response to both the hailing account and the profile account.
The next time the device polls the hailing account, it retrieves the connection data:


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MAW6-O4D3-KIXK-YWBJ-QQNW-ICMT-QTGB
   Account = alice@example.com
   Account UDF = MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ
</div>
~~~~

Once connected to an account, a device does not attempt to poll the hailing account. 
Further attempts to make a connection are thus ignored unless the device is 
reset.


## Dynamic QR connection and Post Authentication




~~~~
<div="terminal">
<cmd>Alice> meshman account pin
<rsp>PIN=AAGU-46ZA-IBXM-A5UE-YSJL-ARON-NI
 (Expires=2021-12-21T14:00:38Z)
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice5> meshman device join tbs
<rsp>ERROR - The specified connection URI was invalid
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NBLB-D3DX-6Z6Z-PQCS-4NEO-RQGQ-HQUL
        Group invitation::
        MessageID: NBLB-D3DX-6Z6Z-PQCS-4NEO-RQGQ-HQUL
        To: alice@example.com From: alice@example.com
MessageID: NDI6-772L-UUBU-RIFV-S5GM-3B3J-4LFV
        Confirmation Request::
        MessageID: NDI6-772L-UUBU-RIFV-S5GM-3B3J-4LFV
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NAHB-XJ7W-IEJY-NB4D-27UK-Y2HS-WPEA
        Contact Request::
        MessageID: NAHB-XJ7W-IEJY-NB4D-27UK-Y2HS-WPEA
        To: alice@example.com From: bob@example.com
        PIN: AA3C-HQL4-JNCZ-BJTD-IVOS-G5KU-2YIA
<cmd>Alice> meshman account sync /auto
</div>
~~~~

~~~~
Missing example 5
~~~~

~~~~
<div="terminal">
<cmd>Alice> meshman device auth Alice5 /all
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~


