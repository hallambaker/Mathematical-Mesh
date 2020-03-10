##Example: Messaging group

NB: The current code implements encryption in the Elliptic Curve Ed25519, not the Montgomery
Curve X.25519 as it should. This will be lifted in the near future.

Alice creates an encryption keypair.

~~~~
Group Key:
  51 C5 D1 84  5F C3 31 97  D3 80 2A 25  CE 7F 82 AF
  F0 30 5B 7D  52 D0 B6 CE  3C 1C 95 A0  33 CB 89 98
Value:
32231959352602868314725639964100760889451477817969178194652896778421852742616
~~~~

To verify the proper function of the group, Alice creates a test message and 
encrypts it under the group key.

~~~~
Message = This is a test as UTF8:
  54 68 69 73  20 69 73 20  61 20 74 65  73 74

[{
    "enc": "A256CBC",
    "Salt": "KDsofrPkFsnlhRsVaxPvvA",
    "recipients": [{
        "kid": "MCGR-HO5N-2FPS-VUFQ-DEKF-7TRA-JHM6",
        "epk": {
          "PublicKeyECDH": {
            "crv": "Ed25519",
            "Public": "wKdpaMbC5sF8moAusBtJlZ9XRetMzOhfb3pnW0F_uIw"}},
        "wmk": "Z0JQvs1BtVDcRDow6hDV47wPiymwn0ybJEXkteYbaSNByhLxGKf3cA"}]},
  "SUXu-b3kAgMzly2_HQZjGg"]
~~~~

Alice decides to add Bob to the group. She creates an encryption key for Bob:
The decryption key is specified in the same way as any other Ed25519 private key
using the hash of a private key seed value:

~~~~
Bob's Member Key:
  C1 3D 09 F2  D0 46 2B ED  34 43 A2 06  EB C9 C5 6D
  68 92 08 3C  31 FC E7 35  EB 3D 65 82  82 66 92 1C
Value:
39765297387767177229798479396757873493329325191929553639423911645504436683984
~~~~

The the recryption key is the group secret scalar minus  (mod p) the secret scalar of Bob's
private key:

~~~~
Bob's Service Key:
   [Not specified as a digest input value]
Value:
6940673119500215512873533693428875877836385344799439767232887009488324560610
~~~~

To decrypt:

~~~~
Member Agreement Value:
  B2 DB FC 97  A5 D9 14 FB  B9 47 85 A0  DF 74 44 31
  0B 28 64 EE  6C C3 97 BF  FA 6A 39 05  16 07 70 0F

Service Agreement Value:
  74 E2 28 0B  FF 65 50 5B  A9 10 87 14  0C C8 91 DB
  6B FE CF 82  CC C9 10 C0  0E 93 05 14  CD 81 28 39

Key Agreement IKM:
  2A 22 97 20  56 77 8D 13  F1 35 C9 5E  5A 5B 93 B0
  4A 18 D5 90  B2 C6 40 3F  9F 2A 9E 3D  9E D3 E4 49
~~~~

This value allows the test message to be decrypted.


