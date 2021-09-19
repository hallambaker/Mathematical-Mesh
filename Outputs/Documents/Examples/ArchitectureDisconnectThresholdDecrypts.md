
The third device was connected with threshold rights, it is disconnected in the same
way as before.


~~~~
<div="terminal">
<cmd>Alice> device delete MD73-BYDQ-RHKR-XGQ6-MLM2-36E7-ZHSI
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


