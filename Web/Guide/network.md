
# Using the `network` Command Set

The `network` command set is used to manage a network configuration catalog which contains
a entries describing how to access particular networks.

## Adding networks

The `network add` command adds a network entry to a catalog:


````
Alice> network add NetworkEntry1.json NetID1
{
  "Key": "NetID1"}Alice> network add NetworkEntry2.json NetID2
{
  "Key": "NetID2"}````


## Finding networks

The `network get`  command retreives a network entry by label:


````
Alice> network get NetID2
{
  "Key": "NetID2"}````

## Deleting networks

Network entries may be deleted using the  `network delete` command:


````
Alice> network delete NetID2
{
  "Key": "NetID2"}Alice> network list
ERROR - The command  is not known.
````

## Listing networks

A complete list of networks is obtained using the  `network list` command:


````
Alice> network list
ERROR - The command  is not known.
````

## Adding devices

Devices are given authorization to access the networks catalog using the 
 `device auth` command:

 %  ConsoleExample (Examples.NetworkAuth);


