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
<rsp>Envelope ID: MBVY-XORI-2GVR-6J4M-RNXQ-RSQJ-XPTU
Message ID: NA5B-6Z6O-F74O-X2AA-CTW2-I7C2-CCRX
Response ID: MAHD-CP2A-XRAI-REOV-ILAZ-A3SE-BAPP
</div>
~~~~

Alice accepts the contact exchange with the `message accept` 
command. She can now check Bob's contact appears in her contacts catalog 
with the `contact list` command:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: NBUX-W5FA-DICN-CBHX-FENN-7TIV-IITD
        Contact Request::
        MessageID: NBUX-W5FA-DICN-CBHX-FENN-7TIV-IITD
        To: alice@example.com From: mallet@example.com
        PIN: ADN2-K5ZO-TB4H-RTCQ-S3Q6-LKEA-FAKQ
MessageID: NA5B-6Z6O-F74O-X2AA-CTW2-I7C2-CCRX
        Contact Request::
        MessageID: NA5B-6Z6O-F74O-X2AA-CTW2-I7C2-CCRX
        To: alice@example.com From: bob@example.com
        PIN: AAIS-4C4B-ZHY7-JJKX-A3RK-NQQU-WOGA
MessageID: NDIR-FXO6-NGSV-7UJL-5TOG-V3ON-2VPX
<cmd>Alice> meshman message accept NA5B-6Z6O-F74O-X2AA-CTW2-I7C2-CCRX
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Person MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Anchor MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Address alice@example.com

Entry<CatalogedContact>: NBWO-LXHG-76BJ-76A3-2S4Q-VHQF-J6BJ
  Person 
  Anchor MBQM-POZD-73H4-KCMN-Y4DB-WQXW-YALS
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
<rsp>Entry<CatalogedContact>: MBQM-POZD-73H4-KCMN-Y4DB-WQXW-YALS
  Person MBQM-POZD-73H4-KCMN-Y4DB-WQXW-YALS
  Anchor MBQM-POZD-73H4-KCMN-Y4DB-WQXW-YALS
  Address bob@example.com

Entry<CatalogedContact>: NAOY-KU74-B43S-RFMU-R3D5-62EQ-MVOE
  Person 
  Anchor MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
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
<rsp>Entry<CatalogedContact>: MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Person MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Anchor MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Address alice@example.com

Entry<CatalogedContact>: NBWO-LXHG-76BJ-76A3-2S4Q-VHQF-J6BJ
  Person 
  Anchor MBQM-POZD-73H4-KCMN-Y4DB-WQXW-YALS
  Address bob@example.com

Entry<CatalogedContact>: NCBF-ESMH-HFJB-3W2H-KP3V-RI55-45SA
  Person 
  Anchor MBQB-3LB7-E5C6-6NNF-VX7C-JFL4-RWDN
  Address groupw@example.com

Entry<CatalogedContact>: NBRK-LJVM-ECSH-DXP6-AOC5-GKHB-YVO5
  Person 
  Anchor MBQB-3LB7-E5C6-6NNF-VX7C-JFL4-RWDN
  Address groupw@example.com

Entry<CatalogedContact>: NC6I-MSDJ-YSFK-ZDD7-MZCX-ZEB6-MOC5
  Person 
  Anchor MBQD-ITC6-FG5B-K25F-OF6W-XNZM-IKLU
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
<rsp>Entry<CatalogedContact>: MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Person MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Anchor MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Address alice@example.com

Entry<CatalogedContact>: NBWO-LXHG-76BJ-76A3-2S4Q-VHQF-J6BJ
  Person 
  Anchor MBQM-POZD-73H4-KCMN-Y4DB-WQXW-YALS
  Address bob@example.com

Entry<CatalogedContact>: NCBF-ESMH-HFJB-3W2H-KP3V-RI55-45SA
  Person 
  Anchor MBQB-3LB7-E5C6-6NNF-VX7C-JFL4-RWDN
  Address groupw@example.com

Entry<CatalogedContact>: NBRK-LJVM-ECSH-DXP6-AOC5-GKHB-YVO5
  Person 
  Anchor MBQB-3LB7-E5C6-6NNF-VX7C-JFL4-RWDN
  Address groupw@example.com

Entry<CatalogedContact>: NC6I-MSDJ-YSFK-ZDD7-MZCX-ZEB6-MOC5
  Person 
  Anchor MBQD-ITC6-FG5B-K25F-OF6W-XNZM-IKLU
  Address carol@example.com

Entry<CatalogedContact>: NDCT-K3DT-UFZT-MALS-D2QQ-LSLV-D7HV
  Person 
  Anchor MBQP-LTD7-WMOA-Y5TA-HWGO-7463-AESU
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
<rsp>Entry<CatalogedContact>: MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Person MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Anchor MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Address alice@example.com

Entry<CatalogedContact>: NBWO-LXHG-76BJ-76A3-2S4Q-VHQF-J6BJ
  Person 
  Anchor MBQM-POZD-73H4-KCMN-Y4DB-WQXW-YALS
  Address bob@example.com

Entry<CatalogedContact>: NCBF-ESMH-HFJB-3W2H-KP3V-RI55-45SA
  Person 
  Anchor MBQB-3LB7-E5C6-6NNF-VX7C-JFL4-RWDN
  Address groupw@example.com

Entry<CatalogedContact>: NBRK-LJVM-ECSH-DXP6-AOC5-GKHB-YVO5
  Person 
  Anchor MBQB-3LB7-E5C6-6NNF-VX7C-JFL4-RWDN
  Address groupw@example.com

Entry<CatalogedContact>: NC6I-MSDJ-YSFK-ZDD7-MZCX-ZEB6-MOC5
  Person 
  Anchor MBQD-ITC6-FG5B-K25F-OF6W-XNZM-IKLU
  Address carol@example.com

Entry<CatalogedContact>: NDCT-K3DT-UFZT-MALS-D2QQ-LSLV-D7HV
  Person 
  Anchor MBQP-LTD7-WMOA-Y5TA-HWGO-7463-AESU
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

