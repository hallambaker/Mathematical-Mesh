<title>contacts
# Using the contacts Command Set

The `contacts` command set is used to manage the user's contacts catalogue.

The contacts catalogue plays an important role in Mesh messaging as it is used to 
determine the security policy for sending outbound messages and is one of the
sources used to perform access control (i.e. spam filtering) on inbound messages.

Although the `meshman` tool is capable of adding, deleting and retrieving
contact entries, it is intended to serve as a component to be used to build user
interfaces rather than a tool designed for daily use.

## Adding contacts

The `contact add` command adds a contact entry to a catalog from
a file. 


~~~~
<div="terminal">
<cmd>Alice> contact add email carol@example.com
<rsp>{
  "Self": false,
  "Key": "NBBK-W7H6-RMXW-D6HP-ZS3Q-EVNC-N7RX",
  "EnvelopedContact": [{},
    "ewogICJDb250YWN0IjogewogICAgIkFkZHJlc3Nlcy
  I6IFt7CiAgICAgICAgIlVSSSI6ICJtYWlsdG86e2VtYWlsfSJ9XX19"]}</div>
~~~~

The file carol-contact.json contains Carol's contact information in
JSON format:

~~~~
[Carol's contact information]
~~~~

The `/self` option is used to mark the contact as being the user's own contact
details:


~~~~
<div="terminal">
<cmd>Alice> contact self email alice@example.com
<rsp>{
  "Self": true,
  "Key": "NDMW-OM2B-66IV-DWFH-MQXO-X322-IP74",
  "EnvelopedContact": [{},
    "ewogICJDb250YWN0IjogewogICAgIkFkZHJlc3Nlcy
  I6IFt7CiAgICAgICAgIlVSSSI6ICJtYWlsdG86e2VtYWlsfSJ9XX19"]}</div>
~~~~

Contacts may also be added by accepting contact request messages using the 
`message accept` command:


~~~~
<div="terminal">
<cmd>Alice> message accept tbs
<rsp></div>
~~~~

## Finding contacts

The `contact get` command retreives a contact by the contact's 
email address or label:


~~~~
<div="terminal">
<cmd>Alice> contact get carol@example.com
<rsp>Empty
</div>
~~~~

## Listing contacts

A complete list of contacts is obtained using the  `contact list` command:


~~~~
<div="terminal">
<cmd>Alice> contact list
<rsp>{
  "Self": true,
  "Key": "NDMW-OM2B-66IV-DWFH-MQXO-X322-IP74",
  "EnvelopedContact": [{},
    "ewogICJDb250YWN0IjogewogICAgIkFkZHJlc3Nlcy
  I6IFt7CiAgICAgICAgIlVSSSI6ICJtYWlsdG86e2VtYWlsfSJ9XX19"]}{
  "Self": false,
  "Key": "NBBK-W7H6-RMXW-D6HP-ZS3Q-EVNC-N7RX",
  "EnvelopedContact": [{},
    "ewogICJDb250YWN0IjogewogICAgIkFkZHJlc3Nlcy
  I6IFt7CiAgICAgICAgIlVSSSI6ICJtYWlsdG86e2VtYWlsfSJ9XX19"]}</div>
~~~~

## Deleting contacts

Contact entries may be deleted using the  `contact delete` command:


~~~~
<div="terminal">
<cmd>Alice> contact delete carol@example.com
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~



## Adding devices

Devices are given authorization to access the contacts catalog using the 
 `device auth` command:

 %  ConsoleExample (Examples.ContactAuth);

 The newly authorized device can now access the contacts catalog:

 %  ConsoleExample (Examples.ContactList2);

