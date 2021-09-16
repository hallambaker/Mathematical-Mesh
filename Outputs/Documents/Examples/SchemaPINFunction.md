

For example, to generate saltedPIN for the pin
AB52-2EXC-Z4YS-XQ2B-3PQS-KDLU-5E used to authenticate a an action of type Device:

~~~~
pin = AB52-2EXC-Z4YS-XQ2B-3PQS-KDLU-5E
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
    = ACL7-NU5B-SW6O-PTCB-EYFF-BWBU-UEPN
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = AAT4-OPCO-C4OF-MNZO-D7NT-CYDX-L7OU
~~~~

