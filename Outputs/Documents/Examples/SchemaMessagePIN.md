
For example, when Alice reads the connection request from the device in the architecture 
examples, a completion message is added to Alice's inbound spool so that the device is not 
activated a second time by mistake:

~~~~
{
  "MessagePin":{
    "MessageId":"ACJ2-4VYW-DQS6-YG7S-6RSV-ONFF-WANV",
    "Account":"alice@example.com",
    "Expires":"2020-11-11T00:57:03Z",
    "Automatic":true,
    "SaltedPin":"ABKU-EXGH-YF5B-LJZW-7KHO-AQ6T-RUEL",
    "Action":"Device"}}
~~~~

The details of the presentation and verification of the PIN code
are further described in the section below.

