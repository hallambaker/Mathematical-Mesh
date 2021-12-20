
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool. The
message specifies the salted pin value used to verify attempts to use the PIN, the
action for which it is authorized. Since this PIN has been issued to authorize a device
connection, the roles for which the device are authorized as well. This allows the 
connection request to be accepted without asking for further input from the user.

~~~~
{
  "MessagePin":{
    "MessageId":"AB2R-5TDM-EGPB-GDBC-IAR3-WPDV-BNUI",
    "Account":"alice@example.com",
    "Expires":"2021-12-21T14:00:30Z",
    "Automatic":true,
    "SaltedPin":"AAF5-5UQV-C4ID-P76M-SXSA-7HEU-G2F7",
    "Action":"Device",
    "Roles":["threshold"
      ]}}
~~~~

