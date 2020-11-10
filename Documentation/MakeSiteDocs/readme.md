# Stuff to do

## RFCTool

* Titles are missing from all figures

* Centering of images

* combine TXT and SVG versions


* Scaling of the QR code

# Nits

## Alice> dare verify ciphertext.dare

The number of bytes and the payload digest fields are not being populated in the response.




# Errors

## Alice> account sync /auto

ERROR - Cannot access a closed file.
Alice> device accept RQUH-LNHP-XVR6-UHQ5-WSCZ-WCZC-Q5PK
ERROR - Cannot access a closed file

## device complete

Gives no report on outcome [pending / accepted / refused]

## Alice2> password get ftp.example.com

ERROR - No decryption key is available
Alice2> dare decode ciphertext.dare plaintext2.txt
ERROR - No decryption key is available

## Alice> device delete TBS

ERROR - The feature has not been implemented


## Alice2> dare decode ciphertext.dare plaintext2.txt

ERROR - No decryption key is available


## Create SSH profile....


## Alice> message accept NBKU-OVBZ-YZRN-FEB4-ARMW-VUVI-2JSG

ERROR - Cannot access a closed file.


## Alice> message accept NBAC-LLBY-E4EU-7ZRF-I47O-ZYHZ-PBCW

ERROR - The specified message could not be found.


## Alice> $message status {confirmResponseID}

ERROR - The command System.Object[] is not known.

## Alice> group create groupw@example.com
ERROR - Cannot access a closed file.


## Alice2> account recover /verify
ERROR - Expected {





# Current bugs to chase

* Connected Devices not being properly provisioned with keys for account

* The Context user is being disposed - stop this.

* Messages can't be feched by envelope ID, confusion envelope vs message IDs here

# Functionality to add

## message pending - selectors to get unread or raw reports.

Should introduce new interogator for the spool class (and catalog???)



# need to sort out the weirdness caused by not adding Transaction names to the TagDirectories.


