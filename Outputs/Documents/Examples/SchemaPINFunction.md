

For example, to generate saltedPIN for the pin
AC23-KHLF-VHYV-MQXF-3PM2-WZRM-TU used to authenticate a an action of type Device:

~~~~
pin = AC23-KHLF-VHYV-MQXF-3PM2-WZRM-TU
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
    = ABXS-QM2B-QTN6-5CN3-UJ7E-5TN3-RGDR
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ACQC-PPVT-LTYX-HID5-GYVZ-G4NF-EA4S
~~~~

