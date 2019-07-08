
# Using the  Command Set

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


````
Alice> group create groupw@example.com
ERROR - The feature has not been implemented
````

This command creates the group groupw@example.com. Since Alice created the
account she is the administrator.

At this point, the group has no members. Bob can encrypt a file under the group
public key but he is unable to read it:


````
Bob> dare encodeTestFile1.txt /out=TestFile1-group.dare /encrypt=groupw@example.com
ERROR - The command  is not known.
Bob> dare decode  TestFile1-group.dare
ERROR - The feature has not been implemented
````

Since Alice is the group administrator, she can decrypt the file using her 
administrator key:


````
Alice> dare decode  TestFile1-group.dare
ERROR - The feature has not been implemented
````


## Adding users

The `group add` command is used to add users to the group:

Alice adds Bob as a member of the group:


````
Alice> group add groupw@example.com bob@example.com
ERROR - The feature has not been implemented
````

Bob can now decrypt the file.


````
Alice> dare decode  TestFile1-group.dare
ERROR - The feature has not been implemented
````

## Reporting users

The `connect ` command returns a list of group members:


````
Alice> group list groupw@example.com
ERROR - The feature has not been implemented
````

The group currently has one administrator and one member.

## Deleting users

Users may be removed from a recryption group using the `group delete` command:


````
Alice> group delete groupw@example.com bob@example.com
ERROR - The feature has not been implemented
````

Bob is no longer a member of the group and his decryption request now fails:


````
Alice> dare decode  TestFile1-group.dare
ERROR - The feature has not been implemented
````


