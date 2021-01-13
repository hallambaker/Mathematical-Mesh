Alice creates the recryption group groupw@example.com to share confidential information with
her closest friends:


~~~~
<div="terminal">
<cmd>Alice> group create groupw@example.com
<rsp>Account=groupw@example.com
UDF=MBND-NF5R-BEOZ-EHDY-PXM3-XTDU-HK5T
</div>
~~~~

Alice encrypts a test file but he can't decrypt it because she hasn't added herself 
to the group yet.


~~~~
<div="terminal">
<cmd>Alice> dare encode grouptext.txt groupsecret.dare /encrypt ^
    groupw@example.com
<cmd>Alice> dare decode groupsecret.dare grouptext_bob.dare
<rsp>ERROR - No decryption key is available
</div>
~~~~

Alice adds herself to the group, now she can decrypt:


~~~~
<div="terminal">
<cmd>Alice> group add groupw@example.com alice@example.com
<rsp>{
  "ContactAddress": "alice@example.com",
  "MemberCapabilityId": "MB44-I7TT-A3JE-N5LK-SKTY-WJD6-URGZ",
  "ServiceCapabilityId": "NAI2-6VHZ-YVLG-6AGV-FGVX-6JOH-XQP6"}
<cmd>Alice> account sync /auto
<cmd>Alice> dare decode groupsecret.dare grouptext_alice.dare
<cmd>Alice> type grouptext_alice.dare
<rsp>The group secret handshake
</div>
~~~~

At this point, Bob can't encrypt or decrypt messages because he doesn't know the 
public key and he isn't in the group. Alice could allow Bob to encrypt but not
decrypt by sending him the group contact information. Instead she adds Bob to 
the group:


~~~~
<div="terminal">
<cmd>Alice> group add groupw@example.com bob@example.com
<rsp>{
  "ContactAddress": "bob@example.com",
  "MemberCapabilityId": "MB44-I7TT-A3JE-N5LK-SKTY-WJD6-URGZ",
  "ServiceCapabilityId": "NC6A-BU3A-VQE7-KXXQ-F352-E5AG-KZW4"}
</div>
~~~~

Adding Bob to the group gives him immediate access to any file encrypted under
the group key without making any change to the encrypted files:


~~~~
<div="terminal">
<cmd>Bob> account sync  /auto
<cmd>Bob> dare decode groupsecret.dare grouptext_bob.dare
<cmd>Bob> type grouptext_bob.dare
<rsp>The group secret handshake
</div>
~~~~

Removing Bob from the group immediately withdraws his access.


~~~~
<div="terminal">
<cmd>Alice> group delete groupw@example.com bob@example.com
<rsp>{
  "ContactAddress": "bob@example.com",
  "MemberCapabilityId": "MB44-I7TT-A3JE-N5LK-SKTY-WJD6-URGZ",
  "ServiceCapabilityId": "NC6A-BU3A-VQE7-KXXQ-F352-E5AG-KZW4"}
</div>
~~~~

Bob cannot decrypt any more files (but he may have kept copies of files he decrypted 
earlier).


~~~~
<div="terminal">
<cmd>Bob> dare decode groupsecret.dare grouptext_bob2.dare
<rsp>ERROR - A requested cryptographic operation failed.
</div>
~~~~

