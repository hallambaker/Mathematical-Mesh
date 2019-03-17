
# Using the `container Command Set

The `container` command set contains commands that operate on DARE Containers.

## Creating Containers

Containers are created with either the `container create` or 
`container archive`. Both commands create a container with the 
specified cryptographic enhancements. The `container archive`
command additionally adds the specified file(s) to the container to create 
a container archive.


````
>container create Container.dcon
OK
````

*catalog* *spool* *archive* *log*


The cryptographic enhancements specified when a container is created have the 
same format and function as for DARE Messages but their scope is the container
as a whole.

For example, Alice creates an encrypted container readable by anyone who is a
member of the group groupies@example.com;


````
>container create ContainerEncrypt.dcon /encrypt=groupies@example.com
OK
````

Since it is rarely desirable to sign every entry in a container, signatures
are typically added to a container when entries or indexes are added. 

The `container archive` creates a new container, adds the
specified file(s) as entries and appends an index as the final record:


````
>container archive ContainerArchive.dcon TestDir1
ERROR - Path cannot be null.
Parameter name: path
````

An archive may be signed and encrypted:


````
>container create ContainerArchiveEncrypt.dcon TestDir1
OK
>/encrypt=groupies@example.com /sign=alice@example.com
ERROR - The command  is not known.
````

The signature on a signed archive is calculated over the final apex of the 
Merkel tree. Thus a single signature verification may be used to validate
any or all entries in the container.

## Reading Containers

The `container verify` command verifies the contents of a container: 


````
>container verify ContainerArchiveEncrypt.dcon
OK
````

The verification performed depends on the type of authentication applied to the
container and whether the verifier can provide the necessary authentication or
decryption keys.


The `container extract` 

One or more container entries may be extracted to a file using the  
`container extract` command. If the container is an archive, all
the files are extracted by default:


````
>container extract Container.dcon TestOut
OK
````

Alternatively, the `/file` option may be used to extract a specific file:


````
>container extract Container.dcon /file=TestDir1\TestFile4.txt
ERROR - Value cannot be null.
Parameter name: path
````


## Writing to Containers

The `container append` command adds an entry to a container:


````
>container append Container.dcon TestFile1.txtcontainer append Container.dcon TestFile2.txtcontainer append Container.dcon TestFile3.txt
ERROR - Could not find file 'C:\Users\hallam\Work\mmm\Web\TestFile1.txtcontainer'.
````

If no security enhancements are specified, the default enhancements specified 
in the index entry are applied.

The `container delete` 

The `container delete` command adds an entry to a container
marking an entry as deleted:


````
>container delete Container.dcon  TestFile2.txt
OK
````

Marking an entry for deletion does not cause the entry itself to be modified.
The entry is merely marked as having been deleted. To erase the entry contents,
it is necessary to either make a copy of the container using the `/purge`
option to reclaim the space used by deleted entries or to use the 
`/erase` or `overwrite` options.


The `container index` command adds an index entry to the end of
container:


````
>container index Container.dcon
OK
````

The index entry may be complete, providing an index of the entire file 
or incremental, only indexing the items added since the last index was created.
Indexing containers allows the contents to be efficiently retrieved.

## Copying Containers

The `container copy` command makes a copy of a container with
the specified filtering rules. By default, no changes are made except to 
collect tree index fields dispersed throughout the container with an index 
at the end:


````
>container copy Container2.dcon
ERROR - Could not find file 'C:\Users\hallam\Work\mmm\Web\Container2.dcon'.
````

The copy command may be used to encrypt or decrypt the container contents during 
the copy:


````
>container copy ContainerArchiveEncrypt.dcon /decrypt
OK
````

The copy command may also be used to reclaim space used by deleted items:


````
>container copy Container2.dcon /purge
ERROR - Could not find file 'C:\Users\hallam\Work\mmm\Web\Container2.dcon'.
````


