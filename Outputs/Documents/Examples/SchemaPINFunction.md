

For example, to generate saltedPIN for the pin
ADCA-JUQP-AWFS-SDGL-6EUP-DCK6-HY used to authenticate a an action of type Device:

~~~~
pin = ADCA-JUQP-AWFS-SDGL-6EUP-DCK6-HY
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
    = ABSR-KCDG-7PWS-XGJF-WNG7-2T4Y-ARQV
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ACO2-35DS-S7ZO-27ZO-HC6F-JYPM-L4L4
~~~~

