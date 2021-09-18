
Alice added Bob to groupw@example.com as a member. This resulted in Bob receiving the
invitation described in section ??? and the following access entry being added
to the Access catalog of the group account:

~~~~
{
  "CatalogedAccess":{
    "Capability":{
      "CapabilityDecryptServiced":{
        "Id":"MDXH-YJVV-NUT4-DSTD-OKEK-JSLV-GN23",
        "Active":true,
        "GranteeUdf":"bob@example.com",
        "EnvelopedKeyShare":[{
            "enc":"A256CBC",
            "kid":"EBQP-5HJP-7EZ4-ZBHS-K4I7-7WHU-Q3B3",
            "Salt":"rtsHXpYdcx4P1vczdS9sDg",
            "recipients":[{
                "kid":"MAKQ-HVRX-WMDV-XWLH-WFVU-CSVP-J542",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"E1Z5GFK0mMniCl9bXtRLEs7NpDa98EPBVvR
  ckqvyOsJ1E00bZBc_DtYfMFRksIELZl2zS-F8U6EA"}},
                "wmk":"gGi-BOqweSPILC2JeteMAJy6vhn0PHVJbxeADnIC6m
  KEi4yYsxpCYg"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjEtMDktMThUMTg6NDY6NTdaIn0"},
          "8RkxA2g46pru_yZqmpS2omBBvJ-ymvVwqTakWE9Mvz-AYZAqoKjo4T
  nULDaEWI_WwXheZ0iwHpzbzRQOcubVuee8Ak6_HDrH1K8NUut5PmF4aUOqF9sQ5QK
  yVZXx5hdXSRVqQ6Nv7fgSUWCcMnbZaaSMdYyYmzTlNf08FY35vcVcXJ2BQonKT7B5
  e36aUX3_oxKSf2hdqMXQN3hMZSqHOwdgoNJYfja69pg_G0cwmuDsCo-1BLgoOvMEo
  0pEu4ie_fscbvWOdvazE4OMdue6LOg_YMumW5p_ufxrmW1bihyHENMLJbvPeDOnoR
  QVkcyo5h7kLSK-adBOxS0Dchob__BEYwRZItvzJdCMfBl0N4MfghLIUI59kHlbKp4
  _P_MOs-v6gy377Fe-IeD1bpBxdqNhgdqGX7rF74QaWGIs3RtUHcrihhkBpE7h0HWE
  AM9BTc-PqqFY1inVVN-dTKyPDJhtN55oa-7isOAoNZF0HWpwGT54ZDsfc46anI-7U
  sVhNQSpYkhobeF1VgSWamakBiSvcbbKARBnsii6j7xAjPrQJeKSbpPi-1hdDWK9Gc
  xG4tu_7lv1ORlalKUrJsD0DQoE6yUj-n3yLDdjpW8b2k3TpA70h7cl0phBCx1S39L
  TSTASG2Npg7aNqfDHkxXPe09aEYmbrULJddUBvVCaeblsWll9b5xxGLKwTzhnYG_o
  VNfx_aBp0ZD5s8w7hRCdbg"
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
          "KeyId":"MDXH-YJVV-NUT4-DSTD-OKEK-JSLV-GN23",
          "PublicKey":{
            "PublicKeyECDH":{
              "crv":"X448",
              "Public":"LMNqJujgtlnN2HG_4bgicB_S_y1rOvelPkSCAh3kb
  2pNOUWvIWQCNFDKjnuJFRzebr-q1V-a840A"}}}}
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
              "Result":"y10kf37FKIC_A5jA8iYRq_3bBsKDBAG_pYDYGs5F6
  Y6Ck-cSmf7RKndqeXtc63w6yLiwIboiERGA"}}}}
      ]}}
~~~~

