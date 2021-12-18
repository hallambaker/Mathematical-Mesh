

For example, to generate saltedPIN for the pin
AA6O-HPNP-PHTZ-7VF7-XTNB-HK3C-3M used to authenticate a an action of type Device:

~~~~
pin = AA6O-HPNP-PHTZ-7VF7-XTNB-HK3C-3M
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
    = ADAL-2LKE-TT6P-3IMM-JJ24-5LXO-W4OX
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ADF5-UQDX-6Q3T-LKTD-XBZP-FF6S-NXEK
~~~~

