
Alice creates an SSH profile within her Mesh on the administrative device making the 
private key information available to devices she has connected to her Mesh with the 
'web' access right.


~~~~
<div="terminal">
<cmd>Alice> ssh create /web
<rsp>Udf: MBTY-JYWG-6OLK-CVCX-2ZG4-4LEB-VCAF/n
</div>
~~~~

She can extract the private key to configure her SSH clients:


~~~~
<div="terminal">
<cmd>Alice> ssh private /file=alice1_ssh_prv.pem
</div>
~~~~

She can also extract her public key to configure her SSH server to allow access to 
the machine:


~~~~
<div="terminal">
<cmd>Alice> ssh public /file=alice1_ssh_pub.pem
</div>
~~~~

Ideally these steps would be performed on Alice's behalf by an automated script
that detects the applications Alice has installed on her device and performs the
necessary configuration on her behalf. 

The SSH keys created on one device are available to every device connected by the 'web' access 
right:


~~~~
<div="terminal">
<cmd>Alice2> account sync
<cmd>Alice2> ssh private /file=alice2_ssh_prv.pem
</div>
~~~~

