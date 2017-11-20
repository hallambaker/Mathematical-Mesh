=Decoding data

While encoding and decoding operations are superficially symmetric, this is
not true in practice at the platform level.

When encrypting data, we may have multiple recipients and/or multiple pieces 
of data to encode. When decrypting we only care if we have at least one key
capable of decrypting the data.

When encrypting data, we only need to consider the algorithm we decide to use. 
When decrypting we need to consider all the possible choices the sender is
allowed to use.

Thus while the basic operations are indeed symmetric, the implementation of
the operations is not. There are different complications to be considered in
each case.

