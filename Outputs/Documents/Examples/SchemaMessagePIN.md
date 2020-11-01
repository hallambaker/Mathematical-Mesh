
For example, when Alice reads the connection request from the device in the architecture 
examples, a completion message is added to Alice's inbound spool so that the device is not 
activated a second time by mistake:

~~~~
{
  "MessagePin":{
    "MessageId":"ACJK-ZOEI-3JF3-3CUK-KQHY-S6EI-IBXS",
    "Account":"alice@example.com",
    "Expires":"2020-11-02T15:44:01Z",
    "Automatic":true,
    "SaltedPin":"ADLF-YGCP-56EO-VHA6-ZMC4-7PNU-FG7W",
    "Action":"Device"}}
~~~~

The details of the presentation and verification of the PIN code
are further described in the section below.

