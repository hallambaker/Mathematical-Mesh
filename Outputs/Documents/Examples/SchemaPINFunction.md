

For example, to generate saltedPIN for the pin
AAIT-WXRD-BVB7-3BBT-D6JS-44GE-B4 used to authenticate a an action of type Device:

~~~~
pin = AAIT-WXRD-BVB7-3BBT-D6JS-44GE-B4
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
    = ADGS-TMEV-G2MR-2NPD-ZJO3-NH2F-363W
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = AD3I-LNZ6-JCHV-UYO6-JDRO-GPQG-R2VC
~~~~

