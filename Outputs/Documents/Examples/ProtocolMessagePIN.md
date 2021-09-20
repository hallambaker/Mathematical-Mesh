
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool. The
message specifies the salted pin value used to verify attempts to use the PIN, the
action for which it is authorized. Since this PIN has been issued to authorize a device
connection, the roles for which the device are authorized as well. This allows the 
connection request to be accepted without asking for further input from the user.

~~~~
{
  "MessagePin":{
    "MessageId":"AAAR-P66O-KGTI-QY6C-CXIW-OMCV-WQZI",
    "Account":"alice@example.com",
    "Expires":"2021-09-21T18:16:18Z",
    "Automatic":true,
    "SaltedPin":"ACZI-EF2U-AAIY-R5MY-KXZ6-UYAF-NUSV",
    "Action":"Device",
    "Roles":["threshold"
      ]}}
~~~~

