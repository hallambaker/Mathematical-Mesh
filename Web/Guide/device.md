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
<rsp>   Device UDF = MBL2-EMUT-CLYH-Q2QK-3FQQ-PXWO-UJN6
   Witness value = FCG4-72L5-Z7Z5-ABWZ-HS7N-TG27-W4WU
</div>
~~~~

In this case there is no existing device profile and so a new profile is
created and used to create a registration request which is posted to the user's 
account.

The tool reports the witness value, a UDF fingerprint which
authenticates this particular request.

Alice must use a device already connected to her account that has been granted the
administration right to complete the connection process.

The `device pending` command gives a list of pending device connection
messages.


~~~~
<div="terminal">
<cmd>Alice> meshman device pending
<rsp>MessageID: FCG4-72L5-Z7Z5-ABWZ-HS7N-TG27-W4WU
        Connection Request::
        MessageID: FCG4-72L5-Z7Z5-ABWZ-HS7N-TG27-W4WU
        To:  From: 
        Device:  MBL2-EMUT-CLYH-Q2QK-3FQQ-PXWO-UJN6
        Witness: FCG4-72L5-Z7Z5-ABWZ-HS7N-TG27-W4WU
</div>
~~~~

Alice sees the request that she posted and approves it with the
`device accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman device accept FCG4-72L5-Z7Z5-ABWZ-HS7N-TG27-W4WU ^
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
<div="terminal">
<cmd>Alice> meshman device list
</div>
~~~~

The `device delete` command removes a device from the catalog:


~~~~
<div="terminal">
<cmd>Alice> meshman device delete
<rsp>ERROR - Value cannot be null. (Parameter 'key')
</div>
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
<rsp>PIN=AAGV-IFMG-7JH7-VLYL-3PEB-PU4S-4E
 (Expires=2021-12-23T01:13:18Z)
</div>
~~~~

The pin code can now be used to authenticate the connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AAGV-IFMG-7JH7-VLYL-3PEB-PU4S-4E
<rsp>   Device UDF = MC3V-V6L6-YHCW-26I5-XFE3-6WGR-BKVP
   Witness value = Q7CA-IZV4-BB7C-7CNA-TQKW-W5HC-GJ6W
</div>
~~~~

Since the PIN code that was issued was set to be self-authorizing, the device
is connected automatically when the user synchronizes their account from an 
administrator device:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: Q7CA-IZV4-BB7C-7CNA-TQKW-W5HC-GJ6W
        Connection Request::
        MessageID: Q7CA-IZV4-BB7C-7CNA-TQKW-W5HC-GJ6W
        To:  From: 
        Device:  MC3V-V6L6-YHCW-26I5-XFE3-6WGR-BKVP
        Witness: Q7CA-IZV4-BB7C-7CNA-TQKW-W5HC-GJ6W
MessageID: NBNO-T2AC-LSGA-MRRH-JN3O-V4YQ-RJLQ
        Group invitation::
        MessageID: NBNO-T2AC-LSGA-MRRH-JN3O-V4YQ-RJLQ
        To: alice@example.com From: alice@example.com
MessageID: NCQL-ONQW-YLJE-NZ5P-2ENL-K5YY-3I4K
        Confirmation Request::
        MessageID: NCQL-ONQW-YLJE-NZ5P-2ENL-K5YY-3I4K
        To: alice@example.com From: console@example.com
        Text: start
MessageID: ND4S-KDPC-PUNU-4X3I-PTRT-LJSO-XGHV
        Contact Request::
        MessageID: ND4S-KDPC-PUNU-4X3I-PTRT-LJSO-XGHV
        To: alice@example.com From: bob@example.com
        PIN: AARR-TR4W-I3P2-Y5OF-KVMP-7KEJ-RVIQ
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
<rsp>Device UDF: MBFG-FGPL-RW44-SBP6-VSFX-J445-ANV6
File: EBFD-WARU-YCA7-WY6M-GYIP-IXWG-HQ.medk
</div>
~~~~

This creates a configuration file that is installed on the device by executing the
`device install` command on the device itself:


~~~~
<div="terminal">
<cmd>Alice4> meshman device install EBFD-WARU-YCA7-WY6M-GYIP-IXWG-HQ.medk
</div>
~~~~

The device can attempt to complete the connection whenever it is provided with power 
and network connectivity using the `device complete` command. Attempts to
connect before there has been a connection request posted will fail of course.


~~~~
Missing example 2
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
    mcu://maker@example.com/EBFD-WARU-YCA7-WY6M-GYIP-IXWG-HQ /web
</div>
~~~~

The tool performs the tasks of resolving the EARL, decrypting the discovery record
and posting a connection response to both the hailing account and the profile account.
The next time the device polls the hailing account, it retrieves the connection data:


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MBFG-FGPL-RW44-SBP6-VSFX-J445-ANV6
   Account = alice@example.com
   Account UDF = MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
</div>
~~~~

Once connected to an account, a device does not attempt to poll the hailing account. 
Further attempts to make a connection are thus ignored unless the device is 
reset.


## Dynamic QR connection and Post Authentication

A static QR code is printed on the device that is to connect which is read using the 
camera on an administration device. The dynamic QR code connection mechanism presents
a QR code on the administration device that is read by the connecting device.

The QR code presented on the administration device comprises the account address of the
service to connect to and a PIN to authenticate the connection request. The protocol
implementation of this connection mechanism is identical to the PIN authenticated 
connection described earlier.


The pin is created using the `account pin` as before but with the
'/uri' option. Note that in this case, the device was not pre-authorized with
any rights.


~~~~
<div="terminal">
<cmd>Alice> meshman account pin
<rsp>PIN=ACTZ-KN3F-4GLN-WGTE-YH3R-XN5Q-BU
 (Expires=2021-12-23T01:13:31Z)
</div>
~~~~

The connecting device requests connection using the  `device join`
command specifying the URI.


~~~~
<div="terminal">
<cmd>Alice5> meshman device join tbs
<rsp>ERROR - The specified connection URI was invalid
</div>
~~~~

The administration device processes the device connection request automatically,
as before.


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NDWD-5CWJ-KV7A-HHB4-3TOO-S4OJ-445C
        Confirmation Request::
        MessageID: NDWD-5CWJ-KV7A-HHB4-3TOO-S4OJ-445C
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NDVI-DOXS-3TK3-LGKN-XP6N-KRNU-ZPXK
        Confirmation Request::
        MessageID: NDVI-DOXS-3TK3-LGKN-XP6N-KRNU-ZPXK
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NDGG-BP7T-FBI6-C4FJ-N6LN-PX2U-MV5G
        Contact Request::
        MessageID: NDGG-BP7T-FBI6-C4FJ-N6LN-PX2U-MV5G
        To: alice@example.com From: bob@example.com
        PIN: ACUN-WB2H-GIIO-ZMDB-WGEI-MFDX-73MA
MessageID: NBNO-T2AC-LSGA-MRRH-JN3O-V4YQ-RJLQ
        Group invitation::
        MessageID: NBNO-T2AC-LSGA-MRRH-JN3O-V4YQ-RJLQ
        To: alice@example.com From: alice@example.com
MessageID: NCQL-ONQW-YLJE-NZ5P-2ENL-K5YY-3I4K
        Confirmation Request::
        MessageID: NCQL-ONQW-YLJE-NZ5P-2ENL-K5YY-3I4K
        To: alice@example.com From: console@example.com
        Text: start
MessageID: ND4S-KDPC-PUNU-4X3I-PTRT-LJSO-XGHV
        Contact Request::
        MessageID: ND4S-KDPC-PUNU-4X3I-PTRT-LJSO-XGHV
        To: alice@example.com From: bob@example.com
        PIN: AARR-TR4W-I3P2-Y5OF-KVMP-7KEJ-RVIQ
<cmd>Alice> meshman account sync /auto
</div>
~~~~

The device completes the connection in the normal fashion.


~~~~
Missing example 3
~~~~

Having completed the connection process, the administrator grants full privileges
using the `device auth` command:


~~~~
<div="terminal">
<cmd>Alice> meshman device auth Alice5 /all
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~


