
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> meshman contact request alice@example.com
<rsp>Envelope ID: MBXA-LC4Y-JPOL-566F-XHFH-UKHT-CPYS
Message ID: NBQT-BJ65-V3KT-VIW7-3CPD-PLUW-VTE7
Response ID: MCKR-A3VX-WNTE-BPWX-7KJN-U5XF-B356
</div>
~~~~

Alice checks her Mesh messages and approves Bob's request:


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

Bob can now collect Alice's contact:


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

