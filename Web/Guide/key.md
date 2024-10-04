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
<rsp>NAMH-DTYV-L3RQ-XCHF-YXKT-QFJR-OSKQ
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> meshman key nonce /bits=256
<rsp>NAWN-QIMU-2DR7-7DPQ-RAOK-WF4Y-KOWQ-N7XH-PYCD-77D3-ZROE-T2Y5-AZFO-G
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret
<rsp>EDCA-XKZK-CR6S-RR3X-IHHA-YA6Z-IMTQ
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret /bits=256
<rsp>EDKK-VXAQ-2HBY-LG3G-4FYK-3A7K-R5A2-PJVL-QSMR-2CQU-6H5W-IL7L-DMPV-U
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
<rsp>EAFE-JAJM-2KAH-PZZX-SUUP-RD5S-ORK4-CU
MBQA-PQEL-PSZZ-ELNR-IG6I-W254-RLCB-Z5EW-BSPW-7VT7-EIB2-DC2A-PSY6-MAUD

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
<rsp>63RN-ESUG-XN3S-AEDH-STW7-UXQU-YQ
MDKI-FFF2-XTFD-3HBR-U643-V2DE-ETQN-IANV-NW5R-MQRQ-6LEE-NPDR-LNWA
SAQM-GI34-24ZL-UJAM-AVK2-LCEZ-P4S6-I
SAQY-6ZBH-MPPL-RUHX-7JB3-MIZY-UA3Q-I
SARF-XJGR-6CFL-O7PD-54Y4-NPOX-YFEC-I
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
    "Key": "63RN-ESUG-XN3S-AEDH-STW7-UXQU-YQ",
    "Identifier": "MDKI-FFF2-XTFD-3HBR-U643-V2DE-ETQN-IANV-NW5R-MQRQ-6LEE-NPDR-LNWA",
    "Shares": ["SAQM-GI34-24ZL-UJAM-AVK2-LCEZ-P4S6-I",
      "SAQY-6ZBH-MPPL-RUHX-7JB3-MIZY-UA3Q-I",
      "SARF-XJGR-6CFL-O7PD-54Y4-NPOX-YFEC-I"],
    "Success": true}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> meshman key recover SAQM-GI34-24ZL-UJAM-AVK2-LCEZ-P4S6-I ^
    SARF-XJGR-6CFL-O7PD-54Y4-NPOX-YFEC-I
<rsp>63RN-ESUG-XN3S-AEDH-STW7-UXQU-YQ
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
<rsp>5XUI-L3EM-IK3X-WKIH-X4R6-IOYA-6I
MB44-3BTU-GCFN-TJQW-K3W4-NRV7-JNX3-CBMV-7SED-LWDT-DFKI-VNXE-Y7LB
SAYH-6UWU-RXBV-G2S7-BSW3-34GE-O3IM-Q
SAY7-2ZGG-CF53-5ZPO-6COT-PYHI-LPW6-C
SAZG-QHS2-O62Y-KKRK-2TLC-Z5CP-5JL5-O
SAZ3-674R-YBYK-MNYS-XFMJ-2KX3-EIHR-A
SA2A-HCDL-5OWS-EDFG-TYSI-RBHK-AMJS-M
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> meshman key share 63RN-ESUG-XN3S-AEDH-STW7-UXQU-YQ
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

