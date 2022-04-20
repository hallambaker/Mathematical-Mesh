<title>network
# Using the network Command Set

The `network` command set is used to manage a network configuration catalog which contains
a entries describing how to access particular networks.

## Adding networks

The `network add` command adds a simple network entry to a catalog. This is typically
a WIfi network SSID and password:


~~~~
<div="terminal">
<cmd>Alice> meshman network add mywifi wifipassword /id=NetID1
<rsp>[:mywifi/NetID1]  mywifi wifipassword
</div>
~~~~

More complicated network configurations are added using the `network import` command:


~~~~
<div="terminal">
<cmd>Alice> meshman network import NetworkEntry2.json /id=NetID2
<rsp>[WPA2:ssid/NetID2] WPA2 ssid Password
</div>
~~~~


## Finding networks

The `network get`  command retreives a network entry by label:


~~~~
<div="terminal">
<cmd>Alice> meshman network get NetID2
<rsp>
</div>
~~~~

## Deleting networks

Network entries may be deleted using the  `network delete` command:


~~~~
<div="terminal">
<cmd>Alice> meshman network delete NetID2
<rsp>[WPA2:ssid/NetID2] WPA2 ssid Password
<cmd>Alice> meshman network list
<rsp>[:myWiFi]  myWiFi securePassword
[:mywifi/NetID1]  mywifi wifipassword
</div>
~~~~

## Listing networks

A complete list of networks is obtained using the  `network list` command:


~~~~
<div="terminal">
<cmd>Alice> meshman network list
<rsp>[:myWiFi]  myWiFi securePassword
[:mywifi/NetID1]  mywifi wifipassword
[WPA2:ssid/NetID2] WPA2 ssid Password
</div>
~~~~

## Adding devices


~~~~
<div="terminal">
<cmd>Alice5> meshman network list
<rsp>ERROR - Unspecified error
</div>
~~~~

Devices are given authorization to access the networks catalog using the 
 `device auth` command:


~~~~
<div="terminal">
<cmd>Alice> meshman device auth Alice5 /all
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~


~~~~
<div="terminal">
<cmd>Alice5> meshman network list
<rsp>ERROR - Unspecified error
</div>
~~~~

