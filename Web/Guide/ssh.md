<title>SSH
# Using the SSH Command Set

The SSH command set contains commands that 

SSH is one of the most successful applications that provides strong cryptographic
protections today. It is certainly the first and so far only cryptographic application
to become so ubiquitous as to replace its insecure predecessor (telnet). 

Despite this success, SSH can be tricky to deploy and not through any fault of the 
design of the application. Configuring SSH access to a machine that you are accessing
via SSH is an inherently tricky task: Any error in the configuration may render the 
machine unavailable.

Another major weakness in the use of SSH is that following best practices for key
management such as using a different authentication key on each client device is
tedious at best. Most worrying of all is the fact that much of the advice given on
'how to configure SSH' is written from the perspective of <i>how to get SSH to work<i>
rather than <i>how to make an SSH configuration secure<i>.

Most people who use SSH reguilarly have developed a set of scripts to perform routine
administrative tasks. But while writing a script is a trivial task, debugging and 
checking for security vulnerabilities is certainly not.

Transferring configuration and administration tasks to the Mesh provides an approach
that is considerably more robust than a shell script is likely to provide and is 
far more likely to attract the third party review necessary to build confidence in
its security.

Since SSH authentication is bidirectional, an SSH profile is used to manage two separate
sets of public keys.

* Client Authentication keys

* Host Authentication keys

Client Authentication public keypairs are used to authenticate a client to a host. 
These are the keys whose private components are stored in user local storage and 
whose public components appear in generate the <tt>authorized_keys</tt> file.

Host Authentication keypairs are used to authenticate a host to a client. These are 
keys whose private components are stored in a system wide storage and whose public 
components appear in the <tt>known_hosts</tt> file.



## Creating an SSH profile

The `ssh create` command adds an SSH profile named `ssh` to a Mesh account:


~~~~
<div="terminal">
<cmd>Alice> meshman ssh create /web /threshold /id=ssh
<rsp>UDF: MDV7-NN5K-SHF5-T3XS-EL5J-WXEO-YJPJ
</div>
~~~~

Since the command creates a new application catalog entry, the command must be given to 
an administration device.

## Client Configuration

Adding an SSH profile causes a public keypair to be created for use with SSH. To make use 
of this keypair for device authentication with legacy applications typically requires the
public and/or private keys to be extracted in a format supported by the application.

The `ssh public` command extracts the public key required top configure
an SSH client:


~~~~
<div="terminal">
<cmd>Alice> meshman ssh get ssh /file=alice1_ssh_pub.pem
</div>
~~~~

The `ssh private` command extracts the private key required top configure
an SSH client:


~~~~
<div="terminal">
<cmd>Alice> meshman ssh get ssh /private /file=alice1_ssh_prv.pem
</div>
~~~~

If a script is being used to automate this process, the best practice is for the
script to first generate a random nonce and request that the private key file
be extracted encrypted under the nonce which can be discarded after the key is
successfully installed. [Not currently supported.]

The `ssh list` command lists the authorized 
clients keys in the profile. This may be used to generate the `authorized_keys` file 
by specifying the SSH file format used by the particular SSH application in use.

Individual client entries may be added using the `ssh client` command
which imports a client entry from a file in the specified format.

[Not yet implemented, assume file format from extension/well known names.]


~~~~
<div="terminal">
<cmd>Alice> meshman ssh client ssh_config.json /id=work
<rsp>[CatalogedApplicationSsh]

</div>
~~~~

This command may be used to add SSH client public keys to the profile without adding
the private key. This provides a means of adding a legacy key that is not under Mesh control
to a Mesh profile. Attempts to access the public key work as normal:


~~~~
<div="terminal">
<cmd>Alice> meshman ssh get work /file=alice1_ssh_pub2.pem /format=pem
</div>
~~~~

Attempts to access the private key fail:


~~~~
<div="terminal">
<cmd>Alice> meshman ssh get work /private /file=alice1_ssh_prv_3.pem
<rsp>ERROR - The feature has not been implemented
</div>
~~~~


Client configurations may be deleted using the `ssh delete` command


~~~~
<div="terminal">
<cmd>Alice> meshman ssh delete work
<rsp>[CatalogedApplicationSsh]

<cmd>Alice> meshman ssh list
<rsp>UDF: MDV7-NN5K-SHF5-T3XS-EL5J-WXEO-YJPJ
</div>
~~~~


## Host Configuration

Host configuration is not currently supported but is an obvious feature to add once
support is introduced for SSH certificates.


## Managing Host Credentials

The `ssh host` command is used to add known hosts to the Mesh credential 
catalog.


~~~~
<div="terminal">
<cmd>Alice> meshman ssh host ssh_host1.json
<rsp>ssh:alice42@ssh1.example.com = []

</div>
~~~~


The `ssh konwn`  command lists the known host keys 
in the profile. This information is stored in the credential catalog and may also be 
retrieved through the password commands.


~~~~
<div="terminal">
<cmd>Alice> meshman ssh known
<rsp>ssh:alice42@ssh1.example.com = []

</div>
~~~~

The `ssh known`  command with a specified host returns the SSH parameters 
for a particular known host:


~~~~
<div="terminal">
<cmd>Alice> meshman ssh known ssh1.example.com
<rsp>ssh:alice42@ssh1.example.com = []

</div>
~~~~


