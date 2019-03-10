
# Using the Key Command Set

The Key command set contains commands that operate on cryptographic secrets and
nonces.

## Generating Secrets and Nonces

Secrets and nonces both consist of a randomly generated sequence of bits. The
only distinction made between a secret and a nonce is the uses that may be 
made of them. For example, a secret value must not be passed in clear text in 
any circumstances. The visual distinction between these uses afforded by UDF 
presentation aids application debugging and audit.

The `key nonce` command is used to generate a new random nonce value:


````
>key nonce
NBBL-AYRC-MFVH-XPGG-MWYF-CKRF-VTUQ
````

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option


````
>key nonce /bits=256
NCZ6-PL65-EEBN-PB64-HLZI-6NWB-TSVQ-EKPP-7KIT-CKSQ-RXAS-LDSM-LRFS-A
````

Secrets are generated using the `key secret` in the same way:


````
>key secret
EBS7-A2XV-32CU-4WTA-LZBY-DY42-K3SA
````

Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
EDDK-CKHW-PCSY-MGFD-7PCU-U7W6-3244-TUSJ-4XVK-4PLG-HU2N-N6XI-7FDW-6
````

## Generating EARL values

An Encrypted Authenticated Resource locator is a form of URI that specifies 
a means of locating and decrypting content stored on a remote Web service.

The EARL itself specifies a domain name and a secret. The content is stored
on the Web Service under a label that is the Content Digest of the secret.

EARLs may be generated using either the `key earl` command to generate
a new secret/digest pair which are then used to process the content data:


````
>key earl
EAQB-56NM-2GKA-ONXH-FU6Y-G23W-SJ3W-M6
````

Alternatively, the 'file earl' command may be used to perform both operations:

**Missing Example***

## Sharing and recovering secrets

Secret sharing splits a secret into a set of shares such that the original
secret can be recovered from a chosen number of shares called the quorum.

The `key share` command creates a secret and splits it into the specified
number of shares with the specified quorum for recovery. By default, a 128
bit secret is created and three shares are created with a quorum of two:


````
>key share
ECHB-MJGP-NEOL-T65F-PN2N-UA6Q-BTTA
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum:

**Missing Example***

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EB3S-ROT3-A3HV-GWGC-M472-HP5X-PMNA
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share ECHB-MJGP-NEOL-T65F-PN2N-UA6Q-BTTA
ECHB-MJGP-NEOL-T65F-PN2N-UA6Q-BTTA
````

