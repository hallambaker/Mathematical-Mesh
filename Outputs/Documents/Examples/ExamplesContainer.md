The data payloads in all the following examples are identical, only the
authentication and/or encryption is different. 

* Frame 0 is omitted in each case

* Frame 1..n consists of 300 bytes being the byte sequence 00, 01, 02, etc. 
repeating after 256 bytes.

For conciseness, the raw data format is omitted for examples after the first, except
where the data payload has been transformed, (i.e. encrypted).


##Simple container

The following example shows a simple container with first frame and a single data frame:

~~~~
f4 82 
f0 7c 
f0 00 
f0 00 
82 f4 
f5 01 74 
f0 43 
f1 01 2c 
74 01 f5 
~~~~

Since there is no integrity check, there is no need for trailer entries.
The header values are:


Frame 0

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "ContainerInfo":{
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
    "ContainerInfo":{
      "Index":1}}}

[Empty trailer]
~~~~



##Payload and chain digests

The following example shows a chain container with a first frame and three 
data frames. The headers of these frames is the same as before but the
frames now have trailers specifying the PayloadDigest and ChainDigest values:


Frame 0

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "ContainerInfo":{
      "DataEncoding":"JSON",
      "ContainerType":"Chain",
      "Index":0}}}

[Empty trailer]
~~~~


Frame 1

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "ContainerInfo":{
      "Index":1}}}

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
    "ContainerInfo":{
      "Index":2}}}

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
    "ContainerInfo":{
      "Index":3}}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "ChainDigest":"T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYV
  RVz9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}}
~~~~


##Merkle Tree

The following example shows a chain container with a first frame and six 
data frames. The trailers now contain the TreePosition and TreeDigest
values:


Frame 0

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "ContainerInfo":{
      "DataEncoding":"JSON",
      "ContainerType":"Merkle",
      "Index":0}}}

[Empty trailer]
~~~~


Frame 1

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "ContainerInfo":{
      "Index":1,
      "TreePosition":0}}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "TreeDigest":"T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYVR
  Vz9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}}
~~~~


Frame 2

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "ContainerInfo":{
      "Index":2,
      "TreePosition":360}}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "TreeDigest":"7fHmkEIsPkN6sDYAOLvpIJn5Dg3PxDDAaq-ll2kh8722kok
  kFnZQcYtjuVC71aHNXI18q-lPnfRkmwryG-bhqQ"}}
~~~~


Frame 3

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "ContainerInfo":{
      "Index":3,
      "TreePosition":360}}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "TreeDigest":"T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYVR
  Vz9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}}
~~~~


Frame 4

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "ContainerInfo":{
      "Index":4,
      "TreePosition":1612}}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "TreeDigest":"vJ6ngNATvZcXSMALi5IUqzl1GBxBnTNVcC87VL_BhMRCbAv
  KSj8gs0VFgxxLkZ2myrtaDIwhHoswiTiBMLNWug"}}
~~~~


Frame 5

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "ContainerInfo":{
      "Index":5,
      "TreePosition":1612}}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "TreeDigest":"T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYVR
  Vz9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}}
~~~~


Frame 6

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "ContainerInfo":{
      "Index":6,
      "TreePosition":2867}}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "TreeDigest":"WgHlz3EHczVPqgtpc39Arv7CFIsCbFVsk8wg0j2qLlEfur9
  SZ0mdr65Ka-HF0Qx8gg_DAoiJwUrwADDXyxVJOg"}}
~~~~


##Signed container

The following example shows a tree container with a signature in the final record.
The signing key parameters are:



~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"B-K6VxuFjt9pIX28Ve1ebVsKL2v8TNxFTYbVx3Vyf0s"}}
~~~~

The container headers and trailers are:


Frame 0

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "ContainerInfo":{
      "DataEncoding":"JSON",
      "ContainerType":"Merkle",
      "Index":0}}}

[Empty trailer]
~~~~


Frame 1

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "ContainerInfo":{
      "Index":1,
      "TreePosition":0}}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "TreeDigest":"T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYVR
  Vz9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}}
~~~~


Frame 2

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "ContainerInfo":{
      "Index":2,
      "TreePosition":360}}}

