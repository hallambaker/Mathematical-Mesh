# Make documents for the Web Site and Github

This project generates the user guide and reference manual for the meshman tool.

The output files are GitHub compatible Markdown.



# Things to fix

## Part 1: Architecture 



5.4.1. Direct Connection


````
Alice2> device request alice@example.com
   Witness value = NGPY-QAYV-OCQD-W6JD-U3HP-3OAQ-57OW
   Personal Mesh = MCSC-2POG-PH7T-ODJX-HOCA-B4XY-AFSK
````


No information in pending!!!
````
Alice> device pending
Alice> device accept NCPO-L452-CMZY-MLQO-TM52-KQYW-EFGP
````

Connected device does not get access to the new info:

````
Alice2> password list
ERROR - Object reference not set to an instance of an object.
````

````
Alice2> password list
ERROR - The feature has not been implemented
````


5.4.2. Pin Connection


Should report the devices that were automatically connected.
````
Alice> device pending
````

````
Alice3> account sync
ERROR - Object reference not set to an instance of an object.
````


5.4.3. EARL/QR Code Connection

````
Alice4> device pre devices@example.com /key=udf://example.com/EDP5-KKAU-JTGJ-LDXT-4UAE-Y4A7-4QVB-C5
ERROR - Object reference not set to an instance of an object.
````

````
Alice4> account sync
ERROR - Object reference not set to an instance of an object.
````

````
Alice> device earl udf://example.com/EC4X-PWKB-JNOA-FRW7-DBBT-ZAYU-3E
    VA-FR
ERROR - Object reference not set to an instance of an object.
````

````
Alice4> account sync
ERROR - Object reference not set to an instance of an object.
````

5.5.1. Remote

Need some report back here:

````
Bob> message contact alice@example.com
````

Implement message pending for the contact messages:
````
Alice> message pending
Alice> message accept tbs
````

Should add some treatment of what Bob does at the other end.


5.6. Sharing Confidential Data in the Cloud

Seems like we are oversharing here:

````
Alice> group create groupw@example.com
{
  "Profile": {
    "KeyOfflineSignature": {
      "UDF": "MB2A-I332-A75U-OHD7-WLHR-XRZK-CLRU",
      "PublicParameters": {
        "PublicKeyECDH": {
          "crv": "Ed448",
          "Public": "V9z0yscYdi-vi2cqWrehpdZhy45EjB-AIaXWC7iIVtmHckZA
              xSlK
  pDd-vDVDwBgF50egU0gEvMUA"}}},
    "KeyEncryption": {
      "UDF": "MB2W-EYG3-EFXZ-QGEL-BCFJ-BA76-IF6H",
      "PublicParameters": {
        "PublicKeyECDH": {
          "crv": "Ed448",
          "Public": "8XTv_F07n1odENFoyPvc8gXF95iZoOp1sLZ3HeO4jwxy42Qe
              TfE8
  2HtQWT59vPV5X8uSg0iKdloA"}}}}}
````

````
Bob> dare encodeTestFile1.txt /out=TestFile1-group.dare /encrypt=grou
    pw@example.com
ERROR - The command  is not known.
Bob> dare decode  TestFile1-group.dare
ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Te
    stFile1-group.dare'.
````

````
Alice> dare decode  TestFile1-group.dare
ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Te
    stFile1-group.dare'.
````

````
Alice> group delete groupw@example.com bob@example.com
ERROR - The feature has not been implemented
````

````
Alice> dare decode  TestFile1-group.dare
ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Te
    stFile1-group.dare'.
````


## Part II: UDF

### Add in the new escrow scheme

## Part III DARE 


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




