

For example, to generate saltedPIN for the pin
ABUT-CB72-7OD7-RCTA-ZKQK-HTBK-QI used to authenticate a an action of type Device:

~~~~
pin = ABUT-CB72-7OD7-RCTA-ZKQK-HTBK-QI
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
    = ABQX-3YEF-U6BP-OZNP-5YEY-TMND-EEXP
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = AC6S-3D4T-4NGR-4NWU-NWIA-SDKK-MEAI
~~~~

