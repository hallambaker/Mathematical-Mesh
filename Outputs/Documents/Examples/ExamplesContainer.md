The data payloads in all the following examples are identical, only the
authentication and/or encryption is different. 

* Frame 0 is omitted in each case

* Frame 1..n consists of 300 bytes being the byte sequence 00, 01, 02, etc. 
repeating after 256 bytes.

For conciseness, the raw data format is omitted for examples after the first, except
where the data payload has been transformed, (i.e. encrypted).


##Simple sequence

The following example shows a simple sequence with first frame and a single data frame:

~~~~
~~~~

Since there is no integrity check, there is no need for trailer entries.
The header values are:


Frame 0

~~~~
{
  "DareHeader":{
    "policy":{},
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "DataEncoding":"JSON",
      "ContainerType":"List",
      "Index":0}}}

[Empty trailer]
~~~~


Frame 0

~~~~
{
  "DareHeader":{
    "policy":{},
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "DataEncoding":"JSON",
      "ContainerType":"List",
      "Index":0}}}

[Empty trailer]
~~~~


Frame 1

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "Index":1}}}

[Empty trailer]
~~~~



##Payload and chain digests

The following example shows a chain sequence with a first frame and three 
data frames. The headers of these frames is the same as before but the
frames now have trailers specifying the PayloadDigest and ChainDigest values:


Frame 0

~~~~
{
  "DareHeader":{
    "policy":{},
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "DataEncoding":"JSON",
      "ContainerType":"Chain",
      "Index":0},
    "dig":"S512"}}

[Empty trailer]
~~~~


Frame 0

~~~~
{
  "DareHeader":{
    "policy":{},
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "DataEncoding":"JSON",
      "ContainerType":"Chain",
      "Index":0},
    "dig":"S512"}}

{
  "DareTrailer":{
    "PayloadDigest":"z4PhNX7vuL3xVChQ1m2AB9Yg5AULVxXcg_SpIdNs6c5H
  0NE8XYXysP-DGNKHfuwvY7kxvUdBeoGlODJ6-SfaPg",
    "ChainDigest":"FEHy24Y6cLModDXWH31kVc2a3TdhjXPooKHpLAb2JbsO1Y
  QnJolmowXAYHhkOGY0kg3jrKNTjds0myf4Dw1sdg"}}
~~~~


Frame 1

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "Index":1},
    "dig":"S512"}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "ChainDigest":"T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYV
  RVz9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}}
~~~~


Frame 2

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "Index":2},
    "dig":"S512"}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "ChainDigest":"T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYV
  RVz9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}}
~~~~


Frame 3

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "Index":3},
    "dig":"S512"}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "ChainDigest":"T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYV
  RVz9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}}
~~~~


##Merkle Tree

The following example shows a chain sequence with a first frame and six 
data frames. The trailers now contain the TreePosition and TreeDigest
values:


Frame 0

~~~~
{
  "DareHeader":{
    "policy":{},
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "DataEncoding":"JSON",
      "ContainerType":"Merkle",
      "Index":0},
    "dig":"S512"}}

[Empty trailer]
~~~~


Frame 0

~~~~
{
  "DareHeader":{
    "policy":{},
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "DataEncoding":"JSON",
      "ContainerType":"Merkle",
      "Index":0},
    "dig":"S512"}}

{
  "DareTrailer":{
    "PayloadDigest":"z4PhNX7vuL3xVChQ1m2AB9Yg5AULVxXcg_SpIdNs6c5H
  0NE8XYXysP-DGNKHfuwvY7kxvUdBeoGlODJ6-SfaPg",
    "ApexDigest":"wvk8X5vTHUlVff7cj3k6fHBqXw52PA_7KK5zRLkheMKnGVF
  gHY0VL46Fz78rIjCnSNGXmDoBBG5phZRCU1guDA"}}
~~~~


Frame 1

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "Index":1,
      "TreePosition":0},
    "dig":"S512"}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "ApexDigest":"vJ6ngNATvZcXSMALi5IUqzl1GBxBnTNVcC87VL_BhMRCbAv
  KSj8gs0VFgxxLkZ2myrtaDIwhHoswiTiBMLNWug"}}
