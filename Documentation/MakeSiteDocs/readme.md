# Make documents for the Web Site and Github

This project generates the user guide and reference manual for the meshman tool.

The output files are GitHub compatible Markdown.



# Things to fix

## Part 1: Architecture 


No information in pending!!!
Alice> device pending
Alice> device accept NDWF-RH6B-OH3E-AO4A-CNLU-7ZWJ-TOLW


5.4.1. Direct Connection
Alice2> password list
ERROR - The feature has not been implemented

5.4.2. Pin Connection
Alice3> account sync
ERROR - The feature has not been implemented

5.4.3. EARL/QR Code Connection
Alice4> device pre devices@example.com /key=udf://example.com/EDP5-KKAU-JTGJ-LDXT-4UAE-Y4A7-4QVB-C5
ERROR - Object reference not set to an instance of an object.

Alice4> account sync
ERROR - The feature has not been implemented

Alice4> account sync
ERROR - The feature has not been implemented


5.5.1. Remote

Bob> message contact alice@example.com

Alice> message pending
Alice> message accept tbs


5.6. Sharing Confidential Data in the Cloud

Alice> group create groupw@example.com
ERROR - The feature has not been implemented


5.7. Escrow and Recovery of Keys

lice> mesh escrow
ERROR - The cryptographic provider does not permit export of the private key parameters



## Part II: UDF

### Add in the new escrow scheme

## Part III DARE 

Rename Container to DARE Sequence

## Part IV Schema

Fill in text for 

3.3. Mesh Connections
3.4. Mesh Private Declarations

Mesh Messaging
[DT the following bit]

4.2.1. Creating a ProfileAccount
4.3.1. Creating a ProfileService
4.3.2. Creating a ProfileHost
4.3.3. Creating a ConnectionHost

[TBS]

5.1.2. SSH

$$$$ Empty $$$$

5.1.3. Mail

$$$$ Empty $$$$


5.3. Contact

$$$$ Empty $$$$

5.4. Credential
Formatting error

5.7. Network

$$$$ Empty $$$$


6.1. Completion

[NYI]


6.2. Connection

[NYI]


6.3. Contact

[NYI]

6.4. Confirmation

[NYI]


11. Appendix A: Example Container Organization (not normative)

Just kill

## Part V: Protocol

4.5. Error handling and response codes

Formatting

7. Container Synchronization

7.1. Status Transaction
Add example

7.2. Download Transaction
Add example

7.2.1. Conflict Detection
Move to upload!!!!

Mention use of digest values on the container.


8. Device Connection

Formatting


8.1. Device Authenticated
Add example

8.2. PIN Authenticated
Add example

8.3. EARL connection mode
Add example


9.1. Message Exchange

Figure 1 : Use existing image


9.1.2. Service-Service (Post Transaction)

This really should be a different method if not a separate protocol entirely.




