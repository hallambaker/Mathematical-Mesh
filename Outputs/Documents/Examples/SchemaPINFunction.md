

For example, to generate saltedPIN for the pin
AB23-ZBOI-CEIZ-MTD4-VQ used to authenticate a an action of type Device:

~~~~
pin = AB23-ZBOI-CEIZ-MTD4-VQ
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
    = AANT-HAQW-KDUY-GUMW-YFY2-YWB5-23YC
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ABVQ-HJHJ-UUIJ-SLQE-KMK4-XUVP-DTVG
~~~~

