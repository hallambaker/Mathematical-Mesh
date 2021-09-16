

For example, to generate saltedPIN for the pin
ABOD-YUZY-JRGD-M27U-UM used to authenticate a an action of type Device:

~~~~
pin = ABOD-YUZY-JRGD-M27U-UM
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
    = ABN6-O3O3-FWJ3-42NH-BQEX-ATKD-PRKB
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = AC7K-A7LV-FTI4-VINB-J3IR-B2BA-LTV5
~~~~

