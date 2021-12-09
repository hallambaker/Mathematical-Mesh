
The device can no longer access the password catalog, but it can still decrypt files:


~~~~
<div="terminal">
<cmd>Alice2> meshman account sync
<rsp>ERROR - The server returned an invalid response.
<cmd>Alice2> meshman dare decode ciphertext.dare plaintext3.txt
<cmd>Alice2> meshman type plaintext3.txt
<rsp>This is a test
</div>
~~~~

