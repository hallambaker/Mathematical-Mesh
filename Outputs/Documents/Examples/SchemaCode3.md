~~~~
alg = UdfAlg (PIN)
pinData = UdfBDS (PIN)
saltedPINData = MAC (Action, pinData)
saltedPIN = UDFPresent (Authenticator_HMAC_SHA_2_512 + saltedPINData)
PinId = UDFPresent (MAC (Account, saltedPINData))
witnessData = Account.ToUTF8() + ClientNonce + PayloadDigest
witnessValue =  MAC (witnessData , saltedPINData)
~~~~
