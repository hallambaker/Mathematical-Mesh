
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

The archive may be signed and encrypted:


````
>container create ContainerArchiveEncrypt.dcon TestDir1
OK
>/encrypt=groupies@example.com /sign=alice@example.com
ERROR - The command  is not known.
````

## Reading Containers

The `container verify` 


````
>container verify ContainerArchiveEncrypt.dcon
OK
````


The `container extract` 


````
>container extract Container.dcon TestOut
OK
````


````
>container extract Container.dcon /file=TestDir1\TestFile4.txt
ERROR - Value cannot be null.
Parameter name: path
````






## Writing to Containers

The `container append` 


````
>container append Container.dcon TestFile1.txtcontainer append Container.dcon TestFile2.txtcontainer append Container.dcon TestFile3.txt
ERROR - Could not find file 'C:\Users\hallam\Work\mmm\Web\TestFile1.txtcontainer'.
````



The `container delete` 


````
>container delete Container.dcon  TestFile2.txt
OK
````


The `container index` 


````
>container index Container.dcon
OK
````



## Copying Containers

The `container copy` 


````
>container copy Container2.dcon
ERROR - Could not find file 'C:\Users\hallam\Work\mmm\Web\Container2.dcon'.
````


````
>container copy ContainerArchiveEncrypt.dcon /decrypt
OK
````


````
>container copy Container2.dcon /purge
ERROR - Could not find file 'C:\Users\hallam\Work\mmm\Web\Container2.dcon'.
````


