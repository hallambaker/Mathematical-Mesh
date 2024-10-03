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
<rsp>   Device UDF = MBQP-MYOA-LTSP-B5GX-A7HP-ZFJ5-4VQ6
   Witness value = IFC5-FUKU-3JVW-JZME-5DP2-XQEX-SV7B
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
<rsp>MessageID: IFC5-FUKU-3JVW-JZME-5DP2-XQEX-SV7B
        Connection Request::
        MessageID: IFC5-FUKU-3JVW-JZME-5DP2-XQEX-SV7B
        To:  From: 
        Device:  MBQP-MYOA-LTSP-B5GX-A7HP-ZFJ5-4VQ6
        Witness: IFC5-FUKU-3JVW-JZME-5DP2-XQEX-SV7B
</div>
~~~~

Alice sees the request that she posted and approves it with the
`device accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman device accept IFC5-FUKU-3JVW-JZME-5DP2-XQEX-SV7B ^
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
  Base UDF MBQO-BATX-GU7O-GMTN-CXCI-JWKT-VIMN
  Mesh UDF 
Encrypted: MDTR-774C-4Q2X-AFER-NEVZ-WTUG-W7SX
  Profile User
    Signed by: MDD2-JKDP-6SBB-KIML-47CQ-QCOJ-4W5F
      KeyOfflineSignature: MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3 
      AccountAddress : alice@example.com 
      KeyEncryption:       MDSO-NJIQ-HUNW-UWRS-WPOE-BBO3-NDWN 
  Profile Device
    Signed by: MADH-ZREB-4C6F-OO6F-LV2G-QL5P-ATSL
      ProfileUDF:          MBQO-BATX-GU7O-GMTN-CXCI-JWKT-VIMN 
      KeySignature:        MBKG-GPIY-5SAA-TVIR-RUAB-EJAE-TNXZ 
      KeyEncryption:       MCCN-625E-XVZI-OLRZ-JTCM-XQAG-4F4M 
      KeyAuthentication:   MAER-QIII-OG55-HVFY-LSIK-VJ3I-OC5C 
  Connection Device
    Signed by: MBLM-W4XU-5LMK-3REN-25WP-GWFU-EKTV
      KeyAuthentication:   MAUI-OIG7-BIAF-O7KD-FPL3-RX55-X4WZ 

ContextDevice Local: -
  Base UDF MBQP-MYOA-LTSP-B5GX-A7HP-ZFJ5-4VQ6
  Mesh UDF 
Encrypted: MATK-HNZD-J3L3-FJP2-XY3S-ETCA-V46Q
  Profile User
    Signed by: MDD2-JKDP-6SBB-KIML-47CQ-QCOJ-4W5F
      KeyOfflineSignature: MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3 
      AccountAddress : alice@example.com 
      KeyEncryption:       MDSO-NJIQ-HUNW-UWRS-WPOE-BBO3-NDWN 
  Profile Device
    Signed by: MCX4-LPSP-JJRF-FKTZ-SVG7-I7HS-KPUA
      ProfileUDF:          MBQP-MYOA-LTSP-B5GX-A7HP-ZFJ5-4VQ6 
      KeySignature:        MBYL-PWIV-L54F-7XK6-FDRE-N7BP-ZKFZ 
      KeyEncryption:       MCO6-RDDJ-ODGA-LDXX-LAED-F4U4-BMG6 
      KeyAuthentication:   MB2X-XJRH-ERZY-HDQW-RWZV-RHSP-A7IU 
  Connection Device
    Signed by: MBLM-W4XU-5LMK-3REN-25WP-GWFU-EKTV
      KeyAuthentication:   MAH3-YBVX-PYRE-XOEN-B3DR-3O5H-Z4OJ 

</div>
~~~~

The `device delete` command removes a device from the catalog:


~~~~
<div="terminal">
<cmd>Alice> meshman device delete
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
<rsp>PIN=AASP-5A76-VKQO-CZZF-SQ6R-DQUU-2A
 (Expires=2024-10-04T14:57:13Z)
</div>
~~~~

The pin code can now be used to authenticate the connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AASP-5A76-VKQO-CZZF-SQ6R-DQUU-2A
<rsp>   Device UDF = MBQN-RX3S-JAXD-GPDP-U3HD-PAOR-7ZVF
   Witness value = FIFD-IQCW-5UHI-F2H6-XMWU-ECYP-OOTA
</div>
~~~~

Since the PIN code that was issued was set to be self-authorizing, the device
is connected automatically when the user synchronizes their account from an 
administrator device:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: FIFD-IQCW-5UHI-F2H6-XMWU-ECYP-OOTA
        Connection Request::
        MessageID: FIFD-IQCW-5UHI-F2H6-XMWU-ECYP-OOTA
        To:  From: 
        Device:  MBQN-RX3S-JAXD-GPDP-U3HD-PAOR-7ZVF
        Witness: FIFD-IQCW-5UHI-F2H6-XMWU-ECYP-OOTA
MessageID: NBHK-3QNB-UGZT-H5XN-2CXU-RIL7-XJZY
MessageID: NC75-ZYCL-N3BL-FVYI-TFSW-FFJV-DZHW
        Confirmation Request::
        MessageID: NC75-ZYCL-N3BL-FVYI-TFSW-FFJV-DZHW
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDYX-HZYP-X7E3-4UR4-LH7A-BQMT-PQXJ
MessageID: NDXB-RN25-2RVC-F3FL-FULX-GQNG-TAYB
MessageID: NCDS-JZQ5-N633-ZKWA-7U5I-6LNU-PFT5
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
<rsp>Device UDF: MBQI-JNHL-6QU5-BMOC-PX4M-P2PV-NYDM
File: EDZW-33F5-EL2X-SWIB-LKM3-J5PP-FM.medk
</div>
~~~~

This creates a configuration file that is installed on the device by executing the
`device install` command on the device itself:


~~~~
<div="terminal">
<cmd>Alice4> meshman device install EDZW-33F5-EL2X-SWIB-LKM3-J5PP-FM.medk
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
    mcd://maker@example.com/EDZW-33F5-EL2X-SWIB-LKM3-J5PP-FM /web
</div>
~~~~

The tool performs the tasks of resolving the EARL, decrypting the discovery record
and posting a connection response to both the hailing account and the profile account.
The next time the device polls the hailing account, it retrieves the connection data:


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MBQI-JNHL-6QU5-BMOC-PX4M-P2PV-NYDM
   Account = alice@example.com
   Account UDF = MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
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
<rsp>PIN=ABXA-OPP3-GHXO-SHKI-ZBFX-MWN5-O4
 (Expires=2024-10-04T14:57:18Z)
</div>
~~~~

The connecting device requests connection using the  `device join`
command specifying the URI.


~~~~
<div="terminal">
<cmd>Alice5> meshman device join ^
    mcd://alice@example.com/ABXA-OPP3-GHXO-SHKI-ZBFX-MWN5-O4
<rsp>   Device UDF = MBQD-THF4-QEOJ-FZJ4-6HZE-SGJT-NJ7K
   Witness value = XUFB-NAUM-HTI6-7KBJ-LSTU-D6VK-7MCN
</div>
~~~~

The administration device processes the device connection request automatically,
as before.


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: XUFB-NAUM-HTI6-7KBJ-LSTU-D6VK-7MCN
        Connection Request::
        MessageID: XUFB-NAUM-HTI6-7KBJ-LSTU-D6VK-7MCN
        To:  From: 
        Device:  MBQD-THF4-QEOJ-FZJ4-6HZE-SGJT-NJ7K
        Witness: XUFB-NAUM-HTI6-7KBJ-LSTU-D6VK-7MCN
MessageID: NCXJ-O4KW-TYR2-NLAH-IMBE-XRMZ-6LEW
        Confirmation Request::
        MessageID: NCXJ-O4KW-TYR2-NLAH-IMBE-XRMZ-6LEW
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NCCP-EY2P-JOLB-Y6CP-62LW-N66N-LJ2K
        Confirmation Request::
        MessageID: NCCP-EY2P-JOLB-Y6CP-62LW-N66N-LJ2K
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NBO6-PMM3-RAWS-FXXA-OGRB-2RSW-U32O
        Contact Request::
        MessageID: NBO6-PMM3-RAWS-FXXA-OGRB-2RSW-U32O
        To: alice@example.com From: carol@example.com
        PIN: 
MessageID: NBVM-E7SA-FVGJ-BOHH-FV7P-YI5C-RFP2
MessageID: NBHK-3QNB-UGZT-H5XN-2CXU-RIL7-XJZY
MessageID: NC75-ZYCL-N3BL-FVYI-TFSW-FFJV-DZHW
        Confirmation Request::
        MessageID: NC75-ZYCL-N3BL-FVYI-TFSW-FFJV-DZHW
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDYX-HZYP-X7E3-4UR4-LH7A-BQMT-PQXJ
MessageID: NDXB-RN25-2RVC-F3FL-FULX-GQNG-TAYB
MessageID: NCDS-JZQ5-N633-ZKWA-7U5I-6LNU-PFT5
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


