

# Create a service

~~~~
serviceadmin create MeshProvider example.com /host=host1.example.com /ip=108.20.156.67 /admin=admin@example.com
~~~~

Locate the config files

~~~~
serviceadmin locate MeshProvider
~~~~

Create a DNS configuration

~~~~
serviceadmin dns MeshProvider
~~~~


Install the DNS configuration on a DNS service. This is of course something we 
would like to automate in the future.


~~~~
[Probably stick this on Orac]
~~~~









## Issues 

1) Need some feedback after creating a new service

2) Need to default to writing the service config to the roaming profile?

3) Add a 'where' option to find config file

4) Make sure test data does not stomp on persistence stores.

5) Make loging default, grant admin access

6) Need to set up bind resolver on local machine



# start the host


~~~~
meshhost MeshProvider /console
~~~~


Look at the log file [different window]

~~~~
Format-Hex [log file]
~~~~

# Use the admin account


Read the log

~~~~
meshman dump [log file]
~~~~

Synchronize

~~~~
meshman sync
~~~~

Look at the log file [different window]

~~~~
Format-Hex [log file]
~~~~


# Create a user account for Alice


~~~~
ssh [same machine]
alice

meshman create alice@example.com 
~~~~

Encrypt a word document

Decrypt a word document

Add a password

Dump the password


# Add a device


Decrypt a word document

Dump the password


# Create an SSH profile


[This is only proof of concept so far]

Use on device 1

Use on Device 2





# Group encryption

Create a group 'W'

Encrypt a word document

Decrypt a word document [fail]




Add Alice to the group


Decrypt a word document





# Create an account for Bob

~~~~
meshman create bob@example.com 
~~~~

Decrypt a word document [fail]



Send a contact request

Accept at Alice


Accept at Bob



Add Bob to the group


Decrypt a word document

