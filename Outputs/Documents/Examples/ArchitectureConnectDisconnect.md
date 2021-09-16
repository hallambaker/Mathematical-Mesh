
Alice disconnects the new device:


~~~~
<div="terminal">
<cmd>Alice> device delete MDFM-UH3N-NGM3-UKTT-ZFBB-NB74-O55S
</div>
~~~~

The device can no longer access the password catalog:


~~~~
<div="terminal">
<cmd>Alice2> account sync
<rsp>ERROR - The server returned an invalid response.
<cmd>Alice2> dare decode ciphertext.dare plaintext2.txt
</div>
~~~~

The device can still decrypt data encrypted under the account encryption key however.
While a Mesh application SHOULD attempt to delete private keys after being disconnected,
such requirements cannot be enforced since the user might choose to use a non compliant
application. 

[Threshold]


[Connect/disconnect]

