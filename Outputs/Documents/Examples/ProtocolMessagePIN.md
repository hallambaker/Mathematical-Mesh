
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
    "Expires":"2023-06-29T17:00:45Z",
    "Automatic":true,
    "SaltedPin":"AA6H-GDQF-3QDF-B7MB-GBAO-RJ4O-ZTPI",
    "Action":"Device",
    "Roles":["threshold"
      ],
    "MessageId":"AAGD-BQIW-ZKOT-UAIT-U4EJ-XSKW-AWMK"}}
~~~~

