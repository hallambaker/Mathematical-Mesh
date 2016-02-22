
#Protocol Overview



##Creating a new user profile


##Creating a new portal account

A user interacts with a Mesh service through a Mesh portal provider 
with which she establishes a portal account. 

For user convenience, a portal account identifier has the familiar 
<username>@<domain> format established in [~RFC822].

For example Alice selects example.com as her 
portal provider and chooses the account name alice.
Her portal account identifier is alice.

A user MAY establish accounts with multiple portal providers
and/or change their portal provider at any time they choose.

###Checking Account Identifier for uniqueness


<pre>
POST /.well-known/mmm/HTTP/1.1
Host: example.com
Content-Length: 88

{
  "ValidateRequest": {
    "Account": "alice@example.com",
    "Language": ["en-uk"]}}
</pre>

###Publishing a new user profile

##Connecting a device profile to a user profile

##Adding an application profile to a user profile

##Updating an application profile

##Creating a recovery profile

##Recovering a profile

Accidents happen and so do disasters. For most users and most applications,
data loss is a much more important concern than data disclosure. The option 
of using a robust key recovery mechanism is therefore essential for use of 
strong cryptography is to become ubiquitous.

There are of course circumstances in which some users may prefer to risk
losing some of their data rather than risk disclosure. Since any key recovery
infrastructure necessarily introduces the risk of 

A Mesh profile 


