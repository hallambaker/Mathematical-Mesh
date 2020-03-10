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
    "Index": 0,
    "ContainerType": "List"}}

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
    "Index": 0,
    "ContainerType": "Chain"}}

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
    "Index": 0,
    "ContainerType": "Merkle"}}

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
    "Private":"P7ZGsbYzQAT47Ht6QgYlMnun7rbYhyuWZFnmmbvRMGI"}}
~~~~

The container headers and trailers are:

Frame 0

~~~~
{
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "DataEncoding": "JSON",
    "Index": 0,
    "ContainerType": "Merkle"}}

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
  "Salt": "fcHcotFCsQli4KDqrTAi5Q",
  "recipients": [{
      "kid": "MAUC-ZTKR-N3D5-TZCI-K6IR-5Q5C-VKU2",
      "epk": {
        "PublicKeyECDH": {
          "crv": "Ed25519",
          "Public": "PVUAJYFQFVgLzO49lkZCL7pe5qj-6s3T7MHx92AZ8ng"}},
      "wmk": "3ExPlpasWGqw-_z7EGIJM8-rWZgNwt8_bd9inlE-ZWYB5Ef7sY68sQ"}],
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "DataEncoding": "JSON",
    "Index": 0,
    "ContainerType": "List"}}

[Empty trailer]
~~~~

Frame 1

~~~~
{
  "enc": "A256CBC",
  "Salt": "lmMrQYd-BjfKfhskOHZliw",
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 1}}

[Empty trailer]
~~~~

Frame 2

~~~~
{
  "enc": "A256CBC",
  "Salt": "2zLKKKsoKkMeTB8lbPXH-g",
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 2}}

[Empty trailer]
~~~~


Here are the container bytes. Note that the content is now encrypted and has expanded by
25 bytes. These are the salt (16 bytes), the AES padding (4 bytes) and the 
JSON-B framing (5 bytes).

~~~~
f5 01 e5 
f1 01 ce 
f0 10 
f0 00 
e5 01 f5 
f5 01 b0 
f0 7b 
f1 01 30 
b0 01 f5 
f5 01 b0 
f0 7b 
f1 01 30 
b0 01 f5 


~~~~


The following example shows a container in which all the frame payloads are encrypted 
under separate key agreements specified in the payload frames.

Frame 0

~~~~
{
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "DataEncoding": "JSON",
    "Index": 0,
    "ContainerType": "List"}}

[Empty trailer]
~~~~

Frame 1

~~~~
{
  "enc": "A256CBC",
  "Salt": "47z0KQHD-eDI7aUcPUsovA",
  "recipients": [{
      "kid": "MAUC-ZTKR-N3D5-TZCI-K6IR-5Q5C-VKU2",
      "epk": {
        "PublicKeyECDH": {
          "crv": "Ed25519",
          "Public": "T8Mkrlmefhjx1OBtoirTQfX60UYX6FPjEBFnA1ow6Yo"}},
      "wmk": "92XvuomsbaG-TWHLe9xrwLzvJS7Dn5bkU5s5RqRSHbfnhNoN-0Cn0Q"}],
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 1}}

[Empty trailer]
~~~~

Frame 2

~~~~
{
  "enc": "A256CBC",
  "Salt": "ALTV-PlxDTV28RkhJ4wt8g",
  "recipients": [{
      "kid": "MAUC-ZTKR-N3D5-TZCI-K6IR-5Q5C-VKU2",
      "epk": {
        "PublicKeyECDH": {
          "crv": "Ed25519",
          "Public": "0gk_OnQKjLCYET-jv0rW963PsNGkXMfULPDZZ4TXCMk"}},
      "wmk": "vVxGQX3n0lJZ5Z1q1PYkax6tiJs8mWji0DYB4_Pj3_YNSKexnKCLnQ"}],
  "ContentMetaData": "e30",
  "ContainerInfo": {
    "Index": 2}}

[Empty trailer]
~~~~


