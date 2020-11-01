# Stuff to do

## RFCTool


* Wrap bigintegers, etc. at 72 cols. - DO THIS NEXT!!!

* Work out cause of extra trailing space after examples.

* Centering of images

* combine TXT and SVG versions

* Scaling of the QR code



* check wrapping of JSON dumps

* fix wrapping of commands to be more intelligent

## unfinished business

### ProtocolHelloRequest

Don't have the protocol HTTP binding:


### Decryption of catalog on connected devices

Not granting access to the catalogs as should happen. Possibly because we are not granting web rights.


### Confirm verify not implemented

Also need to spit out the message id of the confirmation request and the
details.

### Account sync explanation is bogus

Sync only pulls data from the service. There is no separate status upload/download scheme.

### File encryption examples

Need mechanism to display contents of the file in examples. Both the
plaintext and summary of the siphertext envelope.

###Create Group 

Should just dump the group fingerprint, not the profile.

### Escrow/Recover

Recovery is failing for some reason. Need to specify the account ???

### EARL

The URI version of the EARL is not being shown. Possibly due to the 
QR not being generated.

### Hello Result

Need to extend hello result to populate the service profile. And every response to
include the host profile.

### Create Account

The Connected device field is not being populated.

#% DescribeMessage (Connect.ConnectPINCompleteWitness);
QR = {Connect.ConnectQRURI}
#% DescribeMessage (Connect.ConnectRequestPIN);
#% DescribeMessage (Connect.AcknowledgeConnectionPIN);
#% DescribeMessage (Connect.RespondConnectionPIN);
#% DescribeMessage (Contact.BobRequest);
#% DescribeMessage (Contact.AliceResponse);
#% DescribeMessage (Confirm.RequestConfirmation);
#% DescribeMessage (Confirm.ResponseConfirmation);


# Current bugs to chase

* Connected Devices not being properly provisioned with keys for account

* The Context user is being disposed - stop this.

* Messages can't be feched by envelope ID, confusion envelope vs message IDs here

# Functionality to add

## message pending - selectors to get unread or raw reports.

Should introduce new interogator for the spool class (and catalog???)



# need to sort out the weirdness caused by not adding Transaction names to the TagDirectories.


