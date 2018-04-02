=To set up the Demonstration

<ol>
<li>Start the server
<li>Create a Mesh/Recrypt account for each user
<li>Create the recryption group
<li>Encrypt a data file
<li>Check it can be decrypted by group owner
<li>Check it can't be decrypted by non member
<li>Add member to the group
<li>Check it can be decrypted by new member
</ol>

<h2>Start the server

TBS

My server should be running at prismproof.org from Tuesday on.

<h2>Create a Mesh/Recrypt account for each user

The Mesh/Recrypt account is recorded in the Windows registry for each user. This version of 
the tool does not support multiple Mesh accounts per windows account So it is necessary 
to run the tool separately for each user.

~~~~
dareman register alice@prismproof.org
~~~~

Second machine:

~~~~
dareman register bob@prismproof.org
~~~~


<h2>Create the recryption group

On Alice's machine type:

~~~~
dareman group create mygroup@prismproof.org
~~~~

<h2>Encrypt a data file

This can be run by any user as it does not require an account.

~~~~
dareman encrypt mygroup@prismproof.org file1.html file1.dare
~~~~

<h2>Check it can be decrypted by group owner

On Alice's machine type:

~~~~
dareman decrypt file1.dare
[succeeds]
~~~~

<h2>Check it can't be decrypted by non member

On Bob's machine type:

~~~~
dareman decrypt file1.dare
[fails]
~~~~

<h2>Add member to the group

On Alice's machine type:

~~~~
dareman group add bob@prismproof.org
~~~~

<h2>Check it can be decrypted by new member

On Bob's machine type:

~~~~
dareman decrypt file1.dare
[succeeds]
~~~~
