Setting up the test environment

1) Start ServerMesh

ServerMesh is the Mesh portal service. It needs to run on a machine you can 
connect to and requires the correct privileges to be configured in order
to run.

1a) To configure network privileges

netsh http add urlacl url="http://prismproof.org:80/.well-known/" user=\Everyone

Note that you may have to delete any existing urls and the interface is junk. You will
probably have issues if you are running Apache or some other Web server on the machine.


1b) To run the Server

The server is started from the command line with the following command:

servermesh <<machinename>>


For example:

servermesh mesh.prismproof.org

The server creates two log files in the directory it is run from. These have a .jlog 
extension and contain the account data that is local to the portal and the mesh data 
that will be shared with other mesh nodes in due course.

