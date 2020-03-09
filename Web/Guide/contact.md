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

**Missing Example***

The file carol-contact.json contains Carol's contact information in
JSON format:

~~~~
[Carol's contact information]
~~~~

The `/self` option is used to mark the contact as being the user's own contact
details:

**Missing Example***

Contacts may also be added by accepting contact request messages using the 
`message accept` command:

**Missing Example***

## Finding contacts

The `contact get` command retreives a contact by the contact's 
email address or label:

**Missing Example***

## Listing contacts

A complete list of contacts is obtained using the  `contact list` command:

**Missing Example***

## Deleting contacts

Contact entries may be deleted using the  `contact delete` command:

**Missing Example***



## Adding devices

Devices are given authorization to access the contacts catalog using the 
 `device auth` command:

 %  ConsoleExample (Examples.ContactAuth);

 The newly authorized device can now access the contacts catalog:

 %  ConsoleExample (Examples.ContactList2);

