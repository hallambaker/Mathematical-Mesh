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
<rsp>Envelope ID: MAE2-VMU3-PDAH-HZX7-CGYV-75XQ-Z4EA
Message ID: NAQL-6SJP-VLQD-7BNN-EB6L-DLQQ-K2ZE
Response ID: MDNG-ME2U-6X4T-FEVR-46MH-2RLM-WCOP
</div>
~~~~

Alice accepts the contact exchange with the `message accept` 
command. She can now check Bob's contact appears in her contacts catalog 
with the `contact list` command:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: ND2G-PHUE-PLPY-QAPP-UU6P-BAXW-EOBS
        Contact Request::
        MessageID: ND2G-PHUE-PLPY-QAPP-UU6P-BAXW-EOBS
        To: alice@example.com From: mallet@example.com
        PIN: ACGN-LZXP-H2WB-R5UE-VGMF-VGQD-AR5Q
MessageID: NAQL-6SJP-VLQD-7BNN-EB6L-DLQQ-K2ZE
        Contact Request::
        MessageID: NAQL-6SJP-VLQD-7BNN-EB6L-DLQQ-K2ZE
        To: alice@example.com From: bob@example.com
        PIN: AAAZ-RZSW-ZMBI-A6R6-WTPY-INAA-OZLQ
MessageID: NA7V-2XT2-2ZJO-IDUY-GK6W-CTVX-HDDM
<cmd>Alice> meshman message accept NAQL-6SJP-VLQD-7BNN-EB6L-DLQQ-K2ZE
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Person MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Anchor MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Address alice@example.com

Entry<CatalogedContact>: NCIO-3ZRE-NYUC-XRNS-CDLI-HL42-EDBR
  Person 
  Anchor MDCR-A2UE-SKQA-3HBF-YFO6-VQ6H-E72X
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
<rsp>Entry<CatalogedContact>: MDCR-A2UE-SKQA-3HBF-YFO6-VQ6H-E72X
  Person MDCR-A2UE-SKQA-3HBF-YFO6-VQ6H-E72X
  Anchor MDCR-A2UE-SKQA-3HBF-YFO6-VQ6H-E72X
  Address bob@example.com

Entry<CatalogedContact>: ND4G-SEV3-KQ5B-U4F4-YXHC-JUVK-EO73
  Person 
  Anchor MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
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
    mcu://carol@example.com/EFQH-S7D5-WFDK-3TUO-H4RJ-RDFQ-MHAQ
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Person MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Anchor MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Address alice@example.com

Entry<CatalogedContact>: NCIO-3ZRE-NYUC-XRNS-CDLI-HL42-EDBR
  Person 
  Anchor MDCR-A2UE-SKQA-3HBF-YFO6-VQ6H-E72X
  Address bob@example.com

Entry<CatalogedContact>: NDNA-G2KO-GNLV-RMLQ-YAOB-ZDHC-SRZU
  Person 
  Anchor MBXT-N7ZN-3U5H-HTTC-4VWF-6WA5-LKGR
  Address groupw@example.com

Entry<CatalogedContact>: NCZO-YOS4-JWWD-H7YZ-CRN2-XQGP-4QXQ
  Person 
  Anchor MBXT-N7ZN-3U5H-HTTC-4VWF-6WA5-LKGR
  Address groupw@example.com

Entry<CatalogedContact>: NCIP-SDNI-F6PT-CERQ-MRF5-RQVS-KVW4
  Person 
  Anchor MCO6-N3XT-LVAR-CFKY-SWDF-A5QC-6SBU
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
    mcu://doug@example.com/EFQA-NB6U-DGXX-CTWH-UVVB-2F47-5NDA
<rsp>[CatalogedContact]

<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Person MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Anchor MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Address alice@example.com

Entry<CatalogedContact>: NCIO-3ZRE-NYUC-XRNS-CDLI-HL42-EDBR
  Person 
  Anchor MDCR-A2UE-SKQA-3HBF-YFO6-VQ6H-E72X
  Address bob@example.com

Entry<CatalogedContact>: NDNA-G2KO-GNLV-RMLQ-YAOB-ZDHC-SRZU
  Person 
  Anchor MBXT-N7ZN-3U5H-HTTC-4VWF-6WA5-LKGR
  Address groupw@example.com

Entry<CatalogedContact>: NCZO-YOS4-JWWD-H7YZ-CRN2-XQGP-4QXQ
  Person 
  Anchor MBXT-N7ZN-3U5H-HTTC-4VWF-6WA5-LKGR
  Address groupw@example.com

Entry<CatalogedContact>: NCIP-SDNI-F6PT-CERQ-MRF5-RQVS-KVW4
  Person 
  Anchor MCO6-N3XT-LVAR-CFKY-SWDF-A5QC-6SBU
  Address carol@example.com

Entry<CatalogedContact>: NDXE-QPPP-SHIC-AFBT-JMRM-6V42-IUF2
  Person 
  Anchor MA5M-JWKL-FIH4-URF7-R3SB-ERJE-Q3K7
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
<rsp>Entry<CatalogedContact>: MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Person MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Anchor MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Address alice@example.com

Entry<CatalogedContact>: NCIO-3ZRE-NYUC-XRNS-CDLI-HL42-EDBR
  Person 
  Anchor MDCR-A2UE-SKQA-3HBF-YFO6-VQ6H-E72X
  Address bob@example.com

Entry<CatalogedContact>: NDNA-G2KO-GNLV-RMLQ-YAOB-ZDHC-SRZU
  Person 
  Anchor MBXT-N7ZN-3U5H-HTTC-4VWF-6WA5-LKGR
  Address groupw@example.com

Entry<CatalogedContact>: NCZO-YOS4-JWWD-H7YZ-CRN2-XQGP-4QXQ
  Person 
  Anchor MBXT-N7ZN-3U5H-HTTC-4VWF-6WA5-LKGR
  Address groupw@example.com

Entry<CatalogedContact>: NCIP-SDNI-F6PT-CERQ-MRF5-RQVS-KVW4
  Person 
  Anchor MCO6-N3XT-LVAR-CFKY-SWDF-A5QC-6SBU
  Address carol@example.com

Entry<CatalogedContact>: NDXE-QPPP-SHIC-AFBT-JMRM-6V42-IUF2
  Person 
  Anchor MA5M-JWKL-FIH4-URF7-R3SB-ERJE-Q3K7
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

