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
<cmd>Alice> meshman key nonce
<rsp>NBZF-KCXZ-FVOO-VVIO-ALFR-5JVE-UO3A
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> meshman key nonce /bits=256
<rsp>NDJC-VMCV-MGYW-XVDA-FDNR-OXDQ-6YN7-5QCW-QPXZ-GUNC-KL7N-LELY-BPVU-E
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret
<rsp>EDUS-AMYO-VAKG-FONE-IK3T-JWP7-JW6Q
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret /bits=256
<rsp>ED57-7KJV-MFPI-3K53-C3X6-DRJ3-4R34-M7AJ-5OAI-BYCX-QG5G-2K6B-553R-K
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
<cmd>Alice> meshman key earl
<rsp>EASN-PHWS-DJAI-DWS7-4BVK-MWFF-J4MR-NW
MBRI-NYZW-2OIT-REUD-VMYC-2LUR-5BIB-VPSB-TX2A-OZ77-JPRT-K7CW-MKQF-PN2S

</div>
~~~~

Alternatively, the `dare earl` command may be used to perform both operations:


~~~~
<div="terminal">
<cmd>Alice> meshman dare earl TestFile1.txt example.com
<rsp>ERROR - An unknown error occurred
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
<cmd>Alice> meshman key share
<rsp>4YKU-TJ76-37Z7-3YOJ-WDFX-F4S4-NM
MCCR-4JZO-JBIS-YKP3-7ZWS-DOFL-VTLY-EW2T-2WDJ-GZJY-VFYH-WEUS-M32U
SAQD-5NHQ-BTGZ-DQEB-GOI4-A4VV-WMPN-A
SAQZ-OVEW-OGOE-HDIE-QVM5-AGPY-OPQW-Q
SARO-75B4-2ZVP-KWMH-24Q5-7QJ3-GSSA-A
</div>
~~~~

The first UDF output is the secret key, followed by the key identifier 
two shares. The different outputs are easily distinguished by their first 
letter. As with every meshman command, the `/json` option may be used to 
obtain the result as a JSON structure:


~~~~
<div="terminal">
<cmd>Alice> meshman key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "4YKU-TJ76-37Z7-3YOJ-WDFX-F4S4-NM",
    "Identifier": "MCCR-4JZO-JBIS-YKP3-7ZWS-DOFL-VTLY-EW2T-2WDJ-GZJY-VFYH-WEUS-M32U",
    "Shares": ["SAQD-5NHQ-BTGZ-DQEB-GOI4-A4VV-WMPN-A",
      "SAQZ-OVEW-OGOE-HDIE-QVM5-AGPY-OPQW-Q",
      "SARO-75B4-2ZVP-KWMH-24Q5-7QJ3-GSSA-A"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> meshman key recover SAQD-5NHQ-BTGZ-DQEB-GOI4-A4VV-WMPN-A ^
    SARO-75B4-2ZVP-KWMH-24Q5-7QJ3-GSSA-A
<rsp>4YKU-TJ76-37Z7-3YOJ-WDFX-F4S4-NM
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
<cmd>Alice> meshman key share /quorum=3 /shares=5
<rsp>HOXO-W5B7-NBCM-7QDZ-S46P-3VJ5-YU
MD3D-LIV5-GGFJ-FOXB-3BUE-2NUZ-VQWC-GNHC-4O7X-6Q7N-R64V-CFSQ-SBPC
SAYB-SUK6-RMO2-5UAQ-56SB-5WDK-RN5W-Y
SAYU-7ATM-FJXT-VUCS-BEOM-VMWF-7KFA-I
SAZN-4QQU-KI2A-YRMT-BTRZ-VTAQ-EJUY-2
SAZ4-LECX-AJWC-GL6T-7L4I-6JCJ-AMM5-I
SA2A-K3JU-HMLX-7DYU-2NN2-PO3Q-TSNN-S
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> meshman key share 4YKU-TJ76-37Z7-3YOJ-WDFX-F4S4-NM
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

