

For example, to generate saltedPIN for the pin
ADPP-WZ47-R74B-4IJV-G7QF-KLLQ-N4 used to authenticate a an action of type Device:

~~~~
pin = ADPP-WZ47-R74B-4IJV-G7QF-KLLQ-N4
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
    = ABOK-WDJO-5B67-LM6M-L73X-XGGF-7V33
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = AACH-XWVY-MKJI-JMBP-BCZR-KKB5-FO6D
~~~~

