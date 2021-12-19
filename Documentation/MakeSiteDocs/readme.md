# Stuff to do

## Bootmaker

Need to recognize 'command' as inline emphasis style.

Need to recognize GitHub style preformatted areas.

## Documentation for meshhost / serviceadmin

Need docs for both of course.

## Missing examples in meshman reference 


Need to fix command description of nested commands...

### Account 

Missing examples

* Import/Export
* List/Status/Get
* Account recovery / purge secret
* Pin example

[All missing from reference section as well.]


### Bookmark

* Add support for Abstract/react in the code
* The delete command is really bad
* Need to actually return useful stuff in the dump dialog.
* Add device simply doesn't work.
* Add via JSON blob.

### Calendar

* The ID scheme is really not working
* Need to add labels
* Add via iCal data


### Contact 

* Need to fill in the contact exchange schemes
* Need to consider the authorization scheme

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





