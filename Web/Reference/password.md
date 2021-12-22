

# password

~~~~
<div="helptext">
<over>
password    Manage password catalogs connected to an account
    add   Add password entry
    delete   Delete password entry
    get   Lookup password entry
    list   List password entries
<over>
</div>
~~~~


# password add

~~~~
<div="helptext">
<over>
add   Add password entry
       The site(s) at which the password is to be used.
       The username
       The password
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'password add' command is used to add credential entries to the catalog.


~~~~
<div="terminal">
<cmd>Alice> meshman password add ftp.example.com alice1 password
<rsp>alice1@ftp.example.com = [password]

</div>
~~~~



# password delete

~~~~
<div="helptext">
<over>
delete   Delete password entry
       Domain name of Web site
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'password delete' command deletes a credential entry by means of the site identifier.


~~~~
<div="terminal">
<cmd>Alice> meshman password delete www.example.com
<rsp></div>
~~~~




# password get

~~~~
<div="helptext">
<over>
get   Lookup password entry
       The site name
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'password get' command retrieves a credential entry  by means of the site identifier.


~~~~
<div="terminal">
<cmd>Alice> meshman password get ftp.example.com
<rsp>alice1@ftp.example.com = [newpassword]

</div>
~~~~




# password list

~~~~
<div="helptext">
<over>
list   List password entries
       The site or sites to return.
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'password list' command lists all data in the credential catalog.


~~~~
<div="terminal">
<cmd>Alice> meshman password list
<rsp>CatalogedCredential

CatalogedCredential

</div>
~~~~




