
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
        Recipient: MBUF-P7S2-WFEF-D3ML-OKCC-XYOT-6SLD
    Digest Algorithm: S512
    Payload Digest: 0F80F0A764D7A6F4AF97738E39FDD2ACD4F46D3FFEA567FFE
3DB2EE2A586E4D1F3D4158EEB6451FE39477A58ECADB8FA4FAC7D76FAA29AE811CC16
0E4F50B4AB
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

