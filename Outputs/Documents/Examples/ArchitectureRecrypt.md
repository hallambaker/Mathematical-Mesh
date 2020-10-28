Alice creates the recryption group groupw@example.com to share confidential information with
her closest friends:


~~~~
<div="terminal">
<cmd>Alice> group create groupw@example.com
<rsp>{
  "Key": "groupw@example.com",
  "EnvelopedProfileGroup": [{
      "EnvelopeID": "MC4U-BX5B-3MNS-NWQZ-6MHR-5QK3-XNFE",
      "dig": "S512",
      "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQzRVLUJYNUItM01OUy1
  OV1FaLTZNSFItNVFLMy1YTkZFIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Udyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjAtMTAtMjhUMTU6NTg6MTdaIn0"},
    "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZml
  sZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQzRVLUJYNUItM01OUy1OV
  1FaLTZNSFItNVFLMy1YTkZFIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB
  7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiNXJWVnlLMzZJcFlqU1NUVTZ
  wSUhSV1kycVJjYzVURWdIbDltVWlwZGl6S3pkUFRGRXJFeQogIEFEM2lYcVFfc
  EJIbExvMllXd3dHRUVrQSJ9fX0sCiAgICAiQWNjb3VudEFkZHJlc3MiOiAiZ3J
  vdXB3QGV4YW1wbGUuY29tIiwKICAgICJBY2NvdW50RW5jcnlwdGlvbiI6IHsKI
  CAgICAgIlVkZiI6ICJNQlpKLVNQR0QtU0NaRC1ISlgzLVlEWkotVFJYTC1PQlV
  XIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJycDlmWElNN0dLLVZBTWFYXy05OE9OenNVWGNRTExjN29Zb
  1lkaVNJQ0xTVVZvWXVLUnk2CiAgbmJHV2Q0RjNqRGF4bHVsa05NQllzYmFBIn1
  9fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogICAgICAiVWRmI
  jogIk1DNFUtQlg1Qi0zTU5TLU5XUVotNk1IUi01UUszLVhORkUiLAogICAgICA
  iUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6I
  HsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI
  6ICI1clZWeUszNklwWWpTU1RVNnBJSFJXWTJxUmNjNVRFZ0hsOW1VaXBkaXpLe
  mRQVEZFckV5CiAgQUQzaVhxUV9wQkhsTG8yWVd3d0dFRWtBIn19fX19",
    {
      "signatures": [{
          "alg": "S512",
          "kid": "MC4U-BX5B-3MNS-NWQZ-6MHR-5QK3-XNFE",
          "signature": "Q2b6bBq8DSN_sY9gz7MDLHGVEKfVTchInRE5XkVhWC1pkPE9x
  nu-5s2vQiC38rMqbRTsRTPE4AGArjRjjWufWhwwAJs-tupAkwZgdEjiNzms8gL
  6hrKotcr2L0FE3EUOFSpSI4FqbOr5QaBuucX5aggA"}],
      "PayloadDigest": "yE2TBXm-GuK2hknbZ9F8YeYqDhmoze6a19DiyqPMloh8V
  aUKgMidJyeLZ08RaRg7kP2Jrl2YWQLbb5fQFwSgyQ"}],
  "EnvelopedActivationAccount": [{
      "enc": "A256CBC",
      "dig": "S512",
      "kid": "EBQA-5UMP-IQT2-WZAY-JBSC-YDMW-BIXV",
      "Salt": "UeF914dA6K2Jnz40CfeOMQ",
      "recipients": [{
          "kid": "MCLB-IAHX-24D6-SCG4-ASFK-BJUK-WEYZ",
          "epk": {
            "PublicKeyECDH": {
              "crv": "X448",
              "Public": "OKJhMPBf9-9v3JsvZhXqOVdmY9ceaukjbzBy-EfgRkWcK4a7KnF5
  Gmui9Aw61dzRMYHKPZF-C2qA"}},
          "wmk": "ttqEJpg7dRQEwQhh-fvcysphr_2ecBthYZbK665cWjq8Zxs3DYVdVg"}],
      "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0aW9uQWN
  jb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAiQ
  3JlYXRlZCI6ICIyMDIwLTEwLTI4VDE1OjU4OjE3WiJ9"},
    "O7SCiRrwEh5JYs6rDdHYUaWH_p8Ka_ziBrCOlHjPayc",
    {
      "signatures": [{
          "alg": "S512",
          "kid": "MC4U-BX5B-3MNS-NWQZ-6MHR-5QK3-XNFE",
          "signature": "ly2L8F71qvQ_P2he2G4abjwXswFl9CumRjbnYBMfuJ93yLpwH
  7YXxRndSQsrCQPv1wvWe_ivtXAA-xkNEFUISnrCgg1iwwUCknZ5cuuNEJBwGP_
  dehjtxHjKvMUG_5OY5ow2EvYj-W_IqpTd4Q_FBh8A",
          "witness": "FWI23FD0FcX79VYwKZwOMFX7q9KO_aeb5v3dfVUsXRw"}],
      "PayloadDigest": "itEHKG2YQPKcjxPO41uoqq8GM_583K08e_FLJb376H33M
  Vw1aZzwITx8WDdWMI2_lmW2SvO_JtJGecOjezEPOA"}]}</div>
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
  "MemberCapabilityId": "MBZJ-SPGD-SCZD-HJX3-YDZJ-TRXL-OBUW",
  "ServiceCapabilityId": "NAKR-PHTI-6B36-JVW4-HCKN-CNGL-3RWE"}</div>
~~~~

Adding Bob to the group gives him immediate access to any file encrypted under
the group key without making any change to the encrypted files:


~~~~
<div="terminal">
<cmd>Alice> dare decode groupsecret.dare
<rsp>ERROR - No decryption key is available
</div>
~~~~

Removing Bob from the group immediately withdraws his access.


~~~~
<div="terminal">
<cmd>Alice> group delete groupw@example.com bob@example.com
<rsp>{
  "ContactAddress": "bob@example.com",
  "MemberCapabilityId": "MBZJ-SPGD-SCZD-HJX3-YDZJ-TRXL-OBUW",
  "ServiceCapabilityId": "NAKR-PHTI-6B36-JVW4-HCKN-CNGL-3RWE"}</div>
~~~~

Bob cannot decrypt any more files (but he may have kept copies of files he decrypted 
earlier).


~~~~
<div="terminal">
<cmd>Alice> dare decode groupsecret.dare
<rsp>ERROR - No decryption key is available
</div>
~~~~

