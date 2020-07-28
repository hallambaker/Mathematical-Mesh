<title>key
# Using the key Command Set

The `key` command set contains commands that operate on cryptographic secrets and
nonces.

## Generating Secrets and Nonces

Secrets and nonces both consist of a randomly generated sequence of bits. The
only distinction made between a secret and a nonce is the uses that may be 
made of them. For example, a secret value must not be passed in clear text in 
any circumstances. The visual distinction between these uses afforded by UDF 
presentation aids application debugging and audit.

The `key nonce` command is used to generate a new random nonce value:


~~~~
<div="terminal">
<cmd>Alice> key nonce
<rsp>NC6S-4P32-DN6X-X5XT-7FGG-R6ZJ-FPFA
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> key nonce /bits=256
<rsp>NAYG-H57P-E4LH-C3BL-5BB2-VAVR-5TA7-OPNR-RHDF-DIIU-QBKS-6OD4-5DCP-S
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> key secret
<rsp>ECBV-NNU4-LJVA-PZM3-J66J-EMQR-PRBQ
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> key secret /bits=256
<rsp>ECSF-3JCD-BHOT-YNR2-W37O-ERWG-MKVK-55DY-BH5W-FHMJ-SNHJ-4XPD-IC6O-G
</div>
~~~~

## Generating EARL values

An Encrypted Authenticated Resource locator is a form of URI that specifies 
a means of locating and decrypting content stored on a remote Web service.

The EARL itself specifies a domain name and a secret. The content is stored
on the Web Service under a label that is the Content Digest of the secret.

EARLs may be generated using the `key earl` command to generate
a new secret/digest pair which are then used to process the content data:


~~~~
<div="terminal">
<cmd>Alice> key earl
<rsp>EBEW-QNOT-6ACF-6KW3-4DRD-HTZW-G3ZD-JS
MCYP-CCPS-7JOG-NCPS-OQNC-6YXS-IJFK-VQ4S-F7KY-BPHI-FHEX-MDAU-SGD3-FUEH
</div>
~~~~

Alternatively, the `dare earl` command may be used to perform both operations:


~~~~
<div="terminal">
<cmd>Alice> dare earl TestFile1.txt example.net
<rsp>ERROR - Unspecified error
</div>
~~~~

## Sharing and recovering secrets

Secret sharing splits a secret into a set of shares such that the original
secret can be recovered from a chosen number of shares called the quorum.

The `key share` command creates a secret and splits it into the specified
number of shares with the specified quorum for recovery. By default, a 128
bit secret is created and three shares are created with a quorum of two:


~~~~
<div="terminal">
<cmd>Alice> key share
<rsp>EDVG-TQUJ-NBT5-3QPP-OOR7-ECTH-GAOQ
MDNS-WI5Q-NX3W-TG3O-RPX6-QVJ4-MMVT-D6PL-ZZZV-SPWG-N4C7-OM2F-VZZH
SAQO-6O6Z-A6YD-PMHO-TPUZ-ZLPQ-VSA7-K
SAQ7-IDPP-QX4A-PBA3-JBPZ-K2OW-6HJ4-2
SARP-RYAG-AQ75-OV2H-6TKY-4JN5-G4S2-K
</div>
~~~~

The first UDF output is the secret key, followed by the key identifier 
two shares. The different outputs are easily distinguished by their first 
letter. As with every meshman command, the `/json` option may be used to 
obtain the result as a JSON structure:


~~~~
<div="terminal">
<cmd>Alice> key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EDVG-TQUJ-NBT5-3QPP-OOR7-ECTH-GAOQ",
    "Identifier": "MDNS-WI5Q-NX3W-TG3O-RPX6-QVJ4-MMVT-D6PL-ZZZV-SPWG-N4C7-OM2F-VZZH",
    "Shares": ["SAQO-6O6Z-A6YD-PMHO-TPUZ-ZLPQ-VSA7-K",
      "SAQ7-IDPP-QX4A-PBA3-JBPZ-K2OW-6HJ4-2",
      "SARP-RYAG-AQ75-OV2H-6TKY-4JN5-G4S2-K"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> key recover SAQO-6O6Z-A6YD-PMHO-TPUZ-ZLPQ-VSA7-K SARP-RYAG-AQ75-OV2H-6TKY-4JN5-G4S2-K
<rsp>EDVG-TQUJ-NBT5-3QPP-OOR7-ECTH-GAOQ
</div>
~~~~

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


~~~~
<div="terminal">
<cmd>Alice> key share /quorum=3 /shares=5
<rsp>ED35-3FZD-2HSY-L5F4-UQNW-QBMV-E46A
MBAD-PHQZ-PNOY-VKL5-HQKR-S56S-IXV2-5EJN-TQZ7-YUIC-4A7U-G4M3-RIKZ
SAYE-XVZO-DCKF-T2AZ-TNRV-WL24-4NFE-O
SAYQ-6L63-EAPK-YP5J-4LSD-UBXA-IWXY-O
SAZE-DZ46-HJYN-ZDFF-SMTL-P3UP-XRLP-Y
SAZ6-H7TX-M6FO-VTYM-VQVN-JZTL-I5AK-M
SA2P-K5DG-U5WN-OBW7-FXYJ-B3TS-4ZWF-E
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> key share EDVG-TQUJ-NBT5-3QPP-OOR7-ECTH-GAOQ
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

