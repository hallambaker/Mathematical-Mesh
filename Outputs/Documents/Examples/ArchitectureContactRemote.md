
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MCG2-IRWQ-RZUE-YG57-P7EC-43FA-CX7O
Message ID: NDIB-OGS2-XXZG-D2M2-5YJI-QQXN-2IVO
Response ID: MDIP-WVY2-OH4C-BBQQ-IWOX-3IA3-NIV3
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NDIB-OGS2-XXZG-D2M2-5YJI-QQXN-2IVO
        Contact Request::
        MessageID: NDIB-OGS2-XXZG-D2M2-5YJI-QQXN-2IVO
        To: alice@example.com From: bob@example.com
        PIN: AAKO-AYTU-YH3M-DWOO-SLKU-N7ZD-SKUA
<cmd>Alice> message accept NDIB-OGS2-XXZG-D2M2-5YJI-QQXN-2IVO
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MC44-IZC3-IWZT-VCVZ-L2AG-HI4E-LOV2
  Person MC44-IZC3-IWZT-VCVZ-L2AG-HI4E-LOV2
  Anchor MC44-IZC3-IWZT-VCVZ-L2AG-HI4E-LOV2
  Address alice@example.com

Entry<CatalogedContact>: NAJX-T6KH-4NGQ-ES47-AIIU-6633-XMB6
  Person 
  Anchor MA6I-MJ5Z-7BBO-TEBA-HQF6-LNR6-72SF
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MA6I-MJ5Z-7BBO-TEBA-HQF6-LNR6-72SF
  Person MA6I-MJ5Z-7BBO-TEBA-HQF6-LNR6-72SF
  Anchor MA6I-MJ5Z-7BBO-TEBA-HQF6-LNR6-72SF
  Address bob@example.com

Entry<CatalogedContact>: NCTK-FA6N-VGLJ-XAXE-QEDD-6WXC-7ALP
  Person 
  Anchor MC44-IZC3-IWZT-VCVZ-L2AG-HI4E-LOV2
  Address alice@example.com

</div>
~~~~

