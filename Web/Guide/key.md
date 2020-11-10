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
<rsp>NDLG-SJIB-OWFK-WBUB-LXDG-UAC4-D3VQ
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> key nonce /bits=256
<rsp>NBL6-2FLQ-64WZ-VDX4-3RHU-4XJP-6ISR-TR7C-SWE7-XJ5I-ZYVV-ZUDZ-MA42-Y
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> key secret
<rsp>EB2T-PUJQ-EONW-UMZA-YX65-EUOP-OA7A
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> key secret /bits=256
<rsp>EAYZ-RY25-I73L-DQFD-ITTO-3RXW-EEGD-RRCC-3DW5-U24S-UG7G-QAF7-RXWT-C
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
<rsp>EDBP-RZZR-YGCU-FQOV-QECB-IGGB-VQ5J-J5
MC7O-JJME-VNBV-VLUQ-5K5U-D56L-ZOZH-Z7K2-QRVI-XVEH-XXHI-BERQ-TIPX-VISV

</div>
~~~~

Alternatively, the `dare earl` command may be used to perform both operations:


~~~~
Missing example 4
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
<rsp>BMI5-ZURI-RC4J-7LA7-OQLH-SBQY-TA
MDN5-NPL2-X5UW-YACY-U3XC-KICD-3SPL-LTCF-ODP4-PZEA-6LQC-3Q3Q-3HXH
SAQN-UQMI-LHQJ-DRYS-AZXT-B7HV-3JYW-C
SAQ2-S4JT-4GMJ-VVME-MC7O-3Y3S-V3E7-O
SARH-RIG7-NFIK-HY7W-XMHK-VSPP-QMRI-2
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
    "Key": "BMI5-ZURI-RC4J-7LA7-OQLH-SBQY-TA",
    "Identifier": "MDN5-NPL2-X5UW-YACY-U3XC-KICD-3SPL-LTCF-ODP4-PZEA-6LQC-3Q3Q-3HXH",
    "Shares": ["SAQN-UQMI-LHQJ-DRYS-AZXT-B7HV-3JYW-C",
      "SAQ2-S4JT-4GMJ-VVME-MC7O-3Y3S-V3E7-O",
      "SARH-RIG7-NFIK-HY7W-XMHK-VSPP-QMRI-2"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> key recover SAQN-UQMI-LHQJ-DRYS-AZXT-B7HV-3JYW-C ^
    SARH-RIG7-NFIK-HY7W-XMHK-VSPP-QMRI-2
<rsp>BMI5-ZURI-RC4J-7LA7-OQLH-SBQY-TA
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
<rsp>YCUX-45F2-533Q-NG6L-H4FW-FQLP-6I
MCVU-DW5L-BDEZ-QWBF-DSRL-N4G3-MMBS-UHIP-YFBL-56WB-3BL4-HFET-AMVC
SAYJ-MOQZ-VBZ7-BU5U-VL36-WFML-3GRL-O
SAYX-LVDL-Z5O5-YXIM-MST7-ZJZV-KKGN-C
SAZF-66DU-5F4L-DEYN-ZDNX-HQC7-FQXE-A
SAZV-GJRU-63CH-A5NY-26JF-AYIJ-M2DQ-I
SA2F-BXNL-65AR-SBIN-SDGJ-FCJU-AGLR-2
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> key share BMI5-ZURI-RC4J-7LA7-OQLH-SBQY-TA
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

