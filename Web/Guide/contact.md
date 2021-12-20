<title>contact
# Using the contact Command Set

The `contact` command set is used to manage the user's contacts catalogue.

The contacts catalogue plays an important role in Mesh messaging as it is used to 
manage the security policy for sending outbound messages and is one of the
sources used to compile the access control authorizations (i.e. spam filtering) 
on inbound messages.

The Mesh Service cannot read the contacts catalog entries themselves but
the data in the contact catalog is used to compile the access catalog entries
that do.

Although the `meshman` tool is capable of adding, deleting and retrieving
contact entries, it is intended to serve as a component to be used to build user
interfaces rather than a tool designed for daily use.

[Future Feature: Contact/Auth] Specify messaging authorizations

## Adding contacts from a file

The `contact import` command adds a contact entry to a catalog from
a file. 


~~~~
<div="terminal">
<cmd>Alice> meshman contact add email carol@example.com
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

The file carol-contact.json contains Carol's contact information in
JSON format:

~~~~
[Carol's contact information]
~~~~

The  `contact self` command is used to inport a contact and mark it as 
being the user's own contact details:


~~~~
<div="terminal">
<cmd>Alice> meshman contact self email alice@example.com
<rsp>ERROR - An unknown error occurred
</div>
~~~~

## Exchanging contacts with other users.

Every Mesh Messaging communication is mediated through access control. Unlike
a telephone number, a postal or email address, mere knowledge of a Mesh
Messaging address does not grant the ability to use it to send a message. This
makes exchange of contact information considerably easier since we are only
concerned with the authenticity and accuracy of the identity claims made, 
the mesh address information itself is not confidential.

Contacts may be acquired from other users through a variety of approaches. If the 
parties meet in person, the exchange may be performed through a QR code or near
field communication exchange. If they are remote from each other, a network
mediated exchange may be used.

Exchange need not be reciprocated. A unidirectional exchange may be effected by
means of a URI or QR code printed on a business card or a Web site.


### Message Exchange

`message contact`
`message accept`
`message accept`

### Dynamic Exchange

`contact dynamic`
`contact fetch` / `contact exchange`
`message accept`



~~~~
<div="terminal">
<cmd>Alice> meshman message accept tbs
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

### Static Exchange

`contact static`
`contact fetch`

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
<rsp>Entry<CatalogedContact>: MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
  Person MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
  Anchor MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
  Address alice@example.com

Entry<CatalogedContact>: NDEM-WE24-3HOC-XLZC-GC2G-ZXOF-C6HU
  Person 
  Anchor MAEP-FJ5L-ZDUD-4PA4-MLEF-ZZJG-LDER
  Address bob@example.com

Entry<CatalogedContact>: NBMX-PJ74-OQ3W-ZBM3-U525-RJYR-2QCG
  Person 
  Anchor MD2J-ZY5P-QMLE-2UBT-X7QH-C5OO-37K4
  Address groupw@example.com

Entry<CatalogedContact>: NDRA-RYQ6-BGI6-S6ST-3EQO-SIHS-SZ5N
  Person 
  Anchor MD2J-ZY5P-QMLE-2UBT-X7QH-C5OO-37K4
  Address groupw@example.com

Entry<CatalogedContact>: NBR7-T7B7-5BPM-Q6CO-4W7F-PCSK-CHMN
  Person 
  Anchor MD2J-ZY5P-QMLE-2UBT-X7QH-C5OO-37K4
  Address groupw@example.com

Entry<CatalogedContact>: NCNT-D7WI-7OGD-Q4X5-VKN5-2GYO-NQ6M
  Person 
  Anchor MD2J-ZY5P-QMLE-2UBT-X7QH-C5OO-37K4
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



## Adding devices

Devices are given authorization to access the contacts catalog using the 
 `device auth` command:


~~~~
Missing example 26
~~~~

The newly authorized device can now access the contacts catalog:


~~~~
Missing example 27
~~~~

