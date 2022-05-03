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
Missing example 6
~~~~

The  `contact self` command is used to inport a contact and mark it as 
being the user's own contact details:


~~~~
Missing example 7
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
<cmd>Bob> meshman contact request alice@example.com
<rsp>Envelope ID: MCJW-X2TB-QWWK-XEJY-NARU-GI5V-W7XA
Message ID: NBS4-ZWR7-F5JR-DCOK-C5PN-XKDT-WB46
Response ID: MBUW-RS2J-YLXC-R7S5-B6LV-2O7Z-IJCK
</div>
~~~~

Alice accepts the contact exchange with the `message accept` 
command. She can now check Bob's contact appears in her contacts catalog 
with the `contact list` command:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: NBQQ-VHXI-3DZX-6KA3-UN3O-4J7B-MHKG
        Contact Request::
        MessageID: NBQQ-VHXI-3DZX-6KA3-UN3O-4J7B-MHKG
        To: alice@example.com From: mallet@example.com
        PIN: ADFW-BULY-6SM6-BWJ7-FI4H-COZ4-RLBA
MessageID: NBS4-ZWR7-F5JR-DCOK-C5PN-XKDT-WB46
        Contact Request::
        MessageID: NBS4-ZWR7-F5JR-DCOK-C5PN-XKDT-WB46
        To: alice@example.com From: bob@example.com
        PIN: ADHE-RV4P-ETST-FW3C-RIY3-MUQF-NC6Q
<cmd>Alice> meshman message accept NBS4-ZWR7-F5JR-DCOK-C5PN-XKDT-WB46
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Person MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Anchor MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Address alice@example.com

Entry<CatalogedContact>: NBE6-3ZYP-G52L-B6HG-EIRK-XZ7H-73HR
  Person 
  Anchor MDDO-B6Z7-4YXY-BJLQ-WFQZ-BOMG-QB6Y
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
<rsp>Entry<CatalogedContact>: MDDO-B6Z7-4YXY-BJLQ-WFQZ-BOMG-QB6Y
  Person MDDO-B6Z7-4YXY-BJLQ-WFQZ-BOMG-QB6Y
  Anchor MDDO-B6Z7-4YXY-BJLQ-WFQZ-BOMG-QB6Y
  Address bob@example.com

Entry<CatalogedContact>: NDS3-QDKW-ZXAB-7NWJ-KOP5-LSOW-Y5GF
  Person 
  Anchor MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
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
<cmd>Alice> meshman contact exchange ^
    mcu://carol@example.com/EFQF-DPLD-IIUR-ZIUO-G5PK-4WRD-ZFGA
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Person MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Anchor MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Address alice@example.com

Entry<CatalogedContact>: NBE6-3ZYP-G52L-B6HG-EIRK-XZ7H-73HR
  Person 
  Anchor MDDO-B6Z7-4YXY-BJLQ-WFQZ-BOMG-QB6Y
  Address bob@example.com

Entry<CatalogedContact>: NDGW-DE77-QMTX-65RU-GNV2-LMT3-TFDI
  Person 
  Anchor MDUH-SCDO-UMPO-LCBP-QGOU-AZIG-PJ5D
  Address groupw@example.com

Entry<CatalogedContact>: NCX4-Y3QO-5DIZ-23JD-HHLG-EY5C-T3KQ
  Person 
  Anchor MDUH-SCDO-UMPO-LCBP-QGOU-AZIG-PJ5D
  Address groupw@example.com

Entry<CatalogedContact>: NB3K-UFSL-CNOL-VR4I-BXVW-KEUE-4RFG
  Person 
  Anchor MB3W-TFQZ-FMLI-7V2O-TINP-Z33G-VSLD
  Address carol@example.com

</div>
~~~~

Carol can now complete the interaction by synchronizing one of her devices:


~~~~
<div="terminal">
<cmd>Carol> meshman account sync /auto
<cmd>Carol> meshman contact get alice@example.com
<rsp>[CatalogedContact]

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
<rsp>Device Profile UDF=
</div>
~~~~

