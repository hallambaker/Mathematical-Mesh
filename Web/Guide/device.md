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
<rsp>   Device UDF = MDF6-V33U-HPP4-FDY2-IH4G-BVCE-PTOS
   Witness value = JFX3-4WGT-BQCQ-CXTW-SEJJ-YC6D-OBGJ
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
<rsp>MessageID: JFX3-4WGT-BQCQ-CXTW-SEJJ-YC6D-OBGJ
        Connection Request::
        MessageID: JFX3-4WGT-BQCQ-CXTW-SEJJ-YC6D-OBGJ
        To:  From: 
        Device:  MDF6-V33U-HPP4-FDY2-IH4G-BVCE-PTOS
        Witness: JFX3-4WGT-BQCQ-CXTW-SEJJ-YC6D-OBGJ
</div>
~~~~

Alice sees the request that she posted and approves it with the connect
`device accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman device accept JFX3-4WGT-BQCQ-CXTW-SEJJ-YC6D-OBGJ ^
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
<rsp>PIN=ABHT-VP25-WUQY-ZNTF-CJ4F-5AWU-ZA
 (Expires=2021-12-20T19:21:17Z)
</div>
~~~~

The pin code can now be used to authenticate the connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ABHT-VP25-WUQY-ZNTF-CJ4F-5AWU-ZA
<rsp>   Device UDF = MBJ4-APU2-QYGV-OPLC-TDDY-5SOJ-PUYN
   Witness value = FC4F-LTCQ-MEOC-NS22-2Q5U-CVI7-KHM7
</div>
~~~~

Since the PIN code that was issued was set to be self-authorizing, the device
is connected automatically when the user synchronizes their account from an 
administrator device:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: FC4F-LTCQ-MEOC-NS22-2Q5U-CVI7-KHM7
        Connection Request::
        MessageID: FC4F-LTCQ-MEOC-NS22-2Q5U-CVI7-KHM7
        To:  From: 
        Device:  MBJ4-APU2-QYGV-OPLC-TDDY-5SOJ-PUYN
        Witness: FC4F-LTCQ-MEOC-NS22-2Q5U-CVI7-KHM7
MessageID: NDVT-POHA-PJWP-AABG-YXO2-JU2C-4LYT
        Group invitation::
        MessageID: NDVT-POHA-PJWP-AABG-YXO2-JU2C-4LYT
        To: alice@example.com From: alice@example.com
MessageID: NCM5-RFA7-MCBH-UTRQ-2DPH-RIUN-DZEE
        Confirmation Request::
        MessageID: NCM5-RFA7-MCBH-UTRQ-2DPH-RIUN-DZEE
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDA2-TF33-S2GI-CUQB-W7MD-7SUH-TMHU
        Contact Request::
        MessageID: NDA2-TF33-S2GI-CUQB-W7MD-7SUH-TMHU
        To: alice@example.com From: bob@example.com
        PIN: ABS6-M3HZ-3XC3-T2MP-5KAC-7UQW-M65A
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
<rsp>Device UDF: MB43-ZZ44-PWCH-SJME-GZBJ-HZKC-TZUT
File: EAVO-F5LN-W5EH-LUDH-NWHC-FM27-EY.medk
</div>
~~~~

This creates a configuration file that is installed on the device by executing the
`device install` command on the device itself:


~~~~
<div="terminal">
<cmd>Alice4> meshman device install EAVO-F5LN-W5EH-LUDH-NWHC-FM27-EY.medk
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
    mcu://maker@example.com/EAVO-F5LN-W5EH-LUDH-NWHC-FM27-EY /web
</div>
~~~~

The tool performs the tasks of resolving the EARL, decrypting the discovery record
and posting a connection response to both the hailing account and the profile account.
The next time the device polls the hailing account, it retrieves the connection data:


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MB43-ZZ44-PWCH-SJME-GZBJ-HZKC-TZUT
   Account = alice@example.com
   Account UDF = MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
</div>
~~~~

Once connected to an account, a device does not attempt to poll the hailing account. 
Further attempts to make a connection are thus ignored unless the device is 
reset.


## Dynamic QR connection and Post Authentication




~~~~
<div="terminal">
<cmd>Alice> meshman account pin
<rsp>PIN=ABC4-P362-QUHA-EWAD-IUYC-EINM-I4
 (Expires=2021-12-20T19:21:26Z)
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
<rsp>MessageID: NDVT-POHA-PJWP-AABG-YXO2-JU2C-4LYT
        Group invitation::
        MessageID: NDVT-POHA-PJWP-AABG-YXO2-JU2C-4LYT
        To: alice@example.com From: alice@example.com
MessageID: NCM5-RFA7-MCBH-UTRQ-2DPH-RIUN-DZEE
        Confirmation Request::
        MessageID: NCM5-RFA7-MCBH-UTRQ-2DPH-RIUN-DZEE
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDA2-TF33-S2GI-CUQB-W7MD-7SUH-TMHU
        Contact Request::
        MessageID: NDA2-TF33-S2GI-CUQB-W7MD-7SUH-TMHU
        To: alice@example.com From: bob@example.com
        PIN: ABS6-M3HZ-3XC3-T2MP-5KAC-7UQW-M65A
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


