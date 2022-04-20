
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool. The
message specifies the salted pin value used to verify attempts to use the PIN, the
action for which it is authorized. Since this PIN has been issued to authorize a device
connection, the roles for which the device are authorized as well. This allows the 
connection request to be accepted without asking for further input from the user.

~~~~
{
  "MessagePin":{
    "MessageId":"ACKJ-BKB3-J77B-G7HZ-DFKS-E26L-NHXW",
    "Account":"alice@example.com",
    "Expires":"2022-04-21T16:17:50Z",
    "Automatic":true,
    "SaltedPin":"AAV6-EBKF-JIUO-B2UV-UQX7-OKHB-OAAX",
    "Action":"Device",
    "Roles":["threshold"
      ]}}
~~~~

