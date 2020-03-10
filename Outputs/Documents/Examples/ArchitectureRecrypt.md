Alice creates the recryption group groupw@example.com to share confidential information with
her closest friends:


~~~~
<div="terminal">
<cmd>Alice> group create groupw@example.com
<rsp>{
  "Profile": {
    "KeyOfflineSignature": {
      "UDF": "MCJ5-HMK2-SUBS-MOCG-J5IS-S2GT-IY7D",
      "PublicParameters": {
        "PublicKeyECDH": {
          "crv": "Ed448",
          "Public": "bNfUzYfsJJthhioeCukz03BQ9wJWD-2i_0GoDznzdhqEu8eE9iVo
  VAJDOF2gDnMxvkfnBsJk55GA"}}},
    "KeyEncryption": {
      "UDF": "MC25-LCSY-DUTQ-YBUL-XXCI-RLIZ-JHIL",
      "PublicParameters": {
        "PublicKeyECDH": {
          "crv": "Ed448",
          "Public": "sx8WWkgH6k4u8RchFZitCRTvncvWje1xog-cyx4kka9kwmFwlDTi
  t2JXFFalq-LJ-RQlu9eIuP-A"}}}}}</div>
~~~~

Bob encrypts a test file but he can't decrypt it because he isn't in the group:


~~~~
<div="terminal">
<cmd>Bob> dare encodeTestFile1.txt /out=TestFile1-group.dare /encrypt=groupw@example.com
<rsp>ERROR - The command  is not known.
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
<rsp>ERROR - The feature has not been implemented
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

