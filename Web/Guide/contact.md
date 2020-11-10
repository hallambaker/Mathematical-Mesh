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
<cmd>Alice> contact self email alice@example.com
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Contacts may also be added by accepting contact request messages using the 
`message accept` command:


~~~~
<div="terminal">
<cmd>Alice> message accept tbs
<rsp>ERROR - The specified message could not be found.
</div>
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
<rsp>Entry<CatalogedContact>: MCR2-U4OO-FBV3-6BSP-WKEQ-4QOG-QSAV
  Person MCR2-U4OO-FBV3-6BSP-WKEQ-4QOG-QSAV
  Anchor MCR2-U4OO-FBV3-6BSP-WKEQ-4QOG-QSAV
  Address alice@example.com

Entry<CatalogedContact>: NC6S-FHAS-TTJX-5VFB-B57Z-JOG3-DJDA
  Person 
  Anchor MCNN-EDO6-GYYF-2H2H-IJTV-KXQZ-TXXJ
  Address bob@example.com

Entry<CatalogedContact>: NBYD-QOZ3-BUQJ-QTYU-YPZJ-SCXL-LA64
  Person 
  Anchor MCL5-XUKG-CQ6T-ASVR-6RP5-X2C3-BL2L
  Address groupw@example.com

</div>
~~~~

## Deleting contacts

Contact entries may be deleted using the  `contact delete` command:


~~~~
<div="terminal">
<cmd>Alice> contact delete carol@example.com
<rsp>ERROR - The entry could not be found in the store.
</div>
~~~~



## Adding devicesF

Devices are given authorization to access the contacts catalog using the 
 `device auth` command:

 %  ConsoleExample (ShellContact.ContactAuth);

 The newly authorized device can now access the contacts catalog:

 %  ConsoleExample (ShellContact.ContactList2);

