

For example, to generate saltedPIN for the pin
AASP-5A76-VKQO-CZZF-SQ6R-DQUU-2A used to authenticate a an action of type Device:

~~~~
pin = AASP-5A76-VKQO-CZZF-SQ6R-DQUU-2A
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
    = AAI7-MJRN-N4VL-OA4S-MGHR-IYJH-PWXM
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ACYR-7PUU-JQ63-7GJC-K4LB-6LFR-TGTU
~~~~

