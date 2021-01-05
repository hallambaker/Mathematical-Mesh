Alice creates the recryption group groupw@example.com to share confidential information with
her closest friends:


~~~~
<div="terminal">
<cmd>Alice> group create groupw@example.com
</div>
~~~~

Bob encrypts a test file but he can't decrypt it because he isn't in the group:


~~~~
<div="terminal">
<cmd>Alice> dare encode grouptext.txt  groupsecret.dare /encrypt ^
    groupw@example.com
</div>
~~~~

Even though she is the group administrator, Alice can't decrypt the file either until
she adds herself to the group.


~~~~
<div="terminal">
<cmd>Alice> dare decode groupsecret.dare
</div>
~~~~

Alice adds Bob to the group:


~~~~
<div="terminal">
<cmd>Alice> group add groupw@example.com bob@example.com
<rsp>{
  "ContactAddress": "bob@example.com",
  "MemberCapabilityId": "MAF3-FQ2B-VCIJ-K66B-JCFK-HTMA-ZBZH",
  "ServiceCapabilityId": "NDPW-7KR4-TSDP-QZRC-T67Y-CMOL-UAJI"}</div>
~~~~

Adding Bob to the group gives him immediate access to any file encrypted under
the group key without making any change to the encrypted files:


~~~~
<div="terminal">
<cmd>Bob> account sync  /auto
<cmd>Bob> dare decode groupsecret.dare
</div>
~~~~

Removing Bob from the group immediately withdraws his access.


~~~~
<div="terminal">
<cmd>Alice> group delete groupw@example.com bob@example.com
<rsp>{
  "ContactAddress": "bob@example.com",
  "MemberCapabilityId": "MAF3-FQ2B-VCIJ-K66B-JCFK-HTMA-ZBZH",
  "ServiceCapabilityId": "NDPW-7KR4-TSDP-QZRC-T67Y-CMOL-UAJI"}</div>
~~~~

Bob cannot decrypt any more files (but he may have kept copies of files he decrypted 
earlier).


~~~~
<div="terminal">
<cmd>Bob> dare decode groupsecret.dare
<rsp>ERROR - A requested cryptographic operation failed.
</div>
~~~~

