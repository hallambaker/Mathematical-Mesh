# Stuff to do

## Bootmaker

Need to recognize 'command' as inline emphasis style.

Need to recognize GitHub style preformatted areas.

Need to fix the formatting of commands to wrap really long commands (e.g. recovery)


## Documentation for meshhost / serviceadmin

Need docs for both of course.

## Missing examples in meshman reference 


Need to fix command description of nested commands...


## Errors

* Pending messages not being correctly filtered

* Incorrect/insufficient data returned by commands

* Account status does not report the apex hash for the catalogs or inbound spool

* Should autosync


### Key

ConsoleExample (ShellDare.DareEarl);
Alice> meshman dare earl TestFile1.txt example.com
ERROR - An unknown error occurred


ConsoleExample (ShellKey.KeyShare3);
Alice> meshman key share 5QXJ-EEOG-DBDE-TEEU-AOYJ-PGZA-4U
ERROR - Attempted to divide by zero.

## Hash - Good
## Dare 

ConsoleExample (ShellDare.DareSymmetric);

Alice> meshman dare encode TestFile1.txt ^
    /out=TestFile1.txt.symmetric.dare ^
    /key=5QXJ-EEOG-DBDE-TEEU-AOYJ-PGZA-4U
ERROR - The option System.Object[] is not known.

ConsoleExample (ShellDare.DareSub);
Alice> meshman dare encode TestDir1 ^
    /encrypt=5QXJ-EEOG-DBDE-TEEU-AOYJ-PGZA-4U
ERROR - No encryption key is available

ConsoleExample (ShellDare.DareEarl);
Alice> meshman dare decode TestFile1.txt.dare
ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Te
stFile1.txt.dare'.

ConsoleExample (ShellDare.DareEARLLog);
Alice> meshman dare decode TestFile1.txt.symmetric.dare ^
    /encrypt=5QXJ-EEOG-DBDE-TEEU-AOYJ-PGZA-4U
ERROR - The option System.Object[] is not known.

ConsoleExample (ShellDare.DareEARLLogNew);
Alice> meshman dare decode TestFile1.txt.mesh.dare
ERROR - No decryption key is available

ConsoleExample (ShellSequence.SequenceArchive);
Alice> meshman dare archive SequenceArchive.dcon TestDir1
ERROR - Path cannot be null. (Parameter 'path')

ConsoleExample (ShellSequence.SequenceArchiveEnhance);
Alice> meshman dare archive SequenceArchiveEncrypt.dcon TestDir1 ^
    /encrypt=groupw@example.com /sign=alice@example.com
ERROR - Path cannot be null. (Parameter 'path')

ConsoleExample (ShellSequence.SequenceArchiveVerify);
Alice> meshman dare verify SequenceArchiveEncrypt.dcon
ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Se
quenceArchiveEncrypt.dcon'.

ConsoleExample (ShellSequence.SequenceArchiveExtractAll);
[Lacks demonstration of success]

ConsoleExample (ShellSequence.SequenceArchiveExtractFile);
Alice> meshman dare extract Sequence.dcon /file=TestDir1\TestFile4.txt
ERROR - The file was not found.

ConsoleExample (ShellSequence.SequenceAppend);
[Lacks demonstration of success]

ConsoleExample (ShellSequence.SequenceDelete);
[Lacks demonstration of success]

ConsoleExample (ShellSequence.SequenceIndex);
[Lacks demonstration of success]

ConsoleExample (ShellSequence.SequenceArchiveCopy);
Alice> meshman dare copy Sequence2.dcon
ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Se
quence2.dcon'.

ConsoleExample (ShellSequence.SequenceArchiveCopyDecrypt);
Alice> meshman dare copy SequenceArchiveEncrypt.dcon /decrypt
ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Se
quenceArchiveEncrypt.dcon'.

ConsoleExample (ShellSequence.SequenceArchiveCopyPurge);
Alice> meshman dare copy Sequence2.dcon /purge
ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Se
quence2.dcon'.

[Reference sections also missing.]

### Account

ConsoleExample (Account.ListGetAccountAlice);
[Not implemented]

Alice2> meshman account recover /verify
ERROR - The feature has not been implemented

Alice> meshman account purge MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
ERROR - An unknown error occurred

ConsoleExample (Account.Export);
ERROR - The feature has not been implemented

ConsoleExample (Account.Import);
ERROR - The feature has not been implemented

ConsoleExample (Connect.ConnectStaticClaim);
[Not implemented]
[Lacks demonstration of success]

[Reference sections also missing.]

### Device 

ConsoleExample (Connect.ConnectReject);
Missing example 1
This is currently disabled because it is failing due to the pending messages bug.

