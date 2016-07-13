=Mathematical Mesh Test Environment

==Step 1: Start the server

Follow the instructions in Configuration.md.

Note that only one instance of the server can run at once. If the
server won't start it is likely because a ghost process has locked 
the resource or the permissions aren't set right.

The server daemon takes one parameter, the DNS name of the service
to bind to. I have the name mesh.prismproof.org configured to 
point to my server, you will need a different one.

~~~~
servermesh mesh.prismproof.org
~~~~

==Step 2: Create a profile

While the server and the client support multiple personal profiles, 
using multiple personal profiles on the same account is not part of
the regular testing at the moment and results may be unexpected. So
it is suggested that you do this step once and leave it.


~~~~
meshman /create alice@mesh.prismproof.org
~~~~


==Step 3: Add a Web password profile

~~~~
meshman /password
~~~~

At this point you can use the /pwadd, /pwdelete and /pwdump commands to manage 
the password entries,



= Useful commands


==Command line documentation

The commands /about and /brief give details of the tool version and the supported
commands respectively.

==Reset profiles

If you want to ever reset the test environment and start from scratch,
you can delete all the profiles you have created using the reset command:

~~~~
meshman /reset
~~~~

Note that this does not reset the data on the server. To do that you need to 
stop the server, delete the .jlog files and restart it.


==List all profiles

~~~~
meshman /reset
~~~~

==Describe the current profile

~~~~
meshman /dump
~~~~
