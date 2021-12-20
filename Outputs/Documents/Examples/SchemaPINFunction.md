

For example, to generate saltedPIN for the pin
ABHT-VP25-WUQY-ZNTF-CJ4F-5AWU-ZA used to authenticate a an action of type Device:

~~~~
pin = ABHT-VP25-WUQY-ZNTF-CJ4F-5AWU-ZA
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
    = ACFR-GQFO-ORQH-GZJL-Z6HK-UGBU-Z5DZ
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = AD7H-TUMR-MFYW-HVZU-EZDH-XDE7-LNSG
~~~~

