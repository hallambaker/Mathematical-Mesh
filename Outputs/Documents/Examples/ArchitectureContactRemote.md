
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MDU3-3G3D-V6ZL-FT5N-XNYT-MSZN-Y3JI
Message ID: NB7C-4S72-F54E-POHI-4UAC-25EC-C4Z6
Response ID: MAHM-2ND6-CFO6-KLUE-R7AE-ENMY-7C6E
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NB7C-4S72-F54E-POHI-4UAC-25EC-C4Z6
        Contact Request::
        MessageID: NB7C-4S72-F54E-POHI-4UAC-25EC-C4Z6
        To: alice@example.com From: bob@example.com
        PIN: ADYE-Q43Y-EJM7-PWOA-C2I7-IN4Z-ZZ2Q
<cmd>Alice> message accept NB7C-4S72-F54E-POHI-4UAC-25EC-C4Z6
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MA7Z-J7ZZ-47XH-ULST-GS66-737D-OGXC
  Person MA7Z-J7ZZ-47XH-ULST-GS66-737D-OGXC
  Anchor MA7Z-J7ZZ-47XH-ULST-GS66-737D-OGXC
  Address alice@example.com

Entry<CatalogedContact>: NCSP-PVIQ-RA5F-DRFP-ZZSM-SHQ6-ANNG
  Person 
  Anchor MDA3-SFAE-RMFY-C5BO-ORQZ-Q46M-FLAJ
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MDA3-SFAE-RMFY-C5BO-ORQZ-Q46M-FLAJ
  Person MDA3-SFAE-RMFY-C5BO-ORQZ-Q46M-FLAJ
  Anchor MDA3-SFAE-RMFY-C5BO-ORQZ-Q46M-FLAJ
  Address bob@example.com

Entry<CatalogedContact>: NCRN-QPDZ-OYW4-FEWI-KEO4-WCEJ-PKCE
  Person 
  Anchor MA7Z-J7ZZ-47XH-ULST-GS66-737D-OGXC
  Address alice@example.com

</div>
~~~~

