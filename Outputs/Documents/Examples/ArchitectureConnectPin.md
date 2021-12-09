
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=ADKG-ALMU-VUHY-A54X-EWZC-FV3S-KY
 (Expires=2021-12-10T16:46:15Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ADKG-ALMU-VUHY-A54X-EWZC-FV3S-KY
<rsp>   Device UDF = MBXK-HB52-35LF-V3CX-ZRBG-W6IJ-G4NB
   Witness value = ADED-F7RU-T6BX-LPK5-NYPQ-7OSD-ANNV
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: ADED-F7RU-T6BX-LPK5-NYPQ-7OSD-ANNV
        Connection Request::
        MessageID: ADED-F7RU-T6BX-LPK5-NYPQ-7OSD-ANNV
        To:  From: 
        Device:  MBXK-HB52-35LF-V3CX-ZRBG-W6IJ-G4NB
        Witness: ADED-F7RU-T6BX-LPK5-NYPQ-7OSD-ANNV
MessageID: NDRZ-PHXC-54V3-BOEE-BXHH-CZLZ-6RSF
        Group invitation::
        MessageID: NDRZ-PHXC-54V3-BOEE-BXHH-CZLZ-6RSF
        To: alice@example.com From: alice@example.com
MessageID: NDW5-TTEF-B4JG-BZQN-FNPA-CQRM-3AEE
        Confirmation Request::
        MessageID: NDW5-TTEF-B4JG-BZQN-FNPA-CQRM-3AEE
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDVI-PIPP-B7UB-SI6M-LGQR-TBSK-DLRR
        Contact Request::
        MessageID: NDVI-PIPP-B7UB-SI6M-LGQR-TBSK-DLRR
        To: alice@example.com From: bob@example.com
        PIN: ABBR-7XTR-EMOF-HDSS-K34R-YQSW-VEJQ
<cmd>Alice> meshman account sync /auto
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MBXK-HB52-35LF-V3CX-ZRBG-W6IJ-G4NB
   Account = alice@example.com
   Account UDF = MDMG-5KJT-SFQQ-EE3U-GZAK-CEGV-5GR2
<cmd>Alice3> meshman account sync
</div>
~~~~

The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcu://alice@example.com/ADKG-ALMU-VUHY-A54X-EWZC-FV3S-KY
~~~~


