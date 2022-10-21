
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
    "Expires":"2022-10-19T12:48:11Z",
    "Automatic":true,
    "SaltedPin":"ADGS-TMEV-G2MR-2NPD-ZJO3-NH2F-363W",
    "Action":"Device",
    "Roles":["threshold"
      ],
    "MessageId":"ABFI-YEZB-HAEO-7LVM-E7VB-IWUC-YD3F"}}
~~~~

