
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "PublicationId":"EBQM-KNOL-3JSA-7ODT-IDYR-4MIF-T372",
    "ServiceAuthenticate":"ADB6-LL6S-CFGJ-WEGN-ATQH-BIWP-C275",
    "DeviceAuthenticate":"AD5I-TWGR-5JLW-PYMH-6PQC-LVMO-MMBV",
    "MessageId":"NDMW-S56B-O3D3-NAK6-SKHF-3KHR-UCD7",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MAF6-JDZZ-VLXA-HV3Z-333W-OUS6-MKRG",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORE1XLVM1NkItTz
  NEMy1OQUs2LVNLSEYtM0tIUi1VQ0Q3IiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjItMTAtMThUMTI6NDg6MThaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiUHVibGljYXRpb25JZCI6IC
  JFQlFNLUtOT0wtM0pTQS03T0RULUlEWVItNE1JRi1UMzcyIiwKICAgICJTZXJ2aWN
  lQXV0aGVudGljYXRlIjogIkFEQjYtTEw2Uy1DRkdKLVdFR04tQVRRSC1CSVdQLUMy
  NzUiLAogICAgIkRldmljZUF1dGhlbnRpY2F0ZSI6ICJBRDVJLVRXR1ItNUpMVy1QW
  U1ILTZQUUMtTFZNTy1NTUJWIiwKICAgICJNZXNzYWdlSWQiOiAiTkRNVy1TNTZCLU
  8zRDMtTkFLNi1TS0hGLTNLSFItVUNENyIsCiAgICAiU2VuZGVyIjogImFsaWNlQGV
  4YW1wbGUuY29tIiwKICAgICJSZWNpcGllbnQiOiAibWFrZXJAZXhhbXBsZS5jb20i
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCDG-TS7T-UPDD-V667-OXSX-QJ5G-FQRZ",
            "signature":"AZPN7yQXHU7HGacLw1ggJW_huQ2Kx6JDuBhnraAA
  U7b-PFHBMqcLEExjp7uvP_wJRdOHx9vVZJuAvu9qpnOoH2uJpE7i-LHsonlgTSZH9
  _RqqOKXNzQvHhj81K3LecFAFige_yHZXP4aFpLDMVldLh8A"}
          ],
        "PayloadDigest":"UzMKbHTyfoSBf2pi03m-mgLhgFwb6e0qyYFYdV--
  MO5icQ_AxmcJCvoHT698416SI4qvEz749uiE1ZnNf8-AZQ"}
      ]}}
~~~~


The publication is found and the claim is accepted, the publication  is returned
in the response.


