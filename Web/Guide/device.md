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
<rsp>   Device UDF = MCI6-2IJ3-PFLT-GVUQ-5PN7-B337-VWWQ
   Witness value = CI4K-GV7W-VRTX-QTNB-ZNBG-652H-GMWJ
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
<rsp>MessageID: CI4K-GV7W-VRTX-QTNB-ZNBG-652H-GMWJ
        Connection Request::
        MessageID: CI4K-GV7W-VRTX-QTNB-ZNBG-652H-GMWJ
        To:  From: 
        Device:  MCI6-2IJ3-PFLT-GVUQ-5PN7-B337-VWWQ
        Witness: CI4K-GV7W-VRTX-QTNB-ZNBG-652H-GMWJ
</div>
~~~~

Alice sees the request that she posted and approves it with the
`device accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman device accept CI4K-GV7W-VRTX-QTNB-ZNBG-652H-GMWJ ^
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
  Base UDF MDJY-YAXQ-VATX-F52K-YT6M-YMUK-D3PV
  Mesh UDF 
Encrypted: MCPU-YLOY-3PGZ-RS2A-JA2G-73P6-DMQ2
  Profile User
    Signed by: MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
      KeyOfflineSignature: MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V 
      AccountAddress : alice@example.com 
      KeyEncryption:       MASL-5B72-3K3B-PKQR-MGHP-L5QP-MVOA 
  Profile Device
    Signed by: MDJY-YAXQ-VATX-F52K-YT6M-YMUK-D3PV
      ProfileSignature: MDJY-YAXQ-VATX-F52K-YT6M-YMUK-D3PV 
      KeySignature:        MCQU-URCN-F6YN-UXJT-HMTB-IT46-LZI3 
      KeyEncryption:       MATZ-4HLY-OSDB-2MPT-UG75-AWY4-EAYU 
      KeyAuthentication:   MC6M-NIE2-IIBE-QOZR-PAWL-VPCY-L7MM 
  Connection Device
    Signed by: MAJ5-HQAF-XXGK-W6BW-EGH3-ELNH-EQ7I
      KeyAuthentication:   MCLZ-7JDK-R6X2-3TL6-ZAMN-3ZDK-5P3C 

ContextDevice Local: -
  Base UDF MCI6-2IJ3-PFLT-GVUQ-5PN7-B337-VWWQ
  Mesh UDF 
Encrypted: MAST-EV3R-CLXM-LVOO-L3FH-QHJ7-WATP
  Profile User
    Signed by: MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
      KeyOfflineSignature: MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V 
      AccountAddress : alice@example.com 
      KeyEncryption:       MASL-5B72-3K3B-PKQR-MGHP-L5QP-MVOA 
  Profile Device
    Signed by: MCI6-2IJ3-PFLT-GVUQ-5PN7-B337-VWWQ
      ProfileSignature: MCI6-2IJ3-PFLT-GVUQ-5PN7-B337-VWWQ 
      KeySignature:        MANQ-RGWQ-WVGB-67TK-ZYSG-EHKO-L4VZ 
      KeyEncryption:       MBS6-AI2M-MGJN-GLC5-23C7-VIOW-A2WU 
      KeyAuthentication:   MANG-ZBCQ-EKY7-4COM-7WWA-XA43-HQ36 
  Connection Device
    Signed by: MAJ5-HQAF-XXGK-W6BW-EGH3-ELNH-EQ7I
      KeyAuthentication:   MD75-RPX5-5NK4-FHKK-2PSE-DWSY-WU6Y 

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
<rsp>PIN=ADKW-K2ZB-PPZM-ECG4-P3NQ-UN4K-XI
 (Expires=2022-05-04T16:47:51Z)
</div>
~~~~

The pin code can now be used to authenticate the connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ADKW-K2ZB-PPZM-ECG4-P3NQ-UN4K-XI
<rsp>   Device UDF = MAWL-JZU3-BV3H-JBT4-KPLE-OU4A-UNSY
   Witness value = YDLF-TRCY-GPUF-HGY3-7NRH-IIIG-DTGX
</div>
~~~~

Since the PIN code that was issued was set to be self-authorizing, the device
is connected automatically when the user synchronizes their account from an 
administrator device:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: YDLF-TRCY-GPUF-HGY3-7NRH-IIIG-DTGX
        Connection Request::
        MessageID: YDLF-TRCY-GPUF-HGY3-7NRH-IIIG-DTGX
        To:  From: 
        Device:  MAWL-JZU3-BV3H-JBT4-KPLE-OU4A-UNSY
        Witness: YDLF-TRCY-GPUF-HGY3-7NRH-IIIG-DTGX
MessageID: NAJ7-2JAE-5VND-GLM3-YYHF-FQX2-TCF7
        Confirmation Request::
        MessageID: NAJ7-2JAE-5VND-GLM3-YYHF-FQX2-TCF7
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
<rsp>Device UDF: MBYN-VC7T-AIEX-KCK2-WQLP-4B52-3GWY
File: EDRL-4MZP-3OUD-OZBS-SPZN-7OSO-OM.medk
</div>
~~~~

This creates a configuration file that is installed on the device by executing the
`device install` command on the device itself:


~~~~
<div="terminal">
<cmd>Alice4> meshman device install EDRL-4MZP-3OUD-OZBS-SPZN-7OSO-OM.medk
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
    mcu://maker@example.com/EDRL-4MZP-3OUD-OZBS-SPZN-7OSO-OM /web
</div>
~~~~

The tool performs the tasks of resolving the EARL, decrypting the discovery record
and posting a connection response to both the hailing account and the profile account.
The next time the device polls the hailing account, it retrieves the connection data:


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MBYN-VC7T-AIEX-KCK2-WQLP-4B52-3GWY
   Account = alice@example.com
   Account UDF = MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
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
<rsp>PIN=AAOW-DIW2-ZTBT-QUJP-BZZA-HF7N-SA
 (Expires=2022-05-04T16:48:06Z)
</div>
~~~~

The connecting device requests connection using the  `device join`
command specifying the URI.


~~~~
<div="terminal">
<cmd>Alice5> meshman device join ^
    mcu://alice@example.com/AAOW-DIW2-ZTBT-QUJP-BZZA-HF7N-SA
<rsp>   Device UDF = MDRW-QCTK-RYYW-VMFP-2P5B-LCO5-LRV2
   Witness value = PDH5-DZIR-VZKZ-YWHY-EFS6-BRZI-L5CZ
</div>
~~~~

The administration device processes the device connection request automatically,
as before.


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: PDH5-DZIR-VZKZ-YWHY-EFS6-BRZI-L5CZ
        Connection Request::
        MessageID: PDH5-DZIR-VZKZ-YWHY-EFS6-BRZI-L5CZ
        To:  From: 
        Device:  MDRW-QCTK-RYYW-VMFP-2P5B-LCO5-LRV2
        Witness: PDH5-DZIR-VZKZ-YWHY-EFS6-BRZI-L5CZ
MessageID: NBT7-KOGL-6HG3-KLNO-SXJN-3TRC-WD5W
        Confirmation Request::
        MessageID: NBT7-KOGL-6HG3-KLNO-SXJN-3TRC-WD5W
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NAGI-LWB2-E2YE-YCOX-E5AQ-W6KJ-KWC5
        Confirmation Request::
        MessageID: NAGI-LWB2-E2YE-YCOX-E5AQ-W6KJ-KWC5
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NBSD-MRON-A3ED-M7Y6-M7N6-YMV3-J4RZ
        Contact Request::
        MessageID: NBSD-MRON-A3ED-M7Y6-M7N6-YMV3-J4RZ
        To: alice@example.com From: carol@example.com
        PIN: 
MessageID: NAJ7-2JAE-5VND-GLM3-YYHF-FQX2-TCF7
        Confirmation Request::
        MessageID: NAJ7-2JAE-5VND-GLM3-YYHF-FQX2-TCF7
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


