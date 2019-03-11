
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
NBH7-KOKI-2ROG-5HTJ-5OUG-F7LK-U2NA

````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NADW-K4GA-6YMN-WANG-TYWJ-AL7Y-PKLT-P4DP-THAD-TRCR-HASG-QK4N-F2TQ-E

````

Secrets are generated using the `key secret` in the same way:


````
>key secret
EDD5-2ILE-MYZT-GXC3-EG72-JGBJ-O3MQ

````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
EBP6-E2YW-XLUM-G25L-OPPQ-IDUR-NBYL-H5GV-JDFK-I4IG-KFCH-OIKT-C2P6-4

````

## Generating EARL values

An Encrypted Authenticated Resource locator is a form of URI that specifies 
a means of locating and decrypting content stored on a remote Web service.

The EARL itself specifies a domain name and a secret. The content is stored
on the Web Service under a label that is the Content Digest of the secret.

EARLs may be generated using either the `dare earl` command to generate
a new secret/digest pair which are then used to process the content data:


````
>key earl
EDKC-JTJB-LPQH-6452-XJNX-3OLM-TQPW-3I
MDXW-KXQD-GI6R-QNVG-M2PT-KUEX-PR24-AJBG-IW3E-7LEL-YSQN-DS4W-3JOJ-GZA3

````

Alternatively, the 'dare earl' command may be used to perform both operations:

**Missing Example***

## Sharing and recovering secrets

Secret sharing splits a secret into a set of shares such that the original
secret can be recovered from a chosen number of shares called the quorum.

The `key share` command creates a secret and splits it into the specified
number of shares with the specified quorum for recovery. By default, a 128
bit secret is created and three shares are created with a quorum of two:


````
>key share
EBLL-K4LQ-M2UF-XZDL-MCS5-DYIV-SJGQ
MBAK-P45Y-5TTY-YQCW-SB52-6VIY-LLUJ-FV6A-OJV3-PNTJ-A4SJ-Q4N4-JTVQ
SAQJ-NALW-VKTC-HEGY-UJ2J-Q2TY-7N63-M
SAQ5-MTL3-4TSZ-5ROM-3GEI-WAYQ-4FUR-6
SARB-MGMB-D4SR-T6WB-CCOH-3G5I-Y5KF-K

````

The first UDF output is the secret key, followed by the two shares. The shares
are easily distinguished from the secret by the first letter. As with every 
meshman command, the `/json` option may be used to obtain the result as a
JSON structure:


````
>key share
{
  "ResultKey": {
    "Success": true,
    "Key": "EBLL-K4LQ-M2UF-XZDL-MCS5-DYIV-SJGQ",
    "Identifier": "MBAK-P45Y-5TTY-YQCW-SB52-6VIY-LLUJ-FV6A-OJV3-PNTJ-A4SJ-Q4N4-JTVQ",
    "Shares": ["SAQJ-NALW-VKTC-HEGY-UJ2J-Q2TY-7N63-M",
      "SAQ5-MTL3-4TSZ-5ROM-3GEI-WAYQ-4FUR-6",
      "SARB-MGMB-D4SR-T6WB-CCOH-3G5I-Y5KF-K"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum:


````
>key recover SAQJ-NALW-VKTC-HEGY-UJ2J-Q2TY-7N63-M SARB-MGMB-D4SR-T6WB-CCOH-3G5I-Y5KF-K
EBLL-K4LQ-M2UF-XZDL-MCS5-DYIV-SJGQ

````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EBUV-TMBK-BBF4-ALIN-QSBZ-SJKJ-V52A
MAUK-7THJ-JNZM-W6SZ-FMG6-WYZL-IP2L-GG7K-R7XQ-ZE5Q-Q5RR-CBJI-QD4Q
SAYL-6HJW-2UVO-WUI6-U2A5-QB4A-JXXW-O
SAY7-NDFB-VJMM-UUY3-A3OI-5BNE-66O6-I
SAZA-7J7Q-VGI6-RRRC-F2KK-OE4T-I25L-Q
SAZQ-U3ZD-2LLE-NKRU-DWVC-DMKL-HNDE-S
SA2O-NYR3-EYS6-H72Q-2QOP-4XWM-2VAJ-O

````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share EBLL-K4LQ-M2UF-XZDL-MCS5-DYIV-SJGQ
EBLL-K4LQ-M2UF-XZDL-MCS5-DYIV-SJGQ
MBAK-P45Y-5TTY-YQCW-SB52-6VIY-LLUJ-FV6A-OJV3-PNTJ-A4SJ-Q4N4-JTVQ
SAQN-GWTP-FVWN-YP7H-EPDA-PK2U-RFKY-A
SAQU-773M-5JZR-AI7J-3QVW-TBGH-7UMI-A
SARM-ZJDK-U54U-IB7M-SSIM-WXR3-ODN3-G

````

