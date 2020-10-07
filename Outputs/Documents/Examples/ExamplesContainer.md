The data payloads in all the following examples are identical, only the
authentication and/or encryption is different. 

* Frame 0 is omitted in each case

* Frame 1..n consists of 300 bytes being the byte sequence 00, 01, 02, etc. 
repeating after 256 bytes.

For conciseness, the raw data format is omitted for examples after the first, except
where the data payload has been transformed, (i.e. encrypted).


##Simple container

the following example shows a simple container with first frame and a single data frame:

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
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "DataEncoding": "JSON",
    "ContainerType": "List",
    "Index": 0}}

[Empty trailer]
~~~~

Frame 1

~~~~
{
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 1}}

[Empty trailer]
~~~~



##Payload and chain digests

The following example shows a chain container with a first frame and three 
data frames. The headers of these frames is the same as before but the
frames now have trailers specifying the PayloadDigest and ChainDigest values:

Frame 0

~~~~
{
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "DataEncoding": "JSON",
    "ContainerType": "Chain",
    "Index": 0}}

[Empty trailer]
~~~~

Frame 1

~~~~
{
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 1}}

{
  "PayloadDigest": "8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZD
  lZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
  "ChainDigest": "T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYVR
  Vz9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}
~~~~

Frame 2

~~~~
{
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 2}}

{
  "PayloadDigest": "8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZD
  lZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
  "ChainDigest": "T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYVR
  Vz9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}
~~~~

Frame 3

~~~~
{
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 3}}

{
  "PayloadDigest": "8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZD
  lZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
  "ChainDigest": "T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYVR
  Vz9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}
~~~~


##Merkle Tree

The following example shows a chain container with a first frame and six 
data frames. The trailers now contain the TreePosition and TreeDigest
values:

Frame 0

~~~~
{
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "DataEncoding": "JSON",
    "ContainerType": "Merkle",
    "Index": 0}}

[Empty trailer]
~~~~

Frame 1

~~~~
{
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 1,
    "TreePosition": 0}}

{
  "PayloadDigest": "8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZD
  lZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
  "TreeDigest": "T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYVRV
  z9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}
~~~~

Frame 2

~~~~
{
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 2,
    "TreePosition": 360}}

{
  "PayloadDigest": "8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZD
  lZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
  "TreeDigest": "7fHmkEIsPkN6sDYAOLvpIJn5Dg3PxDDAaq-ll2kh8722kokk
  FnZQcYtjuVC71aHNXI18q-lPnfRkmwryG-bhqQ"}
~~~~

Frame 3

~~~~
{
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 3,
    "TreePosition": 360}}

{
  "PayloadDigest": "8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZD
  lZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
  "TreeDigest": "T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYVRV
  z9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}
~~~~

Frame 4

~~~~
{
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 4,
    "TreePosition": 1612}}

{
  "PayloadDigest": "8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZD
  lZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
  "TreeDigest": "vJ6ngNATvZcXSMALi5IUqzl1GBxBnTNVcC87VL_BhMRCbAvK
  Sj8gs0VFgxxLkZ2myrtaDIwhHoswiTiBMLNWug"}
~~~~

Frame 5

~~~~
{
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 5,
    "TreePosition": 1612}}

{
  "PayloadDigest": "8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZD
  lZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
  "TreeDigest": "T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYVRV
  z9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}
~~~~

Frame 6

~~~~
{
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 6,
    "TreePosition": 2867}}

{
  "PayloadDigest": "8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZD
  lZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
  "TreeDigest": "WgHlz3EHczVPqgtpc39Arv7CFIsCbFVsk8wg0j2qLlEfur9S
  Z0mdr65Ka-HF0Qx8gg_DAoiJwUrwADDXyxVJOg"}
~~~~


##Signed container

The following example shows a tree container with a signature in the final record.
The signing key parameters are:



~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"GgPgDJeBzYUl_db4ySfoKmzhos3MGyYcXswgXcirf14"}}
~~~~

The container headers and trailers are:

Frame 0

~~~~
{
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "DataEncoding": "JSON",
    "ContainerType": "Merkle",
    "Index": 0}}

[Empty trailer]
~~~~

