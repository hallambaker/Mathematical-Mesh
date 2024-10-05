
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
    "Expires":"2024-10-06T00:49:11Z",
    "Automatic":true,
    "SaltedPin":"ABZB-VOOM-JCF6-24PM-4NM5-U3HL-S3P2",
    "Action":"Device",
    "Roles":["threshold"
      ],
    "MessageId":"ACJ4-ZU6E-2VVX-5YDL-EYU6-FCHD-CTMK"}}
~~~~

