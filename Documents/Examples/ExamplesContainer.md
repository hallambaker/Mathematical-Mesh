The data payloads in all the following examples are identical, only the
authentication and/or encryption is different. 

* Frame 0 is omitted in each case

* Frame 1..n consists of 300 bytes being the byte sequence 00, 01, 02, etc. 
repeating after 256 bytes.

For conciseness, the wire format is omitted for examples after the first, except
where the data payload has been transformed, (i.e. encrypted).


##Simple container

Here the simple container:

~~~~
f4 2c 
f0 2a 
  7b 0a 20 20 22 49 6e 64   65 78 22 3a 20 30 2c 0a 
  20 20 22 43 6f 6e 74 61   69 6e 65 72 54 79 70 65 
  22 3a 20 22 4c 69 73 74   22 7d 
2c f4 
f5 01 40 
f0 0f 
  7b 0a 20 20 22 49 6e 64   65 78 22 3a 20 31 7d 
f1 01 2c 
  00 01 02 03 04 05 06 07   08 09 0a 0b 0c 0d 0e 0f 
  10 11 12 13 14 15 16 17   18 19 1a 1b 
  ...
  10 11 12 13 14 15 16 17   18 19 1a 1b 1c 1d 1e 1f 
  20 21 22 23 24 25 26 27   28 29 2a 2b 
40 01 f5 
[EOF] 


~~~~

The header values are:

Frame 0

~~~~
{
  "ContainerHeader": {
    "Index": 0,
    "ContainerType": "List"}}
~~~~

Frame 1

~~~~
{
  "ContainerHeader": {
    "Index": 1}}
~~~~



##Payload and chain digests

Frame 0

~~~~
{
  "ContainerHeader": {
    "Index": 0,
    "PayloadDigest": "
z4PhNX7vuL3xVChQ1m2AB9Yg5AULVxXcg_SpIdNs6c5H0NE8XYXysP-DGNKHfuwv
Y7kxvUdBeoGlODJ6-SfaPg",
    "ChainDigest": "
FEHy24Y6cLModDXWH31kVc2a3TdhjXPooKHpLAb2JbsO1YQnJolmowXAYHhkOGY0
kg3jrKNTjds0myf4Dw1sdg"}}
~~~~

Frame 1

~~~~
{
  "ContainerHeader": {
    "Index": 1,
    "PayloadDigest": "
8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZDlZeaWQlBsYhOu88-ekp
NXpZ2iY96zTRI229zaJ5sw",
    "ChainDigest": "
7JaijhBvQUOjBiO1_Zt6NtJil8iB0rW9HeM_4iYooc_AaAfutlF0LLVY6PO7INB-
eztypyEqVzgMil9JkjtRGQ"}}
~~~~

Frame 2

~~~~
{
  "ContainerHeader": {
    "Index": 2,
    "PayloadDigest": "
8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZDlZeaWQlBsYhOu88-ekp
NXpZ2iY96zTRI229zaJ5sw",
    "ChainDigest": "
wJZFYd61nntCJ0Bv80l6-Cn-sR2u3iD0zCRjOLxje8dsKIuUnP4X1mgeNenNDBdX
ysrFs3vVAqkC-hfSAPF0Aw"}}
~~~~

Frame 3

~~~~
{
  "ContainerHeader": {
    "Index": 3,
    "PayloadDigest": "
8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZDlZeaWQlBsYhOu88-ekp
NXpZ2iY96zTRI229zaJ5sw",
    "ChainDigest": "
RORNZxIcM23cZtXPh9vuHhkgiGa_O4a0ZiU0ku2OK4dB974clvh5F0VZsX7IwVBa
yAG2nDTdqhyZ-qOnTRiumA"}}
~~~~


##Merkle Tree

Frame 0

~~~~
{
  "ContainerHeader": {
    "Index": 0,
    "TreePosition": 0,
    "PayloadDigest": "
z4PhNX7vuL3xVChQ1m2AB9Yg5AULVxXcg_SpIdNs6c5H0NE8XYXysP-DGNKHfuwv
Y7kxvUdBeoGlODJ6-SfaPg",
    "TreeDigest": "
FEHy24Y6cLModDXWH31kVc2a3TdhjXPooKHpLAb2JbsO1YQnJolmowXAYHhkOGY0
kg3jrKNTjds0myf4Dw1sdg"}}
~~~~

Frame 1

~~~~
{
  "ContainerHeader": {
    "Index": 1,
    "TreePosition": 0,
    "PayloadDigest": "
8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZDlZeaWQlBsYhOu88-ekp
NXpZ2iY96zTRI229zaJ5sw",
    "TreeDigest": "
fPTYagAvSDP_755jpFUs-Wq6cgvtr5vrFwW-E12vsrbq1ReNsGzp-V2XqzFPiWaU
ckACPjegD7ioe1bGzxoWQQ"}}
~~~~

Frame 2

~~~~
{
  "ContainerHeader": {
    "Index": 2,
    "TreePosition": 263,
    "PayloadDigest": "
8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZDlZeaWQlBsYhOu88-ekp
NXpZ2iY96zTRI229zaJ5sw",
    "TreeDigest": "
7fyKKQNLGEeHX1oCsV8NtOdPm615SkDnM1vkcexx2tOuVd5kkZIdLdsWRCLic9lu
TSsUN6D6_-c-8ftbhL9dJg"}}
~~~~

Frame 3

~~~~
{
  "ContainerHeader": {
    "Index": 3,
    "TreePosition": 263,
    "PayloadDigest": "
8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZDlZeaWQlBsYhOu88-ekp
NXpZ2iY96zTRI229zaJ5sw",
    "TreeDigest": "
b9ca9Pv-6fxUg-V3ulOhhRngxebkZCxyDmWhQUYeADmSvvPbjMcNTUJxdDpKlMPr
DBInSWMChinsc5s9Tv4byw"}}
~~~~

Frame 4

~~~~
{
  "ContainerHeader": {
    "Index": 4,
    "TreePosition": 1398,
    "PayloadDigest": "
8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZDlZeaWQlBsYhOu88-ekp
NXpZ2iY96zTRI229zaJ5sw",
    "TreeDigest": "
g1hQeWJgDlNoTSGfMb6NhQk5-p6iaAI2_GiAhBM-F2Cp3UvJ7AR_bC2Drp5YElGX
AzC2K5qZ30l7j2D-jqykFw"}}
~~~~

Frame 5

~~~~
{
  "ContainerHeader": {
    "Index": 5,
    "TreePosition": 1398,
    "PayloadDigest": "
8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZDlZeaWQlBsYhOu88-ekp
NXpZ2iY96zTRI229zaJ5sw",
    "TreeDigest": "
p89BhjJAgMMoSrOmot6oaBGa6Dgz-zogZjZ9mm1Iz4yLHxm97nWAIBaZFiC1XkuC
oP-tr3tag_rHoZhgQV8_PQ"}}
~~~~

Frame 6

~~~~
{
  "ContainerHeader": {
    "Index": 6,
    "TreePosition": 2537,
    "PayloadDigest": "
8dyi62d7MDJlsLm6_w4GEgKBjzXBRwppu6qbtmAl6UjZDlZeaWQlBsYhOu88-ekp
NXpZ2iY96zTRI229zaJ5sw",
    "TreeDigest": "
HEA7EeUGfSjZqjmN3PDp0FVbnixBBXfSQAYm_rNPHVWJVMDu3SfmxKvN_yBTtMXk
-Jad9cyXDKsecLNHLyoQWg"}}
~~~~


##Signed container


##Encrypted container


