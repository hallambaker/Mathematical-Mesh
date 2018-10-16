import os
import binascii
import eddsa


from eddsa import Ed448

SecretKey = binascii.unhexlify ("6c82a562cb808d10d632be89c8513ebf" +"6c929f34ddfa8c9f63c9960ef6e348a3" +"528c8a3fcc2f044e39a3fc5b94492f8f" +"032e7549a20098f95b")
PublicKey =binascii.unhexlify ("5fd7449b59b461fd2ce787ec616ad46a" +"1da1342485a70e1f8a0ea75d80e96778" +"edf124769b46c7061bd6783df1e50f6c" +"d1fa1abeafe8256180")
privkey,pubkey = eddsa.Ed448.keygen(SecretKey)
Message =  binascii.unhexlify ("")

signature =  eddsa.Ed448.sign(privkey, pubkey, Message)
print ( binascii.b2a_hex(signature))

assert  eddsa.Ed448.verify(pubkey, Message, signature)





#SecretKey = binascii.unhexlify ("c5aa8df43f9f837bedb7442f31dcb7b1" +"66d38535076f094b85ce3a2e0b4458f7")
#PublicKey =binascii.unhexlify ("fc51cd8e6218a1a38da47ed00230f058" +"0816ed13ba3303ac5deb911548908025")


#privkey,pubkey = eddsa.Ed25519.keygen(SecretKey)
#signature =  eddsa.Ed25519.sign(privkey, pubkey, Message)
#print ( binascii.b2a_hex(signature))

#assert  eddsa.Ed25519.verify(pubkey, Message, signature)



#print ( binascii.b2a_hex(pubkey))

