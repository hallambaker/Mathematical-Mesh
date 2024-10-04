
The Alice begins the connection process by creating a one time use PIN authentication code 
on her administration device. The PIN creation request specifies the rights to be granted
to the connecting device:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AC23-KHLF-VHYV-MQXF-3PM2-WZRM-TU
 (Expires=2024-10-05T13:13:13Z)
</div>
~~~~

A connection request is made on the connecting device as before except that this time 
the PIN is specified. This time, only the 'threshold' right is granted.


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AC23-KHLF-VHYV-MQXF-3PM2-WZRM-TU
<rsp>   Device UDF = MBQN-TRFD-22HH-7VJO-3B6R-APJC-HUCP
   Witness value = TWJD-AUPC-2BSP-3V4U-ZS2Z-S63O-2KNH
</div>
~~~~

Since the connection request is pre-authenticated by the PIN, it is not necessary for 
Alice to review the connection request. The connection request is accepted 
automatically when the administration device is synchronized:


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

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MBQN-TRFD-22HH-7VJO-3B6R-APJC-HUCP
   Account = alice@example.com
   Account UDF = MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA
<cmd>Alice3> meshman account sync
</div>
~~~~

The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead 
of the PIN being presented to Alice in the form of an alphanumeric string, the connection
information is encoded as a URI and presented to the connecting device as a QR code.

The URI corresponding to the connection PIN is:

~~~~
mcd://alice@example.com/AC23-KHLF-VHYV-MQXF-3PM2-WZRM-TU
~~~~


