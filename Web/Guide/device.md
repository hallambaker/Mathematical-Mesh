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
<rsp>   Device UDF = MBYI-QYCM-JXEY-OJ5D-4OW2-RPIR-SHUM
   Witness value = Z3PE-JMM5-G3XQ-CB3Q-LNX4-2YY6-Q74Y
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
<rsp>MessageID: Z3PE-JMM5-G3XQ-CB3Q-LNX4-2YY6-Q74Y
        Connection Request::
        MessageID: Z3PE-JMM5-G3XQ-CB3Q-LNX4-2YY6-Q74Y
        To:  From: 
        Device:  MBYI-QYCM-JXEY-OJ5D-4OW2-RPIR-SHUM
        Witness: Z3PE-JMM5-G3XQ-CB3Q-LNX4-2YY6-Q74Y
</div>
~~~~

Alice sees the request that she posted and approves it with the
`device accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman device accept Z3PE-JMM5-G3XQ-CB3Q-LNX4-2YY6-Q74Y ^
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
  Base UDF MDLS-GEJJ-XMUN-IK7Q-N2A2-G2RM-VC7F
  Mesh UDF 
Encrypted: MBVB-YEXV-GLU4-HJEM-JM3W-TVR2-4JFW
  Profile User
    Signed by: MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
      KeyOfflineSignature: MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2 
      AccountAddress : alice@example.com 
      KeyEncryption:       MBUF-P7S2-WFEF-D3ML-OKCC-XYOT-6SLD 
  Profile Device
    Signed by: MDLS-GEJJ-XMUN-IK7Q-N2A2-G2RM-VC7F
      ProfileSignature: MDLS-GEJJ-XMUN-IK7Q-N2A2-G2RM-VC7F 
      KeySignature:        MAWC-HMJX-R2XL-ZK57-4EZV-VEKK-6CEW 
      KeyEncryption:       MBL2-DF7V-CGG4-OBYD-534B-I2CK-TW5F 
      KeyAuthentication:   MDJA-Y34W-IVHF-344H-7KCI-RSHR-FQBI 
  Connection Device
    Signed by: MBL5-JSN3-V56Q-4ULY-GY7X-GM3V-KVPZ
      KeyAuthentication:   MDTR-OHHZ-ZTKT-VBZC-YX23-F2N5-YBMZ 

ContextDevice Local: -
  Base UDF MBYI-QYCM-JXEY-OJ5D-4OW2-RPIR-SHUM
  Mesh UDF 
Encrypted: MARU-OXNG-MA6F-7LZQ-R75I-2DSO-7RHN
  Profile User
    Signed by: MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
      KeyOfflineSignature: MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2 
      AccountAddress : alice@example.com 
      KeyEncryption:       MBUF-P7S2-WFEF-D3ML-OKCC-XYOT-6SLD 
  Profile Device
    Signed by: MBYI-QYCM-JXEY-OJ5D-4OW2-RPIR-SHUM
      ProfileSignature: MBYI-QYCM-JXEY-OJ5D-4OW2-RPIR-SHUM 
      KeySignature:        MCGI-AARY-CKX6-OTD6-XLON-JIZK-HGE5 
      KeyEncryption:       MCFX-IUBA-KOCW-3FUS-23Z5-NR5U-YOLN 
      KeyAuthentication:   MCRL-42BN-TYVI-BDGP-K2NJ-OGNI-QEA3 
  Connection Device
    Signed by: MBL5-JSN3-V56Q-4ULY-GY7X-GM3V-KVPZ
      KeyAuthentication:   MBGO-55A4-MBVM-L2G7-4T5B-NILX-AODX 

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
<rsp>PIN=AAKI-IIAD-GQ3H-JUY3-SXZN-PENW-PQ
 (Expires=2023-06-29T17:00:45Z)
</div>
~~~~

The pin code can now be used to authenticate the connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AAKI-IIAD-GQ3H-JUY3-SXZN-PENW-PQ
<rsp>   Device UDF = MBXV-SIBF-4XEW-4EVE-7URW-F6VT-NTX3
   Witness value = GSJR-OHU5-HHXO-KURY-ST4B-HVBA-7PV5
</div>
~~~~

Since the PIN code that was issued was set to be self-authorizing, the device
is connected automatically when the user synchronizes their account from an 
administrator device:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: GSJR-OHU5-HHXO-KURY-ST4B-HVBA-7PV5
        Connection Request::
        MessageID: GSJR-OHU5-HHXO-KURY-ST4B-HVBA-7PV5
        To:  From: 
        Device:  MBXV-SIBF-4XEW-4EVE-7URW-F6VT-NTX3
        Witness: GSJR-OHU5-HHXO-KURY-ST4B-HVBA-7PV5
MessageID: NCUD-3ROZ-X7UK-MMRA-CTYI-YHOE-UJCM
MessageID: NDTU-IIPR-L5SK-L6CZ-JJGF-XA6L-565H
        Confirmation Request::
        MessageID: NDTU-IIPR-L5SK-L6CZ-JJGF-XA6L-565H
        To: alice@example.com From: console@example.com
        Text: start
MessageID: ND4Y-TGCW-2QO3-KIQM-N3AN-DMIO-2CFT
MessageID: NCVI-FDFU-ZYPN-5274-YBHY-V6WI-FTEJ
MessageID: NA7V-2XT2-2ZJO-IDUY-GK6W-CTVX-HDDM
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
<rsp>Device UDF: MBAI-IMKY-GI2T-D472-4VP5-SKRF-ZXYW
File: ECHI-CYLR-Y22Q-6OME-OAWV-WIQD-YM.medk
</div>
~~~~

This creates a configuration file that is installed on the device by executing the
`device install` command on the device itself:


~~~~
<div="terminal">
<cmd>Alice4> meshman device install ECHI-CYLR-Y22Q-6OME-OAWV-WIQD-YM.medk
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
    mcu://maker@example.com/ECHI-CYLR-Y22Q-6OME-OAWV-WIQD-YM /web
</div>
~~~~

The tool performs the tasks of resolving the EARL, decrypting the discovery record
and posting a connection response to both the hailing account and the profile account.
The next time the device polls the hailing account, it retrieves the connection data:


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MBAI-IMKY-GI2T-D472-4VP5-SKRF-ZXYW
   Account = alice@example.com
   Account UDF = MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
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
<rsp>PIN=ADHN-QSL4-LX54-57PC-4M6I-3B4Q-4E
 (Expires=2023-06-29T17:00:57Z)
</div>
~~~~

The connecting device requests connection using the  `device join`
command specifying the URI.


~~~~
<div="terminal">
<cmd>Alice5> meshman device join ^
    mcu://alice@example.com/ADHN-QSL4-LX54-57PC-4M6I-3B4Q-4E
<rsp>   Device UDF = MB4X-7ZVI-L45S-33KI-6OSQ-IINM-EJVL
   Witness value = WMTF-WPPB-R3IS-WBBK-EULC-SWVX-ZTQE
</div>
~~~~

The administration device processes the device connection request automatically,
as before.


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: WMTF-WPPB-R3IS-WBBK-EULC-SWVX-ZTQE
        Connection Request::
        MessageID: WMTF-WPPB-R3IS-WBBK-EULC-SWVX-ZTQE
        To:  From: 
        Device:  MB4X-7ZVI-L45S-33KI-6OSQ-IINM-EJVL
        Witness: WMTF-WPPB-R3IS-WBBK-EULC-SWVX-ZTQE
MessageID: NB2W-DI3Y-VGDZ-GURG-D3AZ-LUOX-MAE5
        Confirmation Request::
        MessageID: NB2W-DI3Y-VGDZ-GURG-D3AZ-LUOX-MAE5
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NAGC-HVFG-US7J-BANB-YHPP-7DYJ-BJAZ
        Confirmation Request::
        MessageID: NAGC-HVFG-US7J-BANB-YHPP-7DYJ-BJAZ
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NAUI-IGWS-LQDM-K2DR-2FX6-I6M6-HF7O
        Contact Request::
        MessageID: NAUI-IGWS-LQDM-K2DR-2FX6-I6M6-HF7O
        To: alice@example.com From: carol@example.com
        PIN: 
MessageID: NBON-HCPF-EYY4-FCUG-XA4H-UCSZ-SVMR
MessageID: NCUD-3ROZ-X7UK-MMRA-CTYI-YHOE-UJCM
MessageID: NDTU-IIPR-L5SK-L6CZ-JJGF-XA6L-565H
        Confirmation Request::
        MessageID: NDTU-IIPR-L5SK-L6CZ-JJGF-XA6L-565H
        To: alice@example.com From: console@example.com
        Text: start
MessageID: ND4Y-TGCW-2QO3-KIQM-N3AN-DMIO-2CFT
MessageID: NCVI-FDFU-ZYPN-5274-YBHY-V6WI-FTEJ
MessageID: NA7V-2XT2-2ZJO-IDUY-GK6W-CTVX-HDDM
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


