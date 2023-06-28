
Alice creates an SSH profile within her Mesh on the administrative device making the 
private key information available to devices she has connected to her Mesh with the 
'web' access right.


~~~~
<div="terminal">
<cmd>Alice> meshman ssh create /web /threshold /id=ssh
<rsp>UDF: MAOY-3KTL-BIW6-BS7V-EANA-AZTL-5Q2Y
</div>
~~~~

She can extract the private key to configure her SSH clients:


~~~~
<div="terminal">
<cmd>Alice> meshman ssh get ssh /private /file=alice1_ssh_prv.pem
</div>
~~~~

She can also extract her public key to configure her SSH server to allow access to 
the machine:


~~~~
<div="terminal">
<cmd>Alice> meshman ssh get ssh /file=alice1_ssh_pub.pem
</div>
~~~~

Ideally these steps would be performed on Alice's behalf by an automated script
that detects the applications Alice has installed on her device and performs the
necessary configuration on her behalf. 

The SSH keys created on one device are available to every device connected by the 'web' access 
right:


~~~~
<div="terminal">
<cmd>Alice2> meshman account sync
<cmd>Alice2> meshman ssh get ssh /private /file=alice2_ssh_prv.pem
</div>
~~~~

