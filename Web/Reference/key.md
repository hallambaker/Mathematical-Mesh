
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
NBBL-AYRC-MFVH-XPGG-MWYF-CKRF-VTUQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NBBL-AYRC-MFVH-XPGG-MWYF-CKRF-VTUQ"}}
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
EBS7-A2XV-32CU-4WTA-LZBY-DY42-K3SA
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EBS7-A2XV-32CU-4WTA-LZBY-DY42-K3SA"}}
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
EAQB-56NM-2GKA-ONXH-FU6Y-G23W-SJ3W-M6
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAQB-56NM-2GKA-ONXH-FU6Y-G23W-SJ3W-M6",
    "Identifier": "MDYI-XTRB-NVZA-AKIQ-5KEG-4TFH-QJUR-OQVC-UNUT-4QWI-IUF5-VXJO-7EF2-APWM"}}
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
ECHB-MJGP-NEOL-T65F-PN2N-UA6Q-BTTA
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECHB-MJGP-NEOL-T65F-PN2N-UA6Q-BTTA",
    "Identifier": "MB6E-XRXU-FKVX-WTGQ-P77S-UCXC-6M7E-4RHT-K2OF-LEJX-NEWZ-6FTJ-BFQA",
    "Shares": ["SAQA-GR2E-4KS3-LBUH-KIOI-34XM-3GGZ-C",
      "SAQX-Q6DE-6XRE-4UYS-7262-OC6V-4MHG-6",
      "SARO-3KMF-BEPO-OH46-VNPM-AJF6-5SHU-2"]}}
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
    /key   Encrypt data for specified recipient
````

The `key recover` command combines the specified set of share to recover the original secret 
value as a UDF Encryption key type.

**Missing Example***


