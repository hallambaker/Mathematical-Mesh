Alice creates the recryption group groupw@example.com to share confidential information with
her closest friends:


~~~~
<div="terminal">
<cmd>Alice> group create groupw@example.com
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

Bob encrypts a test file but he can't decrypt it because he isn't in the group:


~~~~
<div="terminal">
<cmd>Alice> dare encode grouptext.txt /encrypt groupw@example.com /out ^
    groupsecret.dare
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~

Even though she is the group administrator, Alice can't decrypt the file either until
she adds herself to the group.


~~~~
Missing example 73
~~~~

Alice adds Bob to the group:


~~~~
Missing example 74
~~~~

Adding Bob to the group gives him immediate access to any file encrypted under
the group key without making any change to the encrypted files:


~~~~
Missing example 75
~~~~

Removing Bob from the group immediately withdraws his access.


~~~~
Missing example 76
~~~~

Bob cannot decrypt any more files (but he may have kept copies of files he decrypted 
earlier).


~~~~
Missing example 77
~~~~

