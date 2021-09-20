

For example, to generate saltedPIN for the pin
ABYY-TYLH-XENK-57RH-6PMF-MAE2-JU used to authenticate a an action of type Device:

~~~~
pin = ABYY-TYLH-XENK-57RH-6PMF-MAE2-JU
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
    = ACZI-EF2U-AAIY-R5MY-KXZ6-UYAF-NUSV
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ABWR-ZWRY-BSYG-E7CC-CZPG-ILGO-PBB7
~~~~

