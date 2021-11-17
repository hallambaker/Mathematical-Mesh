

For example, to generate saltedPIN for the pin
ABQR-GO5I-FPIE-TK5O-M4VU-DALE-WM used to authenticate a an action of type Device:

~~~~
pin = ABQR-GO5I-FPIE-TK5O-M4VU-DALE-WM
action = message.

alg = UdfAlg (PIN)
    = Authenticator_HMAC_SHA_2_512

hashalg = default (alg, HMAC_SHA_2_512)

pinData = UdfBDS (PIN)
    = System.Byte[]

saltedPINData 
    = hashalg(pinData, hashalg);
    = System.Byte[]

saltedPIN = UDFPresent (hashalg + saltedPINData)
    = ADL6-MGFR-DK2V-XMCH-Y4VK-FG4R-AIDL
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ACEE-R3XJ-23LL-A562-JOYB-UXNX-W6VO
~~~~

