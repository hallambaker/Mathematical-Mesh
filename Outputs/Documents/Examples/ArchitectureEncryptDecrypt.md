
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
        Recipient: MDO5-NHXU-6OBX-AVZV-EST7-3Y3A-H6VV
    Digest Algorithm: S512
    Payload Digest: 6F4F54F0DEF3913E1DAF20CFD542BA95CEA9142CBEE1DC7C2
3FE54E51E324BCC2206EA54F48C3B981E121000400308EE92DA7DF0E820FBB298F47A
96C7AE3029
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

