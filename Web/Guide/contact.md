<title>contact
# Using the contact Command Set

The `contact` command set is used to manage the user's contacts catalogue.

The contacts catalogue plays an important role in Mesh messaging as it is used to 
manage the security policy for sending outbound messages and is one of the
sources used to compile the access control authorizations (i.e. spam filtering) 
on inbound messages.

The Mesh Service cannot read the contacts catalog entries themselves but
the data in the contact catalog is used to compile the access catalog entries
that grant the service the ability to act on the account holder's behalf..

Although the `meshman` tool is capable of adding, deleting and retrieving
contact entries, it is intended to serve as a component to be used to build user
interfaces rather than a contact book designed for daily use.

[Future Feature: Contact/Auth] Specify messaging authorizations

## Adding contacts from a file

The `contact import` command adds contact information to the catalog directly.

The file carol-contact.json contains Carol's contact information in
JSON format:

~~~~
[Carol's contact information]
~~~~

Alice adds Carol's contact information to her contact catalog directly:


~~~~
<div="terminal">
<cmd>Alice> meshman contact import tbs
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\tb
s'.
</div>
~~~~

The  `contact self` command is used to inport a contact and mark it as 
being the user's own contact details:


~~~~
<div="terminal">
<cmd>Alice> meshman contact import tbs /self
<rsp>ERROR - The option System.Object[] is not known.
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


### Remote Contact Exchange

The  `message contact` command begins a remote contact exchange.
This form of exchange allows exchange of contact information between users
who are not present in the same location.

To request an exchange of contact information with Alice, Bob specifies her 
Mesh account address:


~~~~
<div="terminal">
<cmd>Bob> meshman message contact alice@example.com
<rsp>Envelope ID: MDIT-XD5L-W7AF-2JWM-6UBG-DLZZ-MBXO
Message ID: ND4S-KDPC-PUNU-4X3I-PTRT-LJSO-XGHV
Response ID: MDWU-67CX-VMM6-NRVO-EUTV-KL56-AYZE
</div>
~~~~

Alice accepts the contact exchange with the `message accept` 
command. She can now check Bob's contact appears in her contacts catalog 
with the `contact list` command:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<rsp>ERROR - The entry already exists in the store.
<cmd>Alice> meshman message pending
<rsp>MessageID: ND4S-KDPC-PUNU-4X3I-PTRT-LJSO-XGHV
        Contact Request::
        MessageID: ND4S-KDPC-PUNU-4X3I-PTRT-LJSO-XGHV
        To: alice@example.com From: bob@example.com
        PIN: AARR-TR4W-I3P2-Y5OF-KVMP-7KEJ-RVIQ
<cmd>Alice> meshman message accept ND4S-KDPC-PUNU-4X3I-PTRT-LJSO-XGHV
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Person MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Anchor MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Address alice@example.com

Entry<CatalogedContact>: NDI6-Y4Q5-3K7C-UFFO-ZIZP-HFCS-R34U
  Person 
  Anchor MBNR-RPGE-7V2C-JI4N-F3NF-OD32-MV7R
  Address bob@example.com

</div>
~~~~

Since Bob initiated the contact exchange, the authorization to accept 
Alice's contact information is implicit in Bobs original command. All he needs
to do is synchronize his device with the service and Alice's contact
information appears in his catalog.


~~~~
<div="terminal">
<cmd>Bob> meshman account sync /auto
<cmd>Bob> meshman contact list
<rsp>Entry<CatalogedContact>: MBNR-RPGE-7V2C-JI4N-F3NF-OD32-MV7R
  Person MBNR-RPGE-7V2C-JI4N-F3NF-OD32-MV7R
  Anchor MBNR-RPGE-7V2C-JI4N-F3NF-OD32-MV7R
  Address bob@example.com

Entry<CatalogedContact>: NAOK-BO5X-VXGF-GBQA-ALMQ-ZRYC-INTR
  Person 
  Anchor MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Address alice@example.com

</div>
~~~~


### Dynamic Contact Exchange

The Dynamic Contact Exchange is designed for situations where the parties are
present in the same physical location. The contact exchange being typically mediated
by means of a QR code or near field communication interaction.

Carol begins a dynamic contact exchange with the `contact dynamic` 
command.


~~~~
<div="terminal">
<cmd>Carol> meshman contact dynamic alice@example.com
<rsp>Device Profile UDF=
</div>
~~~~

The URI generated by the contact dynamic command is really intended to be presented as
a QR code or other machine readable form. In this case the URI is entered into the
meshman tool directly using the `message contact` command 

Alice can accept the contact using either the `contact fetch` 
command if she wants to accept Carol's contact without reciprocating or
the `contact exchange` if she wants to provide Carol with her
contact information. In this case she authorizes a mutual exchange
adding Carol to her contacts catalog:


~~~~
<div="terminal">
<cmd>Alice> meshman contact exchange uri
<rsp>ERROR - The specified connection URI was invalid
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Person MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Anchor MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Address alice@example.com

Entry<CatalogedContact>: NDI6-Y4Q5-3K7C-UFFO-ZIZP-HFCS-R34U
  Person 
  Anchor MBNR-RPGE-7V2C-JI4N-F3NF-OD32-MV7R
  Address bob@example.com

Entry<CatalogedContact>: NDAW-LPN7-CMK6-JNTR-A573-CIFE-K34V
  Person 
  Anchor MDLU-46TL-V47W-BWT7-PSUV-FCKP-BEE6
  Address groupw@example.com

Entry<CatalogedContact>: NB2Y-J5D4-SHIA-WBWE-2EDA-D45R-56AU
  Person 
  Anchor MDLU-46TL-V47W-BWT7-PSUV-FCKP-BEE6
  Address groupw@example.com

Entry<CatalogedContact>: NA4V-YEYP-3K74-6ESA-M22I-FFBL-3WWB
  Person 
  Anchor MDLU-46TL-V47W-BWT7-PSUV-FCKP-BEE6
  Address groupw@example.com

</div>
~~~~

Carol can now complete the interaction by synchronizing one of her devices:


~~~~
<div="terminal">
<cmd>Carol> meshman account sync /auto
<cmd>Carol> meshman contact get alice@example.com
<rsp>
</div>
~~~~

### Static Exchange

The static contact exchange allows a QR code or other machine readable presentation
of a URI to be used to publish a contact in a form that allows another to add it to their
catalog. Such a code might be printed on a business card for example.

Doug creates a static contact URI with the `contact static` command:


~~~~
<div="terminal">
<cmd>Doug> meshman contact static 
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Alice scans the URI printed on Doug's business card and collects the contact information.
using the `contact fetch` command:


~~~~
<div="terminal">
<cmd>Alice> meshman contact fetch uri
<rsp>ERROR - The specified connection URI was invalid
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Person MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Anchor MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Address alice@example.com

Entry<CatalogedContact>: NDI6-Y4Q5-3K7C-UFFO-ZIZP-HFCS-R34U
  Person 
  Anchor MBNR-RPGE-7V2C-JI4N-F3NF-OD32-MV7R
  Address bob@example.com

Entry<CatalogedContact>: NDAW-LPN7-CMK6-JNTR-A573-CIFE-K34V
  Person 
  Anchor MDLU-46TL-V47W-BWT7-PSUV-FCKP-BEE6
  Address groupw@example.com

Entry<CatalogedContact>: NB2Y-J5D4-SHIA-WBWE-2EDA-D45R-56AU
  Person 
  Anchor MDLU-46TL-V47W-BWT7-PSUV-FCKP-BEE6
  Address groupw@example.com

Entry<CatalogedContact>: NA4V-YEYP-3K74-6ESA-M22I-FFBL-3WWB
  Person 
  Anchor MDLU-46TL-V47W-BWT7-PSUV-FCKP-BEE6
  Address groupw@example.com

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
<rsp>Entry<CatalogedContact>: MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Person MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Anchor MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Address alice@example.com

Entry<CatalogedContact>: NDI6-Y4Q5-3K7C-UFFO-ZIZP-HFCS-R34U
  Person 
  Anchor MBNR-RPGE-7V2C-JI4N-F3NF-OD32-MV7R
  Address bob@example.com

Entry<CatalogedContact>: NDAW-LPN7-CMK6-JNTR-A573-CIFE-K34V
  Person 
  Anchor MDLU-46TL-V47W-BWT7-PSUV-FCKP-BEE6
  Address groupw@example.com

Entry<CatalogedContact>: NB2Y-J5D4-SHIA-WBWE-2EDA-D45R-56AU
  Person 
  Anchor MDLU-46TL-V47W-BWT7-PSUV-FCKP-BEE6
  Address groupw@example.com

Entry<CatalogedContact>: NA4V-YEYP-3K74-6ESA-M22I-FFBL-3WWB
  Person 
  Anchor MDLU-46TL-V47W-BWT7-PSUV-FCKP-BEE6
  Address groupw@example.com

</div>
~~~~

## Deleting contacts

Contact entries may be deleted using the  `contact delete` command:


~~~~
<div="terminal">
<cmd>Alice> meshman contact delete tbs
<rsp>ERROR - The entry could not be found in the store.
</div>
~~~~



## Adding devices

The device Alice5 was connected to her account without the contact catalog right.
Requests to access the contacts catalog fail:


~~~~
<div="terminal">
<cmd>Alice5> meshman bookmark list
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

The ability to selectively grant access to devices allows realization of the 'least 
privilege' principal in which each user and device is granted the bare minimum
of functionality required to perform their task. What the device does not know, the
device cannot disclose.

Devices are given authorization to access the contacts catalog using the 
 `device auth` command.


~~~~
<div="terminal">
<cmd>Alice> meshman device auth Alice5 /all
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~

The newly authorized device can now access the contacts catalog:


~~~~
<div="terminal">
<cmd>Alice5> meshman bookmark list
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

