

# mesh

````
mesh    Commands for creating and managing a personal Mesh
    create   Create new personal profile
    escrow   Create a set of key escrow shares
    export   Export the specified profile data to the specified file
    get   Describe the specified profile
    import   Import the specified profile data to the specified file
    list   List all profiles on the local machine
    recover   Recover escrowed profile
````

# mesh create

````
create   Create new personal profile
    /account   New account
    /service   New service
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /new   Force creation of new device profile
    /dudf   Device profile fingerprint
    /did   Device identifier
    /dd   Device description
    /alg   List of algorithm specifiers
````

The `profile create` command creates a new Mesh master profile and 
(optionally) registers it with a Mesh service.

By default, the default device profile of the current account is registered as an
administrator device of the newly created profile. If no default device exists, a 
new device profile is created. The `/new` option may be used to force a new device
profile to be created.

The `/did` and `/dd` options specify an identifier and description for the device if
a new profile is created. Otherwise, platform defaults are used.

Cryptographic algorithms to be used for the signature and encryption algorithms 
may be specified using the `/alg` option.


````
Alice> mesh create
Device Profile UDF=MDMK-3WV2-JWE5-VZSE-LHSV-VC5R-A7X2
Personal Profile UDF=MC6F-FW6P-LHO5-DS4P-QUBZ-3V7S-6QX7
````

Specifying the /json option returns a result of type ResultCreatePersonal:

