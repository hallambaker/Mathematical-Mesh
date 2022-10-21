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
<rsp>   Device UDF = MBYN-Q2AT-73EJ-2RO5-FZG3-CMIE-3YFA
   Witness value = 7QI7-PLXA-DZB2-XCQK-NGHH-DRXM-FIRV
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
<rsp>MessageID: 7QI7-PLXA-DZB2-XCQK-NGHH-DRXM-FIRV
        Connection Request::
        MessageID: 7QI7-PLXA-DZB2-XCQK-NGHH-DRXM-FIRV
        To:  From: 
        Device:  MBYN-Q2AT-73EJ-2RO5-FZG3-CMIE-3YFA
        Witness: 7QI7-PLXA-DZB2-XCQK-NGHH-DRXM-FIRV
</div>
~~~~

Alice sees the request that she posted and approves it with the
`device accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman device accept 7QI7-PLXA-DZB2-XCQK-NGHH-DRXM-FIRV ^
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
  Base UDF MDNC-XN2Z-LSPT-S4BS-CS73-BMYP-XPA7
  Mesh UDF 
Encrypted: MCCF-J5M6-B6PO-2GKN-M2ES-E2CQ-DRCG
  Profile User
    Signed by: MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
      KeyOfflineSignature: MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA 
      AccountAddress : alice@example.com 
      KeyEncryption:       MC7V-XVMJ-73OL-YWGL-5MIK-ROXQ-GL3Y 
  Profile Device
    Signed by: MDNC-XN2Z-LSPT-S4BS-CS73-BMYP-XPA7
      ProfileSignature: MDNC-XN2Z-LSPT-S4BS-CS73-BMYP-XPA7 
      KeySignature:        MCFV-WLBT-SWYG-Q6CM-XKUQ-VAMS-L2HC 
      KeyEncryption:       MD2W-TY6E-UJZ4-HFE5-OZEF-W2OL-RHC7 
      KeyAuthentication:   MD6Q-A7XT-VEHN-NA23-6W4C-RCI3-IIIX 
  Connection Device
    Signed by: MBFM-XW2H-CBLT-AMNQ-ZWVZ-USGI-KOGI
      KeyAuthentication:   MBPX-J5VL-TRSF-ETQ7-WHOK-UODK-3CAM 

ContextDevice Local: -
  Base UDF MBYN-Q2AT-73EJ-2RO5-FZG3-CMIE-3YFA
  Mesh UDF 
Encrypted: MA6D-RU2J-LL73-LAW6-7JO6-IFCU-WRNI
  Profile User
    Signed by: MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
      KeyOfflineSignature: MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA 
      AccountAddress : alice@example.com 
      KeyEncryption:       MC7V-XVMJ-73OL-YWGL-5MIK-ROXQ-GL3Y 
  Profile Device
    Signed by: MBYN-Q2AT-73EJ-2RO5-FZG3-CMIE-3YFA
      ProfileSignature: MBYN-Q2AT-73EJ-2RO5-FZG3-CMIE-3YFA 
      KeySignature:        MAW3-J5NK-BZ7B-EBTD-UHUL-HB6L-ZNS2 
      KeyEncryption:       MA45-T6UD-ZGTI-CT4A-6ZVK-5QFN-CV4E 
      KeyAuthentication:   MCIB-UBQQ-RFSJ-HSYP-3KHU-7FFP-26ZS 
  Connection Device
    Signed by: MBFM-XW2H-CBLT-AMNQ-ZWVZ-USGI-KOGI
      KeyAuthentication:   MBYN-SC4W-IU4X-LIVF-PSC6-6ADO-ZJOF 

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
<rsp>PIN=AAIT-WXRD-BVB7-3BBT-D6JS-44GE-B4
 (Expires=2022-10-19T12:48:11Z)
</div>
~~~~

The pin code can now be used to authenticate the connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AAIT-WXRD-BVB7-3BBT-D6JS-44GE-B4
<rsp>   Device UDF = MDVU-AOST-TDIH-AXGE-WUJS-I56V-WJP3
   Witness value = AI7W-YKPK-MR3U-CZW7-GAVQ-24LZ-MSFA
</div>
~~~~

Since the PIN code that was issued was set to be self-authorizing, the device
is connected automatically when the user synchronizes their account from an 
administrator device:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: AI7W-YKPK-MR3U-CZW7-GAVQ-24LZ-MSFA
        Connection Request::
        MessageID: AI7W-YKPK-MR3U-CZW7-GAVQ-24LZ-MSFA
        To:  From: 
        Device:  MDVU-AOST-TDIH-AXGE-WUJS-I56V-WJP3
        Witness: AI7W-YKPK-MR3U-CZW7-GAVQ-24LZ-MSFA
MessageID: NBGK-6BGU-5C5H-4WUR-OGDF-NZTH-ZLCW
        Confirmation Request::
        MessageID: NBGK-6BGU-5C5H-4WUR-OGDF-NZTH-ZLCW
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
<rsp>Device UDF: MALQ-6D3Y-ERRF-TIFW-36LR-6GJK-4OZI
File: ED6B-KIW3-TSCC-P4LM-4D3I-IAPD-LE.medk
</div>
~~~~

This creates a configuration file that is installed on the device by executing the
`device install` command on the device itself:


~~~~
<div="terminal">
<cmd>Alice4> meshman device install ED6B-KIW3-TSCC-P4LM-4D3I-IAPD-LE.medk
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
    mcu://maker@example.com/ED6B-KIW3-TSCC-P4LM-4D3I-IAPD-LE /web
</div>
~~~~

The tool performs the tasks of resolving the EARL, decrypting the discovery record
and posting a connection response to both the hailing account and the profile account.
The next time the device polls the hailing account, it retrieves the connection data:


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MALQ-6D3Y-ERRF-TIFW-36LR-6GJK-4OZI
   Account = alice@example.com
   Account UDF = MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
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
<rsp>PIN=ABQ3-UAY6-S63P-ORJF-3CFL-GLNF-SY
 (Expires=2022-10-19T13:15:56Z)
</div>
~~~~

The connecting device requests connection using the  `device join`
command specifying the URI.


~~~~
<div="terminal">
<cmd>Alice5> meshman device join ^
    mcu://alice@example.com/ABQ3-UAY6-S63P-ORJF-3CFL-GLNF-SY
<rsp>   Device UDF = MAVB-4V4O-JT7P-3BBT-VFK2-DRK4-BYOU
   Witness value = Y6SY-FOMH-6IJG-JHXQ-KB6E-7HDB-RYMK
</div>
~~~~

The administration device processes the device connection request automatically,
as before.


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: Y6SY-FOMH-6IJG-JHXQ-KB6E-7HDB-RYMK
        Connection Request::
        MessageID: Y6SY-FOMH-6IJG-JHXQ-KB6E-7HDB-RYMK
        To:  From: 
        Device:  MAVB-4V4O-JT7P-3BBT-VFK2-DRK4-BYOU
        Witness: Y6SY-FOMH-6IJG-JHXQ-KB6E-7HDB-RYMK
MessageID: NAAN-AMII-QI36-DSX5-GWJ3-QQ6A-6X37
        Confirmation Request::
        MessageID: NAAN-AMII-QI36-DSX5-GWJ3-QQ6A-6X37
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NDTG-NFEV-6O5F-ATRV-HF4Z-5HMN-ADOI
        Confirmation Request::
        MessageID: NDTG-NFEV-6O5F-ATRV-HF4Z-5HMN-ADOI
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NDAN-32MX-AACC-PTBG-NYMD-7TQ4-T2UD
        Contact Request::
        MessageID: NDAN-32MX-AACC-PTBG-NYMD-7TQ4-T2UD
        To: alice@example.com From: carol@example.com
        PIN: 
MessageID: NBGK-6BGU-5C5H-4WUR-OGDF-NZTH-ZLCW
        Confirmation Request::
        MessageID: NBGK-6BGU-5C5H-4WUR-OGDF-NZTH-ZLCW
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


