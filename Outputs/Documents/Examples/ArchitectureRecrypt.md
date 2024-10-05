Alice creates the recryption group groupw@example.com to share confidential information with
her closest friends:


~~~~
<div="terminal">
<cmd>Alice> meshman group create groupw@example.com /web
<rsp>Account=groupw@example.com
UDF=MBQI-GRBW-QGJ4-WPKJ-J224-X7IY-HA7S
</div>
~~~~

Alice encrypts a test file but she can't decrypt it because she hasn't added herself 
to the group yet.


~~~~
<div="terminal">
<cmd>Alice> meshman type grouptext.txt
<rsp>The group secret handshake
<cmd>Alice> meshman dare encode grouptext.txt groupsecret.dare /encrypt ^
    groupw@example.com
<cmd>Alice> meshman dare decode groupsecret.dare grouptext_alice.dare
<rsp>ERROR - No decryption key is available
</div>
~~~~

Alice adds herself to the group, now she can decrypt:



~~~~
<div="terminal">
<cmd>Alice> meshman group add groupw@example.com alice@example.com
<rsp>alice@example.com [MBSX-VMLY-JDTV-GYNX-G6F4-2J5P-4JKS]

<cmd>Alice> meshman account sync /auto
<cmd>Alice> meshman dare decode groupsecret.dare grouptext_alice.dare
<cmd>Alice> meshman type grouptext_alice.dare
<rsp>The group secret handshake
</div>
~~~~

At this point, Bob can't encrypt or decrypt messages because he doesn't know the 
public key and he isn't in the group. Alice could allow Bob to encrypt but not
decrypt by sending him the group contact information without a decryption share. 
Instead she adds Bob to the group as a member:


~~~~
<div="terminal">
<cmd>Alice> meshman group add groupw@example.com bob@example.com
<rsp>bob@example.com [MBSX-VMLY-JDTV-GYNX-G6F4-2J5P-4JKS]

</div>
~~~~

Adding Bob to the group gives him immediate access to any file encrypted under
the group key without making any change to the encrypted files:


~~~~
<div="terminal">
<cmd>Bob> meshman account sync  /auto
<cmd>Bob> meshman dare decode groupsecret.dare grouptext_bob.dare
<cmd>Bob> meshman type grouptext_bob.dare
<rsp>The group secret handshake
</div>
~~~~

Removing Bob from the group immediately withdraws his access.


~~~~
<div="terminal">
<cmd>Alice> meshman group delete groupw@example.com bob@example.com
<rsp>bob@example.com [MBSX-VMLY-JDTV-GYNX-G6F4-2J5P-4JKS]

</div>
~~~~

Bob cannot decrypt files encrypted under the group key any more. But he 
still has access to the file grouptext_bob.dare he decrypted earlier.


~~~~
<div="terminal">
<cmd>Bob> meshman dare decode groupsecret.dare grouptext_bob2.dare
<rsp>ERROR - A cryptographic operation was refused.
<cmd>Bob> meshman type grouptext_bob.dare
<rsp>The group secret handshake
</div>
~~~~

The threshold key service acts as a policy enforcement point and can impose 
additional accounting and authorization controls on the use of the decryption
service.

For example, the threshold key service might be configured to alert a 
supervisor and/or deny decryption requests if a group member made an unusual 
volume of requests in a short period.


