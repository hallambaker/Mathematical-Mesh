
Alice disconnects the new device:


~~~~
<div="terminal">
<cmd>Alice> device delete MC2E-CN5B-VD4E-WYKC-PRQJ-GYP7-3HJS
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

