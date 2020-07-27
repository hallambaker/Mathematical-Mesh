Alice creates the recryption group groupw@example.com to share confidential information with
her closest friends:


~~~~
<div="terminal">
<cmd>Alice> group create groupw@example.com
<rsp>{
  "Key": "groupw@example.com",
  "Profile": {
    "KeyOfflineSignature": {
      "UDF": "MC7M-VCLK-M42M-AUE6-L5QT-2Z4G-QNDW",
      "PublicParameters": {
        "PublicKeyECDH": {
          "crv": "Ed448",
          "Public": "sERuuOQfOYYFTGLhPbH1NOrF2RT1hXCIveZc1Zk9NfSg45csI30V
  GEXAXZweDMfRfPFIkIEqovOA"}}},
    "KeyEncryption": {
      "UDF": "MAWX-U6RL-AMTZ-3TXN-KM7D-OOIC-YWFH",
      "PublicParameters": {
        "PublicKeyECDH": {
          "crv": "X448",
          "Public": "SW9tWFmDEfLS4KzdhojHHK2bK8uQ7D9s3K5lpnKBs8VebgKmsAr1
  orx4zpZxB-NaQCyZHUCMSpGA"}}}}}</div>
~~~~

Bob encrypts a test file but he can't decrypt it because he isn't in the group:


~~~~
<div="terminal">
<cmd>Bob> dare encodeTestFile1.txt /out=TestFile1-group.dare /encrypt=groupw@example.com
<rsp>ERROR - The command System.Object[] is not known.
<cmd>Bob> dare decode  TestFile1-group.dare
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\TestFile1-group.dare'.
</div>
~~~~

Since she is the group administrator, Alice can decrypt the
test file using the group decryption key:


~~~~
<div="terminal">
<cmd>Alice> dare decode  TestFile1-group.dare
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\TestFile1-group.dare'.
</div>
~~~~

Adding Bob to the group gives him immediate access to any file encrypted under
the group key without making any change to the encrypted files:


~~~~
<div="terminal">
<cmd>Alice> dare decode  TestFile1-group.dare
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\TestFile1-group.dare'.
</div>
~~~~

Removing Bob from the group immediately withdraws his access.


~~~~
<div="terminal">
<cmd>Alice> group delete groupw@example.com bob@example.com
<rsp>ERROR - The entry could not be found in the store.
</div>
~~~~

Bob cannot decrypt any more files (but he may have kept copies of files he decrypted 
earlier).


~~~~
<div="terminal">
<cmd>Alice> dare decode  TestFile1-group.dare
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\TestFile1-group.dare'.
</div>
~~~~

