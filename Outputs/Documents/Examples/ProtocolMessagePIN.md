
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool. The
message specifies the salted pin value used to verify attempts to use the PIN, the
action for which it is authorized. Since this PIN has been issued to authorize a device
connection, the roles for which the device are authorized as well. This allows the 
connection request to be accepted without asking for further input from the user.

~~~~
{
  "MessagePin":{
    "MessageId":"ACPO-LFX6-MTIP-CLH7-WBLA-F6AB-YQFZ",
    "Account":"alice@example.com",
    "Expires":"2021-12-10T16:46:15Z",
    "Automatic":true,
    "SaltedPin":"AACW-GWRM-PPBY-MKRO-Y7O7-SMUF-ENO2",
    "Action":"Device",
    "Roles":["threshold"
      ]}}
~~~~