{
  "DareTrailer":{
    "PayloadDigest":"8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZ
  DlZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
    "TreeDigest":"7fHmkEIsPkN6sDYAOLvpIJn5Dg3PxDDAaq-ll2kh8722kok
  kFnZQcYtjuVC71aHNXI18q-lPnfRkmwryG-bhqQ"}}
~~~~


##Encrypted container

The following example shows a container in which all the frame payloads are encrypted 
under the same master secret established in a key agreement specified in the first frame.


Frame 0

~~~~
{
  "DareHeader":{
    "enc":"A256CBC",
    "kid":"EBQB-Q3I5-54EX-5JF7-IUHI-FOIP-HNNY",
    "Salt":"4AX0kxxF3iOiyXNVhXph8g",
    "recipients":[{
        "kid":"MAAB-5QQZ-WH4Z-YE3R-KYUY-7DCU-JW3D",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"cmjF8BcKQ4Dbm_iYiGCLJVPjJuR9SST6bUxC-Vy0AB8"}},
        "wmk":"ok4-KZhgD9UwrpsZHEK0PUCrb55ErVel7JchHiyHSzN7GooT-e
  vqfw"}
      ],
    "ContentMetaData":"e30",
    "ContainerInfo":{
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
    "kid":"EBQB-Q3I5-54EX-5JF7-IUHI-FOIP-HNNY",
    "Salt":"EfWVWw0kavl0AUIRHKRvyA",
    "ContentMetaData":"e30",
    "ContainerInfo":{
      "Index":1}}}

[Empty trailer]
~~~~


Frame 2

~~~~
{
  "DareHeader":{
    "enc":"A256CBC",
    "kid":"EBQB-Q3I5-54EX-5JF7-IUHI-FOIP-HNNY",
    "Salt":"3WD2eb2Ucc129NjvgDgoLA",
    "ContentMetaData":"e30",
    "ContainerInfo":{
      "Index":2}}}

[Empty trailer]
~~~~


Here are the container bytes. Note that the content is now encrypted and has expanded by
25 bytes. These are the salt (16 bytes), the AES padding (4 bytes) and the 
JSON-B framing (5 bytes).

~~~~
f5 02 14 
f1 01 fd 
f0 10 
f0 00 
14 02 f5 
f5 01 df 
f0 aa 
f1 01 30 
df 01 f5 
f5 01 df 
f0 aa 
f1 01 30 
df 01 f5 


~~~~


The following example shows a container in which all the frame payloads are encrypted 
under separate key agreements specified in the payload frames.


Frame 0

~~~~
{
  "DareHeader":{
    "ContentMetaData":"e30",
    "ContainerInfo":{
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
    "kid":"EBQL-G4BM-7O7A-KDKK-I26L-NRO5-MRLZ",
    "Salt":"fb-oAnvqsosXPx8EjcPFFw",
    "recipients":[{
        "kid":"MAAB-5QQZ-WH4Z-YE3R-KYUY-7DCU-JW3D",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"YcQSp3pfXGFt2sgKAIkk_M-GsZn6PmuTPs9wN7opTeA"}},
        "wmk":"ggY4TbpZFOew2ZpkkfkIgTo76LtWod4TVNRtSl4PLtrySFvUnl
  W9Eg"}
      ],
    "ContentMetaData":"e30",
    "ContainerInfo":{
      "Index":1}}}

[Empty trailer]
~~~~


Frame 2

~~~~
{
  "DareHeader":{
    "enc":"A256CBC",
    "kid":"EBQB-DTUV-NAAC-E6ET-4AC5-BAWF-I3ZH",
    "Salt":"DUUtwuzMtGl_g9qNQzqi7A",
    "recipients":[{
        "kid":"MAAB-5QQZ-WH4Z-YE3R-KYUY-7DCU-JW3D",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"oOq0f-OchHTZu6UcnjyyjsThqefpVWwSiu5H6exSjO4"}},
        "wmk":"qI4t9XqGSBmmebf0OlOECKgjhhfoofN1ECBc4tD-fLwg9VskQQ
  hnTA"}
      ],
    "ContentMetaData":"e30",
    "ContainerInfo":{
      "Index":2}}}

[Empty trailer]
~~~~


