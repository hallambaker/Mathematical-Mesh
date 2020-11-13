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
    "Private":"-5zIro5wEnRp0fvMBc5m7bofU0bfG74jJJQs38sMyAg"}}
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
    "kid":"EBQI-IUV4-YVFB-T46D-2IMR-PYNY-6EQS",
    "Salt":"isRTli7V_v8NbuX4oGIfMw",
    "recipients":[{
        "kid":"MCOP-FVIJ-Y67Y-UY5G-4POC-T43X-VKME",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"gSen3A3vdrfTyUKnGp5mcZ51xIIfrFXuyCK_bVuqOdE"}},
        "wmk":"ipU11m6gRVFNeLeu5uf_bkhgYWCqa-hgP6_sxXF9KoysbhLX-r
  6KsA"}
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
    "kid":"EBQI-IUV4-YVFB-T46D-2IMR-PYNY-6EQS",
    "Salt":"1zCfDgETSdcFSGIxvvYfRA",
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
    "kid":"EBQI-IUV4-YVFB-T46D-2IMR-PYNY-6EQS",
    "Salt":"tueEAhpDYPz1_UEeOi1WyA",
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
    "kid":"EBQK-IH24-X3VD-ZZ7V-SURY-WGMH-IG75",
    "Salt":"5PZUe91W2YS7ZdH54JOP6g",
    "recipients":[{
        "kid":"MCOP-FVIJ-Y67Y-UY5G-4POC-T43X-VKME",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"wdQXSEyhRMsQu7BL7PTb_YWGzfSGCwQddN-HI7PQlNc"}},
        "wmk":"_BCBEHITg6g6TkI5lfEL0aAyKkM9mrhhkPA-azDQEpSm-n4v3W
  twWg"}
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
    "kid":"EBQI-JJD5-YXBR-QCCZ-DKUE-WFDT-57UD",
    "Salt":"jlYFWBSWrKb5b38ca_2HZg",
    "recipients":[{
        "kid":"MCOP-FVIJ-Y67Y-UY5G-4POC-T43X-VKME",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"YDk9YA7nVgkPYkqi_X3U07WnQQ9DV_TXvTUaU5u3q2A"}},
        "wmk":"JYMa-KHT6lrzIFKxuZ3n1XhJTQVNxfTo4LeABNjufX3z5al2YU
  YFlg"}
      ],
    "ContentMetaData":"e30",
    "ContainerInfo":{
      "Index":2}}}

[Empty trailer]
~~~~