~~~~
{
  "ClaimResponse":{
    "CatalogedPublication":{
      "Id":"EBQM-KNOL-3JSA-7ODT-IDYR-4MIF-T372",
      "Authenticator":"EDXZ-IUXU-GCCB-5UD6-CVI6-P2VM-DJJ2-KFOR-2MZF
-KBFT-KJ2T-VLSZ-5UAC-O",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQO-CDBL-LUJ2-Z6BX-KZPG-MUHN-Y33K",
          "Salt":"kHA8EsOojCTci4giaqmN1Q",
          "recipients":[{
              "kid":"EBQM-KNOL-3JSA-7ODT-IDYR-4MIF-T372",
              "wmk":"ILbNKbCEfU5mY7AAOVa5YnsDmsDqwt1B8XcvuNJk9eNE
  4883axJMqg"}
            ]},
        "qUY6yGZc7Oka15XfdCEdUhms-ldQJV5j6lIIX5NDNV_JPSWhMYwfwtVR
  MRl3tO89xo6-8Fi5YjMlv9IkTWckXnCojOTa7CsL_bR_mgTcV0n2HTWFTFqmavqrn
  mb9eP_EbPXMva1r1oGay9dpC2QGWNKqCeiiA6dNA8JE4NqLwfU85VdmD-E8dDB3a-
  1BRFgvQ9TMO2SxwYnhcQSv3o-JvhePufvHpG6Mdlhrarx7I-XprBnmtVtYGe85pQa
  4mSVGj4Ziqq-c-okgM2imjgJBnDyMQwhNY3D_40FAtBR8cPDDBLG5BmLXO0clrLxJ
  _CNr1efRVu0Qh8J9s3PNx89FUeWcMvj-XyVYcjBxcnaFHfUYJlmSGzGy7WDQ7gAxz
  TE5SUrc88D2mtVEcLDUg296Mn2GlzeXgEsWWl18p_Zbk71Bd6So3qfBnGMYbOtMiS
  4V9bibdrWqwaYOUWW3Vqkt6zS2_6dFTaffb-8rZLz-AuHw3cTdIYkoqPm7iOXvvf7
  haAj9Y57mRx8H-rNoORn8L5dxqy8CE_22ZKHXWqMTGJr6KQpZRXRlBpXkUg-ctcHO
  NgjtkEQMDHvrRQScP5NCiRhjfNt2d1TWwYzeasTc1-EyFHPc_ieCiI7hpAxLToER0
  B8Q47aj2jRaea01V9mRQiolZXgYWijWHmotU5RPPAbfvrkbp_GiYpFV6Azi409TUB
  QgqCjCXjYP3VmJp1_2oxQB5C5Scz_LSeL8z9dgPFbE8l1ZSTEb_fh7KRjpqtTT-UI
  49OXxg2nvSedeBAluTKXZJS-9YodmjQWy9jtqUcFy_cMy9h7SxUx5SHVkM4b0-6GX
  8f-O5H4TmFu_QLLclti8kHpy-hcaaX3E9mJQdApfqVzHvbQnxWCaj3xRLqjo15ZqW
  m8qV0UVSYs0iue_zAjB88NS4nmnqswMjz6UVqVVCvg3Y2q6ZKejY-qxEwvMq9DZtk
  JXp-x8sP1fa7XdsCuHMuUEGRKj03pzw8fbFiinFp4T31G8V4N8CoTpMepUBok3M3l
  UJs27N6IqiJ023IPdz0NNf64BRXC4s3X3vIe2Tk6pT98Cu04G1oIgkftq3rSEnDgy
  STPitQm66PGyD-dtfkjB9fvVe9fuSMSjn9db8WuidkfZFlxRZLlat_0cdAdy0c7my
  4-Hn_wMIAvK8m_WQ9DLbwNhupkJWAtYiKLXiFzCAQX-35xr6VaUNDi3pRUBC8wcaU
  Xx8OohhftOZC0eMIRLGLiymvdBggClCz0an5a-OQezNBWLTNwGhC0IkgQHfBO5CII
  QBMQiHSiXeslVyoiERBJY8MvRGAg28lmj0FOzfyE8SeDNI9wKwREgRWH5oS4qeoCt
  Ls_fY8XMPQpjJyvpF5Ki2meoIfPAseAzimuomyFksbC00ZAxfUInjrk_12ejTW2Vq
  -mE-MrCE4ND1HifcODNTAKUHWQY-zO0tt4iXfI7oLcfJHA0WPocZ14i-2VZfyD_O1
  79kbAic2S5JNhmReSsHI_EzYYz3TwrQfbMsEDtu90KF8BlMa0QOJvY1hnvCnmNWnJ
  oPp5ZX8jJx-EYBxdhpQM2K5LmT7P-7VjQGY-1OmJ0NORnjqXtzJljgrX0B2HgzZqH
  Z0lU4vuqcO0okE2-PlyjZJvsbzOvbs6WnL5XLFpMKooJkIk-TlSh51SNkDEft5WpK
  kN-ToGyPOdDWRbaclHtks7HejZTUab6axL27Rqq8X2k1DJrKYz68JS18WOSujKtZ8
  culepBu-MR9tLi4nu1x9WE1vScAkzJTdh4r7lYt4QW7I9tSVEqGBiRs5xAhWcwA9T
  -PPq_9KhV6XMHoWiO3PWPO7-_P36qlskDiGgPRQiydUPiumxcJkY8SMnOKZhM-nSX
  ccZzNmD8QzQiZYHKYUl1zVYYDa0fl8U_9RIKyf8SSF12JjElr_CGrHVfsMSbh6LYF
  fY5DkeWq-Y57fkuNY9nIznzChShMzACZ0Sl79nCMLpnyJFzs28CGncmZBM56E2UNT
  nfBBk1dOo0-a_LvOPIh8GaHe29thDDO1lB23afKTbHvpI9Av5fk_t3vzEYq-PNbaI
  lE9-ANHZcDMhr24yX3QkwpQdMR5L1onozE8z9R25AvxRxiabXzK8qXNtTKcQLl3UG
  oD4lElYBsY31uj_V2ILJNcOZkexZW3V8qGdJoRM4yt4x9C4QA0BUPMhB_I5BJl3Mc
  8GKrJe-ucmsFlVQMTkFg_up7WmcDwS1PwBAu5DBTpsX9mzsKUYAKP2FCG25DDvN6l
  QPmcb5o-xEgSMku38JEXm_aSWpUlEad2dnFfHmKB1epJGYerhWCxJci8DC2kLbkIX
  ZYOqWltHnGupUYhHAP9J6jKTbxpG0u_eU7qF_rHZeiq5bR01F8ajLBkQQjwYj91ql
  Ua6oIeWzOoHZXraQnVMJ53f-xhR0HSdvNkNYFjaTkanshD0bIC01vNVOcDD_M8BZJ
  Jw4I7nZR49DouwytKs80Wdi55Vn1s7fAqodpIRNsjpzQQnONGUA9FV2Zhd6hMaoVU
  rjneak4ps1Rk_WgTbfHYpcDPK4StI3PQ67doNAbAkFH6KMvhZX386MtngfoPOaYM5
  EytpXC1Z9OT_Y3eE0fgTdbDbQZGQUHd7Sy9VmBqsyPwi2qM2UrZsT50_eO6KcZDIY
  N51jP7zXbF7t3y9-tnwIfF9lhDBRHonPyt4bZSiYI4TUNnES5MbBgJna7Lc7UPFye
  jGi8hbcaxwGN1D2wZ_k7CImFbtHraYRwuX37PRaAWYqHGte7R5wNUXoDPE_4BuCNx
  9S4obV5pwsPwEZU8tqHyPJsFVXw_M23yRzRsuRZ3zNKyT91AnjApgYOnm5drQdPdX
  cgkhl2oueebm3JEvP1W7v6C2JoxzjCwUr6XmVHqgYMVuPV1Jnw8X1B3f-ZGAQNAwe
  fGY1Os-LxDkw7kS596yvbIuZLIg56iFZqv0AKhIf1TUJ0npuxALK1YvhpOeVToCan
  XLTFV3lArI85NFuzQUCwwBe3LyD6q2SvTsX89TV6S3Qc_Hy8A"
        ]},
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