Alice scans the URI printed on Doug's business card and collects the contact information.
using the `contact fetch` command:


~~~~
<div="terminal">
<cmd>Alice> meshman contact fetch ^
    mcu://doug@example.com/EFQJ-TZRT-O3DN-YTJH-TOUC-IMGI-6KAQ
<rsp>[CatalogedContact]

<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Person MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Anchor MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Address alice@example.com

Entry<CatalogedContact>: NBE6-3ZYP-G52L-B6HG-EIRK-XZ7H-73HR
  Person 
  Anchor MDDO-B6Z7-4YXY-BJLQ-WFQZ-BOMG-QB6Y
  Address bob@example.com

Entry<CatalogedContact>: NDGW-DE77-QMTX-65RU-GNV2-LMT3-TFDI
  Person 
  Anchor MDUH-SCDO-UMPO-LCBP-QGOU-AZIG-PJ5D
  Address groupw@example.com

Entry<CatalogedContact>: NCX4-Y3QO-5DIZ-23JD-HHLG-EY5C-T3KQ
  Person 
  Anchor MDUH-SCDO-UMPO-LCBP-QGOU-AZIG-PJ5D
  Address groupw@example.com

Entry<CatalogedContact>: NB3K-UFSL-CNOL-VR4I-BXVW-KEUE-4RFG
  Person 
  Anchor MB3W-TFQZ-FMLI-7V2O-TINP-Z33G-VSLD
  Address carol@example.com

Entry<CatalogedContact>: NAB5-SH4F-CF5Y-SJYA-6ZN6-L3CV-X2KR
  Person 
  Anchor MD46-DS24-JRJD-GZKT-ZXR6-74VM-D3Z2
  Address doug@example.com

</div>
~~~~


## Finding contacts

The `contact get` command retreives a contact by the contact's 
email address or label:


~~~~
<div="terminal">
<cmd>Alice> meshman contact get carol@example.com
<rsp>[CatalogedContact]

</div>
~~~~

## Listing contacts

A complete list of contacts is obtained using the  `contact list` command:


~~~~
<div="terminal">
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Person MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Anchor MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Address alice@example.com

Entry<CatalogedContact>: NBE6-3ZYP-G52L-B6HG-EIRK-XZ7H-73HR
  Person 
  Anchor MDDO-B6Z7-4YXY-BJLQ-WFQZ-BOMG-QB6Y
  Address bob@example.com

Entry<CatalogedContact>: NDGW-DE77-QMTX-65RU-GNV2-LMT3-TFDI
  Person 
  Anchor MDUH-SCDO-UMPO-LCBP-QGOU-AZIG-PJ5D
  Address groupw@example.com

Entry<CatalogedContact>: NCX4-Y3QO-5DIZ-23JD-HHLG-EY5C-T3KQ
  Person 
  Anchor MDUH-SCDO-UMPO-LCBP-QGOU-AZIG-PJ5D
  Address groupw@example.com

Entry<CatalogedContact>: NB3K-UFSL-CNOL-VR4I-BXVW-KEUE-4RFG
  Person 
  Anchor MB3W-TFQZ-FMLI-7V2O-TINP-Z33G-VSLD
  Address carol@example.com

Entry<CatalogedContact>: NAB5-SH4F-CF5Y-SJYA-6ZN6-L3CV-X2KR
  Person 
  Anchor MD46-DS24-JRJD-GZKT-ZXR6-74VM-D3Z2
  Address doug@example.com

</div>
~~~~

## Deleting contacts

Contact entries may be deleted using the  `contact delete` command:


~~~~
Missing example 8
~~~~



## Adding devices

The device Alice5 was connected to her account without the contact catalog right.
Requests to access the contacts catalog fail:


~~~~
<div="terminal">
<cmd>Alice5> meshman contact list
<rsp>ERROR - Unspecified error
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
<cmd>Alice5> meshman contact list
<rsp>ERROR - Unspecified error
</div>
~~~~

