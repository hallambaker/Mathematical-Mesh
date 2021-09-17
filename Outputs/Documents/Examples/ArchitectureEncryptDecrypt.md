
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
        Recipient: MA27-7XVW-GDJL-SY6H-6HZW-EKMC-TFD3
    Digest Algorithm: S512
    Payload Digest: 0AEBDCB57CC001C47E154A8D35CE36B67366186F116F70B83
95AC3EF93983D9DB92CA5CF1B2B5618275625AE0A7826108F303B3E9A7170C791F353
701AD05B1D
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

