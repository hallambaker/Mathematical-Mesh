
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MAIW-5M5Q-DQYE-LKK7-TT4V-GYYJ-OMQI
Message ID: NAEM-GZRG-JZX2-F7WC-MYTS-4WFX-NDG3
Response ID: MCNT-5Y3T-TYST-EIHA-IDJZ-OIRV-PV37
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NAEM-GZRG-JZX2-F7WC-MYTS-4WFX-NDG3
        Contact Request::
        MessageID: NAEM-GZRG-JZX2-F7WC-MYTS-4WFX-NDG3
        To: alice@example.com From: bob@example.com
        PIN: AAY2-O4MG-V2I3-EAOB-T6HN-M6CY-NF6Q
<cmd>Alice> message accept NAEM-GZRG-JZX2-F7WC-MYTS-4WFX-NDG3
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MDT2-CV27-KXQC-UNRX-NUEQ-USYA-UYN4
  Person MDT2-CV27-KXQC-UNRX-NUEQ-USYA-UYN4
  Anchor MDT2-CV27-KXQC-UNRX-NUEQ-USYA-UYN4
  Address alice@example.com

Entry<CatalogedContact>: NA7E-PWDP-ZACR-SB4O-PQEL-AK4U-QH5K
  Person 
  Anchor MAM2-LUTK-J7ON-5CCP-OTKW-MJMM-FDG3
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MAM2-LUTK-J7ON-5CCP-OTKW-MJMM-FDG3
  Person MAM2-LUTK-J7ON-5CCP-OTKW-MJMM-FDG3
  Anchor MAM2-LUTK-J7ON-5CCP-OTKW-MJMM-FDG3
  Address bob@example.com

Entry<CatalogedContact>: NDDQ-OGZB-QMZR-CGJB-6XE7-YP4X-T4DA
  Person 
  Anchor MDT2-CV27-KXQC-UNRX-NUEQ-USYA-UYN4
  Address alice@example.com

</div>
~~~~

