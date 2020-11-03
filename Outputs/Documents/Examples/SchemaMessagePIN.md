
For example, when Alice reads the connection request from the device in the architecture 
examples, a completion message is added to Alice's inbound spool so that the device is not 
activated a second time by mistake:

~~~~
{
  "MessagePin":{
    "MessageId":"ADPN-NW2M-7FVD-EN7C-FDA7-GB35-TMYZ",
    "Account":"alice@example.com",
    "Expires":"2020-11-04T01:50:44Z",
    "Automatic":true,
    "SaltedPin":"AAVT-FNF3-WCPJ-YLSC-ORUV-XNXJ-AEVJ",
    "Action":"Device"}}
~~~~

The details of the presentation and verification of the PIN code
are further described in the section below.

