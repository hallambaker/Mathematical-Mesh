
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool. The
message specifies the salted pin value used to verify attempts to use the PIN, the
action for which it is authorized. Since this PIN has been issued to authorize a device
connection, the roles for which the device are authorized as well. This allows the 
connection request to be accepted without asking for further input from the user.

~~~~
{
  "MessagePin":{
    "MessageId":"AB6H-76PI-2QPS-ER5S-HILC-JCNU-7F4H",
    "Account":"alice@example.com",
    "Expires":"2021-09-20T17:52:42Z",
    "Automatic":true,
    "SaltedPin":"AA57-FIMW-AKOY-MFB3-OTHO-2TQN-HLRZ",
    "Action":"Device",
    "Roles":["threshold"
      ]}}
~~~~

