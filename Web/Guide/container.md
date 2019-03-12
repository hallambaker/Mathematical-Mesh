
# Using the `container Command Set

The `container` command set contains commands that operate on DARE Containers.

## Creating Containers

Containers are created with either the `container create` or 
`container archive`. Both commands create a container with the 
specified cryptographic enhancements. The `container archive`
command additionally adds the specified file(s) to the container to create 
a container archive.

**Missing Example***

*catalog* *spool* *archive* *log*


The cryptographic enhancements specified when a container is created have the 
same format and function as for DARE Messages but their scope is the container
as a whole.

For example, Alice creates an encrypted container readable by anyone who is a
member of the group groupies@example.com;

**Missing Example***

Since it is rarely desirable to sign every entry in a container, signatures
are typically added to a container when entries or indexes are added. 

The `container archive` creates a new container, adds the
specified file(s) as entries and appends an index as the final record:

**Missing Example***

The archive may be signed and encrypted:

**Missing Example***

## Reading Containers

The `container verify` 

**Missing Example***


The `container extract` 

**Missing Example***

**Missing Example***






## Writing to Containers

The `container append` 

**Missing Example***



The `container delete` 

**Missing Example***


The `container index` 

**Missing Example***



## Copying Containers

The `container copy` 

**Missing Example***

**Missing Example***

**Missing Example***


