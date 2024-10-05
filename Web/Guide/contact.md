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
Missing example 8
~~~~

The  `contact self` command is used to inport a contact and mark it as 
being the user's own contact details:


~~~~
Missing example 9
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
<rsp>Envelope ID: MBXA-LC4Y-JPOL-566F-XHFH-UKHT-CPYS
Message ID: NBQT-BJ65-V3KT-VIW7-3CPD-PLUW-VTE7
Response ID: MCKR-A3VX-WNTE-BPWX-7KJN-U5XF-B356
</div>
~~~~

Alice accepts the contact exchange with the `message accept` 
command. She can now check Bob's contact appears in her contacts catalog 
with the `contact list` command:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: NCJ2-ZO44-ATSC-DUIY-PYQF-HNUN-2HJC
        Contact Request::
        MessageID: NCJ2-ZO44-ATSC-DUIY-PYQF-HNUN-2HJC
        To: alice@example.com From: mallet@example.com
        PIN: ACNM-L4LA-JHOZ-HRMM-XANW-BKWF-26DA
MessageID: NBQT-BJ65-V3KT-VIW7-3CPD-PLUW-VTE7
        Contact Request::
        MessageID: NBQT-BJ65-V3KT-VIW7-3CPD-PLUW-VTE7
        To: alice@example.com From: bob@example.com
        PIN: ACGU-5FLZ-EUCZ-EBAY-LA4U-VT2K-KJQA
MessageID: ND2F-I3BZ-645E-OSBR-Z5NI-MIUG-4IRN
<cmd>Alice> meshman message accept NBQT-BJ65-V3KT-VIW7-3CPD-PLUW-VTE7
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
  Person MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
  Anchor MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
  Address alice@example.com

Entry<CatalogedContact>: NBYF-NJLS-POE7-YZJT-CWOW-T4DV-MJPQ
  Person 
  Anchor MBQL-4JMF-6I3J-ZEZ4-YFNC-H32E-RDP5
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
<rsp>Entry<CatalogedContact>: MBQL-4JMF-6I3J-ZEZ4-YFNC-H32E-RDP5
  Person MBQL-4JMF-6I3J-ZEZ4-YFNC-H32E-RDP5
  Anchor MBQL-4JMF-6I3J-ZEZ4-YFNC-H32E-RDP5
  Address bob@example.com

Entry<CatalogedContact>: NDP6-2XWO-OZVI-VRUS-UDOV-TXMY-TOJR
  Person 
  Anchor MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
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
<cmd>Alice> meshman contact exchange
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
  Person MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
  Anchor MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
  Address alice@example.com

Entry<CatalogedContact>: NBYF-NJLS-POE7-YZJT-CWOW-T4DV-MJPQ
  Person 
  Anchor MBQL-4JMF-6I3J-ZEZ4-YFNC-H32E-RDP5
  Address bob@example.com

Entry<CatalogedContact>: NAD5-OSJK-5WXL-ONCN-JNSC-RIDA-KVHN
  Person 
  Anchor MBQI-GRBW-QGJ4-WPKJ-J224-X7IY-HA7S
  Address groupw@example.com

Entry<CatalogedContact>: NCAY-W6SV-SE4A-MEIA-WCPJ-KAHT-EO4H
  Person 
  Anchor MBQI-GRBW-QGJ4-WPKJ-J224-X7IY-HA7S
  Address groupw@example.com

Entry<CatalogedContact>: NA63-UAMB-OVOS-Z6QG-KLDD-TXTB-LMIU
  Person 
  Anchor MBQD-CVDL-6P74-KAYN-EFYO-UNPA-R6IR
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
<cmd>Alice> meshman contact fetch
<rsp>[CatalogedContact]

<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
  Person MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
  Anchor MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
  Address alice@example.com

Entry<CatalogedContact>: NBYF-NJLS-POE7-YZJT-CWOW-T4DV-MJPQ
  Person 
  Anchor MBQL-4JMF-6I3J-ZEZ4-YFNC-H32E-RDP5
  Address bob@example.com

Entry<CatalogedContact>: NAD5-OSJK-5WXL-ONCN-JNSC-RIDA-KVHN
  Person 
  Anchor MBQI-GRBW-QGJ4-WPKJ-J224-X7IY-HA7S
  Address groupw@example.com

Entry<CatalogedContact>: NCAY-W6SV-SE4A-MEIA-WCPJ-KAHT-EO4H
  Person 
  Anchor MBQI-GRBW-QGJ4-WPKJ-J224-X7IY-HA7S
  Address groupw@example.com

Entry<CatalogedContact>: NA63-UAMB-OVOS-Z6QG-KLDD-TXTB-LMIU
  Person 
  Anchor MBQD-CVDL-6P74-KAYN-EFYO-UNPA-R6IR
  Address carol@example.com

Entry<CatalogedContact>: NCST-FUWN-V2DB-5VIL-LJM5-4SIC-7GQ4
  Person 
  Anchor MBQC-OXNK-BMFM-QMMQ-FOKA-MOBQ-J42I
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
<rsp>Entry<CatalogedContact>: MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
  Person MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
  Anchor MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
  Address alice@example.com

Entry<CatalogedContact>: NBYF-NJLS-POE7-YZJT-CWOW-T4DV-MJPQ
  Person 
  Anchor MBQL-4JMF-6I3J-ZEZ4-YFNC-H32E-RDP5
  Address bob@example.com

Entry<CatalogedContact>: NAD5-OSJK-5WXL-ONCN-JNSC-RIDA-KVHN
  Person 
  Anchor MBQI-GRBW-QGJ4-WPKJ-J224-X7IY-HA7S
  Address groupw@example.com

Entry<CatalogedContact>: NCAY-W6SV-SE4A-MEIA-WCPJ-KAHT-EO4H
  Person 
  Anchor MBQI-GRBW-QGJ4-WPKJ-J224-X7IY-HA7S
  Address groupw@example.com

Entry<CatalogedContact>: NA63-UAMB-OVOS-Z6QG-KLDD-TXTB-LMIU
  Person 
  Anchor MBQD-CVDL-6P74-KAYN-EFYO-UNPA-R6IR
  Address carol@example.com

Entry<CatalogedContact>: NCST-FUWN-V2DB-5VIL-LJM5-4SIC-7GQ4
  Person 
  Anchor MBQC-OXNK-BMFM-QMMQ-FOKA-MOBQ-J42I
  Address doug@example.com

</div>
~~~~

## Deleting contacts

Contact entries may be deleted using the  `contact delete` command:


~~~~
Missing example 10
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

