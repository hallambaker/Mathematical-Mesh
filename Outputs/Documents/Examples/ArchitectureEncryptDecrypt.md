
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
        Recipient: MCGS-T6PR-YQBN-KZI6-LUQO-XIVI-OSFJ
    Digest Algorithm: S512
    Payload Digest: A2AAD60FAE2F106FB3DFE0AF2A88D7B5C2CC48FB334B9B518
121BBFCB691142E8AFBAB9479E680D598C50BFAF000B0F9B48843992FBFBE6BE837A7
7507CF0E6F
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

