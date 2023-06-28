

For example, to generate saltedPIN for the pin
AAKI-IIAD-GQ3H-JUY3-SXZN-PENW-PQ used to authenticate a an action of type Device:

~~~~
pin = AAKI-IIAD-GQ3H-JUY3-SXZN-PENW-PQ
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
    = AA6H-GDQF-3QDF-B7MB-GBAO-RJ4O-ZTPI
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ACVB-JSGA-EUN7-QIGS-XYWQ-G3OU-77IZ
~~~~

