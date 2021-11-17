
Alice added Bob to groupw@example.com as a member. This resulted in Bob receiving the
invitation described in section ??? and the following access entry being added
to the Access catalog of the group account:

~~~~
{
  "CatalogedAccess":{
    "Capability":{
      "CapabilityDecryptServiced":{
        "Id":"MD6W-KDFX-PSF7-5NBQ-WFJE-34PL-7JWQ",
        "Active":true,
        "GranteeUdf":"bob@example.com",
        "EnvelopedKeyShare":[{
            "enc":"A256CBC",
            "kid":"EBQL-CGOH-LPTR-WNYL-RXDU-7LK4-G4GZ",
            "Salt":"xUeBS0V_Z4GJV9s2N3OAPw",
            "recipients":[{
                "kid":"MBBR-KLL4-YRFX-K63E-2DCT-6UGQ-Z5JC",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"2hYs3byJFTbFtPgYaBplYVgtBJOuYjMSvi8
  BcCEFoOy8JRaOWg37ygj8m4hUjoZhPlC6bZ-MQEoA"}},
                "wmk":"9iJlp63lB9Og5mog603Of1NJtrVsTFCC2GzUKDLv-P
  Hb3Dn9tNTepw"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjEtMTAtMjVUMTU6NDk6MDBaIn0"},
          "hY6vVvnbC6y-a5ULJNUh0aVv_YEIu1BRiTDS-gBY6nKX7tqs_oIMFR
  Qipj8bUHdtE46dYu2Ud0ue88CMOX3qsLTDP_5d7UgqKUk5yfr3nlSJzlKU7u3W7YF
  b9tOW-svw3sE4UncLN7vJ5V90bF9DUS_xek8s9SxnyeZxWY5z5GvCTJr0TxCO5hFh
  FR6Bwv2cwqG9eqyFhWCu4GrrgLUk-fk5rOdF9KTZW6g0wqg0xTUFDuY4tfTTwzp4N
  iffzB2rj88nOkvvW-6SwVVrExLY5E4l-7ClfnlBH-20Zz-z8faYy85gDl6zVGDyYd
  JelTPlRmlbM_tsW2NRyKNz4WCAreq_QZx3XBBqoKNi1CA4GdO2qiMOOE6NigTKB9C
  Rlc4EzUtwCU8Zdw6yUWxxCEtHoXVh8OpvWixTdmznouCLyDUVsvfx1dM-PIrSfbEl
  _K2v9IHZrtcgh5vahoaWY60ELJYLnARsvnWchyfZCgZMNbknDYiAyNAwxI_Wgm3xo
  7vyTkF0ARe0-RWofxYlyzDcFk2yA6-edTAq0PHiOFSl3j90hVmcaWC903uI_keNGU
  4egZ370UCWrFUz-O5woKJDllJu-GubgpJ5YTc628m-_6ASaVEw9G4uGiIx0oCcSqR
  SENXe9tnD90HkaZCCZhz2Cscfm8uRAVG9wasFrDjaKxUwf6N3nVjOmFVJwBl_G14i
  go4PmNHI2dgJBLqxlof76g"
          ]}}}}
~~~~

The private key (in this case a key share) is encrypted under the service key.

To make use of the access entry, a request is made that specifies the key share
to be operated on and the public key parameters to perform the agreement with.

The request payload:


~~~~
{
  "OperateRequest":{
    "AccountAddress":"groupw@example.com",
    "Operations":[{
        "CryptographicOperationKeyAgreement":{
          "KeyId":"MD6W-KDFX-PSF7-5NBQ-WFJE-34PL-7JWQ",
          "PublicKey":{
            "PublicKeyECDH":{
              "crv":"X448",
              "Public":"mNrpSHZmFqcMBHYAwEyp0tUshHkBafWjCe3mDMcoV
  PIuqBhrbj5ZIpQdgfcS1BWgb5cwGXmIEPcA"}}}}
      ]}}
~~~~


The service checks to see if the request is authorized and if so, performs the
operation and returns the result:


~~~~
{
  "OperateResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "Results":[{
        "CryptographicResultKeyAgreement":{
          "KeyAgreement":{
            "KeyAgreementECDH":{
              "Curve":"X448",
              "Result":"JmEGQN2398IzXNI4j1CG4ZWtLVk1u8P8SnBw1_cEQ
  Os5INanZUEewbDxEQp5ocl_QP0EnBoSdUMA"}}}}
      ]}}
~~~~

