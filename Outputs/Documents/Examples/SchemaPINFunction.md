

For example, to generate saltedPIN for the pin
ABNT-NYMS-CWFX-HKC7-M5NF-A7P5-LI used to authenticate a an action of type Device:

~~~~
pin = ABNT-NYMS-CWFX-HKC7-M5NF-A7P5-LI
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
    = AAUY-PCOU-GPBI-3PTC-YW6C-GMJ7-B7GF
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ADS3-DGAE-37FR-X6YK-TPB7-TJYM-5PRV
~~~~

