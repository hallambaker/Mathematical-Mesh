
Alice encrypts the text file plaintext.txt to create an encrypted version
readable only by Alice:


~~~~
<div="terminal">
<cmd>Alice> type plaintext.txt
<rsp>This is a test
<cmd>Alice> dare encode plaintext.txt ciphertext.dare /encrypt ^
    alice@example.com 
<cmd>Alice> dare verify ciphertext.dare
<rsp>File: ciphertext.dare
    Bytes: 16
    Encryption Algorithm: A256CBC
        Recipient: MDQY-J72A-VPAO-WDOD-GYY7-4ZZ5-PLVL
    Digest Algorithm: S512
    Payload Digest: 5E4B7C65F97D17B998B292CA5DDDED2904E9BF047928A374A
D12118FD2DD32779AB27CC7CDEDBD0B7559D94E610678BEBE65E71B989919DA5ECFB8
C43A6B7154
</div>
~~~~

Alice can recover the file at any time using the decryption command:


~~~~
<div="terminal">
<cmd>Alice> dare decode ciphertext.dare plaintext1.txt
<cmd>Alice> type plaintext1.txt
<rsp>This is a test
</div>
~~~~

Although the encrypted file can be accessed by Alice with precisely the same ease as the plaintext
version, the contents of the encrypted file are not readable by any other user of the machine unless 
Alice explicitly grants access. The encrypted file may be stored on a shared drive, cloud file system
or removable storage without disclosing the contents.

