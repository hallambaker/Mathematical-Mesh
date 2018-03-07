<h1>Object Model

The object model supported by the persistence store is deliberately limited.

Each object instance has a globally unique object identifier that is constant 
for the life of the object

An object instance is created with the 'New' event at which point it is given
an initial value.

After creation, the value of the object instance may be modified at any time 
by an 'Update' event or erased by a 'Delete' event. Once the object instance is
deleted, no further update events are possible. 

The lifecycle of an object instance is thus described by the following trace:

~~~~
New → Update* → Delete 
~~~~

An object instance is described by the following metadata values that MUST stay
constant for the life of the object:

* Unique ID

* IANA Content Type 

* Creation DateTime (optional)

An object instance value is described by the following metadata values. Different
object instance values MAY have different values for thes metadata items.

<dt> Event
<dd> The event that cause the creation of the entry. This MUST be one of
New, Update or Delete.

<dt> Labels
<dd> A set of string values that describe the object instance value

<dt> Key/Value pairs
<dd> A set of string keys that map to a set of string values describing the 
object instance value


