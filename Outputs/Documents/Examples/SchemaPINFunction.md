

For example, to generate saltedPIN for the pin
ABZQ-GFJC-V7RM-XIXD-DL7B-AVGD-54 used to authenticate a an action of type Device:

~~~~
pin = ABZQ-GFJC-V7RM-XIXD-DL7B-AVGD-54
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
    = AASM-IAYF-UHGF-4NNI-YCAY-7MP5-YNBG
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ACBY-OOS4-VEN7-APBW-2WK3-3WU3-PMD6
~~~~

