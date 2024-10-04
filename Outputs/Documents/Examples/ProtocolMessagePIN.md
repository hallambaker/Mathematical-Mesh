
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
    "Expires":"2024-10-05T13:13:13Z",
    "Automatic":true,
    "SaltedPin":"ABXS-QM2B-QTN6-5CN3-UJ7E-5TN3-RGDR",
    "Action":"Device",
    "Roles":["threshold"
      ],
    "MessageId":"ACQ2-2RB7-4PU3-ESSI-AYXC-V5NC-BT3C"}}
~~~~

