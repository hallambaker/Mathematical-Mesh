<title>container
# Using the container Command Set

The `container` command set contains commands that operate on DARE Containers.

## Creating Containers

Containers are created with either the `container create` or 
`container archive`. Both commands create a container with the 
specified cryptographic enhancements. The `container archive`
command additionally adds the specified file(s) to the container to create 
a container archive.


~~~~
<div="terminal">
<cmd>Alice> container create Container.dcon
<rsp></div>
~~~~

*catalog* *spool* *archive* *log*


The cryptographic enhancements specified when a container is created have the 
same format and function as for DARE Messages but their scope is the container
as a whole.

For example, Alice creates an encrypted container readable by anyone who is a
member of the group groupw@example.com;


~~~~
<div="terminal">
<cmd>Alice> container create ContainerEncrypt.dcon /encrypt=groupw@example.com
<rsp></div>
~~~~

Since it is rarely desirable to sign every entry in a container, signatures
are typically added to a container when entries or indexes are added. 

The `container archive` creates a new container, adds the
specified file(s) as entries and appends an index as the final record:


~~~~
<div="terminal">
<cmd>Alice> container archive ContainerArchive.dcon TestDir1
<rsp>ERROR - Path cannot be null. (Parameter 'path')
</div>
~~~~

An archive may be signed and encrypted:


~~~~
<div="terminal">
<cmd>Alice> container create ContainerArchiveEncrypt.dcon TestDir1
<rsp><cmd>Alice> /encrypt=groupw@example.com /sign=alice@example.com
<rsp>ERROR - The command  is not known.
</div>
~~~~

The signature on a signed archive is calculated over the final apex of the 
Merkel tree. Thus a single signature verification may be used to validate
any or all entries in the container.

## Reading Containers

The `container verify` command verifies the contents of a container: 


~~~~
<div="terminal">
<cmd>Alice> container verify ContainerArchiveEncrypt.dcon
<rsp></div>
~~~~

The verification performed depends on the type of authentication applied to the
container and whether the verifier can provide the necessary authentication or
decryption keys.


The `container extract` 

One or more container entries may be extracted to a file using the  
`container extract` command. If the container is an archive, all
the files are extracted by default:


~~~~
<div="terminal">
<cmd>Alice> container extract Container.dcon TestOut
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Alternatively, the `/file` option may be used to extract a specific file:


~~~~
<div="terminal">
<cmd>Alice> container extract Container.dcon /file=TestDir1\TestFile4.txt
<rsp>ERROR - Value cannot be null. (Parameter 'path')
</div>
~~~~


## Writing to Containers

The `container append` command adds an entry to a container:


~~~~
<div="terminal">
<cmd>Alice> container append Container.dcon TestFile1.txtcontainer append Container.dcon TestFile2.txtcontainer append Container.dcon TestFile3.txt
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\TestFile1.txtcontainer'.
</div>
~~~~

If no security enhancements are specified, the default enhancements specified 
in the index entry are applied.

The `container delete` 

The `container delete` command adds an entry to a container
marking an entry as deleted:


~~~~
<div="terminal">
<cmd>Alice> container delete Container.dcon  TestFile2.txt
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Marking an entry for deletion does not cause the entry itself to be modified.
The entry is merely marked as having been deleted. To erase the entry contents,
it is necessary to either make a copy of the container using the `/purge`
option to reclaim the space used by deleted entries or to use the 
`/erase` or `overwrite` options.


The `container index` command adds an index entry to the end of
container:


~~~~
<div="terminal">
<cmd>Alice> container index Container.dcon
<rsp></div>
~~~~

The index entry may be complete, providing an index of the entire file 
or incremental, only indexing the items added since the last index was created.
Indexing containers allows the contents to be efficiently retrieved.

## Copying Containers

The `container copy` command makes a copy of a container with
the specified filtering rules. By default, no changes are made except to 
collect tree index fields dispersed throughout the container with an index 
at the end:


~~~~
<div="terminal">
<cmd>Alice> container copy Container2.dcon
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Container2.dcon'.
</div>
~~~~

The copy command may be used to encrypt or decrypt the container contents during 
the copy:


~~~~
<div="terminal">
<cmd>Alice> container copy ContainerArchiveEncrypt.dcon /decrypt
<rsp></div>
~~~~

The copy command may also be used to reclaim space used by deleted items:


~~~~
<div="terminal">
<cmd>Alice> container copy Container2.dcon /purge
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Container2.dcon'.
</div>
~~~~


