

For example, to generate saltedPIN for the pin
ACFR-G2S3-K6IF-TBUA-6U used to authenticate a an action of type Device:

~~~~
pin = ACFR-G2S3-K6IF-TBUA-6U
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
    = AASJ-7OXP-TMIO-63ZC-Z7IE-PGIR-TPXX
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = AB4H-QW4H-27MS-RC4O-662X-VWXI-NZXT
~~~~

