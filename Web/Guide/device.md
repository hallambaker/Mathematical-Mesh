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
<rsp>   Device UDF = MBQD-67IL-PJTR-EYFE-2ZGV-QLZF-QC6W
   Witness value = 5B3I-YIJU-2ACH-J6NE-K5YF-RJDF-PN25
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
<rsp>MessageID: 5B3I-YIJU-2ACH-J6NE-K5YF-RJDF-PN25
        Connection Request::
        MessageID: 5B3I-YIJU-2ACH-J6NE-K5YF-RJDF-PN25
        To:  From: 
        Device:  MBQD-67IL-PJTR-EYFE-2ZGV-QLZF-QC6W
        Witness: 5B3I-YIJU-2ACH-J6NE-K5YF-RJDF-PN25
</div>
~~~~

Alice sees the request that she posted and approves it with the
`device accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman device accept 5B3I-YIJU-2ACH-J6NE-K5YF-RJDF-PN25 ^
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
  Base UDF MBQC-YFCL-LW2W-SPPP-UKYD-SVR6-OJHQ
  Mesh UDF 
Encrypted: MADR-L26E-LD6Z-5O57-2VBH-AGRC-PYYR
  Profile User
    Signed by: MDHF-7GNO-ALJT-2IU7-K4B5-HW5P-HMGX
      KeyOfflineSignature: MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA 
      AccountAddress : alice@example.com 
      KeyEncryption:       MANS-YZVU-VA6V-CCK6-PCQR-E2QD-5F6P 
  Profile Device
    Signed by: MA4B-ENAN-4DK2-VRKJ-MLXA-VYMT-AFOU
      ProfileUDF:          MBQC-YFCL-LW2W-SPPP-UKYD-SVR6-OJHQ 
      KeySignature:        MC7I-KD5E-YMGR-DEP7-WIHR-HFJ7-MWUR 
      KeyEncryption:       MBQV-LWLV-66EA-Y3EB-56DO-WPWO-RJYM 
      KeyAuthentication:   MDL7-BZGY-XLEK-7EZR-4VMS-XPCM-D3K6 
  Connection Device
    Signed by: MD5M-A4YJ-AMPV-YTOS-3GVV-62RQ-HW4V
      KeyAuthentication:   MD62-7COY-3OJW-5BZ5-7DIJ-E552-FXTM 

ContextDevice Local: -
  Base UDF MBQD-67IL-PJTR-EYFE-2ZGV-QLZF-QC6W
  Mesh UDF 
Encrypted: MCUM-EI7S-VLIJ-ALQO-SPSK-VM5P-R6MA
  Profile User
    Signed by: MDHF-7GNO-ALJT-2IU7-K4B5-HW5P-HMGX
      KeyOfflineSignature: MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA 
      AccountAddress : alice@example.com 
      KeyEncryption:       MANS-YZVU-VA6V-CCK6-PCQR-E2QD-5F6P 
  Profile Device
    Signed by: MBLC-Q7UK-UUF6-MLNT-DCUM-WNL2-ZSWS
      ProfileUDF:          MBQD-67IL-PJTR-EYFE-2ZGV-QLZF-QC6W 
      KeySignature:        MDCJ-2FTP-PBLN-BPGQ-7DV3-L32H-V732 
      KeyEncryption:       MAXU-PRRI-4UUI-JYUA-BOA6-YTF3-ZU66 
      KeyAuthentication:   MDWG-3KU4-YWVF-Y2OQ-2BZ3-J3SN-VQIU 
  Connection Device
    Signed by: MD5M-A4YJ-AMPV-YTOS-3GVV-62RQ-HW4V
      KeyAuthentication:   MBO5-BV4J-OXHA-RA27-3CAW-4WNR-XOYW 

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
<rsp>PIN=AC23-KHLF-VHYV-MQXF-3PM2-WZRM-TU
 (Expires=2024-10-05T13:13:13Z)
</div>
~~~~

The pin code can now be used to authenticate the connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AC23-KHLF-VHYV-MQXF-3PM2-WZRM-TU
<rsp>   Device UDF = MBQN-TRFD-22HH-7VJO-3B6R-APJC-HUCP
   Witness value = TWJD-AUPC-2BSP-3V4U-ZS2Z-S63O-2KNH
</div>
~~~~

Since the PIN code that was issued was set to be self-authorizing, the device
is connected automatically when the user synchronizes their account from an 
administrator device:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: TWJD-AUPC-2BSP-3V4U-ZS2Z-S63O-2KNH
        Connection Request::
        MessageID: TWJD-AUPC-2BSP-3V4U-ZS2Z-S63O-2KNH
        To:  From: 
        Device:  MBQN-TRFD-22HH-7VJO-3B6R-APJC-HUCP
        Witness: TWJD-AUPC-2BSP-3V4U-ZS2Z-S63O-2KNH
MessageID: NAPX-XU4B-T4ET-JQOC-TTUN-EXCZ-2BSR
MessageID: NDPC-BWU4-ULAU-DUSZ-PDP5-7QOH-H53L
        Confirmation Request::
        MessageID: NDPC-BWU4-ULAU-DUSZ-PDP5-7QOH-H53L
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NANH-ZJY3-4XRC-G3WA-WMFB-DFU6-HW3X
MessageID: NA5L-OBCK-V3V3-VRBZ-4ISE-GB3B-VR64
MessageID: NADD-B6K4-SDGI-BSJX-SKLV-R2X5-IPYH
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
<rsp>Device UDF: MBQB-XXTS-WODJ-3IRX-5UUM-T5RQ-PRJK
File: EACX-H62H-KJOX-E6DY-OA7A-R7ZC-PE.medk
</div>
~~~~

This creates a configuration file that is installed on the device by executing the
`device install` command on the device itself:


~~~~
<div="terminal">
<cmd>Alice4> meshman device install EACX-H62H-KJOX-E6DY-OA7A-R7ZC-PE.medk
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
    mcd://maker@example.com/EACX-H62H-KJOX-E6DY-OA7A-R7ZC-PE /web
</div>
~~~~

The tool performs the tasks of resolving the EARL, decrypting the discovery record
and posting a connection response to both the hailing account and the profile account.
The next time the device polls the hailing account, it retrieves the connection data:


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MBQB-XXTS-WODJ-3IRX-5UUM-T5RQ-PRJK
   Account = alice@example.com
   Account UDF = MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA
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
<rsp>PIN=AAHV-L3WI-3N6X-VYRQ-4FPX-6UHZ-YE
 (Expires=2024-10-05T13:13:18Z)
</div>
~~~~

The connecting device requests connection using the  `device join`
command specifying the URI.


~~~~
<div="terminal">
<cmd>Alice5> meshman device join ^
    mcd://alice@example.com/AAHV-L3WI-3N6X-VYRQ-4FPX-6UHZ-YE
<rsp>   Device UDF = MBQK-7VV6-BIHW-UKBO-S7MO-6LS2-VHEJ
   Witness value = QOHC-T2N6-EGYF-3YKO-BPEC-MM7O-KT3F
</div>
~~~~

The administration device processes the device connection request automatically,
as before.


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: QOHC-T2N6-EGYF-3YKO-BPEC-MM7O-KT3F
        Connection Request::
        MessageID: QOHC-T2N6-EGYF-3YKO-BPEC-MM7O-KT3F
        To:  From: 
        Device:  MBQK-7VV6-BIHW-UKBO-S7MO-6LS2-VHEJ
        Witness: QOHC-T2N6-EGYF-3YKO-BPEC-MM7O-KT3F
MessageID: NAUT-J3JS-GKV6-YH3V-7WIU-46W4-Y6ZM
        Confirmation Request::
        MessageID: NAUT-J3JS-GKV6-YH3V-7WIU-46W4-Y6ZM
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NA26-KNMO-Y5GI-HLZL-SROC-OZMC-TEDT
        Confirmation Request::
        MessageID: NA26-KNMO-Y5GI-HLZL-SROC-OZMC-TEDT
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NAHP-52ZQ-2W3U-GZ36-FUXX-UCFU-4GY5
        Contact Request::
        MessageID: NAHP-52ZQ-2W3U-GZ36-FUXX-UCFU-4GY5
        To: alice@example.com From: carol@example.com
        PIN: 
MessageID: NDR2-72HA-DLC7-JBPZ-3UGL-BGJ5-FFYC
MessageID: NAPX-XU4B-T4ET-JQOC-TTUN-EXCZ-2BSR
MessageID: NDPC-BWU4-ULAU-DUSZ-PDP5-7QOH-H53L
        Confirmation Request::
        MessageID: NDPC-BWU4-ULAU-DUSZ-PDP5-7QOH-H53L
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NANH-ZJY3-4XRC-G3WA-WMFB-DFU6-HW3X
MessageID: NA5L-OBCK-V3V3-VRBZ-4ISE-GB3B-VR64
MessageID: NADD-B6K4-SDGI-BSJX-SKLV-R2X5-IPYH
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


