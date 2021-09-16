

For example, to generate saltedPIN for the pin
AC65-2CFF-LYWI-2NHU-TI used to authenticate a an action of type Device:

~~~~
pin = AC65-2CFF-LYWI-2NHU-TI
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
    = AANJ-3XGI-Y7FD-343G-56GO-SBNN-NPSH
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ACPI-UKHK-GN4I-AYC4-E3DB-KVMX-TTGH
~~~~

