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
<rsp>   Device UDF = MBQB-RX7H-5QIR-V7MS-AN4W-JW7A-UXYV
   Witness value = L6YU-SEXF-YXRF-FVKG-EL2H-VJE4-LX7D
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
<rsp>MessageID: L6YU-SEXF-YXRF-FVKG-EL2H-VJE4-LX7D
        Connection Request::
        MessageID: L6YU-SEXF-YXRF-FVKG-EL2H-VJE4-LX7D
        To:  From: 
        Device:  MBQB-RX7H-5QIR-V7MS-AN4W-JW7A-UXYV
        Witness: L6YU-SEXF-YXRF-FVKG-EL2H-VJE4-LX7D
</div>
~~~~

Alice sees the request that she posted and approves it with the
`device accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman device accept L6YU-SEXF-YXRF-FVKG-EL2H-VJE4-LX7D ^
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
  Base UDF MBQF-3C7V-X6DE-MT5V-YI7G-JCUM-J2Q7
  Mesh UDF 
Encrypted: MDLT-S6G4-TRJZ-45Y6-BT2A-YQC4-QDZI
  Profile User
    Signed by: MBQX-M7KX-OMIR-UD3I-ARRZ-AT2O-3Z6Q
      KeyOfflineSignature: MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU 
      AccountAddress : alice@example.com 
      KeyEncryption:       MDRA-PU42-MQON-2CUT-OO6N-IQUC-HFNA 
  Profile Device
    Signed by: MBYQ-VEUV-KMDV-TQAY-UF7R-HFHV-MIHK
      ProfileUDF:          MBQF-3C7V-X6DE-MT5V-YI7G-JCUM-J2Q7 
      KeySignature:        MCBW-VT62-TIRM-ND4D-MPD3-VURA-VESS 
      KeyEncryption:       MBIY-ZGYT-4XJK-NW6O-Z3OT-JYQT-MGBB 
      KeyAuthentication:   MBX5-IVXD-NMA4-QDHP-L5V6-7TW5-E26R 
  Connection Device
    Signed by: MBJV-4SW6-OHDS-EWDH-S5TT-2EU2-IFNZ
      KeyAuthentication:   MAWH-CC26-QOXF-V3SH-QFDN-AY72-SBNA 

ContextDevice Local: -
  Base UDF MBQB-RX7H-5QIR-V7MS-AN4W-JW7A-UXYV
  Mesh UDF 
Encrypted: MDKH-VEF5-NGE4-6VBJ-2XFG-GFGC-PXA3
  Profile User
    Signed by: MBQX-M7KX-OMIR-UD3I-ARRZ-AT2O-3Z6Q
      KeyOfflineSignature: MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU 
      AccountAddress : alice@example.com 
      KeyEncryption:       MDRA-PU42-MQON-2CUT-OO6N-IQUC-HFNA 
  Profile Device
    Signed by: MDP2-FV5U-IVPY-5YYC-NKJK-UMO5-P52A
      ProfileUDF:          MBQB-RX7H-5QIR-V7MS-AN4W-JW7A-UXYV 
      KeySignature:        MBJ4-UXIT-QU64-ZONW-WA4C-SFVE-4QS5 
      KeyEncryption:       MA36-GZU2-6TEY-24CC-527W-6SOI-WXZ6 
      KeyAuthentication:   MDB3-S7OM-VK4R-UDC6-E7BG-MI4W-HMOV 
  Connection Device
    Signed by: MBJV-4SW6-OHDS-EWDH-S5TT-2EU2-IFNZ
      KeyAuthentication:   MCQQ-D7WM-KUN7-GGBZ-BYWA-NLOF-FNFJ 

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
<rsp>PIN=ADPP-WZ47-R74B-4IJV-G7QF-KLLQ-N4
 (Expires=2024-10-05T01:04:39Z)
</div>
~~~~

The pin code can now be used to authenticate the connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ADPP-WZ47-R74B-4IJV-G7QF-KLLQ-N4
<rsp>   Device UDF = MBQJ-ZMG4-QN7C-E4AL-HPH6-FW26-JJVF
   Witness value = 7OEH-LCAH-B226-XXBQ-QDIQ-C35C-L4UV
</div>
~~~~

Since the PIN code that was issued was set to be self-authorizing, the device
is connected automatically when the user synchronizes their account from an 
administrator device:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: 7OEH-LCAH-B226-XXBQ-QDIQ-C35C-L4UV
        Connection Request::
        MessageID: 7OEH-LCAH-B226-XXBQ-QDIQ-C35C-L4UV
        To:  From: 
        Device:  MBQJ-ZMG4-QN7C-E4AL-HPH6-FW26-JJVF
        Witness: 7OEH-LCAH-B226-XXBQ-QDIQ-C35C-L4UV
MessageID: NDN7-5NYH-LD43-4TCU-YJWW-Z37V-GYTG
MessageID: NDQ7-UANN-QSPT-CRYP-B4YY-4PNG-N2Z7
        Confirmation Request::
        MessageID: NDQ7-UANN-QSPT-CRYP-B4YY-4PNG-N2Z7
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NBJL-SNE5-XPQV-PO5I-RN52-SZHY-E4DZ
MessageID: NDCJ-UV2Z-2FNH-WOK3-46NP-M4PY-MMTJ
MessageID: NDIR-FXO6-NGSV-7UJL-5TOG-V3ON-2VPX
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
<rsp>Device UDF: MBQD-ZLNM-GMVL-EBDD-JARQ-3KC7-ENHQ
File: EA5X-HFHU-RL5B-SRQQ-AWST-OZNY-UE.medk
</div>
~~~~

This creates a configuration file that is installed on the device by executing the
`device install` command on the device itself:


~~~~
<div="terminal">
<cmd>Alice4> meshman device install EA5X-HFHU-RL5B-SRQQ-AWST-OZNY-UE.medk
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
    mcd://maker@example.com/EA5X-HFHU-RL5B-SRQQ-AWST-OZNY-UE /web
</div>
~~~~

The tool performs the tasks of resolving the EARL, decrypting the discovery record
and posting a connection response to both the hailing account and the profile account.
The next time the device polls the hailing account, it retrieves the connection data:


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MBQD-ZLNM-GMVL-EBDD-JARQ-3KC7-ENHQ
   Account = alice@example.com
   Account UDF = MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
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
<rsp>PIN=AD2J-M3UB-2AGS-X24X-GSJQ-JHYI-B4
 (Expires=2024-10-05T01:04:45Z)
</div>
~~~~

The connecting device requests connection using the  `device join`
command specifying the URI.


~~~~
<div="terminal">
<cmd>Alice5> meshman device join ^
    mcd://alice@example.com/AD2J-M3UB-2AGS-X24X-GSJQ-JHYI-B4
<rsp>   Device UDF = MBQI-PDDP-2TLE-ZUA7-3HM4-I5WC-CESA
   Witness value = 4KHR-REZF-RMAB-2WFW-R3AP-RGEU-CZJ4
</div>
~~~~

The administration device processes the device connection request automatically,
as before.


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: 4KHR-REZF-RMAB-2WFW-R3AP-RGEU-CZJ4
        Connection Request::
        MessageID: 4KHR-REZF-RMAB-2WFW-R3AP-RGEU-CZJ4
        To:  From: 
        Device:  MBQI-PDDP-2TLE-ZUA7-3HM4-I5WC-CESA
        Witness: 4KHR-REZF-RMAB-2WFW-R3AP-RGEU-CZJ4
MessageID: NABA-V3FF-P7VT-YAWQ-OPCO-VDGA-SGEW
        Confirmation Request::
        MessageID: NABA-V3FF-P7VT-YAWQ-OPCO-VDGA-SGEW
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NCUU-OQR5-XQHS-FFJY-E23R-MSEV-GENU
        Confirmation Request::
        MessageID: NCUU-OQR5-XQHS-FFJY-E23R-MSEV-GENU
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NB4E-NQIR-FRPV-6XCH-GMCZ-NTB7-RHZW
        Contact Request::
        MessageID: NB4E-NQIR-FRPV-6XCH-GMCZ-NTB7-RHZW
        To: alice@example.com From: carol@example.com
        PIN: 
MessageID: NBB4-CUJO-MBE4-ZYUM-SJR2-W2IE-JKAO
MessageID: NDN7-5NYH-LD43-4TCU-YJWW-Z37V-GYTG
MessageID: NDQ7-UANN-QSPT-CRYP-B4YY-4PNG-N2Z7
        Confirmation Request::
        MessageID: NDQ7-UANN-QSPT-CRYP-B4YY-4PNG-N2Z7
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NBJL-SNE5-XPQV-PO5I-RN52-SZHY-E4DZ
MessageID: NDCJ-UV2Z-2FNH-WOK3-46NP-M4PY-MMTJ
MessageID: NDIR-FXO6-NGSV-7UJL-5TOG-V3ON-2VPX
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