~~~~


Frame 2

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "Index":2,
      "TreePosition":392},
    "dig":"S512"}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "ApexDigest":"T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYVR
  Vz9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}}
~~~~


Frame 3

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "Index":3,
      "TreePosition":392},
    "dig":"S512"}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "ApexDigest":"7fHmkEIsPkN6sDYAOLvpIJn5Dg3PxDDAaq-ll2kh8722kok
  kFnZQcYtjuVC71aHNXI18q-lPnfRkmwryG-bhqQ"}}
~~~~


Frame 4

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "Index":4,
      "TreePosition":1676},
    "dig":"S512"}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "ApexDigest":"T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYVR
  Vz9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}}
~~~~


Frame 5

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "Index":5,
      "TreePosition":1676},
    "dig":"S512"}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "ApexDigest":"vJ6ngNATvZcXSMALi5IUqzl1GBxBnTNVcC87VL_BhMRCbAv
  KSj8gs0VFgxxLkZ2myrtaDIwhHoswiTiBMLNWug"}}
~~~~


Frame 6

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "Index":6,
      "TreePosition":2963},
    "dig":"S512"}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "ApexDigest":"T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYVR
  Vz9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}}
~~~~


##Signed sequence

The following example shows a tree sequence with a signature in the final record.
The signing key parameters are:



~~~~
{
  "PrivateKeyECDH":{
    "Private":"H4vYLegql3J8i2rDmU0t9rFGRpg5P2IeBdykCE_YMWo",
    "crv":"Ed25519"}}
~~~~

The sequence headers and trailers are:


Frame 0

~~~~
{
  "DareHeader":{
    "policy":{},
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "DataEncoding":"JSON",
      "ContainerType":"Merkle",
      "Index":0},
    "dig":"S512"}}

[Empty trailer]
~~~~


Frame 0

~~~~
{
  "DareHeader":{
    "policy":{},
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "DataEncoding":"JSON",
      "ContainerType":"Merkle",
      "Index":0},
    "dig":"S512"}}

{
  "DareTrailer":{
    "PayloadDigest":"z4PhNX7vuL3xVChQ1m2AB9Yg5AULVxXcg_SpIdNs6c5H
  0NE8XYXysP-DGNKHfuwvY7kxvUdBeoGlODJ6-SfaPg",
    "ApexDigest":"wvk8X5vTHUlVff7cj3k6fHBqXw52PA_7KK5zRLkheMKnGVF
  gHY0VL46Fz78rIjCnSNGXmDoBBG5phZRCU1guDA"}}
~~~~


Frame 1

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "Index":1,
      "TreePosition":0},
    "dig":"S512"}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "ApexDigest":"vJ6ngNATvZcXSMALi5IUqzl1GBxBnTNVcC87VL_BhMRCbAv
  KSj8gs0VFgxxLkZ2myrtaDIwhHoswiTiBMLNWug"}}
~~~~


Frame 2

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "Index":2,
      "TreePosition":392},
    "dig":"S512"}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "ApexDigest":"T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYVR
  Vz9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}}
~~~~


##Encrypted sequence

The following example shows a sequence in which all the frame payloads are encrypted 
under the same base seed established in a key agreement specified in the first frame.


Frame 0

~~~~
{
  "DareHeader":{
    "enc":"A256CBC",
    "kid":"EBQF-MUOR-2SRA-TGTR-4GAU-NQOS-VTV6",
    "Salt":"Vo73JB-bMliSaGxMYdn28g",
    "recipients":[{
        "kid":"MC76-W4OU-INGZ-PG5U-TEOO-WOAV-3VGU",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"lgeR7EU59do_w5n4eqG9ziYmk6RNL-dqUCmoBKyqRKc"}},
        "wmk":"jDxwV06iQ0cA1v2da-LtSQF9l9caN26TtHlZOhPglj4DnbgxsP
  B2jA"}
      ],
    "policy":{
      "enc":"none",
      "dig":"none",
      "EncryptKeys":[{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"hvJXZNC4r0jxBiw1pLFRQOHW3zgwTV4ObgTaxC6C2OM"}}
        ],
      "Sealed":true},
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "DataEncoding":"JSON",
      "ContainerType":"List",
      "Index":0}}}

