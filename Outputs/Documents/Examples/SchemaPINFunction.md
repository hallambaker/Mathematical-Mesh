

For example, to generate saltedPIN for the pin
ADE7-U5DR-2YNJ-XKVX-4RUE-SVL5-5I used to authenticate a an action of type Device:

~~~~
pin = ADE7-U5DR-2YNJ-XKVX-4RUE-SVL5-5I
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
    = ABYY-PTS3-HOUO-E3VH-TOCJ-GFJI-XPHS
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ACMS-5CGG-NMBJ-JOPG-MALJ-ZPSP-GDLS
~~~~

