
~~~~
<div="terminal">
<cmd>Alice> password add ftp.example.com alice1 password
<rsp>ERROR - Cannot access a closed file.
<cmd>Alice> password add www.example.com alice@example.com newpassword
<rsp>ERROR - Cannot access a closed file.
<cmd>Alice> password list
<rsp><cmd>Alice> password add ftp.example.com alice1 newpassword
<rsp>ERROR - Cannot access a closed file.
<cmd>Alice> password get ftp.example.com
<rsp>Empty
</div>
~~~~
