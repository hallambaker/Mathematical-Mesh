

For example, to generate saltedPIN for the pin
AAG5-W46I-6ZU6-TSRM-CY used to authenticate a an action of type Device:

~~~~
pin = AAG5-W46I-6ZU6-TSRM-CY
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
    = ABZ2-JREO-CTK2-LD5Z-EYTK-NMD4-VK44
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = AAIX-SXT3-D7VK-DMMP-HT5L-4ABG-UV6F
~~~~

