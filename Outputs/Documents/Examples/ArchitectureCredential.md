
Alice adds the username and password she uses to access her weather service account 
to her credentials catalog:


~~~~
<div="terminal">
<cmd>Alice> password add ftp.example.com alice1 password
<rsp>alice1@ftp.example.com = [password]
<cmd>Alice> password add www.example.com alice@example.com newpassword
<rsp>alice@example.com@www.example.com = [newpassword]
</div>
~~~~

As with all Mesh Catalogs, the catalog data is encrypted and cannot be accessed by any unauthorized
party including the Mesh Service Provider.

If needed, she can retrieve the credentials from the catalog by specifying the network
resource to which access is required:


~~~~
<div="terminal">
<cmd>Alice> password get ftp.example.com
<rsp>alice1@ftp.example.com = [password]
</div>
~~~~

This capability provides a means of preventing one of the most common causes of enterprise password
breach in which a system administrator encodes the access credentials for a service into a 
script used to access the service. A script containing a command to extract the credentials from
a Mesh catalog will only work for a user authorized to access the credentials in the Mesh.

