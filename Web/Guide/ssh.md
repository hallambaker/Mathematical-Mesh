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

<dl>
<dt>Client Authentication keys</dt>
<dd>Public keypairs used to authenticate a client to a host. These are the keys whose
private components are stored in user local storage and whose public components 
appear in generate the <tt>authorized_keys</tt> file.</dd>
<dt>Host Authentication keys</dt>
<dd>Public keypairs used to authenticate a host to a client. These are keys whose
private components are stored in a system wide storage and whose public components
appear in the <tt>known_hosts</tt> file.</dd>
</dl>


## Creating an SSH profile

The `ssh create` command adds an SSH profile named `ssh` to a Mesh account:


~~~~
<div="terminal">
<cmd>Alice> meshman ssh create /web
<rsp>UDF: MDDO-QOQ3-U6RO-HNBP-DCQX-S74X-MY27
</div>
~~~~

Since the command creates a new application catalog, the command must be given to 
an administration device.

## Client Configuration

Adding an SSH profile causes a public keypair to be created for use with SSH. To make use 
of this keypair for device authentication with legacy applications typically requires the
public and/or private keys to be extracted in a format supported by the application.

The `ssh private` command extracts the private key required top configure
an SSH client:


~~~~
<div="terminal">
<cmd>Alice> meshman ssh private /file=alice1_ssh_prv.pem
</div>
~~~~

The `ssh public` command extracts the public key required top configure
an SSH client:


~~~~
<div="terminal">
<cmd>Alice> meshman ssh public /file=alice1_ssh_pub.pem
</div>
~~~~

If a script is being used to automate this process, the best practice is for the
script to first generate a random nonce and request that the private key file
be extracted encrypted under the nonce which can be discarded after the key is
successfully installed. [Not currently supported.]

## Configuring authentication entries on hosts and clients

The `ssh merge client`  command is run on a host to update mesh key entries 
in the `authorized_keys` file using information from the specified mesh portal.

For example, if the `authorized_keys` file has an entry for Alice's Mesh profile
(`alice@example.com.mm--ssss`), the corresponding profile is fetched and the 
corresponding SSH device public keys added:


~~~~
<div="terminal">
<cmd>Alice2> meshman ssh merge client
<rsp>ERROR - TBS
</div>
~~~~

The `ssh merge host`  command reads the `known_hosts` file on a client machine and adds
the listed hosts to the user's ssh catalog.


~~~~
<div="terminal">
<cmd>Alice2> meshman ssh merge hosts
<rsp>ERROR - TBS
</div>
~~~~

## Client Key management

SSH keys belonging to the user that are not part of the Mesh profile may be added using the 
`ssh import`  command.



~~~~
<div="terminal">
<cmd>Alice> meshman ssh import
<rsp>ERROR - TBS
</div>
~~~~


~~~~
<div="terminal">
<cmd>Alice> meshman ssh add client
<rsp>ERROR - An unknown error occurred
</div>
~~~~


~~~~
<div="terminal">
<cmd>Alice> meshman ssh get
<rsp>ERROR - TBS
</div>
~~~~



The list of known clients may be returned in various formats using the `ssh show client`  command.


~~~~
<div="terminal">
<cmd>Alice> meshman ssh import
<rsp>ERROR - TBS
</div>
~~~~


~~~~
<div="terminal">
<cmd>Alice> meshman ssh delete
<rsp>ERROR - TBS
</div>
~~~~


~~~~
<div="terminal">
<cmd>Alice2> meshman ssh merge client
<rsp>ERROR - TBS
</div>
~~~~


## Host Key Management

The `ssh add host`  command adds specific host entries to the user's SSH profile.


~~~~
<div="terminal">
<cmd>Alice> meshman ssh add host
<rsp>ERROR - TBS
</div>
~~~~

The current list of known hosts in the SSH catalog is returned by the `ssh show known` 
command.


~~~~
<div="terminal">
<cmd>Alice> meshman ssh list /hosts
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~


~~~~
<div="terminal">
<cmd>Alice2> meshman ssh merge hosts
<rsp>ERROR - TBS
</div>
~~~~


## Additional Devices

Whenever an SSH profile is created, a separate keypair is created for every device
connected to the profile. This mitigates the consequences of a device being lost
or stolen. The device key for the compromised device can be removed from the 
profile without affecting any other device. Investigation of possibly unauthorized logins
can be focused on those from the compromised device alone.

The `device auth /ssh`  command is used *from an administration device* to 
enable use of ssh on the machine:


~~~~
<div="terminal">
<cmd>Alice> meshman device auth Alice5 /ssh
</div>
~~~~

Once the device has been authorized, the client machine can start using SSH immediately:


~~~~
<div="terminal">
<cmd>Alice5> meshman openpgp sign alice@example.net ^
    /file=alice1_opgp_sign.pem
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

