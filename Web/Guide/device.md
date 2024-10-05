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
<rsp>   Device UDF = MBQC-IDY4-CZUY-G67R-2TLC-2C5Z-DQRB
   Witness value = WSUK-ELAN-TR7B-AYXK-MO6C-WPWZ-CLJN
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
<rsp>MessageID: WSUK-ELAN-TR7B-AYXK-MO6C-WPWZ-CLJN
        Connection Request::
        MessageID: WSUK-ELAN-TR7B-AYXK-MO6C-WPWZ-CLJN
        To:  From: 
        Device:  MBQC-IDY4-CZUY-G67R-2TLC-2C5Z-DQRB
        Witness: WSUK-ELAN-TR7B-AYXK-MO6C-WPWZ-CLJN
</div>
~~~~

Alice sees the request that she posted and approves it with the
`device accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman device accept WSUK-ELAN-TR7B-AYXK-MO6C-WPWZ-CLJN ^
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
  Base UDF MBQF-YQKD-WHOG-DW7W-M3TY-L3ZH-NYQY
  Mesh UDF 
Encrypted: MD2Q-S3EX-AUSX-7NIM-M6ER-K5DY-O5RU
  Profile User
    Signed by: MCYG-N23F-5DZK-HEFN-CNPG-MO4B-IHGT
      KeyOfflineSignature: MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ 
      AccountAddress : alice@example.com 
      KeyEncryption:       MB54-OEEK-JZSG-TRLU-HPIR-SABF-T35O 
  Profile Device
    Signed by: MDH6-WLKO-NLJG-IB2E-ADKW-Y3MP-U6MO
      ProfileUDF:          MBQF-YQKD-WHOG-DW7W-M3TY-L3ZH-NYQY 
      KeySignature:        MBXL-LS6K-I3A2-5SVY-CAC7-SXZ7-US57 
      KeyEncryption:       MCBB-M7O3-CAME-DTAL-GNUB-IADA-BHUX 
      KeyAuthentication:   MBAO-C3HO-FRF3-4RT2-JNDS-RX73-FPLU 
  Connection Device
    Signed by: MAOW-5PUN-MGDW-NTP4-42BU-XE63-JKHS
      KeyAuthentication:   MDEI-XJXK-WDPK-LJA4-RXKZ-AHZI-ASGL 

ContextDevice Local: -
  Base UDF MBQC-IDY4-CZUY-G67R-2TLC-2C5Z-DQRB
  Mesh UDF 
Encrypted: MBJP-LVFC-3QCA-MYXF-JNDH-XRYD-AHOL
  Profile User
    Signed by: MCYG-N23F-5DZK-HEFN-CNPG-MO4B-IHGT
      KeyOfflineSignature: MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ 
      AccountAddress : alice@example.com 
      KeyEncryption:       MB54-OEEK-JZSG-TRLU-HPIR-SABF-T35O 
  Profile Device
    Signed by: MDOG-NDYF-DFJ4-D47A-NYXR-JXR2-FD7F
      ProfileUDF:          MBQC-IDY4-CZUY-G67R-2TLC-2C5Z-DQRB 
      KeySignature:        MAO4-ST3F-DYFM-SBPU-SJXR-SQK4-4SD4 
      KeyEncryption:       MDXH-OU3E-BSXS-RV5M-RRW5-TL22-F5LV 
      KeyAuthentication:   MDLF-R6QH-UDWS-2HDN-EX4Q-6KBA-F55U 
  Connection Device
    Signed by: MAOW-5PUN-MGDW-NTP4-42BU-XE63-JKHS
      KeyAuthentication:   MBHZ-TYG5-5ZX2-DR7Y-TVOI-5WO6-K3VP 

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
<rsp>PIN=AA34-4UB6-2FPH-KPT6-JNTU-PNWR-MU
 (Expires=2024-10-06T00:49:11Z)
</div>
~~~~

The pin code can now be used to authenticate the connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AA34-4UB6-2FPH-KPT6-JNTU-PNWR-MU
<rsp>   Device UDF = MBQB-VIJP-5XSD-4LQL-R6VP-DRGB-T2TU
   Witness value = F7X6-DDMV-2X7D-3KQ7-GW55-ES6F-WZAC
</div>
~~~~

Since the PIN code that was issued was set to be self-authorizing, the device
is connected automatically when the user synchronizes their account from an 
administrator device:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: F7X6-DDMV-2X7D-3KQ7-GW55-ES6F-WZAC
        Connection Request::
        MessageID: F7X6-DDMV-2X7D-3KQ7-GW55-ES6F-WZAC
        To:  From: 
        Device:  MBQB-VIJP-5XSD-4LQL-R6VP-DRGB-T2TU
        Witness: F7X6-DDMV-2X7D-3KQ7-GW55-ES6F-WZAC
MessageID: NDW4-S5EU-3BER-BTL2-EA2D-C4LL-TKLA
MessageID: NBUX-DOPM-JJKG-NKMV-K24G-MX24-4QNW
        Confirmation Request::
        MessageID: NBUX-DOPM-JJKG-NKMV-K24G-MX24-4QNW
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NA2W-XWGB-F4LB-MUSW-MC4I-YK2G-GAJT
MessageID: NBTZ-WSA2-2OFC-QMTP-LA2D-FMRE-P4N5
MessageID: ND2F-I3BZ-645E-OSBR-Z5NI-MIUG-4IRN
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
<rsp>Device UDF: MBQF-KCLE-D7QI-5DMJ-M4CE-CS3H-Z53R
File: EC2K-TADU-3ZHN-BPBC-TZY6-EAKJ-SM.medk
</div>
~~~~

This creates a configuration file that is installed on the device by executing the
`device install` command on the device itself:


~~~~
<div="terminal">
<cmd>Alice4> meshman device install EC2K-TADU-3ZHN-BPBC-TZY6-EAKJ-SM.medk
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
    mcd://maker@example.com/EC2K-TADU-3ZHN-BPBC-TZY6-EAKJ-SM /web
</div>
~~~~

The tool performs the tasks of resolving the EARL, decrypting the discovery record
and posting a connection response to both the hailing account and the profile account.
The next time the device polls the hailing account, it retrieves the connection data:


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MBQF-KCLE-D7QI-5DMJ-M4CE-CS3H-Z53R
   Account = alice@example.com
   Account UDF = MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
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
<rsp>PIN=ABMC-2GCP-MLEY-NUKJ-T4SE-GOEY-DI
 (Expires=2024-10-06T00:49:16Z)
</div>
~~~~

The connecting device requests connection using the  `device join`
command specifying the URI.


~~~~
<div="terminal">
<cmd>Alice5> meshman device join ^
    mcd://alice@example.com/ABMC-2GCP-MLEY-NUKJ-T4SE-GOEY-DI
<rsp>   Device UDF = MBQD-GLW5-UWZF-33EF-ADZN-G7FM-YPMY
   Witness value = LDUW-ZIG2-ABJE-KRZD-SEPD-A624-LBNH
</div>
~~~~

The administration device processes the device connection request automatically,
as before.


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: LDUW-ZIG2-ABJE-KRZD-SEPD-A624-LBNH
        Connection Request::
        MessageID: LDUW-ZIG2-ABJE-KRZD-SEPD-A624-LBNH
        To:  From: 
        Device:  MBQD-GLW5-UWZF-33EF-ADZN-G7FM-YPMY
        Witness: LDUW-ZIG2-ABJE-KRZD-SEPD-A624-LBNH
MessageID: NCKP-YT3W-P6UO-RMXC-AADI-UMZU-MXHM
        Confirmation Request::
        MessageID: NCKP-YT3W-P6UO-RMXC-AADI-UMZU-MXHM
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NCWS-U7X5-KH5X-GJGQ-YMRS-JDDX-VUGY
        Confirmation Request::
        MessageID: NCWS-U7X5-KH5X-GJGQ-YMRS-JDDX-VUGY
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NCNQ-GNZL-T5OB-LMG3-QRLO-ZJJS-HLUN
        Contact Request::
        MessageID: NCNQ-GNZL-T5OB-LMG3-QRLO-ZJJS-HLUN
        To: alice@example.com From: carol@example.com
        PIN: 
MessageID: NCJE-CLT3-KBMJ-PTYB-YIKW-Y776-MFA6
MessageID: NDW4-S5EU-3BER-BTL2-EA2D-C4LL-TKLA
MessageID: NBUX-DOPM-JJKG-NKMV-K24G-MX24-4QNW
        Confirmation Request::
        MessageID: NBUX-DOPM-JJKG-NKMV-K24G-MX24-4QNW
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NA2W-XWGB-F4LB-MUSW-MC4I-YK2G-GAJT
MessageID: NBTZ-WSA2-2OFC-QMTP-LA2D-FMRE-P4N5
MessageID: ND2F-I3BZ-645E-OSBR-Z5NI-MIUG-4IRN
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


