<title>group
# Using the group Command Set

The group command set is used to manage recryption groups

In traditional public key encryption, the public key is used to encrypt data
and the private key is used to decrypt. In the proxy re-encryption scheme used 
in the Mesh, the public key is used to encrypt data in the exact same way as 
for two key cryptography but the decryption key is split into two parts. One 
half of which is held by the recipient and the other half of which is sent 
to a recryption service.

Decrypting encrypted data requires the use of both halves of the key. The recryption
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
restrictions of this form do not appear to be frequently realized in practice.

## Creating a Recryption Group

Recryption groups are created using the `group create` command:


~~~~
<div="terminal">
<cmd>Alice> meshman group create groupw@example.com /web
<rsp>Account=groupw@example.com
UDF=MCXX-WFN3-4M63-LOT6-PO7W-PDME-JZCK
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
<rsp>{
  "ContactAddress": "alice@example.com",
  "MemberCapabilityId": "MBK4-3JBR-FQE6-SIGE-PBL7-BYFI-ZFPN",
  "ServiceCapabilityId": "MCSE-AYRM-VEET-M3JA-AUNI-SUY3-E6HV"}
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
<rsp>{
  "ContactAddress": "bob@example.com",
  "MemberCapabilityId": "MBK4-3JBR-FQE6-SIGE-PBL7-BYFI-ZFPN",
  "ServiceCapabilityId": "MCAL-TOGV-SG7G-N3I2-I6EB-HJ5A-D3FR"}
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
<cmd>Alice> meshman group get groupw@example.com
<rsp>ERROR - Value cannot be null. (Parameter 'key')
</div>
~~~~


## Deleting users

Users may be removed from a recryption group using the `group delete` command:


~~~~
<div="terminal">
<cmd>Alice> meshman group delete groupw@example.com bob@example.com
<rsp>{
  "ContactAddress": "bob@example.com",
  "MemberCapabilityId": "MBK4-3JBR-FQE6-SIGE-PBL7-BYFI-ZFPN",
  "ServiceCapabilityId": "MCAL-TOGV-SG7G-N3I2-I6EB-HJ5A-D3FR"}
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


