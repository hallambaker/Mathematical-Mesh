

For example, to generate saltedPIN for the pin
ADFR-TEQU-3HJD-IRND-P4TS-CRBD-NI used to authenticate a an action of type Device:

~~~~
pin = ADFR-TEQU-3HJD-IRND-P4TS-CRBD-NI
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
    = AAV6-EBKF-JIUO-B2UV-UQX7-OKHB-OAAX
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ADDU-7BE6-DN7R-U2BB-VST6-DYZL-YEZR
~~~~

