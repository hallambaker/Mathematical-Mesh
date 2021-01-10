
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
        Recipient: MC2R-Y263-JNCD-S337-WMP5-NRZH-OZN7
    Digest Algorithm: S512
    Payload Digest: AAA2F8E6BD79C386364A42A01E88E3C66D3D25B304424DC06
602201E6B2EC23DDDCC7C3D493E4E3F27E20A55C689A2AB6E6320D5E56E859CCDECF3
6D259294F0
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

