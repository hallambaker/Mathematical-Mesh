
# key

````
key    
    earl   Return a randomized secret value and locator as UDFs
    nonce   Return a randomized nonce value formatted as a UDF Nonce Type
    recover   Recover a secret value from the shares provided
    secret   Return a randomized secret value formatted as a UDF Encryption Key Type.
    share   Split a secret value according to the specified shares and quorum
````

The Key command set contains commands that operate on cryptographic keys and
nonces.


# key nonce

````
nonce   Return a randomized nonce value formatted as a UDF Nonce Type
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /bits   Secret size in bits
````


The `key nonce` command returns a randomized nonce value formatted as a UDF nonce type.

Nonce values should be used when it is important that a value be unpredictable but 
does not need to be kept secret. For example, the challenge in a challenge/response
protocol.


````
>key nonce
ND6K-4V5M-WMTG-FVAL-72XE-ZPUK-F23A
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ND6K-4V5M-WMTG-FVAL-72XE-ZPUK-F23A"}}
````


# key secret

````
secret   Return a randomized secret value formatted as a UDF Encryption Key Type.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /bits   Secret size in bits
````

The `key secret` command returns a randomized secret value formatted as a UDF Encryption 
key type.


````
>key secret
EDGJ-IBRS-MVP2-ZMDS-MPLP-4A4B-3HAA
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDGJ-IBRS-MVP2-ZMDS-MPLP-4A4B-3HAA"}}
````


# key earl

````
earl   Return a randomized secret value and locator as UDFs
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   Encrypt data for specified recipient
    /bits   Secret size in bits
````

The `key earl` command returns a randomized secret value and a fingerprint of the secret 
value, formatted as a UDF Encryption key type and Content Digest Type


````
>key earl
ED5O-JDQF-EVYM-6E7A-PJM7-VK2B-LFKT-56
MCZF-2HFB-TGTZ-U4H6-U4OL-6D2E-BO2G-T4MR-EZFU-GUFL-RK2H-BFWG-BBCF-7K6U
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ED5O-JDQF-EVYM-6E7A-PJM7-VK2B-LFKT-56",
    "Identifier": "MCZF-2HFB-TGTZ-U4H6-U4OL-6D2E-BO2G-T4MR-EZFU-GUFL-RK2H-BFWG-BBCF-7K6U"}}
````

# key share

````
share   Split a secret value according to the specified shares and quorum
       The parameter to share
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   Encrypt data for specified recipient
    /bits   Secret size in bits
    /quorum   The number of shares required to recover the secret
    /shares   The number of shares to create
````

The `key share` command returns a randomized secret value and a set of shares for the secret
formatted as a UDF Encryption key type and Share types


````
>key share
ECVW-NEF6-TRU2-VMQW-XNZX-V7IQ-Y5ZQ
MCOM-OP2I-R2WY-DMO2-QT7F-3E3H-PAMX-ORCH-2COT-VHYM-AW7E-BDSE-NOPA
SAQN-2OD4-7X2C-P7NK-OEMF-CPCZ-4UPB-U
SAQQ-6CTJ-HVF6-MUFC-ZN2S-57NW-XF2I-4
SARE-BXCV-PSR2-JI43-EXJA-ZPYT-RXFT-K
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECVW-NEF6-TRU2-VMQW-XNZX-V7IQ-Y5ZQ",
    "Identifier": "MCOM-OP2I-R2WY-DMO2-QT7F-3E3H-PAMX-ORCH-2COT-VHYM-AW7E-BDSE-NOPA",
    "Shares": ["SAQN-2OD4-7X2C-P7NK-OEMF-CPCZ-4UPB-U",
      "SAQQ-6CTJ-HVF6-MUFC-ZN2S-57NW-XF2I-4",
      "SARE-BXCV-PSR2-JI43-EXJA-ZPYT-RXFT-K"]}}
````


# key recover

````
recover   Recover a secret value from the shares provided
       Share value #1
       Share value #2
       Share value #3
       Share value #4
       Share value #5
       Share value #6
       Share value #7
       Share value #8
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `key recover` command combines the specified set of share to recover the original secret 
value as a UDF Encryption key type.


````
>key recover SAQN-2OD4-7X2C-P7NK-OEMF-CPCZ-4UPB-U SARE-BXCV-PSR2-JI43-EXJA-ZPYT-RXFT-K
ECVW-NEF6-TRU2-VMQW-XNZX-V7IQ-Y5ZQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQN-2OD4-7X2C-P7NK-OEMF-CPCZ-4UPB-U SARE-BXCV-PSR2-JI43-EXJA-ZPYT-RXFT-K /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECVW-NEF6-TRU2-VMQW-XNZX-V7IQ-Y5ZQ"}}
````


