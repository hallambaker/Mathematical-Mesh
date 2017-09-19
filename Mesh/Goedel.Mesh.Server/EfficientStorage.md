=An efficient persistence store

The persistence store as currently defined is problematic:

* It is not properly designed for concurrent updates

* It does not support sharding

* The memory footprint is huge - all records ever

There are two ways this could be fixed

* Use a no-sql database (e.g. MongoDB)

* Add these features to the persistence store.

If we go the second route, here are some considerations:

==Isolate entries by account

The main objection to using a package like MongoDB is that we have a degree of
trivial parallelism built into the data structures themselves. Specifically, an
operation affecting account A will never have impact on data stored in any other 
account. Unlike a transaction ledger system, we have no need to track the case of
money being deducted from A and added to B and thus any record in the system may
in principle lock any other. 

So the first thing to do is to construct BrokerIDs so that they contain a unique 
identifier for the account ID. This is straightforward. The account management part
is separate anyway and we probably never need to consider adding more than 
10K accounts per second if we go global scale. And we can easily support a million 
accounts without a global lock in the accounts system becoming an issue. Even 
when it does, we simply allocate different parts of the account number space to 
different hosts.

This means that when answering a query by BrokerID, it can be immediately routed 
to the correct responder. The BrokerID is simply an encrypted blob whose inner 
structure is { AccountID: int , TransactionID: int }

==Shard database by account

Each user should be directed to a host that supports their specific account and
has all the data local to it. Each host has a global lock for a transaction 
scoreboard which tracks which accounts are engaged in a transaction at that moment.

We use the scoreboard to monitor the time taken for each thread to complete/fail, thje
number of active threads required, etc.

==Offload data to a fixed repository on disk

At present, all data is held in memory. A much more efficient approach would be to 
keep the bulk of the data in an offline, on-disk structure and only hold updates in memory.
The offline structure would be constructed so as to permit rapid navigation using
the limited set of index terms.

To effect this, a background task would scan the persistence log and form a 
consolidated form in which all indexes used fixed length binary keys and specified 
their target using fixed file indexes.

<dt> Preamble record
   <dd> List of index tables {name, offset}
   <dd> Object table length
<dt> Index table #1
   <dd> List of index entries {key, offset}
<dt> ...
<dt> Index table #n
   <dd> List of index entries {key, offset}
<dt> Object table
   <dd> List of data objects

To quickly synchronize to an existing DB, the process simply reads the preamble record and the
incremental log.