ConsoleExample (Connect.ConnectList);
Alice> meshman device list
The `device delete` command removes a device from the catalog:

ConsoleExample (Connect.ConnectDelete);
Alice> meshman device delete
ERROR - Value cannot be null. (Parameter 'key')

 ConsoleExample (Connect.ConnectPINPending);
 [Need proof Alice 3 connected]


ConnectStaticPollFail is failing hard internally
Missing example 2

ConsoleExample (Connect.ConnectJoinPinCreate);
[Not implemented]
ConsoleExample (Connect.ConnectJoin);
[Not implemented]
ConsoleExample (Connect.ConnectJoinPending);
[Not implemented]
ConsoleExample (Connect.ConnectJoinComplete);
[Not implemented]
ConsoleExample (Connect.ConnectJoinAuth);
[Not implemented]


### Message

Pending messages are not being filtered to remove read messages. This is also causing 
fails on the automatic execution side.

ConsoleExample (ShellMessage.ContactPending);
Purge read messages

ConsoleExample (ShellMessage.ContactCatalogList);
Strange output
Repeatred group W entries 

ConsoleExample (ShellMessage.ContactGetResponse);
[Wrong !]

ConsoleExample (ShellMessage.ContactReject);
[Message Ids not working right]

ConsoleExample (ShellMessage.ContactBlock);
[Not implemented]
[No feedback]


ConsoleExample (ShellMessage.ConfirmAccept);
[Bjorked by unread pending messages]

ConsoleExample (ShellMessage.ConfirmGetAccept);
[Also message ids issue]

ConsoleExample (ShellMessage.ConfirmReject);
[Not implemented]

ConsoleExample (ShellMessage.ConfirmGetReject);
[Ditto]

[Consider reworking this part to make the Mallet narrative flow from 
message request, reject, block, request fails]

### Contact 

* The JSON contact is not filled in or shown in the example.

ConsoleExample (Connect.ConnectJoinAuth );
Alice> meshman device auth Alice5 /all
ERROR - The option System.Object[] is not known.
Not implemented


### Bookmark

* Add support for Abstract/react in the code
* The delete command is really bad
* Need to actually return useful stuff in the dump dialog.
* Add device simply doesn't work.
* Add via JSON blob.


### Password

* The password list information is pretty poor.

ConsoleExample (ShellPassword.PasswordUpdate);
[Feedback]


### Calendar

* The ID scheme is really not working
* Need to add labels
* Add via iCal data
* Add by command line!

### Network

[make the id handling consistent!!!]

Alice> meshman network import NetworkEntry2.json /id=NetID2
[Not implemented]

Alice> meshman network list
[Insufficient data]


# Prior stuff - check if fixed!


## Bug fixes

* Make handling of newlines after shell results consistent.


# Phase 1 Drafts

## draft-hallambaker-mesh-architecture-19

* Spurious newlines in examples due to inconsistent handling of newlines in result prep.

* message pending - remove read messages from message pending.
* 4.3.1. Contact exchange spurious entry already exists in store error.

>>>> Unfinished ArchitectureRecovery 

## draft-hallambaker-mesh-dare-14

Signing sequences of envelopes (with Callsign / notarization)

Make use of SHA-3 KMAC as KDF (also for UDF??)

3.6.1. Field: kwd. Add KMAC as KDF

RFCTOOL has issues with use of italics and subscripts? Terminating subscript 
seems to stop italic handling working.

## draft-hallambaker-mesh-schema-09

Remaining issues are all connected to future work on notary/callsign/etc.

## draft-hallambaker-mesh-protocol-11

6.2. Account Management

RecoverAccount - provide description

6.2.2. Unbind Account
6.2.3. Account Recovery and Transfer.

Add examples.

6.3.1. Status

Bug in the status operation. Does not return digests for catalogs.

[Need to cross reference sections in SCHEMA where the account connection, 
device connection request etc. are described.

6.6. Cryptographic

Need to explain that the service account encryption key is now specified 
by the host during connection. Also need to document that structure.

6.7.2. Outbound Service

Need to better explain post method not implemented.

7. Access Control

This is unfinished.

8.2. Completion Interaction

Missing example!

Probably somethingt to do with why message read status is not being tracked.


8.4. Group Invitation

Missing example!





# Additional drafts

## draft-hallambaker-threshold-07

Needs extensive work to fill in sections marked TBS.

Need to sync up with FROST.

## draft-hallambaker-mesh-developer-11

Completely out of date. Move stuff into Platform

## draft-hallambaker-mesh-platform-07

Not really started.



## RFCTool

* Centering of images

* combine TXT and SVG versions





