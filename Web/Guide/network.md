<title>network
# Using the network Command Set

The `network` command set is used to manage a network configuration catalog which contains
a entries describing how to access particular networks.

## Adding networks

The `network add` command adds a network entry to a catalog:


~~~~
<div="terminal">
<cmd>Alice> network add NetworkEntry1.json NetID1
<rsp>ERROR - Cannot access a closed file.
<cmd>Alice> network add NetworkEntry2.json NetID2
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~


## Finding networks

The `network get`  command retreives a network entry by label:


~~~~
<div="terminal">
<cmd>Alice> network get NetID2
<rsp>Empty
</div>
~~~~

## Deleting networks

Network entries may be deleted using the  `network delete` command:


~~~~
<div="terminal">
<cmd>Alice> network delete NetID2
<rsp>ERROR - The entry could not be found in the store.
<cmd>Alice> network list
<rsp>Entry<CatalogedContact>: MCAP-Q4KN-WUUZ-PAAK-AB6K-5JVV-AKRD
  Person MCAP-Q4KN-WUUZ-PAAK-AB6K-5JVV-AKRD
  Anchor MCAP-Q4KN-WUUZ-PAAK-AB6K-5JVV-AKRD
  Address alice@example.com

</div>
~~~~

## Listing networks

A complete list of networks is obtained using the  `network list` command:


~~~~
<div="terminal">
<cmd>Alice> network list
<rsp>Entry<CatalogedContact>: MCAP-Q4KN-WUUZ-PAAK-AB6K-5JVV-AKRD
  Person MCAP-Q4KN-WUUZ-PAAK-AB6K-5JVV-AKRD
  Anchor MCAP-Q4KN-WUUZ-PAAK-AB6K-5JVV-AKRD
  Address alice@example.com

</div>
~~~~

## Adding devices

Devices are given authorization to access the networks catalog using the 
 `device auth` command:

 %  ConsoleExample (Examples.NetworkAuth);


