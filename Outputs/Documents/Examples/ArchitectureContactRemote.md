
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> meshman contact request alice@example.com
<rsp>Envelope ID: MAQZ-5I5U-RM2L-A6L5-HDQL-GPP5-LYKY
Message ID: NCXX-LH2E-SJMD-H2LI-J7KB-DJV2-45UR
Response ID: MBIU-SC6Z-NNEF-4463-L2WK-UUQ6-5ELH
</div>
~~~~

Alice checks her Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: NAF3-GGMH-PTI3-NHTN-F5SU-XMHC-UCU5
        Contact Request::
        MessageID: NAF3-GGMH-PTI3-NHTN-F5SU-XMHC-UCU5
        To: alice@example.com From: mallet@example.com
        PIN: ABUK-CGY3-NTGJ-QMIM-LPTM-RDCE-CVMA
MessageID: NCXX-LH2E-SJMD-H2LI-J7KB-DJV2-45UR
        Contact Request::
        MessageID: NCXX-LH2E-SJMD-H2LI-J7KB-DJV2-45UR
        To: alice@example.com From: bob@example.com
        PIN: ADUJ-IRU6-RAPP-K6KB-EJ3U-DRDB-KWKA
MessageID: NADD-B6K4-SDGI-BSJX-SKLV-R2X5-IPYH
<cmd>Alice> meshman message accept NCXX-LH2E-SJMD-H2LI-J7KB-DJV2-45UR
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA
  Person MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA
  Anchor MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA
  Address alice@example.com

Entry<CatalogedContact>: NB4A-ZXEH-I6SL-XNQ6-MN5E-C5MB-JNJ6
  Person 
  Anchor MBQN-CAEX-IDBY-ZSEK-HCAC-OBZB-JLSA
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> meshman account sync /auto
<cmd>Bob> meshman contact list
<rsp>Entry<CatalogedContact>: MBQN-CAEX-IDBY-ZSEK-HCAC-OBZB-JLSA
  Person MBQN-CAEX-IDBY-ZSEK-HCAC-OBZB-JLSA
  Anchor MBQN-CAEX-IDBY-ZSEK-HCAC-OBZB-JLSA
  Address bob@example.com

Entry<CatalogedContact>: NABZ-GIXI-IYQV-VYK4-YTS4-E6LZ-GB5S
  Person 
  Anchor MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA
  Address alice@example.com

</div>
~~~~

