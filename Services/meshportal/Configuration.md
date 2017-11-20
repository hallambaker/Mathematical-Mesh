<h1>Configuring the server

Getting the server to run is a PITA because Windows requires the process
running a Web service to have a specific privilege assigned to it.

These are the privs that are set to enable the base server to run:

~~~~
   Reserved URL            : http://host1.prismproof.org:80/.well-known/
        User: VOODOO\hallam
            Listen: Yes
            Delegate: No
            SDDL: D:(A;;GX;;;S-1-5-21-4237498542-1133628048-3486816621-1001)

    Reserved URL            : http://mmm.prismproof.org:80/.well-known/
        User: VOODOO\hallam
            Listen: Yes
            Delegate: No
            SDDL: D:(A;;GX;;;S-1-5-21-4237498542-1133628048-3486816621-1001)
~~~~

Note that the URLACL matching rules require that a connection be rejected if more
than one rule matches. Thus having permissions for http://+:80/ in addition 
causes all requests to be rejected. Isn't that special?