````
Alice> mesh create /json
{
  "ResultCreatePersonal": {
    "Success": true,
    "DeviceUDF": "MDMK-3WV2-JWE5-VZSE-LHSV-VC5R-A7X2",
    "CatalogedDevice": {
      "UDF": "MDMK-3WV2-JWE5-VZSE-LHSV-VC5R-A7X2",
      "DeviceUDF": "MBDO-IXWT-KLFJ-D56Z-EVKL-6PCL-PAPB",
      "EnvelopedProfileDevice": [{
          "dig": "S512",
          "cty": "application/mmm"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUJETy1JWFdULUtMRkotRDU2Wi1FV
  ktMLTZQQ0wtUEFQQiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogIkt2ZFdYR3QyUkZibUF2UXIyczFtX2l
  3VU0ySVBvYjNtZ0pHelhjcEdPSzZNSmg2N0xLYWYKICBYX2JyRk56b3V1TTZPb
  EVZSW96a3NxMkEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUFYNC1YM0tELUVFWFctSUVZUC1VSVJBLVhTRUstQVdUSCIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogIm9ZMlZmMzRWQVZTaWZwQ05JekNhV1AwU3VlTnFjMTUxb0t1eTV6OTV
  Nc1NKYzZRenc3ekgKICB2R3B2NFEzb2hYYjNCd1laa2lKQXVka0EifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1CQUwtNzZ
  OUS0zSUs0LUxCU1QtRDM0Ti1VTFBGLVo3WVIiLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJGUWoxVi1DQ
  XR5VmFDbjhZMFlQNXhfTHg3a2NLYXVMMzVJd3BVNlpWUDVoM181dWdqbHV4CiA
  gWDgzbXl4amVUQ2JwbVBhZHQ3NFlTQWVBIn19fX19",
        {
          "signatures": [{
              "signature": "cD_7R412Rm5r7_SMyvbbpA474f8tPPEySDGaa_83xsH1x6hCS
  wBN_TEVCxD6Rwq0-e50VuEnvEAA68AsVwJUslKtyZCl25HL6HKlIdqnffxuPAT
  RtpwV59nKaoJXCiJTqmk0695O6qDcYOq44FFQgBQA"}],
          "PayloadDigest": "4k421iiczL0by7HkyNWalXEluAvPb4mi8Ea5gVKhVKdZQ
  eBtOKpNfimCGnKnAqb0KnKANTYWYVkP4pM94ZwxwQ"}],
      "EnvelopedConnectionDevice": [{
          "dig": "S512"},
        "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNRE1LLTNXVjItSldFNS1WWlNFLUxIU1YtV
  kM1Ui1BN1gyIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiVFRwaWQ5OUh1N21VWjMySjAwS0JVNEpUaGd
  pdWZ0TXFjNTluNHljclhReDBfNlJxX2N4MQogIFNFLW8wZW5KUnhsYVppdmpkb
  2dCdjBPQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNQ1VKLVBXQUMtVE9aWi1USlBVLVVUTVEtT0xBUi1ZRllEIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiSXM3Y19URjJseWc2TzkzbWpUZl9iblFpUHVzSUt5WkFuR0Q5S0N6UVVwMGJ
  RRTQ5ZkRwVQogIGlBUy1Pa2ZRUFIydzI4cmVEazJObk0yQSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTURWSS1IVlVILVk
  1UE0tVTJLMi1GTVNGLUEyRlAtRE9QUiIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIlNKUExzVFZ4Q2Q5b
  XlVNGhjcEJxZTdkRXZFcjJBbU44UWJWUGpEOUF3bnc3R29KNzFKVmYKICAwTXN
  OVC15U3YxOU9PM1lBVVdxMlR2NkEifX19fX0",
        {
          "signatures": [{
              "signature": "de5loewue9NNAKSrlK0jVJA-GaXsiorKgDtEkAOKlfuJYW8UB
  V5QAyv-mAN0vSVpYdbfdwflu5EAXOvaZQTTU1hT_AFc-e4annPy4B78WsQdQBN
  BFgiFiwzSiPceUkgGMIYQRhwk0JQA5FRW174Y2C4A"}],
          "PayloadDigest": "xQLg7mkOG20KmVzEOMZJryq246KxxHJv-Zyi-q_ITPLXr
  aYemXk61ox4XUarj7Kt0ucfS_4pSL5TPNZ68ElAwA"}],
      "EnvelopedActivationDevice": [{
          "enc": "none",
          "Salt": "mb-Ahxr90ifpiNFqLIZCoA",
          "cty": "application/mmm",
          "recipients": [{
              "kid": "MAX4-X3KD-EEXW-IEYP-UIRA-XSEK-AWTH",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "p5lLNgzUpLZHQWgarLGqPDWTifCpIuU8vEnHygDc4kTTdjhrc5xT
  fWI0KxJaAPx8-cyGg9bEDSmA"}},
              "wmk": "pqampqampqY"},
            {
              "kid": "MDNU-VYX5-RNPU-XOSX-3VRO-IROL-V6XE",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "HMlHUdCRscaDb381VJ0enhoKJPUPNB0K-63-03MNi12jsWyOtmLP
  CbfI5STSxffVj3-MiXRLm7MA"}},
              "wmk": "pqampqampqY"}]},
        "ewogICJBY3RpdmF0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNRE1LLTNXVjItSldFNS1WWlNFLUxIU1YtV
  kM1Ui1BN1gyIiwKICAgICAgIkJhc2VVREYiOiAiTUJETy1JWFdULUtMRkotRDU
  2Wi1FVktMLTZQQ0wtUEFQQiIsCiAgICAgICJPdmVybGF5IjogewogICAgICAgI
  CJQcml2YXRlS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAo
  gICAgICAgICAgIlByaXZhdGUiOiAiWWhMWGR3Vkh1SVVRLXZwcjRqa2t2UU1DN
  l9Bdzg0Qy1Mby1LZllPbVRnWGFGSW9JYm8xCiAgYVRPOE5HZ0FWNGU3WGZJM3N
  LdXN6RVNRIn19fSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVURGI
  jogIk1DVUotUFdBQy1UT1paLVRKUFUtVVRNUS1PTEFSLVlGWUQiLAogICAgICA
  iQmFzZVVERiI6ICJNQVg0LVgzS0QtRUVYVy1JRVlQLVVJUkEtWFNFSy1BV1RII
  iwKICAgICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjo
  gewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0Z
  SI6ICJ5X1FWSGZON25LR2EwMVlTYjZielNKTzg3aV82QUZTT1UycEZpWWU1V2s
  4UDJqTHRQVXAKICBYRmd0dlFOR0FBVE1RSUllalhlM184alUifX19LAogICAgI
  ktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1EVkktSFZVSC1
  ZNVBNLVUySzItRk1TRi1BMkZQLURPUFIiLAogICAgICAiQmFzZVVERiI6ICJNQ
  kFMLTc2TlEtM0lLNC1MQlNULUQzNE4tVUxQRi1aN1lSIiwKICAgICAgIk92ZXJ
  sYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjogewogICAgICAgICAgI
  mNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0ZSI6ICItbWtnQ3I0ejR
  5NThpWHpYbkVrWHRYV21PTTI4b21nQUxiTEhkNnV4a1VpODBjVkh5LU0KICBjT
  lMxRm5odEx2SF9HcGM2dmF6YndNU3MifX19fX0"]},
    "MeshUDF": "MC6F-FW6P-LHO5-DS4P-QUBZ-3V7S-6QX7",
    "ProfilePersonal": {
      "KeyOfflineSignature": {
        "UDF": "MC6F-FW6P-LHO5-DS4P-QUBZ-3V7S-6QX7",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "DdjdGqBf48plpJ6fCRZBmWI94cYykSC3-gU4P8tcov4UCO3Q-y76
  D6esFt0gT-7Ca9sDhtqT0lGA"}}},
      "KeysOnlineSignature": [{
          "UDF": "MBWO-SUGG-DKWZ-WIYK-N7SS-VPOR-57QF",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "Wyok522ySthWuXUoTOG1wvKowEX3Du34nMODk4FuiCCdVU4KYNdE
  TKaPyVtvUwOJb40cVZ9O5h4A"}}}],
      "KeyEncryption": {
        "UDF": "MDNU-VYX5-RNPU-XOSX-3VRO-IROL-V6XE",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "mXjjT1-u3aEZ54JBONHwoLq5UV8YBGiy53li84xqRIsza9Jt4ko1
  SQlHPTinfHZhOR4YQtc7yGwA"}}}}}}
````


# mesh escrow

````
escrow   Create a set of key escrow shares
       <Unspecified>
    /alg   List of algorithm specifiers
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /quorum   <Unspecified>
    /shares   <Unspecified>
````

The `profile escrow` command 


````
Alice> mesh escrow
ERROR - The cryptographic provider does not permit export of the private key parameters
````

Specifying the /json option returns a result of type Result:

````
Alice> mesh escrow /json
{
  "Result": {
    "Success": false,
    "Reason": "The cryptographic provider does not permit export of the private key parameters"}}
````

# mesh export

````
export   Export the specified profile data to the specified file
       <Unspecified>
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile export` command 


````
Alice> mesh export profile.dare
````

Specifying the /json option returns a result of type ResultMachine:

````
Alice> mesh export profile.dare /json
{
  "ResultMachine": {
    "Success": true,
    "CatalogedMachines": []}}
````

# mesh get

````
get   Describe the specified profile
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile get` command 


````
Alice> mesh get
````

Specifying the /json option returns a result of type ResultMachine:

````
Alice> mesh get /json
{
  "ResultMachine": {
    "Success": true,
    "CatalogedMachines": []}}
````




# mesh import

````
import   Import the specified profile data to the specified file
       <Unspecified>
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile import` command 


````
Alice4> mesh import profile.dare
````

Specifying the /json option returns a result of type ResultFile:

````
Alice4> mesh import profile.dare /json
{
  "ResultFile": {
    "Success": true}}
````

# mesh list

````
list   List all profiles on the local machine
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /mudf   Master profile fingerprint
````

The `profile list` command 


````
Alice> mesh list
````

Specifying the /json option returns a result of type ResultMachine:

````
Alice> mesh list /json
{
  "ResultMachine": {
    "Success": true,
    "CatalogedMachines": []}}
````


# mesh recover

````
recover   Recover escrowed profile
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /file   <Unspecified>
    /verify   <Unspecified>
````

The `profile recover` command 


````
Alice> mesh recover $TBS $TBS /verify
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
Alice> mesh recover $TBS $TBS /verify /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

