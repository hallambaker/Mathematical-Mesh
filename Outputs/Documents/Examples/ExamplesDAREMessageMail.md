
For example, consider the following mail message:

~~~~
From: Alice@example.com
To: bob@example.com
Subject: TOP-SECRET Product Launch Today!

The CEO told me the product launch is today. Tell no-one!
~~~~

Existing encryption approaches require that header fields such as the subject line be encrypted 
with the body of the message or not encrypted at all. Neither approach is satisfactory.
In this example, the subject line gives away important information that the sender
probably assumed would be encrypted. But if the subject line is encrypted together with the
message body, a mail client must retrieve at least part of the message body to provide a 
'folder' view.

The plaintext form of the equivalent DARE Message encoding is:

~~~~
[{
    "annotations":["iAEAiBdGcm9tOiBBbGljZUBleGFtcGxlLmNvbQ",
      "iAEBiBNUbzogYm9iQGV4YW1wbGUuY29t",
      "iAECiClTdWJqZWN0OiBUT1AtU0VDUkVUIFByb2R1Y3QgTGF1bmNoIFRvZG
  F5IQ"
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "VGhlIENFTyB0b2xkIG1lIHRoZSBwcm9kdWN0IGxhdW5jaCBpcyB0b2RheS4gVG
  VsbCBuby1vbmUh"
  ]
~~~~

This contains the same information as before but the mail message headers are 
now presented as  a list of Encoded Data Sequences.

