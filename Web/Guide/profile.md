<title>profile
# Using the profile Command Set

The `profile` command set contains commands used to create and manage
Mesh profiles.


## Contacting a Mesh Service

The `profile hello` command contacts a Mesh service and returns
a description of the service parameters.


~~~~
<div="terminal">
<cmd>Alice> account hello alice@example.com
<rsp>MeshService 3.0
   Service UDF = MCUD-TPYU-KHKX-2IMU-V7LO-ZFFR-LLMO
   Host UDF = MDQC-MWVF-5OEG-5LZ2-MY67-KMBP-B6OY
</div>
~~~~

If a Mesh account is specified, the tool attempts to connect to a Mesh service
at the associated domain. It is not necessary for the account to be registered
at the service when the request is made.

## Creating a profile

To begin using the Mesh, it is necessary for the user to create a Mesh profile.
This includes the steps of:

* Create a Master profile.

* Create a Mesh Account

* Create a Mesh profile and make the current device an administrator.

* Register the Mesh profile with a Mesh service.

The `profile create` command creates a profile:


~~~~
<div="terminal">
<cmd>Alice> mesh create
<rsp>Device Profile UDF=MA6N-3GFW-6HDE-VA4U-ZCL4-RRXH-OEHK
Personal Profile UDF=MA5E-Q7B3-SQ5O-6OS2-WBTJ-BFVE-I3S3
</div>
~~~~




## Listing profiles installed on a machine

The `profile list` command lists all the profiles available on the 
machine:


~~~~
<div="terminal">
<cmd>Alice> mesh list
<rsp></div>
~~~~

The `profile dump` command provides a more detailed description of 
a profile:


~~~~
<div="terminal">
<cmd>Alice> mesh get
<rsp></div>
~~~~

## Escrowing Profile Master Keys

The more reliance that a user puts on a cryptographic infrastructure, the more 
serious the consequences of the loss of the encryption and authentication keys.
As the recent episode of 'ransomware' attacks demonstrates, for most users, the
very worst security compromise that could affect them is the loss of the
pictures of their children when they were five years old.

The `profile ` command escrows the signature and encryption keys
of the user's master profile and returns a set of recovery shares. 


~~~~
<div="terminal">
<cmd>Alice> mesh escrow
<rsp>ERROR - The cryptographic provider does not permit export of the private key parameters
</div>
~~~~

By default, three recovery shares are created such that two shares are required to
recover the master keys.

Recovery of the master keys is performed by the `profile recover`
command.


~~~~
<div="terminal">
<cmd>Alice> mesh recover $TBS $TBS /verify
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

The `/verify` flag causes the tool to check that the keys can be correctly recovered
without actually installing on the machine.


## Direct profile management

A Mesh profile may be exported as a file using the `profile ` command:


~~~~
<div="terminal">
<cmd>Alice> mesh export profile.dare
<rsp></div>
~~~~

The `profile ` profile can then be used to import the file on another 
machine:


~~~~
<div="terminal">
<cmd>Alice4> mesh import profile.dare
<rsp></div>
~~~~

