
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool. The
message specifies the salted pin value used to verify attempts to use the PIN, the
action for which it is authorized. Since this PIN has been issued to authorize a device
connection, the roles for which the device are authorized as well. This allows the 
connection request to be accepted without asking for further input from the user.

~~~~
{
  "MessagePin":{
    "MessageId":"AAVE-RXUN-6AYB-FMU3-3BZA-VFVP-SARG",
    "Account":"alice@example.com",
    "Expires":"2021-09-22T00:58:53Z",
    "Automatic":true,
    "SaltedPin":"ABSR-KCDG-7PWS-XGJF-WNG7-2T4Y-ARQV",
    "Action":"Device",
    "Roles":["threshold"
      ]}}
~~~~

