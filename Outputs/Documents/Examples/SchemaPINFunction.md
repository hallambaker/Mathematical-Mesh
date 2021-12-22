

For example, to generate saltedPIN for the pin
AAGV-IFMG-7JH7-VLYL-3PEB-PU4S-4E used to authenticate a an action of type Device:

~~~~
pin = AAGV-IFMG-7JH7-VLYL-3PEB-PU4S-4E
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
    = ACTB-LHXX-4JUE-E6OR-AC6U-MKZX-XVUW
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ADSO-6OAE-UFNZ-PCD5-LIFH-UDBK-HPLM
~~~~

