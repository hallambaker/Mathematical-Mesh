

For example, to generate saltedPIN for the pin
ACOX-HK6J-HHBF-47KK-M4 used to authenticate a an action of type Device:

~~~~
pin = ACOX-HK6J-HHBF-47KK-M4
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
    = ACU4-IFOZ-UFDV-HZI5-I2B6-ZWHL-2WVH
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = AB6F-KUZD-SMSF-4CHD-63T4-BNVW-LGFK
~~~~