Frame 1

~~~~
{
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 1,
    "TreePosition": 0}}

{
  "PayloadDigest": "8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZD
  lZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
  "TreeDigest": "T7S1FcrgY3AaWD4L-t5W1K-3XYkPTcOdGEGyjglTD6yMYVRV
  z9tn_KQc6GdA-P4VSRigBygV65OEd2Vv3YDhww"}
~~~~

Frame 2

~~~~
{
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 2,
    "TreePosition": 360}}

{
  "PayloadDigest": "8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZD
  lZeaWQlBsYhOu88-ekpNXpZ2iY96zTRI229zaJ5sw",
  "TreeDigest": "7fHmkEIsPkN6sDYAOLvpIJn5Dg3PxDDAaq-ll2kh8722kokk
  FnZQcYtjuVC71aHNXI18q-lPnfRkmwryG-bhqQ"}
~~~~


##Encrypted container

The following example shows a container in which all the frame payloads are encrypted 
under the same master secret established in a key agreement specified in the first frame.

Frame 0

~~~~
{
  "enc": "A256CBC",
  "kid": "EBQF-NTVG-C5H2-NRBY-MKJJ-42P7-SAOQ",
  "Salt": "nUaQgdC5Gu8j_FllSW9Wjg",
  "recipients": [{
      "kid": "MDRV-TDBP-FXUP-GBGD-3BNT-ATMX-HBHE",
      "epk": {
        "PublicKeyECDH": {
          "crv": "Ed25519",
          "Public": "XzfzgrwZ_JAhhdwWByh9iI4tCBShrpnwLTexRuzuQtE"}},
      "wmk": "hcFRYJbsX4lf_CoL4xpclRq7ppiIdRg0HmvfzcA1mdvcfw3wN_akfg"}],
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "DataEncoding": "JSON",
    "ContainerType": "List",
    "Index": 0}}

[Empty trailer]
~~~~

Frame 1

~~~~
{
  "enc": "A256CBC",
  "kid": "EBQF-NTVG-C5H2-NRBY-MKJJ-42P7-SAOQ",
  "Salt": "hxeyfTNwYFYNju8byFAyEw",
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 1}}

[Empty trailer]
~~~~

Frame 2

~~~~
{
  "enc": "A256CBC",
  "kid": "EBQF-NTVG-C5H2-NRBY-MKJJ-42P7-SAOQ",
  "Salt": "9K2ZH-M1gL1bZGKcfSHXxQ",
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 2}}

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
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "DataEncoding": "JSON",
    "ContainerType": "List",
    "Index": 0}}

[Empty trailer]
~~~~

Frame 1

~~~~
{
  "enc": "A256CBC",
  "kid": "EBQN-C2FZ-BR4F-HP45-QYX7-6N6X-SEXK",
  "Salt": "7dwNNakrq-utGSsY3KktRA",
  "recipients": [{
      "kid": "MDRV-TDBP-FXUP-GBGD-3BNT-ATMX-HBHE",
      "epk": {
        "PublicKeyECDH": {
          "crv": "Ed25519",
          "Public": "I0tiSVF6M3nJgv6Kr2C7ZJiDfW96Jm-cl6h8Q_Yi6Mo"}},
      "wmk": "guWJ-UWn7Nm3hoai_SSgG7i2WoM6FE-kuDdlv6G4NgogYCnnpKzpbA"}],
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 1}}

[Empty trailer]
~~~~

Frame 2

~~~~
{
  "enc": "A256CBC",
  "kid": "EBQG-S2U3-PVUU-LALI-6U5Z-XUMW-RVDL",
  "Salt": "aukfBXXGIX2MBY6ED7ys9w",
  "recipients": [{
      "kid": "MDRV-TDBP-FXUP-GBGD-3BNT-ATMX-HBHE",
      "epk": {
        "PublicKeyECDH": {
          "crv": "Ed25519",
          "Public": "w5kcUG7_Jyx7TJBNRbXaYrseYKy8ZAj3nRyasDCj010"}},
      "wmk": "MhxflUOnWBIFcFSiU9ty_RKckSnZMkzJN9uKmf2G7dOwYu34J4l9QQ"}],
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 2}}

[Empty trailer]
~~~~


