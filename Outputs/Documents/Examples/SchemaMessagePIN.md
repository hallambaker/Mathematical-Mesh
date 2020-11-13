
For example, when Alice reads the connection request from the device in the architecture 
examples, a completion message is added to Alice's inbound spool so that the device is not 
activated a second time by mistake:

~~~~
{
  "MessagePin":{
    "MessageId":"ABGK-7DCK-Z4PK-UYZY-DHZE-TMS5-ITLE",
    "Account":"alice@example.com",
    "Expires":"2020-11-14T14:25:46Z",
    "Automatic":true,
    "SaltedPin":"AB7W-WWNW-AERH-JLED-FF5S-NVQ4-SY3Y",
    "Action":"Device"}}
~~~~

The details of the presentation and verification of the PIN code
are further described in the section below.

