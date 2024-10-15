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
<rsp>NC6T-MFS3-63KA-TI2S-MGAI-57EF-VCLQ
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> meshman key nonce /bits=256
<rsp>NCY6-XM6V-VZEC-G74U-W7L6-RFP3-ROFX-LEHE-MCSV-J65Y-22L2-JV4D-HN75-U
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret
<rsp>EDEJ-XK3A-77MA-JPC2-6SV5-6HMY-WA7A
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret /bits=256
<rsp>ECYS-T5I4-J7CO-VVJR-LBFZ-7TGU-X6EZ-TP4D-IWGL-TA75-372A-7BTY-XP4F-2
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
<rsp>ECL3-IMAO-CDHQ-COYV-XWQV-MTW6-VMHZ-KV
MC46-CEBM-EBWF-QTTL-LEB2-SDZ4-DCH6-DRGX-TJKH-R2PG-7PK3-LXBO-SUN5-SKN7

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
<rsp>DFMU-EGO5-W2FD-76HK-L5NL-PTYI-KU
MDQN-EFIS-LI56-O7UB-BPXQ-AJVQ-42HJ-VVUI-M4N5-EPK2-XAG4-OBXU-QE5K
SAQK-CQ65-75VB-JFWD-H26J-JGFM-QQAS-Y
SAQS-SLTZ-4T3H-FI2G-QSHM-TVVB-HD45-A
SARL-CGIV-ZKBN-BL6J-ZJQP-6FEV-5XZK-O
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
    "Key": "DFMU-EGO5-W2FD-76HK-L5NL-PTYI-KU",
    "Identifier": "MDQN-EFIS-LI56-O7UB-BPXQ-AJVQ-42HJ-VVUI-M4N5-EPK2-XAG4-OBXU-QE5K",
    "Shares": ["SAQK-CQ65-75VB-JFWD-H26J-JGFM-QQAS-Y",
      "SAQS-SLTZ-4T3H-FI2G-QSHM-TVVB-HD45-A",
      "SARL-CGIV-ZKBN-BL6J-ZJQP-6FEV-5XZK-O"],
    "Success": true}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> meshman key recover SAQK-CQ65-75VB-JFWD-H26J-JGFM-QQAS-Y ^
    SARL-CGIV-ZKBN-BL6J-ZJQP-6FEV-5XZK-O
<rsp>DFMU-EGO5-W2FD-76HK-L5NL-PTYI-KU
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
<rsp>SAVJ-UPEU-6WFL-GM3L-UOIE-XKRC-NY
MB5N-NSY5-JDTH-VCMH-H23Q-AYMY-V4OE-CMUJ-E2MN-ONRB-NNQV-RXVS-LN56
SAYD-5INK-AAKZ-NYLX-FUBU-RV2T-FA4I-C
SAYR-UO65-4RWF-N2N4-UVH6-CIVG-5YEW-G
SAZC-F6JV-5GMT-LI4D-TRIW-Y4SG-7OKR-I
SAZV-RWNS-B6OD-GDWM-CID6-VRRT-KDNZ-I
SA2L-XXKS-KZ2U-6K4W-AZZV-YHTL-5XOO-G
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> meshman key share DFMU-EGO5-W2FD-76HK-L5NL-PTYI-KU
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

