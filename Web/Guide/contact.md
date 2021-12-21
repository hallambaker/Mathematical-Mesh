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

The '/self' option is used to mark an entry as being a contact entry for the account
holder.


~~~~
<div="terminal">
<cmd>Alice> meshman contact import tbs
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\tb
s'.
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


### Message Exchange


`message contact`


~~~~
<div="terminal">
<cmd>Bob> meshman message contact alice@example.com
<rsp>Envelope ID: MBD3-HVVY-FCMJ-FPHW-AYJB-ZTDN-EV25
Message ID: NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
Response ID: MDFD-KXCY-SQMH-TIUS-QREA-UFJQ-TTI2
</div>
~~~~

`message accept`
`contact list`



~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<rsp>ERROR - The entry already exists in the store.
<cmd>Alice> meshman message pending
<rsp>MessageID: NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
        Contact Request::
        MessageID: NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
        To: alice@example.com From: bob@example.com
        PIN: ACPD-YENT-3EM4-PUHD-D4Q4-4TX5-C25A
<cmd>Alice> meshman message accept NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Person MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Anchor MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Address alice@example.com

Entry<CatalogedContact>: NAQN-NQDL-LKHW-DY3U-QAFS-N2LW-6DHS
  Person 
  Anchor MCKB-VDWV-FXBV-ZEQC-62VO-UWU7-RKYC
  Address bob@example.com

</div>
~~~~


~~~~
<div="terminal">
<cmd>Bob> meshman account sync /auto
<cmd>Bob> meshman contact list
<rsp>Entry<CatalogedContact>: MCKB-VDWV-FXBV-ZEQC-62VO-UWU7-RKYC
  Person MCKB-VDWV-FXBV-ZEQC-62VO-UWU7-RKYC
  Anchor MCKB-VDWV-FXBV-ZEQC-62VO-UWU7-RKYC
  Address bob@example.com

Entry<CatalogedContact>: NC3T-S6WY-N6BC-ZSTR-64FV-BZPG-N73A
  Person 
  Anchor MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Address alice@example.com

</div>
~~~~



### Dynamic Exchange



~~~~
<div="terminal">
<cmd>Carol> meshman contact dynamic alice@example.com
<rsp>Device Profile UDF=
</div>
~~~~


~~~~
<div="terminal">
<cmd>Alice> meshman message accept tbs
<rsp>ERROR - The specified message could not be found.
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Person MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Anchor MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Address alice@example.com

Entry<CatalogedContact>: NAQN-NQDL-LKHW-DY3U-QAFS-N2LW-6DHS
  Person 
  Anchor MCKB-VDWV-FXBV-ZEQC-62VO-UWU7-RKYC
  Address bob@example.com

Entry<CatalogedContact>: NBJM-J77F-WGI4-U42M-A273-L4LO-KUL4
  Person 
  Anchor MCXX-WFN3-4M63-LOT6-PO7W-PDME-JZCK
  Address groupw@example.com

Entry<CatalogedContact>: NBYB-VQJX-5JFD-M35Q-OFJD-TXNQ-R3A2
  Person 
  Anchor MCXX-WFN3-4M63-LOT6-PO7W-PDME-JZCK
  Address groupw@example.com

Entry<CatalogedContact>: NBDI-IEHI-35UN-DNGC-KVZN-37NZ-DCIH
  Person 
  Anchor MCXX-WFN3-4M63-LOT6-PO7W-PDME-JZCK
  Address groupw@example.com

</div>
~~~~


~~~~
<div="terminal">
<cmd>Carol> meshman account sync /auto
<cmd>Carol> meshman contact get alice@example.com
<rsp>
</div>
~~~~



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


~~~~
<div="terminal">
<cmd>Doug> meshman contact static 
<rsp>ERROR - The feature has not been implemented
</div>
~~~~


~~~~
<div="terminal">
<cmd>Alice> meshman contact fetch uri
<rsp>ERROR - The specified connection URI was invalid
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Person MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Anchor MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Address alice@example.com

Entry<CatalogedContact>: NAQN-NQDL-LKHW-DY3U-QAFS-N2LW-6DHS
  Person 
  Anchor MCKB-VDWV-FXBV-ZEQC-62VO-UWU7-RKYC
  Address bob@example.com

Entry<CatalogedContact>: NBJM-J77F-WGI4-U42M-A273-L4LO-KUL4
  Person 
  Anchor MCXX-WFN3-4M63-LOT6-PO7W-PDME-JZCK
  Address groupw@example.com

Entry<CatalogedContact>: NBYB-VQJX-5JFD-M35Q-OFJD-TXNQ-R3A2
  Person 
  Anchor MCXX-WFN3-4M63-LOT6-PO7W-PDME-JZCK
  Address groupw@example.com

Entry<CatalogedContact>: NBDI-IEHI-35UN-DNGC-KVZN-37NZ-DCIH
  Person 
  Anchor MCXX-WFN3-4M63-LOT6-PO7W-PDME-JZCK
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
<rsp>Entry<CatalogedContact>: MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Person MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Anchor MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Address alice@example.com

Entry<CatalogedContact>: NAQN-NQDL-LKHW-DY3U-QAFS-N2LW-6DHS
  Person 
  Anchor MCKB-VDWV-FXBV-ZEQC-62VO-UWU7-RKYC
  Address bob@example.com

Entry<CatalogedContact>: NBJM-J77F-WGI4-U42M-A273-L4LO-KUL4
  Person 
  Anchor MCXX-WFN3-4M63-LOT6-PO7W-PDME-JZCK
  Address groupw@example.com

Entry<CatalogedContact>: NBYB-VQJX-5JFD-M35Q-OFJD-TXNQ-R3A2
  Person 
  Anchor MCXX-WFN3-4M63-LOT6-PO7W-PDME-JZCK
  Address groupw@example.com

Entry<CatalogedContact>: NBDI-IEHI-35UN-DNGC-KVZN-37NZ-DCIH
  Person 
  Anchor MCXX-WFN3-4M63-LOT6-PO7W-PDME-JZCK
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


~~~~
<div="terminal">
<cmd>Alice5> meshman bookmark list
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Devices are given authorization to access the contacts catalog using the 
 `device auth` command:


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

