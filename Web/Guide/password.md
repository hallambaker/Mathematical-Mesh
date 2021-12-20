<title>password
# Using the password Command Set

The `password` command set contains commands for managing a catalog of username 
and password entries protected by end to end encryption.

## Adding passwords

The `password add` command adds a username/password entry to the
credentials catalog associated with a profile:

Alice adds the username and password for an ftp service to her catalog:


~~~~
<div="terminal">
<cmd>Alice> meshman password add ftp.example.com alice1 password
<rsp>alice1@ftp.example.com = [password]

<cmd>Alice> meshman password add www.example.com alice@example.com ^
    newpassword
<rsp>alice@example.com@www.example.com = [newpassword]

</div>
~~~~

## Synchronizing passwords to an application.

The `password list` command lists all the passwords in the catalog:


~~~~
<div="terminal">
<cmd>Alice> meshman password list
<rsp>CatalogedCredential

CatalogedCredential

</div>
~~~~

The output of the list command may be used to configure a user application 
such as a Web browser that supports password management. But care is obviously
required as the passwords will only be as secure as the other application.

## Finding passwords

The `password get`  command retreives the username and password 
values for a specified service:


~~~~
<div="terminal">
<cmd>Alice> meshman password get ftp.example.com
<rsp>alice1@ftp.example.com = [newpassword]

</div>
~~~~

### Using Credentials in scripts

Alice can use Mesh to provide an *aide memoire* for credentials for access credentials
for sites she rarely visits. She can also use it as a tool to allow scripted access to
remote services requiring username and password authentication without putting those
credentials in the script itself.

The commands for doing this vary according to the scripting environment.

Windows

~~~~
set credential = ""
for /f "delims=" %%a in ('meshman password get ftp.example.com')^
  do @set credential=%%a
~~~~

Most Unix shells, including Bash, the following syntax may be used:

~~~~
set credential=`meshman password get ftp.example.com`
~~~~

## Updating passwords

Having automated access to the ftp site, Alice doesn't need her password to be either
memorable or conveniently short. She decides to replace her bad password with a strong
password that is randomly generated:


~~~~
<div="terminal">
<cmd>Alice> meshman password add ftp.example.com alice1 newpassword
<rsp>alice1@ftp.example.com = [newpassword]

</div>
~~~~


## Deleting passwords

Password entries may be deleted using the  `password delete` command:


~~~~
<div="terminal">
<cmd>Alice> meshman password delete www.example.com
</div>
~~~~

## Adding a Device.

When a device is added, it gets a copy of the password file:


~~~~
Missing example 23
~~~~





