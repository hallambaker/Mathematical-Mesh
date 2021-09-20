
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NCQB-Q5L2-AFBH-NB7E-FEI7-3QFE-ZONS",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQI-T2FU-LP4G-KIFQ-PMYI-V6XH-PZLB",
    "ServiceAuthenticate":"ACKX-DTYK-TMVD-T7Q5-FDK6-IJR2-DHNF",
    "DeviceAuthenticate":"ADZG-TVGE-DPQP-4Q4X-EBD7-PUSQ-JTTO"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MDH7-B3JK-3KWW-XMRX-3UIS-AVZR-EJR2",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ1FCLVE1TDItQU
  ZCSC1OQjdFLUZFSTctM1FGRS1aT05TIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMjBUMTg6MTY6MzlaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5DUU
  ItUTVMMi1BRkJILU5CN0UtRkVJNy0zUUZFLVpPTlMiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUktVDJGVS1MUDRHLUtJR
  lEtUE1ZSS1WNlhILVBaTEIiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  NLWC1EVFlLLVRNVkQtVDdRNS1GREs2LUlKUjItREhORiIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFEWkctVFZHRS1EUFFQLTRRNFgtRUJENy1QVVNRLUpUVE8i
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCUM-SQ35-ZJUQ-TMTK-HB4X-57QQ-YK2Z",
            "signature":"WmjtRkJpq6QiqLNxY_ljzSrAUO-BzxDqK9yT-HB0
  gN1TdLw93Jsj2vkIHsdQOMmVbullSyjK66OAodsKV-DEPP2EUPHA7_iNu6HwHoOaa
  SJvtUhBaiYirIe8_-ufIpfZfRxZbQdrU7uIsD78Fw8JhBcA"}
          ],
        "PayloadDigest":"QeCfPNqPnIgnkZqOk5ocOCmmJUNa5Zj1DqhPE5OS
  giY_01726xlWNvmn10PwOwdQsuQpgyRxASzsi5z5yRMcwA"}
      ]}}
~~~~


The publication is found and the claim is accepted, the publication  is returned
in the response.


