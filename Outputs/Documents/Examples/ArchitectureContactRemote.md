
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> meshman message contact alice@example.com
<rsp>Envelope ID: MDIT-XD5L-W7AF-2JWM-6UBG-DLZZ-MBXO
Message ID: ND4S-KDPC-PUNU-4X3I-PTRT-LJSO-XGHV
Response ID: MDWU-67CX-VMM6-NRVO-EUTV-KL56-AYZE
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


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

Bob can now collect Alice's contact:


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

