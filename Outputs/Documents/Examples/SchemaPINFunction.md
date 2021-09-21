

For example, to generate saltedPIN for the pin
ABCA-P2J7-3NE5-EIWH-YUUP-F7PA-JM used to authenticate a an action of type Device:

~~~~
pin = ABCA-P2J7-3NE5-EIWH-YUUP-F7PA-JM
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
    = AC7J-WKPX-QWLV-DNXN-UDEF-HMDN-4L5T
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ABFH-NOPL-EPQ7-Y6VG-TKTI-5ZUM-CTBU
~~~~

