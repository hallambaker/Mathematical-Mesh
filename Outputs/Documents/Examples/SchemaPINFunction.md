

For example, to generate saltedPIN for the pin
ABMQ-PEXV-4NWU-VZ6Y-GV7N-QESY-AI used to authenticate a an action of type Device:

~~~~
pin = ABMQ-PEXV-4NWU-VZ6Y-GV7N-QESY-AI
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
    = ACFQ-PVTL-H5SU-C5EH-N7MA-KJ6O-6KTS
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ABWS-3OFG-S5T4-NW7Z-A3WH-H7PE-HB6J
~~~~

