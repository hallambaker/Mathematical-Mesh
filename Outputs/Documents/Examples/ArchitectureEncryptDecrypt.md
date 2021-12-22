
Alice encrypts the text file plaintext.txt to create an encrypted version
readable only by Alice:


~~~~
<div="terminal">
<cmd>Alice> meshman type plaintext.txt
<rsp>This is a test
<cmd>Alice> meshman dare encode plaintext.txt ciphertext.dare /encrypt ^
    alice@example.com 
<cmd>Alice> meshman dare verify ciphertext.dare
<rsp>File: ciphertext.dare
    Bytes: 16
    Encryption Algorithm: A256CBC
        Recipient: MDRQ-KSVX-EF4Z-REJR-NSE2-5LNW-DDHY
    Digest Algorithm: S512
    Payload Digest: 9178ED9EA5ECA6FB3AED16AE759F3D1C7CB8B206E0F9EE874
82100A462FDE80694B76211818F599E225EDDC126700DCEEB4B6DF6834F45F50B4B3C
22220290B0
</div>
~~~~

Alice can recover the file at any time using the decryption command:


~~~~
<div="terminal">
<cmd>Alice> meshman dare decode ciphertext.dare plaintext1.txt
<cmd>Alice> meshman type plaintext1.txt
<rsp>This is a test
</div>
~~~~

Although the encrypted file can be accessed by Alice with precisely the same ease as the plaintext
version, the contents of the encrypted file are not readable by any other user of the machine unless 
Alice explicitly grants access. The encrypted file may be stored on a shared drive, cloud file system
or removable storage without disclosing the contents.

