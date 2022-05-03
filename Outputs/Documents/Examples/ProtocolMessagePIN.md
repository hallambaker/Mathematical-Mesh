
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool. The
message specifies the salted pin value used to verify attempts to use the PIN, the
action for which it is authorized. Since this PIN has been issued to authorize a device
connection, the roles for which the device are authorized as well. This allows the 
connection request to be accepted without asking for further input from the user.

~~~~
{
  "MessagePin":{
    "MessageId":"AALG-XLJN-YZC3-2PZ5-LJK4-2TWB-7TST",
    "Account":"alice@example.com",
    "Expires":"2022-05-04T16:47:51Z",
    "Automatic":true,
    "SaltedPin":"AA3X-AOXG-CTAE-HAQ3-EDP7-PSLZ-CIHS",
    "Action":"Device",
    "Roles":["threshold"
      ]}}
~~~~

