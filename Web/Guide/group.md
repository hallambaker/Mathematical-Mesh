<title>group
# Using the group Command Set

The group command set is used to create groups of users to whom the ability 
to decrypt documents is granted without modification of the documents themselves
or compromise to the end-to-end security of the encrypted documents.

In traditional public key encryption, the public key is used to encrypt data
and the private key is used to decrypt. In the threshold encryption scheme used 
in the Mesh, the public key is used to encrypt data in the exact same way as 
for two key cryptography but the decryption key is split into two parts. One 
half of which is held by the recipient and the other half of which is sent 
to a recryption service.

Decrypting encrypted data requires the use of both halves of the key. The key service
service cannot decrypt data because it does not have access to the recipient's half
of the decryption key and the recipient can't decrypt the data unless the recryption
service performs its half of the work and returns the result to the recipient.

This approach has important benefits:

* Data cannot be decrypted without the decryption key held by the recipient, thus
encryption end-to-end. 

* Even a total breach of the recryption service does not result in disclosure of
the data unless at least one recipient decryption key is also compromised.

* Recipients may be added to a recryption group at any time and immediately gain access
to all data previously encrypted to the group.

* If a recipient is removed from a recryption group, the recyption service can
deny further access to the data encrypted under that group by refusing recryption 
requests from that recipient.

* All access to encrypted data must be mediated through the recryption service.
The recryption service may therefore enforce audit and accounting controls, detect
and prevent suspicious behavior.

From the user's point of view, management of recryption groups is essentially the 
same as management of groups in traditional access control. The principal difference
being that there is no cryptographically enforced means of denying access to a 
specific group of users as is provided in traditional Access Control List schemes.

To implement access restrictions of the form 'allow access to a file to every member
of the red team who is not a member of the blue team', it would be necessary to create 
and maintain a 'red not blue' group. Fortunately, the need for access control 
restrictions of this form do not appear to be occur frequently in practice.

## Creating a Recryption Group

Recryption groups are created using the `group create` command:


~~~~
<div="terminal">
<cmd>Alice> meshman group create groupw@example.com /web
<rsp>Account=groupw@example.com
UDF=MASC-RP6Y-4AQ5-HYVY-IOMY-HSXT-FJU5
</div>
~~~~

This command creates the group groupw@example.com. Since Alice created the
account she is the administrator.

At this point, the group has no members. Bob can encrypt a file under the group
public key but he is unable to read it:


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

Even though Alice is the group administrator, she cannot decrypt the file by default:


~~~~
<div="terminal">
<cmd>Alice> meshman dare decode groupsecret.dare
<rsp>ERROR - No decryption key is available
</div>
~~~~

Alice adds herself to the group, now she can decrypt:


~~~~
<div="terminal">
<cmd>Alice> meshman group add groupw@example.com alice@example.com
<rsp>alice@example.com [MA3U-EQIV-5G6I-SK6H-2MSE-HEN3-SDVK]

<cmd>Alice> meshman account sync /auto
<cmd>Alice> meshman dare decode groupsecret.dare grouptext_alice.dare
<cmd>Alice> meshman type grouptext_alice.dare
<rsp>The group secret handshake
</div>
~~~~


## Adding users

The `group add` command is used to add users to the group:

Alice adds Bob as a member of the group:


~~~~
<div="terminal">
<cmd>Alice> meshman group add groupw@example.com bob@example.com
<rsp>bob@example.com [MA3U-EQIV-5G6I-SK6H-2MSE-HEN3-SDVK]

</div>
~~~~

Bob can now decrypt the file.


~~~~
<div="terminal">
<cmd>Bob> meshman account sync  /auto
<cmd>Bob> meshman dare decode groupsecret.dare grouptext_bob.dare
<cmd>Bob> meshman type grouptext_bob.dare
<rsp>The group secret handshake
</div>
~~~~

## Reporting users

The `group list` command returns a list of group members:


~~~~
<div="terminal">
<cmd>Alice> meshman group list groupw@example.com
</div>
~~~~

The group currently has one administrator and one member.

The `group get` command returns information about a particular member.
If the service hosting the key service tracks key operations, this might report the
number of documents a user has viewed.


~~~~
<div="terminal">
<cmd>Alice> meshman group get groupw@example.com bob@example.com
<rsp>bob@example.com [MA3U-EQIV-5G6I-SK6H-2MSE-HEN3-SDVK]

</div>
~~~~

## Future directions

The implementation of the group encryption scheme provides only limited control over the 
encrypted document corpus. A more comprehensive implementation would support the
ability to impose fine grained access control criteria at the document level, to
track the number of documents decrypted for each user generating warnings if the
number or type of documents being accessed might raise concern.

In short, a comprehensive approach to securing data at rest requires the use
of both access controls and accountability controls. Access controls by their
nature set the low bar for security, any user that might require access to a
document must be granted access even if there are thousands of documents and they
certainly don't need acess to every single one.

Authorization controls fill in the gaps left by access control by putting users on
notice that even though they have the ability to access a large corpus of material,
every access is logged and there will be consequences if they abuse that access.


## Deleting users

Users may be removed from a recryption group using the `group delete` command:


~~~~
<div="terminal">
<cmd>Alice> meshman group delete groupw@example.com bob@example.com
<rsp>bob@example.com [MA3U-EQIV-5G6I-SK6H-2MSE-HEN3-SDVK]

</div>
~~~~

Bob is no longer a member of the group and his decryption request now fails:


~~~~
<div="terminal">
<cmd>Bob> meshman dare decode groupsecret.dare grouptext_bob2.dare
<rsp>ERROR - A cryptographic operation was refused.
<cmd>Bob> meshman type grouptext_bob.dare
<rsp>The group secret handshake
</div>
~~~~


