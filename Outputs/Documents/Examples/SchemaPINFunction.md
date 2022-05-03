

For example, to generate saltedPIN for the pin
ADKW-K2ZB-PPZM-ECG4-P3NQ-UN4K-XI used to authenticate a an action of type Device:

~~~~
pin = ADKW-K2ZB-PPZM-ECG4-P3NQ-UN4K-XI
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
    = AA3X-AOXG-CTAE-HAQ3-EDP7-PSLZ-CIHS
~~~~

The PinId binding the pin to the account alice@example.com is

~~~~
Account =  alice@example.com 

PinId = UDFPresent (MAC (Account, saltedPINData))
    = ACRN-XIMG-4ZH6-MTNS-JCXH-6CGM-X7UA
~~~~

