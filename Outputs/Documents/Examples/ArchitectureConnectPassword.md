
For example, Alice can now decrypt the file she encrypted on her first device and access her 
credential catalog from the new device:


~~~~
<div="terminal">
<cmd>Alice2> password get ftp.example.com
<rsp>ERROR - No decryption key is available
<cmd>Alice2> dare decode ciphertext.dare plaintext2.txt
<rsp>ERROR - No decryption key is available
</div>
~~~~

