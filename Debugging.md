#Useful debugging tools

To determine which IP ports are bound:



netstat -an

The URL prefixes reserved have to match those registered to the letter.


~~~~
C:\WINDOWS\system32>netsh http add urlacl "http://mmm.prismproof.org:80/.well-known/mmm/" user=voodoo\hallam

URL reservation successfully added


C:\WINDOWS\system32>netsh http add urlacl "http://host1.prismproof.org:80/.well-known/mmm/" user=voodoo\hallam

URL reservation successfully added


C:\WINDOWS\system32>netsh http add urlacl "http://host2.prismproof.org:80/.well-known/mmm/" user=voodoo\hallam

URL reservation successfully added
~~~~


~~~~
http://host1.prismproof.org/.well-known/mmm/: Add Listener on {0}
http://mmm.prismproof.org/.well-known/mmm/: Add Listener on {0}
Start Listener
Wait..
~~~~