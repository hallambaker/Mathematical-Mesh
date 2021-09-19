

For example, to generate saltedPIN for the pin
AB2H-VRFJ-XANZ-JPXG-UIBC-5CGN-3Q used to authenticate a an action of type Device:

~~~~
pin = AB2H-VRFJ-XANZ-JPXG-UIBC-5CGN-3Q
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
    = AA57-FIMW-AKOY-MFB3-OTHO-2TQN-HLRZ
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ACUW-OQFE-CZPR-RUCT-3KGS-OJPB-HK7X
~~~~