~~~~
{
  "ClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "CatalogedPublication":{
      "Id":"EBQI-T2FU-LP4G-KIFQ-PMYI-V6XH-PZLB",
      "Authenticator":"EADT-KVZF-RR6U-D6KP-NRYQ-TAI2-F3AU-4NZL-MBHT
-MHOX-SUNE-X7UK-P5WD-Y",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQL-DNYM-VM4G-UE4U-4PDF-UWSQ-7ONX",
          "Salt":"6TNjMCiVgB1PpVNeEaH-iA",
          "recipients":[{
              "kid":"EBQI-T2FU-LP4G-KIFQ-PMYI-V6XH-PZLB",
              "wmk":"bYJ4W7F-Oa7o5pR50uwdq4GCtF2wX3tgr3zNt2pTk7DB
  tHyUamIX_g"}
            ]},
        "ZrETLTXinD0jkRoz_OAYlnFRPAFVgVrORZM2qLUfNQts8qSkaTBoOQ2_
  CwTcH7htUnMhm8k9JZgfztKvY3ggmN-tf0gKnkY-nUc4UOBW7VXmkXYtnF9iEjtRq
  taIe0RbmeT5lv4P-1ahs2G2PEm3nqnyygfcfyRn_XJpXgICKGzIQvK2pjNXLHsRJ7
  Ef9yQg9tSQR0dk8Js_YaOeQwrP7XCogBCk2XSaPwyo-8fufIfSnbUea5ZcDdglnQy
  stbj-TKtM9WgNNBxy4BU4jXMZhu2_hPaOXFqYN5hFwr-uZXXi4iHsOg6Xo8qNHZ8H
  d__86f_1_9XPpggnHXjAFyIjSf7VDo3JR2Mv_lTXExlMfIjYpaclg2r_CmlkBNROu
  RqZPxKzMbLnSMLd_x1M5JkIO21UDq7wt5_Dm_R1AObLCqJnr5EyTeZ0UV5eqCENOS
  9oxLc4It4Y1vy4ZAwXkUVqgsQSV2j2tfOUDFmPtO3qrPuOsUoPViP_Vczxusp1KPm
  19vt1-ZG-PcW5KK9HK1lTN9Ym1Xp92hPh_p4S2tDsRtKf1L3EI3wgqWc3Czk5atk8
  VoM-Ty4kkYfwVpEp_tUvzq6T5j252NpdE2vZSbHt66yCHVs6XrPMAyYMWTUxLjcRi
  qEmVI-dFAoFbFUpVFfNN8u56eXfRQ16YG0YTwwsvnO9bFFiMP69Pup-SvcP9Eox7J
  76DAtI09IQFt6ohU1RUOHXCDRZPos1kI6T04vrfX_AEfnwDs0XgNk92zKx1KQ6IOo
  66HDY2qOFJgDdiES_xC3VjgQHD40D200CjXeVPjsbtBrEBZC9_y0E5fNT8mQb9hVs
  swheBeYZ0Lwobl2Rm1IfQAcul66Xhxur3f32ZEm7iD_npBi2TnCyp2rLPA88_PDV4
  pn1WBqSjB2QCSqi-GagQ-z9h-RbGig2ef_eQ3GdmT_YLVIzEVtsNhFHMWi2BlEUZ7
  jN3sS0vE4EBK_v18c9_yUxRunOzX9K4_VBBbBExXznHxydIHhsgDzU8cb5CcjKw0n
  6GkpbO4IrdWQPWwCNa8zTB_KlymiY2YykQ7ttd35kKHGVC7EzYGuIEPj-pnPyKmfn
  oClIruA1CNc5_De4fQ9PeeMnB-xibqoDyMBPxKnfUrHfYgZj1hvgfCFjfcf2Qqslc
  5UcUNZh94E6iNX4ScIeio_X2wfEkVUSkU675v6Cy2kH9LJ9LfdinyuPHpzHAqvHAX
  ePbu8lF1nCMhhrGgY7yD42pnobf5ljgFPxxvrKs8PElKyU-1Ciqb6bAOxNKlHZ9cm
  ZNstFlnPN-rWggw_n1lcHQDW4mCztdGtD3eevp6RcVlb5wA-5otl30qxqWR8p0Hhx
  lQo7gExMftfiRHiHzZG2-8OqkYRBlAsDIoGqPaMElEiG-FChvWfEHVNpNqiiWgpXh
  UfeB_FGjnv0fVT0B2jRcSh7A2s-JO0p9ohizC4E4yCdwY-d6G193vAhCyonQgVtgQ
  0rM1oAgXJ3sy65flm5MTRoPtRt2uBFmhza7iW-4IaH5_LLapZ3ry8Fct8-NV55XfE
  BmLiH_Ga0ASCD7yPb1ylSiMSMfOJ8VkdeUv09A__ZGETUOVxb1oTZ951pbSlwZdf3
  VXptUoKvqKzluYQWRv-QBvL2r691cPRMQWUQ2Yhafg4U43An5XhLSwBtt2As_Y06g
  lZiPmk0wrzkgrrd1eD2e9jJrH3_XKjL2d2FUeRLsNhe0YCqXxYv60VIWookDpDZY0
  GQmHa7I_bSRzBwR9QbIa5EafXMND8adCsTMH4cUWKGNwFK00jtSY8igc22NHljSmQ
  LA_bV2RdUVJ0tU2qnIWFPscpBcpYUh1PvrcSZ4M2ThiOUi193Up5-Y5Ibgz66F0Zw
  jtWgxCIUiz4oOEXLxmj7NkhLR7EFuWrKrNCUNhRgBDC2tlzwBnudaFeWnG019NeG7
  EC7D_osaloz1936fct2l81OKkOeBozPkT6xSpvtNQuTsfVvAFgE-XHRivhcD3DJ9s
  4YJpw2-aKqo5fJvS1qwxEQnQQZAbU8yoe7o0DSCBvbVIfZGjS448ksqazhlkE-1kS
  TB4wqCi5eUJuWDBCx3b1ykUONWLvqPmsIwe_lN4Jxg3RCVEpZBJ39EZ4uIKTmfI02
  jwkmNpvbRK52NwTHtYxsf7gRDQf3N7bUxppVsZqay49zW5fOxCHgfcBp9Z8NSw1Mt
  XNJ-SNKHbTFbpAwc5uvK4M6J30fZyuT1KBGYsmq5mxV-Oj35GOqLYmq9VCB39kvbe
  uuBDGEp_agvQ7azWUZ3UE-Goir0Vfrx3G0skadYfqPNz88YZzQAp5rNbaZoFgpjqk
  GibVRjaLM8watr_qClb1HJ4cHS-unDDv3PdFu4qVLlcuhOZduBTRi87f9WgS1XEzA
  Qlo9M3y2xlzfXurE6ZnFX8JcV5MYx2RmofAl17nduGesNaBNJ8CX-ho2ahJPFUf-P
  rlIdGPGRzHbCFO4Ol4naqsOv-Ji5jZc2Raz-MPyEc7SyBcdX0Ryd0WUcWZ9ao60qN
  rc0EufZPmJOE2g1wijQ-UUKKxXI6CX6n4QPy_E8w59XzjYf-IZTNkkOp34hDrhUcT
  61ReWo9rinqVGVDz6Ziff3z8YST02yYTaxG1PHoLp_y5j9oGSLovAvx1bWOXvajAx
  Uedy4GZxfsJr4EA3xZs8ayXilKffV_OEqR5vW32S3-qRY-L0TA_ye42kZ8FHAgvok
  EzJGl7bCFBgHt7z5sxyjUYPrvpCr5XWfhVY69jzwVBhgrPnaSOQ3m2j4-uxy_lZWD
  hxe5vrgIMBbhCAgzuTeDJtNdj4cJIuoLhNTJvHh4FyA9ne_b1LWbn_w7nssr0gBN1
  WHhz2FnxaFb-v-5TMTaS1kJy4FZUnAENM7ukDG07ND7anOV-6MK6lhX2tccQLI3wC
  sAzwwrfb6dgV-kS813rTK24DicNvnuKFFxJkQaA0fEUY7XUpnFjdf-k8YrB93zX5o
  COj-g0ucMrImDMS0-6Wsm8yd8eDUhVx9Zyb7HnCwA8DV0Ob7w"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

