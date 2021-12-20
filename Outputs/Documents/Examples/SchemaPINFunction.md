

For example, to generate saltedPIN for the pin
AC6L-KOKA-W62V-54R5-MU2D-KZVP-OA used to authenticate a an action of type Device:

~~~~
pin = AC6L-KOKA-W62V-54R5-MU2D-KZVP-OA
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
    = AAF5-5UQV-C4ID-P76M-SXSA-7HEU-G2F7
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = AAIH-N4XW-D6MP-LJKH-PQC7-5ETJ-TTKH
~~~~

