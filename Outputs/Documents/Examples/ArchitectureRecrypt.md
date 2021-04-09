Alice creates the recryption group groupw@example.com to share confidential information with
her closest friends:


~~~~
<div="terminal">
<cmd>Alice> group create groupw@example.com
<rsp>Account=groupw@example.com
UDF=MARH-IIDG-JIAU-4YFZ-5DNO-NPCZ-YKVC
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
  "MemberCapabilityId": "MC37-4KGF-WZ2P-ZFBC-WI2R-RLVJ-DXJF",
  "ServiceCapabilityId": "NDIQ-4NHI-RGTF-3KLF-YH4G-77NB-AKEB"}
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
  "MemberCapabilityId": "MC37-4KGF-WZ2P-ZFBC-WI2R-RLVJ-DXJF",
  "ServiceCapabilityId": "ND36-BKGE-44KA-MRU3-7BIH-P57L-X5U6"}
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

