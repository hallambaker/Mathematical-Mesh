

For example, to generate saltedPIN for the pin
AD5M-D6JD-5QGC-YLLU-UM65-2NQX-4M used to authenticate a an action of type Device:

~~~~
pin = AD5M-D6JD-5QGC-YLLU-UM65-2NQX-4M
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
    = AA4V-J4PL-7ASB-KEG6-D6VI-XPUA-PRVZ
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = AALG-I44D-ELZ7-264W-OA7K-TWLC-CI74
~~~~

