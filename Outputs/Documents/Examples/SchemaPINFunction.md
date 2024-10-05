

For example, to generate saltedPIN for the pin
AA34-4UB6-2FPH-KPT6-JNTU-PNWR-MU used to authenticate a an action of type Device:

~~~~
pin = AA34-4UB6-2FPH-KPT6-JNTU-PNWR-MU
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
    = ABZB-VOOM-JCF6-24PM-4NM5-U3HL-S3P2
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = AC5Q-A2U3-LPVY-DHRL-BZYF-RPQD-EWKE
~~~~

