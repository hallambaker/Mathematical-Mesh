
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool. The
message specifies the salted pin value used to verify attempts to use the PIN, the
action for which it is authorized. Since this PIN has been issued to authorize a device
connection, the roles for which the device are authorized as well. This allows the 
connection request to be accepted without asking for further input from the user.

~~~~
{
  "MessagePin":{
    "Account":"alice@example.com",
    "Expires":"2024-10-05T01:04:39Z",
    "Automatic":true,
    "SaltedPin":"ABOK-WDJO-5B67-LM6M-L73X-XGGF-7V33",
    "Action":"Device",
    "Roles":["threshold"
      ],
    "MessageId":"ACCL-KIFZ-YH2G-WHPU-VGJJ-IGGW-4BUL"}}
~~~~

