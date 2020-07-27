
~~~~
<div="terminal">
<cmd>Alice> password add ftp.example.com alice1 password
<rsp>alice1@ftp.example.com = [password]
<cmd>Alice> password add www.example.com alice@example.com newpassword
<rsp>alice@example.com@www.example.com = [newpassword]
<cmd>Alice> password list
<rsp>CatalogedCredential

CatalogedCredential

<cmd>Alice> password add ftp.example.com alice1 newpassword
<rsp>alice1@ftp.example.com = [newpassword]
<cmd>Alice> password get ftp.example.com
<rsp>alice1@ftp.example.com = [newpassword]
</div>
~~~~
