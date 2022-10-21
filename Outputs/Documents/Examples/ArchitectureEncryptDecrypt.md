
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
        Recipient: MC7V-XVMJ-73OL-YWGL-5MIK-ROXQ-GL3Y
    Digest Algorithm: S512
    Payload Digest: 6EA307959C0C97D67F8464954CCD0E4CCEEC0EC1FF0356565
B574E9CDC49F6DD4E2FBF825E995B20DD307DDE6AE91153B3074846157F0FC8284068
4A02F3630E
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

