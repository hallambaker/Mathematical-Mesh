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
<cmd>Alice> meshman contact add email carol@example.com
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\em
ail'.
</div>
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
<cmd>Alice> meshman contact self email alice@example.com
<rsp>ERROR - An unknown error occurred
</div>
~~~~

Contacts may also be added by accepting contact request messages using the 
`message accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept tbs
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

## Finding contacts

The `contact get` command retreives a contact by the contact's 
email address or label:


~~~~
<div="terminal">
<cmd>Alice> meshman contact get carol@example.com
<rsp>
</div>
~~~~

## Listing contacts

A complete list of contacts is obtained using the  `contact list` command:


~~~~
<div="terminal">
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
  Person MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
  Anchor MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
  Address alice@example.com

Entry<CatalogedContact>: NAWB-M7G7-OXPC-I6YS-SIXH-JQ7E-OOXA
  Person 
  Anchor MBYX-JPOL-7H24-YL2Z-LOHO-7MWV-IFGG
  Address bob@example.com

Entry<CatalogedContact>: NBLD-QB2F-UVQD-MHP5-PHY3-J2MO-YUKD
  Person 
  Anchor MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK
  Address groupw@example.com

Entry<CatalogedContact>: NDXP-NDKS-PFFD-WBA7-VQ74-5KM5-355Y
  Person 
  Anchor MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK
  Address groupw@example.com

Entry<CatalogedContact>: NCC4-BLBH-RHO3-UHOG-YRJO-W4J2-JCNL
  Person 
  Anchor MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK
  Address groupw@example.com

</div>
~~~~

## Deleting contacts

Contact entries may be deleted using the  `contact delete` command:


~~~~
<div="terminal">
<cmd>Alice> meshman contact delete carol@example.com
<rsp>ERROR - The entry could not be found in the store.
</div>
~~~~



## Adding devicesF

Devices are given authorization to access the contacts catalog using the 
 `device auth` command:

 %  ConsoleExample (ShellContact.ContactAuth);

 The newly authorized device can now access the contacts catalog:

 %  ConsoleExample (ShellContact.ContactList2);

