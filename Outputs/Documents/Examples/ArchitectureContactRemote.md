
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MB7J-KQPU-Y7X5-FLIZ-KV52-NGS4-ZA5V
Message ID: NC73-FK3T-VLKH-TVJG-AUNW-NIXV-5JEW
Response ID: MDZ6-VP5D-7I6M-OYKI-DLPA-2KJK-54H3
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NC73-FK3T-VLKH-TVJG-AUNW-NIXV-5JEW
        Contact Request::
        MessageID: NC73-FK3T-VLKH-TVJG-AUNW-NIXV-5JEW
        To: alice@example.com From: bob@example.com
        PIN: ADMA-QBVV-7O32-EYN5-QMI2-H74W-3YCQ
<cmd>Alice> message accept NC73-FK3T-VLKH-TVJG-AUNW-NIXV-5JEW
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MA62-NMPL-3OBH-KM2M-LPOO-RUZC-HUH3
  Person MA62-NMPL-3OBH-KM2M-LPOO-RUZC-HUH3
  Anchor MA62-NMPL-3OBH-KM2M-LPOO-RUZC-HUH3
  Address alice@example.com

Entry<CatalogedContact>: NB4X-KK5M-QP5H-CWXJ-NSS4-SIIY-LL4F
  Person 
  Anchor MACP-HQ3V-6LAZ-HW62-Y5DP-4ZYQ-OV7V
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MACP-HQ3V-6LAZ-HW62-Y5DP-4ZYQ-OV7V
  Person MACP-HQ3V-6LAZ-HW62-Y5DP-4ZYQ-OV7V
  Anchor MACP-HQ3V-6LAZ-HW62-Y5DP-4ZYQ-OV7V
  Address bob@example.com

Entry<CatalogedContact>: NAE3-2SRF-HS3A-AB5T-O5L3-W3YC-R2UV
  Person 
  Anchor MA62-NMPL-3OBH-KM2M-LPOO-RUZC-HUH3
  Address alice@example.com

</div>
~~~~

