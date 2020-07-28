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
   Service UDF = MD3E-TZGL-T2KW-XPUT-NLED-JPRG-AGLU
   Host UDF = MCBZ-6BPF-XG3U-DPBF-5CUW-ERYV-EDYS
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
<rsp>Device Profile UDF=MC7B-CDOG-VA7F-TCBO-4JCY-QC6F-2F5A
Personal Profile UDF=MCOZ-GIZ3-34VQ-GQ6J-FCS7-BJIU-JCOY
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

**Missing Example***

By default, three recovery shares are created such that two shares are required to
recover the master keys.

Recovery of the master keys is performed by the `profile recover`
command.

**Missing Example***

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

