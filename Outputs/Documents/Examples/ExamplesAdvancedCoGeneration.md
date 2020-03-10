##Example: Provisioning the Confirmation Service

For example, Alice provisions the confirmation service to her watch. The device profile
of the watch specifies an Ed25519 signature key. Note that for production use, Ed448 is
almost certainly prefered but Ed25519 has the advantage of more compact presentation.

~~~~
Device Key

UDF Seed:       ZAAA-G4F5-G34W-HHLC-24AP-SZKI-VGO7-UHI
Private Key:
  B7 48 FF 8A  1B D2 04 BC  BA 53 70 80  91 66 08 8E
  26 15 B5 52  ED C9 C4 CE  80 D7 75 A6  BD A9 4A 1C
Secret Scalar:
56125651237600354228798699639619403779855821496596976661382393571903134631504
Public Key:
  2B B3 8F D1  93 16 E1 5E  24 44 BA 82  9F 4A D3 7D
  F6 7F B5 A0  92 65 A1 7B  F4 8C B6 51  6D F3 9F DC
Fingerprint:    MANZ-N7DM-BYZH-EQIO-E7YL-C6SX-GONP
~~~~

The provisioning device could generate a signature key for the device and encrypt it
under the encryption key of the device. But this means that we cannot attribute signatures
to the watch with absolute certainty as the provisioning device has had knowledge of the 
watch signature key. Nor do we wish to use the device signature key for the confirmation
service.

Instead, the provisioning device generates an overlay keypair:

~~~~
Device Key

UDF Seed:       ZAAA-HIGJ-GGBY-NTBF-YS2T-ABNO-4WT2-SIY
Private Key:
  F9 44 69 38  A7 E2 52 A1  F6 1D 9D 9B  29 D1 5D 52
  77 23 26 0C  AF F3 14 A6  4E 95 CB 76  5B 24 B1 67
Secret Scalar:
49437431830830005043554286843388551057265319605872247754572631754571997461496
Public Key:
  C7 EF 8B 19  BE D9 E7 F7  45 17 73 8E  B3 92 6E 86
  C2 0F A4 06  84 58 BF 3B  FE EE 87 A5  B8 EB 62 0A
Fingerprint:    MBQO-UETO-EL5H-EQBI-PM4Y-QOE7-E6PH
~~~~

The provisioning device can calculate the public key of the composite keypair
by adding the public keys of the device profile and the companion public key:

~~~~
Composite public key = Device + Overlay:
  0A FD 34 5B  D7 49 47 BF  C3 CC 2E 4B  AB A6 BF FE
  E1 7A B1 3C  74 C6 49 EE  04 9C FF C0  4B D3 05 F6
Fingerprint:    MBAK-3KK5-F3AN-E6AJ-EIIT-IIL6-7KTP
~~~~

The provisioning device encrypts the private key of the comanion keypair (or the seed from which it
was generated) under the encryption key of the device. 

The provisioning device calculates the private key of the composite keypair by 
adding the two private key values modulo the order of the group and verifies that scalar 
multiplication of the base point returns the composite public key value.

~~~~
Composite Secret Scalar = Device + Overlay:
3696218815216775247999600833593893946854897602495339232735523069524455498173
Fingerprint:    MBAK-3KK5-F3AN-E6AJ-EIIT-IIL6-7KTP
~~~~


