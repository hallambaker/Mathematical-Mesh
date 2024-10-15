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
<rsp>   Device UDF = MBQO-4TTM-QOTS-MKEG-XQTU-XNFM-WUWM
   Witness value = HPSV-N4OL-ME5Y-JOKE-ESFQ-OLFL-YOWQ
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
<rsp>MessageID: HPSV-N4OL-ME5Y-JOKE-ESFQ-OLFL-YOWQ
        Connection Request::
        MessageID: HPSV-N4OL-ME5Y-JOKE-ESFQ-OLFL-YOWQ
        To:  From: 
        Device:  MBQO-4TTM-QOTS-MKEG-XQTU-XNFM-WUWM
        Witness: HPSV-N4OL-ME5Y-JOKE-ESFQ-OLFL-YOWQ
</div>
~~~~

Alice sees the request that she posted and approves it with the
`device accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman device accept HPSV-N4OL-ME5Y-JOKE-ESFQ-OLFL-YOWQ ^
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
<rsp>ContextDevice Local: -
  Base UDF MBQO-CM6D-BZKE-DBUJ-KXN6-YRXQ-YDNR
  Mesh UDF 
Encrypted: MALC-SMGV-SLQI-I2RQ-4LKA-KBNH-RZI5
  Profile User
    Signed by: MAJF-DXRU-OY7F-RXLC-JZVM-LNM5-DWGS
      KeyOfflineSignature: MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36 
      AccountAddress : alice@example.com 
      KeyEncryption:       MAYF-D7LJ-5IMP-EUCG-HSGH-7LSR-AAPZ 
  Profile Device
    Signed by: MASV-Q35N-2VYE-CBR3-QGL6-SZKP-O624
      ProfileUDF:          MBQO-CM6D-BZKE-DBUJ-KXN6-YRXQ-YDNR 
      KeySignature:        MAWL-RYGS-H7B3-ZZLH-OO7G-2NR6-6O4P 
      KeyEncryption:       MAM5-XOIH-6J54-RRUD-KXBZ-5ICO-STXQ 
      KeyAuthentication:   MD2M-63HG-GVI6-VYRY-2RNS-NMZ3-RVPZ 
  Connection Device
    Signed by: MD2L-6M7C-Z3Z3-Q3AL-JFYI-ZIUC-BKUR
      KeyAuthentication:   MBFD-Y37B-6HPN-T6SZ-W4J7-AK2K-3U6Z 

ContextDevice Local: -
  Base UDF MBQO-4TTM-QOTS-MKEG-XQTU-XNFM-WUWM
  Mesh UDF 
Encrypted: MCBL-DEQY-N5WP-FY2B-SGYT-6PH3-LTZV
  Profile User
    Signed by: MAJF-DXRU-OY7F-RXLC-JZVM-LNM5-DWGS
      KeyOfflineSignature: MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36 
      AccountAddress : alice@example.com 
      KeyEncryption:       MAYF-D7LJ-5IMP-EUCG-HSGH-7LSR-AAPZ 
  Profile Device
    Signed by: MDSA-KOXA-MFV2-EER6-7XAT-XGCV-4VLQ
      ProfileUDF:          MBQO-4TTM-QOTS-MKEG-XQTU-XNFM-WUWM 
      KeySignature:        MCUP-MUZ6-5D5T-5KWI-HV57-7BDX-TFEI 
      KeyEncryption:       MB5H-7FO4-AZRD-OJHX-OUZG-XHVG-KH2C 
      KeyAuthentication:   MAZI-3SYG-RZ2X-TQDP-SL63-4OHD-5OTW 
  Connection Device
    Signed by: MD2L-6M7C-Z3Z3-Q3AL-JFYI-ZIUC-BKUR
      KeyAuthentication:   MB7K-AWT2-34F5-TVCT-BV2K-VMRH-JKVS 

</div>
~~~~

The `device delete` command removes a device from the catalog:


~~~~
<div="terminal">
<cmd>Alice> meshman device delete
<rsp>ERROR - One or more errors occurred. (Value cannot be null. (Paramete
r 'key'))
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
<rsp>PIN=ADE7-U5DR-2YNJ-XKVX-4RUE-SVL5-5I
 (Expires=2024-10-15T13:10:56Z)
</div>
~~~~

The pin code can now be used to authenticate the connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ADE7-U5DR-2YNJ-XKVX-4RUE-SVL5-5I
<rsp>   Device UDF = MBQD-CODE-XMWJ-QHE3-2KHZ-UKKF-TVVF
   Witness value = A6J3-EVU5-QGBM-WI4Z-HYUC-ONHP-O3VC
</div>
~~~~

Since the PIN code that was issued was set to be self-authorizing, the device
is connected automatically when the user synchronizes their account from an 
administrator device:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: A6J3-EVU5-QGBM-WI4Z-HYUC-ONHP-O3VC
        Connection Request::
        MessageID: A6J3-EVU5-QGBM-WI4Z-HYUC-ONHP-O3VC
        To:  From: 
        Device:  MBQD-CODE-XMWJ-QHE3-2KHZ-UKKF-TVVF
        Witness: A6J3-EVU5-QGBM-WI4Z-HYUC-ONHP-O3VC
MessageID: NCX7-ADC5-L2CD-W5IY-SFT4-NX2U-XZQL
MessageID: NAZG-5KBV-D32X-O24L-XTYS-26GV-FC6Z
        Confirmation Request::
        MessageID: NAZG-5KBV-D32X-O24L-XTYS-26GV-FC6Z
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NANN-LZ5N-6AHO-AOBD-VD6I-X7C3-GJHY
MessageID: NBCN-N55H-QYZX-F2TB-U5R3-2T6B-5W47
MessageID: NDHA-E73C-WZUG-QCMR-5IPX-52JV-WYX6
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
<rsp>Device UDF: MBQK-36BF-K7RS-UDWD-PVC3-CVMR-BJCP
File: EBH3-DT6M-G2WA-EF7E-DA42-DN55-7E.medk
</div>
~~~~

This creates a configuration file that is installed on the device by executing the
`device install` command on the device itself:


~~~~
<div="terminal">
<cmd>Alice4> meshman device install EBH3-DT6M-G2WA-EF7E-DA42-DN55-7E.medk
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
    mcd://maker@example.com/EBH3-DT6M-G2WA-EF7E-DA42-DN55-7E /web
</div>
~~~~

The tool performs the tasks of resolving the EARL, decrypting the discovery record
and posting a connection response to both the hailing account and the profile account.
The next time the device polls the hailing account, it retrieves the connection data:


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MBQK-36BF-K7RS-UDWD-PVC3-CVMR-BJCP
   Account = alice@example.com
   Account UDF = MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
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
<cmd>Alice> meshman account pin /null
<rsp>PIN=ABAG-RFHA-KTDL-IGKG-TXC7-AM4Q-EY
 (Expires=2024-10-15T13:11:00Z)
</div>
~~~~

The connecting device requests connection using the  `device join`
command specifying the URI.


~~~~
<div="terminal">
<cmd>Alice5> meshman device join ^
    mcd://alice@example.com/ABAG-RFHA-KTDL-IGKG-TXC7-AM4Q-EY
<rsp>   Device UDF = MBQO-NBWH-FMY5-EN6L-S3VE-5MFA-4UKY
   Witness value = LCSQ-ZN25-O4OU-WB7L-2YVO-Q2K4-YGKO
</div>
~~~~

The administration device processes the device connection request automatically,
as before.


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: LCSQ-ZN25-O4OU-WB7L-2YVO-Q2K4-YGKO
        Connection Request::
        MessageID: LCSQ-ZN25-O4OU-WB7L-2YVO-Q2K4-YGKO
        To:  From: 
        Device:  MBQO-NBWH-FMY5-EN6L-S3VE-5MFA-4UKY
        Witness: LCSQ-ZN25-O4OU-WB7L-2YVO-Q2K4-YGKO
MessageID: NBOA-TY35-OY5Y-C5ZH-PXZ6-BVKU-4YGO
        Confirmation Request::
        MessageID: NBOA-TY35-OY5Y-C5ZH-PXZ6-BVKU-4YGO
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NA4S-PTKA-TB7E-ZKBG-2A2H-XTBY-7JUM
        Confirmation Request::
        MessageID: NA4S-PTKA-TB7E-ZKBG-2A2H-XTBY-7JUM
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NCEV-GJQW-H2J5-OXM5-MDFG-VLS5-7BQ2
        Contact Request::
        MessageID: NCEV-GJQW-H2J5-OXM5-MDFG-VLS5-7BQ2
        To: alice@example.com From: carol@example.com
        PIN: 
MessageID: NDVR-22QE-MJFX-NIXO-VWED-H5PP-HFMI
MessageID: NCX7-ADC5-L2CD-W5IY-SFT4-NX2U-XZQL
MessageID: NAZG-5KBV-D32X-O24L-XTYS-26GV-FC6Z
        Confirmation Request::
        MessageID: NAZG-5KBV-D32X-O24L-XTYS-26GV-FC6Z
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NANN-LZ5N-6AHO-AOBD-VD6I-X7C3-GJHY
MessageID: NBCN-N55H-QYZX-F2TB-U5R3-2T6B-5W47
MessageID: NDHA-E73C-WZUG-QCMR-5IPX-52JV-WYX6
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


