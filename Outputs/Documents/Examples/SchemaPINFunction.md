

For example, to generate saltedPIN for the pin
AAJP-KPYV-NSB4-GIYL-AM used to authenticate a an action of type Device:

~~~~
pin = AAJP-KPYV-NSB4-GIYL-AM
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
    = ADBB-JTKR-RGGL-ACEM-TW6E-ZFY6-NQXF
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ADVR-47UA-ZHDX-6CFS-GDDD-RYTA-LSB6
~~~~

