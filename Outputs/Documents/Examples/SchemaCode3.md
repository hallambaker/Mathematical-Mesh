~~~~
alg =           UdfAlg (PIN)
pinData =       UdfBDS (PIN)
saltedPINData = MAC (Action, pinData)
saltedPIN =     UDFPresent (HMAC_SHA_2_512 + saltedPINData)
PinId =         UDFPresent (MAC (Account, saltedPINData))
~~~~

The issuer of the PIN code stores the value saltedPIN for retrieval using the 
key PinId.

The witness value for a Dare Envelope with payload digest PayloadDigest 
authenticated by a PIN code whose salted value is saltedPINData, issued 
by account Account is given by PinWitness() as follows:

~~~~
witnessData =   Account.ToUTF8() + ClientNonce + PayloadDigest
witnessValue =  MAC (witnessData , saltedPINData)
~~~~
