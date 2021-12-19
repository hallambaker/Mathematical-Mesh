
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
        Recipient: MB3Y-65NW-JLNN-IFIC-SYTO-5WY3-SCR3
    Digest Algorithm: S512
    Payload Digest: 4AA768480B412500BA39C09D97B7949E32F4A3FFFD316FCE6
AE89237206111AB0F5E3BEC9D02E411E72E503FFBD8BC02C68D71482124EE5B28F53C
4CF23D6386
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

