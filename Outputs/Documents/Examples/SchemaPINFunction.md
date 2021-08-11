

For example, to generate saltedPIN for the pin
ACQM-XMGT-2VKR-NYUW-PA used to authenticate a an action of type Device:

~~~~
pin = ACQM-XMGT-2VKR-NYUW-PA
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
    = ADP5-W24H-MZH3-C5VS-WF6M-IP2N-4RVD
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = AC2O-PJSJ-SQC7-3HZ3-YZ2S-XJD3-UAPR
~~~~

