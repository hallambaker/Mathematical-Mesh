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
    "Private":"3sqB9SW-AeblQgp1LpQAaeyNwTe9zIL8kCHREN0Z5aI"}}
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
    "kid":"EBQF-WURD-YFJV-I56E-4CL7-SU5P-M25U",
    "Salt":"6LmtY-Qkh0rzgvcXaSLDAw",
    "recipients":[{
        "kid":"MCUG-LA4F-7LOS-Z2JR-MNMJ-BEL5-654X",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"bj4nRCizT1FQneUswgpUkBHhJ9vPni9v6t5MHaRP-CM"}},
        "wmk":"UjepdeWKolqOD43GECKK0D7XLZ3SIS7GjM7T6I5uZfmf9WZRJf
  VPcg"}
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
    "kid":"EBQF-WURD-YFJV-I56E-4CL7-SU5P-M25U",
    "Salt":"oAcK0CCllQoQsD8mSPj0lA",
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
    "kid":"EBQF-WURD-YFJV-I56E-4CL7-SU5P-M25U",
    "Salt":"ZaLu3ETpHZ4YLIiSVy5jtw",
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
    "kid":"EBQN-QBRR-KGRA-XW7H-VGFS-2WQZ-Q5VY",
    "Salt":"t8uSpe09LvQAeeWhiWszRQ",
    "recipients":[{
        "kid":"MCUG-LA4F-7LOS-Z2JR-MNMJ-BEL5-654X",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"XeZWS1mJpVcRn3fDZje6E7iX-Vuo6rQ9K4mRqtyHwF8"}},
        "wmk":"3qGEgztXpxs0eK4dIZ0leHDRegiVnAOvUFFJr6UDFqNtIliErI
  p45g"}
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
    "kid":"EBQA-4T6G-4Y4W-LLPW-HDP5-GBQ5-KCME",
    "Salt":"L7P1gbXeByt_NTwNVsbbGg",
    "recipients":[{
        "kid":"MCUG-LA4F-7LOS-Z2JR-MNMJ-BEL5-654X",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"NZUmu6aY-h_SeODovvWgsAYKfH1CMbTEYI2zo6Sl_4A"}},
        "wmk":"UR72ci9oeCHY1sZsLNI__8fMHkvVl8yXNks9vHMMAitiI7VgH3
  Hvng"}
      ],
    "ContentMetaData":"e30",
    "ContainerInfo":{
      "Index":2}}}

[Empty trailer]
~~~~


