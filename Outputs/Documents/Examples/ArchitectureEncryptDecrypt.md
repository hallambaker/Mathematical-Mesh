
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
        Recipient: MDP5-GPL7-OVDS-KREF-2KCY-JC7P-KSHY
    Digest Algorithm: S512
    Payload Digest: 13E6F329A1E2051342F03C766C9FE41AE0531A089C40B2497
B06B953FFB999F4E977E7237D09B58A9CA26F6DEC7BA0D279B476FB2B987BA158F94D
66E8194FE7
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

