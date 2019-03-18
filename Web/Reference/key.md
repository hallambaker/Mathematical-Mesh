
# key

````
key    Key operations.
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
NBTT-NB6C-DPXI-DDPX-X5T6-DBKA-J2GA
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NBTT-NB6C-DPXI-DDPX-X5T6-DBKA-J2GA"}}
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
EC2U-OMMU-OISE-BUYM-T3FX-CBPJ-A4KA
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EC2U-OMMU-OISE-BUYM-T3FX-CBPJ-A4KA"}}
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
EDNK-UHTM-7YXL-WKPF-R37Z-3EB6-PGFC-Z5
MDMO-SGRK-NIFK-GC2Z-O2JL-T2YG-MMEG-JQSZ-BBHL-KSGA-ZQVQ-SDG2-7GE3-WWQY
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDNK-UHTM-7YXL-WKPF-R37Z-3EB6-PGFC-Z5",
    "Identifier": "MDMO-SGRK-NIFK-GC2Z-O2JL-T2YG-MMEG-JQSZ-BBHL-KSGA-ZQVQ-SDG2-7GE3-WWQY"}}
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
EC6P-HEAP-TJT5-HTFT-D22E-VTB3-CDSQ
MAI4-TOFA-PW2P-3LCR-UTBH-GPIG-6YIL-YBEI-GMF6-G4I6-PH5U-5TUN-XVUA
SAQL-FS4Y-TEJY-KCES-EAJ5-FWBX-FQ75-K
SAQ2-RI5B-EKGK-EPKX-RUEP-CZNC-DVXM-K
SARJ-465J-VQC3-64Q4-7H7A-74YN-B2O3-K
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EC6P-HEAP-TJT5-HTFT-D22E-VTB3-CDSQ",
    "Identifier": "MAI4-TOFA-PW2P-3LCR-UTBH-GPIG-6YIL-YBEI-GMF6-G4I6-PH5U-5TUN-XVUA",
    "Shares": ["SAQL-FS4Y-TEJY-KCES-EAJ5-FWBX-FQ75-K",
      "SAQ2-RI5B-EKGK-EPKX-RUEP-CZNC-DVXM-K",
      "SARJ-465J-VQC3-64Q4-7H7A-74YN-B2O3-K"]}}
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
>key recover SAQL-FS4Y-TEJY-KCES-EAJ5-FWBX-FQ75-K SARJ-465J-VQC3-64Q4-7H7A-74YN-B2O3-K
EC6P-HEAP-TJT5-HTFT-D22E-VTB3-CDSQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQL-FS4Y-TEJY-KCES-EAJ5-FWBX-FQ75-K SARJ-465J-VQC3-64Q4-7H7A-74YN-B2O3-K /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EC6P-HEAP-TJT5-HTFT-D22E-VTB3-CDSQ"}}
````


