
The connection process begins with the assignment of a time-limited PIN value. This is
described in a Message sent by the administration device to allow other admin devices
to accept the request made.

~~~~
{
  "MessageId": "AAKQ-BLN4-BLEX-GLJT-3K4S-5NKO-I2BI",
  "Account": "alice@example.com",
  "Expires": "2020-10-31T14:48:16Z",
  "Automatic": true,
  "SaltedPin": "ACEC-MBX4-UPAG-G5DO-HK72-LPO5-HRAC",
  "Action": "Device"}
~~~~


The initial request is sent to the service


~~~~
Missing example 21
~~~~

The service returns an acknowledgement giving the Witness value. Note that this is not a 'reply'
since it comes from the service, not the user.


~~~~
Missing example 22
~~~~



