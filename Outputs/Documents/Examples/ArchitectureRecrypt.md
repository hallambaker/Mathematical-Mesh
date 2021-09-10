Alice creates the recryption group groupw@example.com to share confidential information with
her closest friends:


~~~~
<div="terminal">
<cmd>Alice> group create groupw@example.com
<rsp>Account=groupw@example.com
UDF=MCEF-LGNU-KJTP-WFVW-MAIF-LW6O-HPB3
</div>
~~~~

Alice encrypts a test file but she can't decrypt it because she hasn't added herself 
to the group yet.


~~~~
<div="terminal">
<cmd>Alice> type plaintext.txt
<rsp>This is a test
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
  "MemberCapabilityId": "MCDE-JLJP-LHN3-X462-HL5O-2FQO-XCPY",
  "ServiceCapabilityId": "MCOU-H4AZ-E224-MIH2-UXMF-GFPM-NZL6"}
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
  "MemberCapabilityId": "MCDE-JLJP-LHN3-X462-HL5O-2FQO-XCPY",
  "ServiceCapabilityId": "MDTP-3IJG-CAXY-M57C-XIIP-MBT6-57BB"}
</div>
~~~~

Adding Bob to the group gives him immediate access to any file encrypted under
the group key without making any change to the encrypted files:

>>>> Unfinished ArchitectureRecrypt  [GroupDecryptBobSuccess]



~~~~
<div="terminal">
<cmd>Bob> account sync  /auto
<cmd>Bob> dare decode groupsecret.dare grouptext_bob.dare
<cmd>Bob> type grouptext_bob.dare
<rsp>The group secret handshake
</div>
~~~~

Removing Bob from the group immediately withdraws his access.

>>>> Unfinished ArchitectureRecrypt  [GroupDeleteBob]



~~~~
<div="terminal">
<cmd>Alice> group delete groupw@example.com bob@example.com
<rsp>{
  "ContactAddress": "bob@example.com",
  "MemberCapabilityId": "MCDE-JLJP-LHN3-X462-HL5O-2FQO-XCPY",
  "ServiceCapabilityId": "MDTP-3IJG-CAXY-M57C-XIIP-MBT6-57BB"}
</div>
~~~~

Bob cannot decrypt any more files (but he may have kept copies of files he decrypted 
earlier).

>>>> Unfinished ArchitectureRecrypt  [GroupDecryptBobRevoked ]



~~~~
<div="terminal">
<cmd>Bob> dare decode groupsecret.dare grouptext_bob2.dare
<rsp>ERROR - A requested cryptographic operation failed.
</div>
~~~~

