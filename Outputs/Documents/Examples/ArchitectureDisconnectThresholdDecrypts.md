
The third device was connected with threshold rights, it is disconnected in the same
way as before.


~~~~
<div="terminal">
<cmd>Alice> meshman device delete MDEH-DBMY-63NX-TNKW-NRWT-ON6M-EOMJ
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

The device can no longer access the password catalog or decrypt files:


~~~~
<div="terminal">
<cmd>Alice3> meshman account sync
<rsp>ERROR - The server returned an invalid response.
<cmd>Alice3> meshman dare decode ciphertext.dare plaintext3.txt
<rsp>ERROR - A cryptographic operation was refused.
</div>
~~~~


