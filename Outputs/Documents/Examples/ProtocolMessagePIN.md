
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool. The
message specifies the salted pin value used to verify attempts to use the PIN, the
action for which it is authorized. Since this PIN has been issued to authorize a device
connection, the roles for which the device are authorized as well. This allows the 
connection request to be accepted without asking for further input from the user.

~~~~
{
  "MessagePin":{
    "MessageId":"AAPO-PUCK-AIYZ-FSOX-OBI5-YZZB-RVT2",
    "Account":"alice@example.com",
    "Expires":"2021-10-26T15:49:02Z",
    "Automatic":true,
    "SaltedPin":"ADL6-MGFR-DK2V-XMCH-Y4VK-FG4R-AIDL",
    "Action":"Device",
    "Roles":["threshold"
      ]}}
~~~~

