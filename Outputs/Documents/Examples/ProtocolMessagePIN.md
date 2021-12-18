
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool. The
message specifies the salted pin value used to verify attempts to use the PIN, the
action for which it is authorized. Since this PIN has been issued to authorize a device
connection, the roles for which the device are authorized as well. This allows the 
connection request to be accepted without asking for further input from the user.

~~~~
{
  "MessagePin":{
    "MessageId":"ACEM-JHJW-YGOY-QOIY-FXNY-I566-KLRU",
    "Account":"alice@example.com",
    "Expires":"2021-12-19T01:57:23Z",
    "Automatic":true,
    "SaltedPin":"ADAL-2LKE-TT6P-3IMM-JJ24-5LXO-W4OX",
    "Action":"Device",
    "Roles":["threshold"
      ]}}
~~~~

