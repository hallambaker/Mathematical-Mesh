Alice creates the recryption group groupw@example.com to share confidential information with
her closest friends:


~~~~
<div="terminal">
<cmd>Alice> group create groupw@example.com
<rsp>Account=groupw@example.com
UDF=MCTZ-HSH7-NUNV-MQ3Z-XNJ6-XGB3-VBPX
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
  "MemberCapabilityId": "MCHU-Q4TP-GE2Y-6DNU-UYEF-P3BF-LZTB",
  "ServiceCapabilityId": "NA3H-TSPB-TVND-S6NK-57T4-6TYM-ZT3Z"}
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
  "MemberCapabilityId": "MCHU-Q4TP-GE2Y-6DNU-UYEF-P3BF-LZTB",
  "ServiceCapabilityId": "NBDJ-WYQO-UIEH-OVLK-B3UM-J5TN-AQ3P"}
</div>
~~~~

Adding Bob to the group gives him immediate access to any file encrypted under
the group key without making any change to the encrypted files:


~~~~
Missing example 4
~~~~

Removing Bob from the group immediately withdraws his access.


~~~~
Missing example 5
~~~~

Bob cannot decrypt any more files (but he may have kept copies of files he decrypted 
earlier).


~~~~
Missing example 6
~~~~

