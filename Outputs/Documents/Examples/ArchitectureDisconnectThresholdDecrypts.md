
The third device was connected with threshold rights, it is disconnected in the same
way as before.


~~~~
<div="terminal">
<cmd>Alice> device delete MAM5-JIA7-DSS2-HXXB-63TD-RDS5-U4XN
</div>
~~~~

The device can no longer access the password catalog or decrypt files:


~~~~
<div="terminal">
<cmd>Alice3> account sync
<rsp>ERROR - The server returned an invalid response.
<cmd>Alice3> dare decode ciphertext.dare plaintext3.txt
<rsp>ERROR - A requested cryptographic operation failed.
</div>
~~~~


