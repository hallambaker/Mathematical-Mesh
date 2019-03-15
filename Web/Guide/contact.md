
# Using the `contacts` Command Set

The `contacts` command set is used to manage the user's contacts catalogue.

The contacts catalogue plays an important role in Mesh messaging as it is used to 
determine the security policy for sending outbound messages and is one of the
sources used to perform access control (i.e. spam filtering) on inbound messages.

## Adding contacts

The `contact add` command adds a contact entry to a catalog:

**Missing Example***

Contacts may also be added by accepting contact request messages:


````
>message 
ERROR - The command  is not known.
````

````
>message 
ERROR - The command  is not known.
````


## Finding contacts

The `contact get` command retreives a contact by the contact's 
email address or label:

**Missing Example***

## Listing contacts

A complete list of contacts is obtained using the  `contact list` command:

**Missing Example***

## Deleting contacts

Contact entries may be deleted using the  `contact delete` command:

**Missing Example***



## Adding devices

Devices are given authorization to access the contacts catalog using the 
 `device auth` command:

 %  ConsoleExample (Examples.ContactAuth);