[Empty trailer]
~~~~


Frame 0

~~~~
{
  "DareHeader":{
    "enc":"A256CBC",
    "kid":"EBQF-MUOR-2SRA-TGTR-4GAU-NQOS-VTV6",
    "Salt":"Vo73JB-bMliSaGxMYdn28g",
    "recipients":[{
        "kid":"MC76-W4OU-INGZ-PG5U-TEOO-WOAV-3VGU",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"lgeR7EU59do_w5n4eqG9ziYmk6RNL-dqUCmoBKyqRKc"}},
        "wmk":"jDxwV06iQ0cA1v2da-LtSQF9l9caN26TtHlZOhPglj4DnbgxsP
  B2jA"}
      ],
    "policy":{
      "enc":"none",
      "dig":"none",
      "EncryptKeys":[{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"hvJXZNC4r0jxBiw1pLFRQOHW3zgwTV4ObgTaxC6C2OM"}}
        ],
      "Sealed":true},
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "DataEncoding":"JSON",
      "ContainerType":"List",
      "Index":0}}}

[Empty trailer]
~~~~


Frame 1

~~~~
{
  "DareHeader":{
    "enc":"A256CBC",
    "kid":"EBQK-6S3Q-R32O-WYTB-IS6Y-ZD3P-J3VR",
    "Salt":"8mUai-sxiSulsdMsdWd1ug",
    "recipients":[{
        "kid":"MC76-W4OU-INGZ-PG5U-TEOO-WOAV-3VGU",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"lXhvcOmziTjpwoNB1Jln9lBUyQY65Qx7mV_bARUe6bw"}},
        "wmk":"dqG1VEJfjnlvmYS7Op-FnFr5_sSTS6Sb5w73OZGox2AR5f-Nrj
  JGsg"}
      ],
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "Index":1}}}

[Empty trailer]
~~~~


Frame 2

~~~~
{
  "DareHeader":{
    "enc":"A256CBC",
    "kid":"EBQL-VR3Q-4BGH-I5NR-7T7Y-FUD6-Z35O",
    "Salt":"8JSnoarjnD_eF87bxT0kvg",
    "recipients":[{
        "kid":"MC76-W4OU-INGZ-PG5U-TEOO-WOAV-3VGU",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"iA59MqMyoVlUufbCdad3xwaj71IIkfI-D9maX7o4m9g"}},
        "wmk":"Q8wrOytFe1l-E-HvEwAxZQeVi4t7a4IrD7hIv1xcWNytAX11KA
  hZjA"}
      ],
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "Index":2}}}

[Empty trailer]
~~~~


Here are the sequence bytes. Note that the content is now encrypted and has expanded by
25 bytes. These are the salt (16 bytes), the AES padding (4 bytes) and the 
JSON-B framing (5 bytes).

~~~~


~~~~


The following example shows a sequence in which all the frame payloads are encrypted 
under separate key agreements specified in the payload frames.


Frame 0

~~~~
{
  "DareHeader":{
    "policy":{
      "enc":"none",
      "dig":"none",
      "Sealed":true},
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "DataEncoding":"JSON",
      "ContainerType":"List",
      "Index":0}}}

[Empty trailer]
~~~~


Frame 0

~~~~
{
  "DareHeader":{
    "policy":{
      "enc":"none",
      "dig":"none",
      "Sealed":true},
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "DataEncoding":"JSON",
      "ContainerType":"List",
      "Index":0}}}

[Empty trailer]
~~~~


Frame 1

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "Index":1}}}

[Empty trailer]
~~~~


Frame 2

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "SequenceInfo":{
      "Index":2}}}

[Empty trailer]
~~~~


