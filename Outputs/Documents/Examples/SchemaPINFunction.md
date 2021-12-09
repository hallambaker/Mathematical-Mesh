

For example, to generate saltedPIN for the pin
ADKG-ALMU-VUHY-A54X-EWZC-FV3S-KY used to authenticate a an action of type Device:

~~~~
pin = ADKG-ALMU-VUHY-A54X-EWZC-FV3S-KY
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
    = AACW-GWRM-PPBY-MKRO-Y7O7-SMUF-ENO2
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ABXS-LMUP-4IHG-EPIY-XRZI-HLPE-SOW4
~~~~

