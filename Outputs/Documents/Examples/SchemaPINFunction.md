

For example, to generate saltedPIN for the pin
AC33-KDTU-XZML-MBR6-53CC-HTM2-RU used to authenticate a an action of type Device:

~~~~
pin = AC33-KDTU-XZML-MBR6-53CC-HTM2-RU
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
    = AAUS-Y4NT-GOQP-5NEV-F3VF-PDN7-SBQK
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ABSM-QMYW-XRAL-EHUQ-NHOE-PLXO-JVC7
~~~~

