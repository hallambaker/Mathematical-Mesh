
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool. The
message specifies the salted pin value used to verify attempts to use the PIN, the
action for which it is authorized. Since this PIN has been issued to authorize a device
connection, the roles for which the device are authorized as well. This allows the 
connection request to be accepted without asking for further input from the user.

~~~~
{
  "MessagePin":{
    "MessageId":"ABBQ-7RHN-DZ2H-53DR-2N6Q-44RF-DS4W",
    "Account":"alice@example.com",
    "Expires":"2021-09-19T18:46:57Z",
    "Automatic":true,
    "SaltedPin":"AAUS-Y4NT-GOQP-5NEV-F3VF-PDN7-SBQK",
    "Action":"Device",
    "Roles":["threshold"
      ]}}
~~~~

