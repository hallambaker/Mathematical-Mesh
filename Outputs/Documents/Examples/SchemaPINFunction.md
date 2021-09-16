

For example, to generate saltedPIN for the pin
AAEM-BR7B-YMN6-IYVY-YC4W-PPQA-54 used to authenticate a an action of type Device:

~~~~
pin = AAEM-BR7B-YMN6-IYVY-YC4W-PPQA-54
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
    = ABNF-BPK6-A2YB-I3QH-BXR5-OB3N-TXIQ
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ABRN-CK4N-SNGX-EMP3-CMR6-WURH-RBDP
~~~~

