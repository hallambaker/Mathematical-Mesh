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
<rsp>Entry<CatalogedContact>: MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT
  Person MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT
  Anchor MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT
  Address alice@example.com

Entry<CatalogedContact>: NDF5-DIN6-FBRI-UI2D-XLQF-SKWC-TCB5
  Person 
  Anchor MDBR-EJYT-5KJY-Z73B-IG7E-WFSN-MRKH
  Address bob@example.com

Entry<CatalogedContact>: NCPX-63X3-SRNM-KJDU-VED6-MYU2-EUG6
  Person 
  Anchor MCVG-W4LF-4BAI-2ZCY-NHCU-E3HO-VVHY
  Address groupw@example.com

Entry<CatalogedContact>: NCPH-YMTN-5HKG-E3GR-YFZC-RDC5-ZM4D
  Person 
  Anchor MCVG-W4LF-4BAI-2ZCY-NHCU-E3HO-VVHY
  Address groupw@example.com

Entry<CatalogedContact>: NDR4-XO5G-PIYW-6H47-ZAGK-ISPY-H2ES
  Person 
  Anchor MCVG-W4LF-4BAI-2ZCY-NHCU-E3HO-VVHY
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
Missing example 47
~~~~

The newly authorized device can now access the contacts catalog:


~~~~
Missing example 48
~~~~

