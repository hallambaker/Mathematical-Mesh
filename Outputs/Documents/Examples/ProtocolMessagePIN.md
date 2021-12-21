
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool. The
message specifies the salted pin value used to verify attempts to use the PIN, the
action for which it is authorized. Since this PIN has been issued to authorize a device
connection, the roles for which the device are authorized as well. This allows the 
connection request to be accepted without asking for further input from the user.

~~~~
{
  "MessagePin":{
    "MessageId":"ABD2-DGNV-KFAH-DCVA-TU4C-KCXF-2YXY",
    "Account":"alice@example.com",
    "Expires":"2021-12-22T13:28:30Z",
    "Automatic":true,
    "SaltedPin":"AA4V-J4PL-7ASB-KEG6-D6VI-XPUA-PRVZ",
    "Action":"Device",
    "Roles":["threshold"
      ]}}
~~~~

