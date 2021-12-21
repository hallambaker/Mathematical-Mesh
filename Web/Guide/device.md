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
<rsp>   Device UDF = MCM4-ZJWE-RSWW-D6VX-KZDN-J5PU-5GHA
   Witness value = YBUK-6XKN-2E3H-RXPT-SMKO-SF4O-STAS
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
<rsp>MessageID: YBUK-6XKN-2E3H-RXPT-SMKO-SF4O-STAS
        Connection Request::
        MessageID: YBUK-6XKN-2E3H-RXPT-SMKO-SF4O-STAS
        To:  From: 
        Device:  MCM4-ZJWE-RSWW-D6VX-KZDN-J5PU-5GHA
        Witness: YBUK-6XKN-2E3H-RXPT-SMKO-SF4O-STAS
</div>
~~~~

Alice sees the request that she posted and approves it with the connect
`device accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman device accept YBUK-6XKN-2E3H-RXPT-SMKO-SF4O-STAS ^
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
<rsp>PIN=AD5M-D6JD-5QGC-YLLU-UM65-2NQX-4M
 (Expires=2021-12-22T13:28:30Z)
</div>
~~~~

The pin code can now be used to authenticate the connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AD5M-D6JD-5QGC-YLLU-UM65-2NQX-4M
<rsp>   Device UDF = MBUY-BN5A-736O-WRRZ-LJCK-UPZZ-CZ52
   Witness value = TGCH-QM7T-2PRP-44HQ-YAZ6-HMR7-73LC
</div>
~~~~

Since the PIN code that was issued was set to be self-authorizing, the device
is connected automatically when the user synchronizes their account from an 
administrator device:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: TGCH-QM7T-2PRP-44HQ-YAZ6-HMR7-73LC
        Connection Request::
        MessageID: TGCH-QM7T-2PRP-44HQ-YAZ6-HMR7-73LC
        To:  From: 
        Device:  MBUY-BN5A-736O-WRRZ-LJCK-UPZZ-CZ52
        Witness: TGCH-QM7T-2PRP-44HQ-YAZ6-HMR7-73LC
MessageID: NCUH-QEYI-3V6A-IQ7Z-6RHR-IPLZ-4MMK
        Group invitation::
        MessageID: NCUH-QEYI-3V6A-IQ7Z-6RHR-IPLZ-4MMK
        To: alice@example.com From: alice@example.com
MessageID: NDSA-RD52-JIV2-RVRU-BY4U-3SAN-HZWQ
        Confirmation Request::
        MessageID: NDSA-RD52-JIV2-RVRU-BY4U-3SAN-HZWQ
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
        Contact Request::
        MessageID: NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
        To: alice@example.com From: bob@example.com
        PIN: ACPD-YENT-3EM4-PUHD-D4Q4-4TX5-C25A
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
<rsp>Device UDF: MBM6-ONBJ-ESIY-SQUC-UNYK-2KWU-KELY
File: ED6U-5FAQ-662T-BTCW-7YFY-W545-EY.medk
</div>
~~~~

This creates a configuration file that is installed on the device by executing the
`device install` command on the device itself:


~~~~
<div="terminal">
<cmd>Alice4> meshman device install ED6U-5FAQ-662T-BTCW-7YFY-W545-EY.medk
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
    mcu://maker@example.com/ED6U-5FAQ-662T-BTCW-7YFY-W545-EY /web
</div>
~~~~

The tool performs the tasks of resolving the EARL, decrypting the discovery record
and posting a connection response to both the hailing account and the profile account.
The next time the device polls the hailing account, it retrieves the connection data:


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MBM6-ONBJ-ESIY-SQUC-UNYK-2KWU-KELY
   Account = alice@example.com
   Account UDF = MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
</div>
~~~~

Once connected to an account, a device does not attempt to poll the hailing account. 
Further attempts to make a connection are thus ignored unless the device is 
reset.


## Dynamic QR connection and Post Authentication




~~~~
<div="terminal">
<cmd>Alice> meshman account pin
<rsp>PIN=AD6J-PWHH-QXWJ-HHKP-7GE7-DFFY-JY
 (Expires=2021-12-22T13:28:42Z)
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
<rsp>MessageID: NAGW-UCHM-Y4IZ-A44R-NQ6Y-JF47-FOVC
        Confirmation Request::
        MessageID: NAGW-UCHM-Y4IZ-A44R-NQ6Y-JF47-FOVC
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NDS6-NWK7-4JYJ-ZQG3-VAEZ-JEYX-YSAE
        Confirmation Request::
        MessageID: NDS6-NWK7-4JYJ-ZQG3-VAEZ-JEYX-YSAE
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NAI7-GORK-6QDL-CRCT-XJHC-CG4P-VNIS
        Contact Request::
        MessageID: NAI7-GORK-6QDL-CRCT-XJHC-CG4P-VNIS
        To: alice@example.com From: bob@example.com
        PIN: ACJZ-GFMD-MOFZ-RQKP-IQ3L-56BK-WURA
MessageID: NCUH-QEYI-3V6A-IQ7Z-6RHR-IPLZ-4MMK
        Group invitation::
        MessageID: NCUH-QEYI-3V6A-IQ7Z-6RHR-IPLZ-4MMK
        To: alice@example.com From: alice@example.com
MessageID: NDSA-RD52-JIV2-RVRU-BY4U-3SAN-HZWQ
        Confirmation Request::
        MessageID: NDSA-RD52-JIV2-RVRU-BY4U-3SAN-HZWQ
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
        Contact Request::
        MessageID: NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
        To: alice@example.com From: bob@example.com
        PIN: ACPD-YENT-3EM4-PUHD-D4Q4-4TX5-C25A
<cmd>Alice> meshman account sync /auto
</div>
~~~~

~~~~
Missing example 3
~~~~

~~~~
<div="terminal">
<cmd>Alice> meshman device auth Alice5 /all
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~


