
Alice disconnects the new device:


~~~~
<div="terminal">
<cmd>Alice> device delete TBS
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

The device can no longer access the password catalog:


~~~~
<div="terminal">
<cmd>Alice2> dare decode ciphertext.dare plaintext2.txt
<rsp>ERROR - No decryption key is available
</div>
~~~~


