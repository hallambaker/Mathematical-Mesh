Alice creates the recryption group groupw@example.com to share confidential information with
her closest friends:


~~~~
<div="terminal">
<cmd>Alice> group create groupw@example.com
<rsp>{
  "Key": "groupw@example.com",
  "EnvelopedProfileGroup": [{
      "EnvelopeID": "MAXH-HSGW-JFNX-HQMR-A3EF-4ST3-DXJU",
      "dig": "S512",
      "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQVhILUhTR1ctSkZOWC1
  IUU1SLUEzRUYtNFNUMy1EWEpVIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Udyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjAtMTAtMjhUMjM6MDE6NDBaIn0"},
    "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZml
  sZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQVhILUhTR1ctSkZOWC1IU
  U1SLUEzRUYtNFNUMy1EWEpVIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB
  7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiOHZfYktKTERkdVFHbVFkNl9
  la25iM21jNlJXV09teVVHczhMUUtjMEg2bVU3bW0zSzE1UwogIDM3TVhsZmlVc
  zdZSUV5N2hIemdZTS1jQSJ9fX0sCiAgICAiQWNjb3VudEFkZHJlc3MiOiAiZ3J
  vdXB3QGV4YW1wbGUuY29tIiwKICAgICJBY2NvdW50RW5jcnlwdGlvbiI6IHsKI
  CAgICAgIlVkZiI6ICJNQUJTLUVUTDYtNlRNQS1JRlNVLU5JSEMtTUxHVi1WQ0R
  DIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJHTXhvMUY2a192SWdHc0w5Q01YeFdZMEE4czdkM2ZyMVc2b
  Eh1M280U1pvVF8zOEJ4T1ZICiAgbFRNNGNpUU52bGRmeTZiTDBHejlmdnlBIn1
  9fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogICAgICAiVWRmI
  jogIk1BWEgtSFNHVy1KRk5YLUhRTVItQTNFRi00U1QzLURYSlUiLAogICAgICA
  iUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6I
  HsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI
  6ICI4dl9iS0pMRGR1UUdtUWQ2X2VrbmIzbWM2UldXT215VUdzOExRS2MwSDZtV
  TdtbTNLMTVTCiAgMzdNWGxmaVVzN1lJRXk3aEh6Z1lNLWNBIn19fX19",
    {
      "signatures": [{
          "alg": "S512",
          "kid": "MAXH-HSGW-JFNX-HQMR-A3EF-4ST3-DXJU",
          "signature": "7hIc5HvdlwpV6Y9MG9Ghf0EV4ODLHyMf94qrNFzyg_dFesBO1
  Iv6COuAItVtJeR8kc9Zxv4ryC4A3qeViUyPS2cuWwYyBsHaHIiYIjjxLYtDCW7
  f-LHtq_y8L4cwS4DTVIW7r9G5fEgU7WBbCHzVJTcA"}],
      "PayloadDigest": "i4ugMq2-bw3lfir-R7EE7IEtncH_vahnRqovuS6Dv3AxA
  YfhJk0BHQSwCduvKq18tLyTOE52xUcLEO5S1OT6gQ"}],
  "EnvelopedActivationAccount": [{
      "enc": "A256CBC",
      "dig": "S512",
      "kid": "EBQK-JHU6-GCXT-NN6H-K4OW-YMO6-RMVH",
      "Salt": "DpKUkqDxzPTl0-JMRnyTZw",
      "recipients": [{
          "kid": "MDJT-SEJ2-HAGY-GBUA-WINT-PZJW-KV57",
          "epk": {
            "PublicKeyECDH": {
              "crv": "X448",
              "Public": "5VDeqBEYUlI2yQ_QneWJTd4QMxKimqwWumU2ivOsCjHspHt3bu11
  9Pp9tdWwsFu2T3JFtCzj9A6A"}},
          "wmk": "6gcIMahqY_9dlVUhc-vXGoN3VixxyPY8xIe8mlWC3YFNJ6B3t3PRCA"}],
      "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0aW9uQWN
  jb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAiQ
  3JlYXRlZCI6ICIyMDIwLTEwLTI4VDIzOjAxOjQwWiJ9"},
    "f96w9KwFJ7Ym0HHDRn5XnZ6yQAAKnmGcSYSvPV2J02A",
    {
      "signatures": [{
          "alg": "S512",
          "kid": "MAXH-HSGW-JFNX-HQMR-A3EF-4ST3-DXJU",
          "signature": "OGloRHFeAA4w32DdLo71nRzjurPKNuJCKUCR_K5a5sKOxSiSP
  1C7a66jsR6Ux7duhviFeD4wfsgA4DXFYpbhMxj2MZ2e_2PTDG9VpHnsdiaTDa1
  XyHBIn2XQyNLnBuQF3uRp7TlVWq0QHlhlQ67ctwoA",
          "witness": "X6yNNfa1H49vkOFVc6UqlbwknBIJZFN1gKlVuHnLz_w"}],
      "PayloadDigest": "Mspum4OYNvhDchQxVUkD3oNWtlBvkojd102Fsh4xYuR-O
  YHwjK01Atd3U5bAAi-pvYEnPJajD6FInu5ZNVuIyA"}]}</div>
~~~~

Bob encrypts a test file but he can't decrypt it because he isn't in the group:


~~~~
<div="terminal">
<cmd>Alice> dare encode grouptext.txt /encrypt groupw@example.com /out groupsecret.dare
<rsp></div>
~~~~

Even though she is the group administrator, Alice can't decrypt the file either until
she adds herself to the group.


~~~~
<div="terminal">
<cmd>Alice> dare decode groupsecret.dare
<rsp>ERROR - No decryption key is available
</div>
~~~~

Alice adds Bob to the group:


~~~~
<div="terminal">
<cmd>Alice> group add groupw@example.com bob@example.com
<rsp>{
  "ContactAddress": "bob@example.com",
  "MemberCapabilityId": "MABS-ETL6-6TMA-IFSU-NIHC-MLGV-VCDC",
  "ServiceCapabilityId": "NCXN-LN4I-IEQF-6BCZ-YYZY-75L6-53LO"}</div>
~~~~

Adding Bob to the group gives him immediate access to any file encrypted under
the group key without making any change to the encrypted files:


~~~~
<div="terminal">
<cmd>Bob> account sync
<rsp><cmd>Bob> dare decode groupsecret.dare
<rsp>ERROR - No decryption key is available
</div>
~~~~

Removing Bob from the group immediately withdraws his access.


~~~~
<div="terminal">
<cmd>Alice> group delete groupw@example.com bob@example.com
<rsp>{
  "ContactAddress": "bob@example.com",
  "MemberCapabilityId": "MABS-ETL6-6TMA-IFSU-NIHC-MLGV-VCDC",
  "ServiceCapabilityId": "NCXN-LN4I-IEQF-6BCZ-YYZY-75L6-53LO"}</div>
~~~~

Bob cannot decrypt any more files (but he may have kept copies of files he decrypted 
earlier).


~~~~
<div="terminal">
<cmd>Bob> dare decode groupsecret.dare
<rsp>ERROR - No decryption key is available
</div>
~~~~

