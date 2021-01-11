

For example, to generate saltedPIN for the pin
AAI6-EZFH-RZFI-2AHG-MI used to authenticate a Device action:

~~~~
pin = AAI6-EZFH-RZFI-2AHG-MI
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
    = AATY-GTQC-5K65-M7XM-LUUD-SL5K-JLCR
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ACPX-YZYD-SAG6-2HX3-7VGJ-XZCN-JSGX
~~~~

