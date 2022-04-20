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
<rsp>   Device UDF = MA75-5N5Q-BPQF-5LMP-AN6X-NM4E-U4KS
   Witness value = 6WH6-YJIZ-OKA7-I54P-WZPA-VXTV-PHKJ
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
<rsp>MessageID: 6WH6-YJIZ-OKA7-I54P-WZPA-VXTV-PHKJ
        Connection Request::
        MessageID: 6WH6-YJIZ-OKA7-I54P-WZPA-VXTV-PHKJ
        To:  From: 
        Device:  MA75-5N5Q-BPQF-5LMP-AN6X-NM4E-U4KS
        Witness: 6WH6-YJIZ-OKA7-I54P-WZPA-VXTV-PHKJ
</div>
~~~~

Alice sees the request that she posted and approves it with the
`device accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman device accept 6WH6-YJIZ-OKA7-I54P-WZPA-VXTV-PHKJ ^
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
  Base UDF MB4Y-QXYP-J6HA-666R-TRAL-OCGI-WDZH
  Mesh UDF 
Encrypted: MBV5-TS4Z-MTT3-H577-ZB7X-IBP3-XVN5
  Profile User
    Signed by: MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
      KeyOfflineSignature: MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF 
      AccountAddress : alice@example.com 
      KeyEncryption:       MDPR-FJVW-GK5Z-2LJA-LMYV-XSCH-HE2C 
  Profile Device
    Signed by: MB4Y-QXYP-J6HA-666R-TRAL-OCGI-WDZH
      ProfileSignature: MB4Y-QXYP-J6HA-666R-TRAL-OCGI-WDZH 
      KeySignature:        MBU5-LHYH-4XVT-GYUU-7SNT-NQFY-GQOK 
      KeyEncryption:       MAU7-F5XO-4JHY-DHSG-27FS-CXSE-4R37 
      KeyAuthentication:   MDHM-LPTT-C6RG-DYSF-3UN4-YMG5-YPDF 
  Connection Device
    Signed by: MBDV-XXNH-2RUB-RBMZ-5NG7-L3CD-3THV
      KeyAuthentication:    

ContextDevice Local: -
  Base UDF MA75-5N5Q-BPQF-5LMP-AN6X-NM4E-U4KS
  Mesh UDF 
Encrypted: MDCW-SXW2-ROVU-4R3G-E5R3-2JGI-YBPF
  Profile User
    Signed by: MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
      KeyOfflineSignature: MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF 
      AccountAddress : alice@example.com 
      KeyEncryption:       MDPR-FJVW-GK5Z-2LJA-LMYV-XSCH-HE2C 
  Profile Device
    Signed by: MA75-5N5Q-BPQF-5LMP-AN6X-NM4E-U4KS
      ProfileSignature: MA75-5N5Q-BPQF-5LMP-AN6X-NM4E-U4KS 
      KeySignature:        MBQA-M2E2-PZPR-GIM3-JCRJ-QDDC-NJXL 
      KeyEncryption:       MAAB-KTVM-DBAR-H2MO-BR65-7ADT-MLLA 
      KeyAuthentication:   MDRS-RHS6-4XIE-34VE-2ZLM-GKWL-VMMN 
  Connection Device
    Signed by: MBDV-XXNH-2RUB-RBMZ-5NG7-L3CD-3THV
      KeyAuthentication:   MAVT-XX2Y-B6D2-7SJ3-VVTW-MQ6C-S2MU 

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
<rsp>PIN=ADFR-TEQU-3HJD-IRND-P4TS-CRBD-NI
 (Expires=2022-04-21T16:17:50Z)
</div>
~~~~

The pin code can now be used to authenticate the connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ADFR-TEQU-3HJD-IRND-P4TS-CRBD-NI
<rsp>   Device UDF = MAA3-BQPZ-WWO4-7Q5B-P7AH-FY5C-ATMD
   Witness value = HS22-VO5M-JAG4-RQT4-ROHX-PERK-YYCW
</div>
~~~~

Since the PIN code that was issued was set to be self-authorizing, the device
is connected automatically when the user synchronizes their account from an 
administrator device:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: HS22-VO5M-JAG4-RQT4-ROHX-PERK-YYCW
        Connection Request::
        MessageID: HS22-VO5M-JAG4-RQT4-ROHX-PERK-YYCW
        To:  From: 
        Device:  MAA3-BQPZ-WWO4-7Q5B-P7AH-FY5C-ATMD
        Witness: HS22-VO5M-JAG4-RQT4-ROHX-PERK-YYCW
MessageID: NDBB-CHFG-OWNI-2WWK-RJI2-KMF7-6AW7
        Confirmation Request::
        MessageID: NDBB-CHFG-OWNI-2WWK-RJI2-KMF7-6AW7
        To: alice@example.com From: console@example.com
        Text: start
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
<rsp>Device UDF: MBOB-5GVY-Q43B-KODG-UJ3E-LY7V-36UV
File: EBKG-ED3O-HBHK-ZQGS-EX4H-X22S-X4.medk
</div>
~~~~

This creates a configuration file that is installed on the device by executing the
`device install` command on the device itself:


~~~~
<div="terminal">
<cmd>Alice4> meshman device install EBKG-ED3O-HBHK-ZQGS-EX4H-X22S-X4.medk
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
    mcu://maker@example.com/EBKG-ED3O-HBHK-ZQGS-EX4H-X22S-X4 /web
</div>
~~~~

The tool performs the tasks of resolving the EARL, decrypting the discovery record
and posting a connection response to both the hailing account and the profile account.
The next time the device polls the hailing account, it retrieves the connection data:


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MBOB-5GVY-Q43B-KODG-UJ3E-LY7V-36UV
   Account = alice@example.com
   Account UDF = MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
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
<rsp>PIN=ACT6-REAK-44NL-JPVW-SIFH-XUZR-UU
 (Expires=2022-04-21T16:18:05Z)
</div>
~~~~

The connecting device requests connection using the  `device join`
command specifying the URI.


~~~~
<div="terminal">
<cmd>Alice5> meshman device join ^
    mcu://alice@example.com/ACT6-REAK-44NL-JPVW-SIFH-XUZR-UU
<rsp>   Device UDF = MAEB-HMZE-CJPW-4XOT-6P7M-D456-CSQ4
   Witness value = LUFR-32LY-CHRM-NOF3-ETQY-LQBI-KXHI
</div>
~~~~

The administration device processes the device connection request automatically,
as before.


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: LUFR-32LY-CHRM-NOF3-ETQY-LQBI-KXHI
        Connection Request::
        MessageID: LUFR-32LY-CHRM-NOF3-ETQY-LQBI-KXHI
        To:  From: 
        Device:  MAEB-HMZE-CJPW-4XOT-6P7M-D456-CSQ4
        Witness: LUFR-32LY-CHRM-NOF3-ETQY-LQBI-KXHI
MessageID: NCEW-LXRK-IUA3-DHU5-CDU6-VZNB-C2GP
        Confirmation Request::
        MessageID: NCEW-LXRK-IUA3-DHU5-CDU6-VZNB-C2GP
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NCOI-775L-BMOW-ZEKQ-YPJQ-IFKG-7MKQ
        Confirmation Request::
        MessageID: NCOI-775L-BMOW-ZEKQ-YPJQ-IFKG-7MKQ
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: ND3G-IANC-6HYG-RWHJ-V3QD-33XI-PL5N
        Contact Request::
        MessageID: ND3G-IANC-6HYG-RWHJ-V3QD-33XI-PL5N
        To: alice@example.com From: carol@example.com
        PIN: 
MessageID: NDBB-CHFG-OWNI-2WWK-RJI2-KMF7-6AW7
        Confirmation Request::
        MessageID: NDBB-CHFG-OWNI-2WWK-RJI2-KMF7-6AW7
        To: alice@example.com From: console@example.com
        Text: start
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


