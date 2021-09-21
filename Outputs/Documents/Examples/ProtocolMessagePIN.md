
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool. The
message specifies the salted pin value used to verify attempts to use the PIN, the
action for which it is authorized. Since this PIN has been issued to authorize a device
connection, the roles for which the device are authorized as well. This allows the 
connection request to be accepted without asking for further input from the user.

~~~~
{
  "MessagePin":{
    "MessageId":"ACLZ-SOE3-SD37-MLE2-VG3Q-RQJL-Q2JH",
    "Account":"alice@example.com",
    "Expires":"2021-09-22T00:56:05Z",
    "Automatic":true,
    "SaltedPin":"AC7J-WKPX-QWLV-DNXN-UDEF-HMDN-4L5T",
    "Action":"Device",
    "Roles":["threshold"
      ]}}
~~~~

