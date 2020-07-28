

# device

~~~~
<div="helptext">
<over>
device    Device management commands.
    accept   Accept a pending connection
    auth   Authorize device to use application
    complete   Complete a pending request
    delete   Remove device from device catalog
    install   Connect by means of a connection URI from an administration device.
    join   Connect by means of a connection URI from an administration device.
    list   List devices in the device catalog
    pending   Get list of pending connection requests
    preconfig   Generate new device profile and publish as an EARL
    reject   Reject a pending connection
    request   Connect to an existing profile registered at a portal
<over>
</div>
~~~~

# device accept

~~~~
<div="helptext">
<over>
accept   Accept a pending connection
       Fingerprint of connection to accept
       Device identifier
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

Accept a pending connection request.


~~~~
<div="terminal">
<cmd>Alice> device accept 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV
<rsp>Result: Accept
Added device: MDTJ-IEIN-4ST6-ZC3G-OUSP-PBNM-PHYK
</div>
~~~~

Specifying the /json option returns a result of type ResultProcess:

~~~~
<div="terminal">
<cmd>Alice> device accept 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV /json
<rsp>{
  "ResultProcess": {
    "Success": true,
    "ProcessResult": {
      "MessageID": "MBJV-MBFO-I6IU-JZD7-LNPH-AZZ7-3P",
      "Sender": "alice@example.com",
      "Result": "Accept",
      "CatalogedDevice": {
        "UDF": "MBD4-HVQB-BRAR-C6CG-VND4-D6DK-TP4N",
        "EnvelopedProfileMesh": [{
            "dig": "SHA2"},
          "ewogICJQcm9maWxlTWVzaCI6IHsKICAgICJLZXlPZmZsaW5lU2lnbmF
  0dXJlIjogewogICAgICAiVURGIjogIk1DT1otR0laMy0zNFZRLUdRNkotRkNTN
  y1CSklVLUpDT1kiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJRMVVBa0ItWE44Z1ZKcV9HTVF0emRZN2Z
  ydndVZi02OF9nbEV1b3BjcE5VMUo2blNtS1EyCiAgZDVkRkZaMVRYbThoWUNFc
  FFXUk5pWDhBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3sKICA
  gICAgICAiVURGIjogIk1ERjQtWUEyRS1GVkdKLUxBRzUtSUs1WS1GWEJCLTJJN
  TYiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogI
  CAgICAgICAgICAiUHVibGljIjogIjhHZXpMOWdseHEtQ3VIcDREUHdnSFpzMks
  1ZVhtX1BhZTQzcHAtbzluRWdvTHRsTVhUMVQKICB2ZVg0VmpSTG1BMGpRaDFIZ
  XRJNUFtbUEifX19XSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVUR
  GIjogIk1CTFQtM0JEQS1TUjRTLVNSQkEtSlZGQS1ZQ0NHLURBRzIiLAogICAgI
  CAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI
  6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljI
  jogIkhLdDhGdnA2QVA0WW9Xam5Dek1UZlp5N1RYWXUzNjBEOThkN0t2bmhaYVh
  XU0gxOE9qczUKICBfY2EzM0I1WXdxeEhJS3VCSTQtRG5zZUEifX19fX0",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MCOZ-GIZ3-34VQ-GQ6J-FCS7-BJIU-JCOY",
                "signature": "-JM6TM7W2WmDOILniZJJBnfNVHW4VzPQ6Hbl8Td17riEgJVUV
  BS40y_NBwRhfC_70vMJeuXRX40AT1G7zFBh_bUTLXBv7fqk4MDAoDdBt_vDGgK
  _LYhVSej_K-0pYIKovb0FiX5za_QuaMJW_HpPkDQA"}],
            "PayloadDigest": "-E9oIRhcwUVwnNhf1-mRhX1mBqBsucvV_q6Va1zKLMk9G
  4HsfjGyBNi1CtOzqcTcOk3kwqcADQYmeQ8DaH3scw"}],
        "DeviceUDF": "MDTJ-IEIN-4ST6-ZC3G-OUSP-PBNM-PHYK",
        "EnvelopedProfileDevice": [{
            "dig": "SHA2"},
          "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTURUSi1JRUlOLTRTVDYtWkMzRy1PV
  VNQLVBCTk0tUEhZSyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogIkNpaDc1QlRPUGFhTHJub3ZoUmN6MVQ
  5ZWx4NmtGVmFJZGVQaTRQSlJTeXIzMGNCbndNQ3QKICB4MUFlSGE1djhXWWpSN
  y1aSjNyZWdyZ0EifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUFQRC1GWTZKLVVKTTItSFhNWi1ZTUQyLVZITlEtWkk3TCIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiUEliLUZUclFzQlplSTNKRkZmMTc0TU9tUUpVYUpNUGdRd3BFMUVvbVg
  3ZHptRTR4WExObgogIFNneVlYUUF3eGtoWm5od2ZubGZwSFB5QSJ9fX0sCiAgI
  CAiS2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTURESS1YSlZ
  RLVFRNVgtNVQyNi1ZUUpKLURLN0EtRklHNiIsCiAgICAgICJQdWJsaWNQYXJhb
  WV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICA
  gImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiTjVSWDZZVmJNR
  U4walBlRTZxSVVmM05rZjJTa2FWdWcwV0lVNENHNkF3TVdURVlwS3g4egogIFo
  wZVZsaXA2YmVlWDdtOV9YN0s4bV9lQSJ9fX19fQ",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MDTJ-IEIN-4ST6-ZC3G-OUSP-PBNM-PHYK",
                "signature": "9Khc20b_XRNPHA1xFH03pvJfa8KeIO1qWY6TSdlo7EeYcsp_I
  c0ljylQg31-UBSnWflyQX4YeoKAq-OBbm5zO778fPhwg_jOwfUfJ0l3NS_b8eO
  9LZwqa_XlNxtG669CHMbgHF2jEiWoF0ocd7VgizUA"}],
            "PayloadDigest": "kzm_AEYZWhhE3akoC19bq8H4vEM3DXbu6tNtvhoGco7Lv
  Rh28tzsiQ9EBf42j3jtw9bz0Fd3g9P6qHZ6813t7Q"}],
        "EnvelopedConnectionDevice": [{
            "dig": "SHA2"},
          "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQkQ0LUhWUUItQlJBUi1DNkNHLVZORDQtR
  DZESy1UUDROIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiMTlWUEcxZ2FIU3VJLWdRWWpJcGlUd3M2ZG9
  0dVBxQnN4aVRuQVVhSVVBTjNVTVVjM0g0RwogIFZZZ0JIUVNyZ2pycjJRSXdaS
  0FoaEdLQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNQUQ0LURDQUQtUUNHNy1SWDZMLTUzTk8tM0pSVi1ORDdPIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6I
  CJTMWc2eGV0NnBta1BQNlhRa2VLQUI4cUZnN1hULUtoNDgwYWd1M0Nrb3FPbGl
  jUnF2RkFXCiAgQVVhVGpBaUpCNHcwX2hHTlBkNmRuTEdBIn19fSwKICAgICJLZ
  XlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVERiI6ICJNQVRQLUNBSEgtTU9
  RRS1TSUlNLURONEktT1FQVC1XVFVRIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlc
  nMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J
  2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJvU0RNV05TMHpTZG43V
  FQ4QzRVTl9HNml5dUZWTDJsYTNwQW9jX3BuaEloeHpFWFFtNTI3CiAgaktwbXl
  qUU1ZUHc3WEF2MVBnT1JPamNBIn19fX19",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MDF4-YA2E-FVGJ-LAG5-IK5Y-FXBB-2I56",
                "signature": "85-DP6_C8dxfvWDl51Y6w5XoJr97POupeq_hYVarH-MSjgdbD
  tnr_7jGCGDvZ-E3A-j1usr9KYWApwYHrgV_8JLcRY-98FEkzqqJBdh3yisEVQH
  gttoGNbnI83GupXsVCCUJzvkphScINkYNzYx_UiQA"}],
            "PayloadDigest": "vEfyh4_fciZJc00t78kiKoJ1xFl_WrigkYWhGl5IMAf9C
  TSo_r8CTX-FYF9ois4JBH8oJCpgB-zR8lyW6CgXjg"}],
        "EnvelopedActivationDevice": [{
            "enc": "A256CBC",
            "dig": "SHA2",
            "kid": "EBQE-ZYAE-QGIW-XRZO-H6VB-4VTB-TQUP",
            "Salt": "Y0JL9xITjmkdY1cMkdxEAg",
            "recipients": [{
                "kid": "MAPD-FY6J-UJM2-HXMZ-YMD2-VHNQ-ZI7L",
                "epk": {
                  "PublicKeyECDH": {
                    "crv": "X448",
                    "Public": "Gyw6QM0frM3qqepbQukK1bmG7iOmfu68EoRfhztGFVcb1tpN-P_9
  i3Dtnhn0BNUFdDBFhtVYbYmA"}},
                "wmk": "5Nh29o7M2Shr7-RnKC5IiahZsjGW-3-ayjns-fICWzqNoVK5MC1r3g"}]},
          "s5HIrQRmWvfb4G7nsJhiFyqpdiC9_af_CySdw-r5xUMhSOHE0K8EDBp
  0Oi60QH6IqI1hz98pf1utE2dpuIVCsrjnunA7QrLzMCE4z0h4WNp_4zDJv-itr
  KNB0f3gDDIUpXkvtdWbgMZzNeMhxeh1XjuixXnPafhMnlcZ0VwuOHstocXBkRQ
  oXy_vx21RHcA1CdaD9_sSV_d-m_sDC0lWA4tLw7Ds66kwDb8Rv61rxy816rxnZ
  -XC4vm3kmMVnsf-Kh14TJtZGB-KQZGxXKjygd_XuKnOslZUySVFqbuDtVNnOGL
  WMszE9U7G_NkCgeskX6yt31QN8SeSrERMBd2ZqVuuhC8xC7w317HnZCfaCccgN
  80ZqV1PWBF_DErtZhsaM1-elNw5jQ-DF3YL-LPy07HeuZFuYsc_C5c6W-rLyyC
  MTZH4FChSZ-w6yQ1XaSdVoJsxPN6yHXYxfwKeCPoCSZFuikFhleSIbZ_yR6bZM
  B2xJwfFPfsrVM4hoyb8afNykijrxD61euZpoi4Lh-58pXHBcQFu4CBD4d8C9uy
  DcTXTYFK64rry2tUP-eNfvwKVQgdgojEkCTdoeca6pDf_xA-4QCXauve2EQzdC
  CE2gqJn-GjxGC9s3ONHdTMKA9m5xom3l5hJvUYS6s7yU9QR-BKVmhIYz0FB_K8
  o-wkYJ0YrlxuMaPGy7HzzpgzhjELjwoenlvX24AIMNTMheplANoy55myWvA80t
  xoluugbne4dS8b1XmOHW73pF0fZcYZStnHNF4MBtP1nbP5SVIehEsEq4jLzLTy
  U7vAP5ADCI7nyi9_BECBkYs_nNmYlGsiOynE5z_DFAWyPjFuWINn4WhSOyIU1t
  uG8sDtariEboF3FdWKZi0LV2437mfWCBYv6j9aJq5pV4QziG8GEUlY9kKGRds2
  XHH-kb0K2Hd0fNaYOls_X64KC6DziLcQGF1j5mxNGHI9siZoSffBOXvcoug8Hx
  u8kJs_1T0GK5V5i77UEx0jy33oanjjTy_1EbGPX-zIMwarvxp0WnhVC_DRLVvJ
  2Hp8kgVFOqgwSdh3grsMmcB_55xbN-KwtsKLLsbDC3_7QRLSHBCfVDZcKXm0_0
  BkCZjz1jc7XCmWbnlNpkGsvJatenkA712E6c8Ei3sIxuCmwWNNcKGBYkFgpbLS
  sd4v-VRsoN1ew9-STOs-AxwVSSATdatMQ4jds4s5X1ZBt60CepkqaHsuuCNNKz
  cl8LW_ydnVQ2S7_60ldhJn9U3qUI007_ydAFIzebjH2aC5h2ZIQgblGMIUmXfN
  ApID-kKT9H1r9Y9FH2JJnR-ZETliMkiAIQX-hyMUp2bhX2l1jA3k7dL3-e1s4O
  nrO3MZGExez-QbMV4xDhBH5xKGqYn6iEyT8y0BecT8C1WlLFK6zVYdNtd5Wrm6
  Y2n6ZEfvyVavWmgjw1Gwaj3bIzY6vU2A2He5x1z8KzQxWzGr1uHg0HqBMDHL0_
  YrBPy1ix6x4RAfPYsPrS_sI8aSAhLtfxMfC44EOaK_hGsmgmbDvighdbBYWH7Y
  9zGEFXx7PQBjyunVGBGIVmdOlqKSgjnV_ASuQXVS8rWWtQFv_HH0D0lNeWZJML
  gv1IW8Kb3u7UX6LyFFKhEn8vRUHivMQpUhD-MLKoZhmyZ1nDriVKerHV5GXT9y
  QoeUBfAscABw8B4fAexST9X4hIVHEkRryqN9_gVWlLsPhI6cvCvERdrzz15cuo
  WlYt66RY_iLPCXdB39pqgS1ufJyXVlTUxgC26NGbQY9AgdlQZE7C69kia31tpN
  oyK_AdIPgIjEFMQ_yRUEtnyu4JqbgAD5oG5r8cThQOfseSYAGAitRk09fKsEuO
  N01juFncxqaMi3Z_BiXHDNuMzZsCu8R9epCPju-DBuQTWENeRcwGuyExW4ApFe
  fY7hy1euEYjvmAdxy25Plw6NMo_MTjFpmpu0RI79aMCpq3G0OAulNlMIPtj2UL
  XHQDT4E50RAOipQZt8gEZvL_kWbrcPLwDMd22gYsFphJNPTGk9MdM5-bSqs7iN
  84HebIkt74TpWqiNaXYZvb9GS00Gif6meF6U9u_eRzOqQVUKbmXCnotU4kxZRb
  -X4Nw87J2H2I8hmvPKeaEU2PkT8u4xXa7G2d6DT7m_qDQ0LEIlc43meHZQEQ-0
  1PT2UC6JlJwSidKWJSXTx9bMaaabixUHY_zF_LGsRiAoANUIcxFUzNSiLaDXvk
  eJ2bRrDUn70cOinqzR-2C-xBwe4hV7XccocHFPvemJeZSwctCR8SVc3lLRZI6S
  wx6BnY4_GuDRa3kJvqWLhxwOaE7qwc-mM53iZjA",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MDF4-YA2E-FVGJ-LAG5-IK5Y-FXBB-2I56",
                "signature": "SBuTYFanmksfT4jyQC4kEB6KxF--rSNx9LrPdjrxOe3KO75PD
  SIqe1M6LLQNTImfSXbcgHMt8PYAz5-3dpxm3DTqD1kAE0F06kPUrD6uLFWIBXW
  _GOsS1UDimJH4KqyCOXpCIdTWxpyrjeVFskBuriYA",
                "witness": "gbvZVM1kwFm_9KffiNllGBhID4pIywj_tqkdmfVXbqk"}],
            "PayloadDigest": "RVuI1N2uL7q4LFzQ-mMGC_PioMCFTI92XIAuLxTXLiDyF
  SOLwKHYl47acTprm_5uF_k9HtPsJJ-77EXU_yYWWg"}],
        "Accounts": [{
            "AccountUDF": "MBEA-67YL-KUQ7-LFXL-BDVK-WA6H-SV7Q",
            "EnvelopedProfileAccount": [{
                "dig": "SHA2"},
              "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1CRUEtNjdZTC1LVVE3LUxGWEwtQ
  kRWSy1XQTZILVNWN1EiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICJwd2pESVR6VmhSMmJncFhGRjR6NFp
  1RTBBT1BiY0JnUExzeWdOMjFEUG5KSUpaWDUwbVZpCiAgYXlTVUpnWXBVRFBKS
  mJEbktudm40bUVBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1BVFMtTDVTTi1PNUFOLUxFUFEtS082WC1RM1BSL
  VlQUEYiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIl94eGFKYThySHBtVjNVX3BDYTlFZkh
  wUkNtanlRb2U4eGxhNkpaaGxkRjR1NTVsd3ZaVjYKICA3MDlSWEIyR00xWDB1b
  2x1aE95YW1hQ0EifX19XSwKICAgICJBY2NvdW50QWRkcmVzc2VzIjogWyJhbGl
  jZUBleGFtcGxlLmNvbSJdLAogICAgIk1lc2hQcm9maWxlVURGIjogIk1DT1otR
  0laMy0zNFZRLUdRNkotRkNTNy1CSklVLUpDT1kiLAogICAgIktleUVuY3J5cHR
  pb24iOiB7CiAgICAgICJVREYiOiAiTUQ2RC1TWUY2LTIzNlEtUTdSNy1NWkdJL
  UlRWlItRVhDTiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICA
  gICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiYVBDV0RwQkozdDF3RGx6YXExREt4TXc0U0p
  SNXdoMWV6RzFTT0JxaFdjcEF6elNaS0kzbQogIGZRMjBfSWlOcGxmamYxTjNYV
  GFOTVlBQSJ9fX0sCiAgICAiS2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUNDNi02WkJPLVdBWlQtM1NPNC1EWk1MLVEySVItTVAzNCIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiYUtIb1l2UHFUaGZsT1V6NWEwTjU0Q3NRZ2ZrQWdOZEZvcTRjNHVtb1g
  3U3ZhM3RIdW0tNwogIDB0Vk5Id29KNVhFZ05HMktlNHNBeGdPQSJ9fX0sCiAgI
  CAiRW52ZWxvcGVkUHJvZmlsZVNlcnZpY2UiOiBbewogICAgICAgICJkaWciOiA
  iU0hBMiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFUyVnlkbWxqWlNJNklIc
  0tJQ0FnSUNKTFpYbFBabVpzYVc1bFUybAogIG5ibUYwZFhKbElqb2dld29nSUN
  BZ0lDQWlWVVJHSWpvZ0lrMUVNMFV0VkZwSFRDMVVNa3RYTFZoUVZWUXRUCiAga
  3hGUkMxS1VGSkhMVUZIVEZVaUxBb2dJQ0FnSUNBaVVIVmliR2xqVUdGeVlXMWx
  kR1Z5Y3lJNklIc0tJQ0EKICBnSUNBZ0lDQWlVSFZpYkdsalMyVjVSVU5FU0NJN
  klIc0tJQ0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlSV1EwTgogIERnaUxBb2dJQ0F
  nSUNBZ0lDQWdJbEIxWW14cFl5STZJQ0k0ZUZGUWRXNXBVazU2VUU1dFVraHRVM
  lY1V25KCiAgaU9WTmpjWE5UUTNBMGNFVnlXbDlJZW1jMldWZHFiRGxOVVVWTGJ
  rMU9DaUFnY1ROeVRVMDRNVVo1Ymw5T1MKICBrRmpZMlJzYlV4SVRFZEJJbjE5Z
  lN3S0lDQWdJQ0pMWlhsRmJtTnllWEIwYVc5dUlqb2dld29nSUNBZ0lDQQogIGl
  WVVJHSWpvZ0lrMUNRVTh0Vmt0R1RTMDNUVXhXTFZoQ1RrVXRWRkpRV1MxUlFVZ
  FRMVmRTTmpNaUxBb2dJCiAgQ0FnSUNBaVVIVmliR2xqVUdGeVlXMWxkR1Z5Y3l
  JNklIc0tJQ0FnSUNBZ0lDQWlVSFZpYkdsalMyVjVSVU4KICBFU0NJNklIc0tJQ
  0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlXRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWl
  VSFZpYgogIEdsaklqb2dJbFZXVkZGdlRGUlBZblZUUVRsVlNERktTVUZ5U1dGT
  VJtZHJlVGhmYlhwSFlWQk9UR0Y0V0ZsCiAgU1ZXVXhjVzlZVVY5UGVtRUtJQ0J
  sWnpKQ05rNXhTMmxLV2tGc1V6VnJYeTFRV0VGek9FRWlmWDE5ZlgwIiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI
  6ICJTSEEyIiwKICAgICAgICAgICAgImtpZCI6ICJNRDNFLVRaR0wtVDJLVy1YU
  FVULU5MRUQtSlBSRy1BR0xVIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICI
  zemozWG5tdUlnVWxvTUdvZzE5X2IxMnVDMXd2aC0tZ1B2dkNNeFBYajJpWXZHV
  Wx0CiAgRFBnQ3FVNUVKOVpuZ005VHlrVDJPU3NZOGdBMm04NERfT3lfS2NyeGN
  nS0szN0pSQUhKbElBakp5RUNwNVYKICBnVUJBNk5ZVGE1aUhuUmFUcXhyaGM0R
  1NCWElRVFlObkxTSl9DSXdrQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI
  6ICJNYTliNkVHN2dZc2FsM2RVb25RNEJnSDRVTFlsYlVGT3R5THQyNUppeGI5Y
  lgKICBCZGhwcFNyMEFkRmo5QmU4QWtvYl9adEFuUm1oeml6a0sxZWd0VUhXQSJ
  9XX19",
              {
                "signatures": [{
                    "alg": "SHA2",
                    "kid": "MDF4-YA2E-FVGJ-LAG5-IK5Y-FXBB-2I56",
                    "signature": "_HCUub4SeVt2cbdVsFNQMo0E9dN7x8eqRVNt3XjxojDL94T3J
  JpV88sYKa28zl_ih07W1YRM5SwA1AydANcXVfxBu3-LEvROhgixHCMuxmyUWsy
  Adn_aSAhtbIXE9uS-X9WEojnGHH_mat1EIiNXxwwA"}],
                "PayloadDigest": "WZslxRLR38CdQ_x9LXB9kFQmj_XvrFy2hqsH_j-9rtJnZ
  hSCtOm2ikd6fw4cO1fGONhFMf3LQaBYRJIwRbvofg"}],
            "EnvelopedConnectionAccount": [{
                "dig": "SHA2"},
              "ewogICJDb25uZWN0aW9uQWNjb3VudCI6IHsKICAgICJLZXlTaWduYXR
  1cmUiOiB7CiAgICAgICJVREYiOiAiTUJOUy1DV0hDLTRJUFAtRllYWi1aRVY3L
  U1aSjItNjNNSiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICA
  gICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsC
  iAgICAgICAgICAiUHVibGljIjogInlFRWdJS3VhRm5qV0lZMjRUVFhtNnlmVmh
  FWmFDMldiX09WdmlaT0NWdENXakZjMElIQlgKICB0MlhDNDh1TEh2czQ1U1RXL
  WpZUjdic0EifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJVREY
  iOiAiTUI3TC1VRFFLLU5XQlItQkg0QS1KWFJBLTdWT1ktNEJNWSIsCiAgICAgI
  CJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjo
  gewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiN2VSb1k4MElSTlZFb3BvYjEyZ1NGZVZrZll5RnZHaW5lak9jLXFlYVpnZWd
  RdVBoVExXUQogIEpGVU9fNE80X3VIbVNlNUJWSFhSWmQ4QSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUNMRy1EVlJCLTR
  HWk0tRlRZSS1ZUkJZLVRSVUwtNUdIRSIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiWWxJTXM5SEdDcmFyM
  mQ5ems5eWNzem9XTlZOWXdrelgtTldkb0UtQ1ZMenRWbFVPT0VLTgogIG5Ga05
  aVm9oNDlwUEQ0cW9MRXhHVDlTQSJ9fX19fQ",
              {
                "signatures": [{
                    "alg": "SHA2",
                    "kid": "MATS-L5SN-O5AN-LEPQ-KO6X-Q3PR-YPPF",
                    "signature": "qtVJtA1e7G2dxhB1VHYq60HxvG0dulaCkRDdOZ_zKBjPvF1zH
  _NC5LLo_ep-Ifk9QkUl0e9qppWAFF8lQIF_zNs1bdhuD0LgbH7Va3HnJacfKhT
  wfUBW0HLQmZY_4AK24MooEpanP13I9ql4GbAkdyEA"}],
                "PayloadDigest": "z-wT7YyVo3tN6Egr6C3wdweuZ7qVVVIU6jYf6LAF6sQMw
  cZQkvCYw6f5vjV6suJswvgBtDTQyUNnqRuDFPvexA"}],
            "EnvelopedActivationAccount": [{
                "enc": "A256CBC",
                "dig": "SHA2",
                "kid": "EBQA-OVNZ-ASLJ-VBRK-6VOK-M3VY-ZRO7",
                "Salt": "youU4QryGwtwbJMQ49et6g",
                "recipients": [{
                    "kid": "MAPD-FY6J-UJM2-HXMZ-YMD2-VHNQ-ZI7L",
                    "epk": {
                      "PublicKeyECDH": {
                        "crv": "X448",
                        "Public": "vFUEryFWIu-LGWkSVvz-qQnQZoWONScCNAMEiE6sYV3PLFSeS284
  memG5V6jkunkgk6UeoItsNSA"}},
                    "wmk": "bapolgBy8xxhjehR5do9BTrGqVT0Tt-MMRLW33hcYdWsCcmZO4r6yQ"}]},
              "PHfR-GtQpygaxLEZdHqh4Foy83pWQXgOoX4IEvNeAdWWkkHJFUbRkQh
  c9UZ5OYNkbj3roAcNZZ-TV5swTSLKPfA0K6GsqiNUqiTBeopveP8-RgbOtZcJv
  3Vw22Xk_JNOqdAxDsyNjBZEa5TX4FDLh0J4-EkJip_WuxBKpaFatZwEX_QgHrU
  CWL6pDZ8ii693yZljy78jExPi9WuHO0g6K36fsOjGTO0EfRlTOwNfi2849UTuO
  MQl_AnWaLfJlqXx9J9ELcKZVTIB1wOwxjzcFWtWxbPa9sRNDmjNx4lWbaBWVNr
  IwwgDNGs_04iTQ-OqdBO-4_bhiy-qYy2hZekoO9NpMX6IxIXfaxNnapo0a-QyD
  b2W3eubXSLZppIEr2THWk56h-JElhj8671XIpe1-1QvvD5NDLgc39CgRyPTrTI
  ZY5hpdsWb1irJb3-Eb7GjwCeCZRno-Xifcl-pebzj_-u4EPAQ4Ry000JG_0DPX
  SpJJDMNj6lE__H84_kiUiUXcz9iJQXqBqh74W9rynKtLcgi5UOl845y8qWPMoy
  l8m9jLqr4lLYxtDSMDdyvbZLPOuo8xke2u6zj1_mIhytyHhghok_f3koTK3ED4
  BRA1QAH8AqDQBtpo3l_QRkxGnInRzoeinNifZ7AnLjwjCVoenlRaBWx1zbe-1f
  Ebabl6RKAoCSjvLdwFvLkQ-5VXuuCk2WZ3VuQTre5asQeuSg21l6LDbhqjdCEo
  I1uhRCoQzOzg2KjoJWTd9uC3tNAa2Sg5ztQ4c4yoV5XrouXEL9L7M3xYLDuTAS
  dTPauRVRzcAJ39VVFsATRoJZTsTKvCnb4B-tRRE5cajkTx-lE69hzYeHmCwbyf
  YGBf4xHI8elVcZkdvncnL6gc6q4y7HZbVYqYzlVgB0uEPDnX5De5SdYlEN83Sb
  g8YCjNmJ4BIzxbtmvxDC_0AeedkStOAYmqiQxvUZzIzjNvHIRzghD4gMhCZVka
  Hu1dSgDjUaR8ea0QYfI2o5E6bdeOcO5yL8FL77Q9XYoMAmmhJFwgfxeOdD3cGl
  VZZD7yIzzQCABJCjNVBQNXP7mnt_qvqBvGcec78NyYQt_Qlqwwy86tsPujWGxw
  gZVL2MbpDeY2AcW57xSCFa7fiRG8yb8eAQgFqIx7dMMWv3vka48-tk1sFpHciu
  6CjtZbbwy2LLVc300AznEo4nWEFgEHZuIy2Sj4AgxGHE6kvaTZqmLPX_QksCgM
  VFJ69Rhri-jupRSqqhOmJzFI9knSh08RdczH0HE2mdHPDC4DdXeyRc55ri6BXn
  6ct8XydOHSo8HK-0CgfMPh-SKeJsQPyzfAh5NoQxEsFCtufBywSXOO-K6nn2IF
  JPUxJiR6so5TZ8zJW4O5uKNsbhcK3Qbg_xNjwVTfuLXBa3I1sL9CTadqgJRqrr
  9rj-QSwZPSZ88DoT0HvVqq_fnTdC38GTnZZ0BQUr0ZBAdAF5r1fme-DIEuM_Qv
  8qxJHMKU3K7GHqZ5N7BpUcuoZHrQ89YMrh6Gm6mora8co6-iYsaXZefyOLPJ_L
  Y0JfDsBdnzw7sH7_E1ejnFPmkJutHKNOVTmkK61AB0OxnhmBVidILD02Wy4ti8
  x2U8LY62HV_IlImSvXrDd0_gwdvypx72DIT6Af21IXJPE_MlK_0sFIOOUsf-Ka
  6Yt9WxJl5jCG0fSjwLEMSLXbHoo5SNQ8reYCcdDi742QYvOX5ch2wVCA_Azumw
  h4-SA19z75p5DAftflID992DEBhhEtR-XQpAeXAMmtYPTboK4Mw-Yv_4VfXtBy
  TUuwb8rDC558dU8HoFz8MQAhtx0YyBQKZpMpf4iRMPLZSQq9Hb2I6x9drKE9sR
  t-HMLf8wMpIEviu31aFtDZkfCNnd7tMcQYjQpW3q-nBxmUJynMyt7HVeVeBp_U
  ctUfdVJuZzhBpKVWlqpUIfNFNnQ-zr-7qao56mRaBGCY_6aEwnilhlcHqFkowg
  klj1ZIVgBbETJGvpYXQ40b94oNH-t2Z1m3ROkTs9lar-nhDwIko1N1nrpLN_b7
  6dxYtfOKTfs96uIas1F4SUJZ_JLELWrPvJn2MoQo6sso02MD-c9O6APYQjP80v
  7sEtYCLTVXEuJMXb_DIcAClJAHdCZnMdckhiNnuQzryRZguZqgan5lWDkeA2IR
  R6Z9IgQjCTkiYfk2br4ZzPM7bul3GzCPXJIbSKMYG6uTSIA0nNEqO1TFzRnR7i
  AtkSrAEEr23oh0K09TLWBMPjHB6wD0yNpdeWoauQ7AGC4aCKe_zJ_GTsnGRbpM
  UN63x3MqlvEOfWU1uoPfSUy37cQiN4KNOjU6sB6TUb8XSnPwzEzlIKSC2gn5ay
  w9F7GIs5Xf95rn74buY0FevOvqfYD4mRWMCAYTYYFOjI9ZMKz2dsmcm3tmiRxK
  uXhf05xxukJoVo5syniMdY4TfhW-0q0xwXJtN4yzn6Jtf4DkLtMacvHw8hfsPI
  3FPGxFX3_98Wa7CITuSl9STxFE-3idkmu2aRRZDcvz0Yv5ByDXMPE14SfRNSIs
  _bGVv0HGrliLbag5n-oGz4yOcnKsaYbUdXm8hdI-NHnodqv2ASGRXUMGL-78Z0
  AF5wh2MuFHcuHYuEnDEqvsrOK3H3EpyFdjHelZZZtorE-ISum7vX1ztqllVvBl
  fVzqV2LgNY6xbGldSsBZnxGr9EhqUcDfrSaKLd07frYavwBrqXKKd6siLtjZII
  sI0mc4f8i4a-tKnlDy44-PlmNd2SFp0Is7if_am5hikWyO8UJn4BQ",
              {
                "signatures": [{
                    "alg": "SHA2",
                    "kid": "MATS-L5SN-O5AN-LEPQ-KO6X-Q3PR-YPPF",
                    "signature": "UnL4c6GelNZW5a7_PJDgSAbJlQzM2UDivh84qbOf892dkFc93
  B46-YP_IF9_vxKxCdDebf1i-pIAjpOTz5y96oa3lBQqsleKAUWN3Jby-wsRL5K
  oAn1PEON6J--B_jzdBKjD3fHMXPjNPpUwJqqKjAIA",
                    "witness": "iFhNOIlHVZIWe1xdSbD50xFD3kohe1Ljft8oVEuYEGg"}],
                "PayloadDigest": "tQ1qsN3JL2ZzPjWLW6GAa5fBuPhIie17Wo_S9zzT3CCzv
  uVY1hZdMXMORPWMd-KTG2D8DB2DDMj_ig8inB1VCQ"}]}]}}}}
</div>
~~~~


# device auth

~~~~
<div="helptext">
<over>
auth   Authorize device to use application
       Device identifier
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device auth` command changes the set of authorizations given to the
specified device, adding or removing authorizations according to the 
flags specified on the command line.

The parameter specifies the device being configured by means of either
the UDF of the device profile or the device identifier.

The `/id` option may be used to specify a friendly name for the device.

Specifying the `/all` option causes the device to be granted all the 
available device authorizations except for those explicitly denied 
by means of a negative authorization grant (e.g. `/nobookmark`).

Specifying the `/noall` option causes the device to be granted no 
available device authorizations except for those explicitly granted 
by means of a positive authorization grant (e.g. `/bookmark`).

If neither the `/all` option or the `/noall` option is specified, the 
device authorizations remain unchanged except where explicitly 
granted or denied.

The following authorizations may be granted or denied:

* `bookmark`: Authorize response to confirmation requests
* `calendar`: Authorize access to calendar catalog
* `contact`: Authorize access to contacts catalog
* `confirm`: Authorize response to confirmation requests
* `mail`: Authorize access to configure SMTP mail services.
* `network`: Authorize access to the network catalog
* `password`: Authorize access to password catalog
* `ssh`: Authorize use of SSH


~~~~
<div="terminal">
<cmd>Alice> device auth Alice2 /contact
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultAuthorize:

~~~~
<div="terminal">
<cmd>Alice> device auth Alice2 /contact /json
<rsp>{
  "ResultAuthorize": {
    "Success": true}}
</div>
~~~~


# device accept

~~~~
<div="helptext">
<over>
accept   Accept a pending connection
       Fingerprint of connection to accept
       Device identifier
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device accept` command accepts the specified connection request.

The command must specify the connection identifier of the request 
being accepted. The connection identifier may be abbreviated provided that
this uniquely identifies the connection being accepted and that at least 
four characters are given.

The `/id` option may be used to specify a friendly name for the device.

The authorizations to be granted to the device may be specified using
the same syntax as for the `device auth` command with the default authorization
being that all authorizations are denied.


~~~~
<div="terminal">
<cmd>Alice> device accept 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV
<rsp>Result: Accept
Added device: MDTJ-IEIN-4ST6-ZC3G-OUSP-PBNM-PHYK
</div>
~~~~

Specifying the /json option returns a result of type ResultProcess:

~~~~
<div="terminal">
<cmd>Alice> device accept 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV /json
<rsp>{
  "ResultProcess": {
    "Success": true,
    "ProcessResult": {
      "MessageID": "MBJV-MBFO-I6IU-JZD7-LNPH-AZZ7-3P",
      "Sender": "alice@example.com",
      "Result": "Accept",
      "CatalogedDevice": {
        "UDF": "MBD4-HVQB-BRAR-C6CG-VND4-D6DK-TP4N",
        "EnvelopedProfileMesh": [{
            "dig": "SHA2"},
          "ewogICJQcm9maWxlTWVzaCI6IHsKICAgICJLZXlPZmZsaW5lU2lnbmF
  0dXJlIjogewogICAgICAiVURGIjogIk1DT1otR0laMy0zNFZRLUdRNkotRkNTN
  y1CSklVLUpDT1kiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJRMVVBa0ItWE44Z1ZKcV9HTVF0emRZN2Z
  ydndVZi02OF9nbEV1b3BjcE5VMUo2blNtS1EyCiAgZDVkRkZaMVRYbThoWUNFc
  FFXUk5pWDhBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3sKICA
  gICAgICAiVURGIjogIk1ERjQtWUEyRS1GVkdKLUxBRzUtSUs1WS1GWEJCLTJJN
  TYiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogI
  CAgICAgICAgICAiUHVibGljIjogIjhHZXpMOWdseHEtQ3VIcDREUHdnSFpzMks
  1ZVhtX1BhZTQzcHAtbzluRWdvTHRsTVhUMVQKICB2ZVg0VmpSTG1BMGpRaDFIZ
  XRJNUFtbUEifX19XSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVUR
  GIjogIk1CTFQtM0JEQS1TUjRTLVNSQkEtSlZGQS1ZQ0NHLURBRzIiLAogICAgI
  CAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI
  6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljI
  jogIkhLdDhGdnA2QVA0WW9Xam5Dek1UZlp5N1RYWXUzNjBEOThkN0t2bmhaYVh
  XU0gxOE9qczUKICBfY2EzM0I1WXdxeEhJS3VCSTQtRG5zZUEifX19fX0",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MCOZ-GIZ3-34VQ-GQ6J-FCS7-BJIU-JCOY",
                "signature": "-JM6TM7W2WmDOILniZJJBnfNVHW4VzPQ6Hbl8Td17riEgJVUV
  BS40y_NBwRhfC_70vMJeuXRX40AT1G7zFBh_bUTLXBv7fqk4MDAoDdBt_vDGgK
  _LYhVSej_K-0pYIKovb0FiX5za_QuaMJW_HpPkDQA"}],
            "PayloadDigest": "-E9oIRhcwUVwnNhf1-mRhX1mBqBsucvV_q6Va1zKLMk9G
  4HsfjGyBNi1CtOzqcTcOk3kwqcADQYmeQ8DaH3scw"}],
        "DeviceUDF": "MDTJ-IEIN-4ST6-ZC3G-OUSP-PBNM-PHYK",
        "EnvelopedProfileDevice": [{
            "dig": "SHA2"},
          "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTURUSi1JRUlOLTRTVDYtWkMzRy1PV
  VNQLVBCTk0tUEhZSyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogIkNpaDc1QlRPUGFhTHJub3ZoUmN6MVQ
  5ZWx4NmtGVmFJZGVQaTRQSlJTeXIzMGNCbndNQ3QKICB4MUFlSGE1djhXWWpSN
  y1aSjNyZWdyZ0EifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUFQRC1GWTZKLVVKTTItSFhNWi1ZTUQyLVZITlEtWkk3TCIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiUEliLUZUclFzQlplSTNKRkZmMTc0TU9tUUpVYUpNUGdRd3BFMUVvbVg
  3ZHptRTR4WExObgogIFNneVlYUUF3eGtoWm5od2ZubGZwSFB5QSJ9fX0sCiAgI
  CAiS2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTURESS1YSlZ
  RLVFRNVgtNVQyNi1ZUUpKLURLN0EtRklHNiIsCiAgICAgICJQdWJsaWNQYXJhb
  WV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICA
  gImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiTjVSWDZZVmJNR
  U4walBlRTZxSVVmM05rZjJTa2FWdWcwV0lVNENHNkF3TVdURVlwS3g4egogIFo
  wZVZsaXA2YmVlWDdtOV9YN0s4bV9lQSJ9fX19fQ",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MDTJ-IEIN-4ST6-ZC3G-OUSP-PBNM-PHYK",
                "signature": "9Khc20b_XRNPHA1xFH03pvJfa8KeIO1qWY6TSdlo7EeYcsp_I
  c0ljylQg31-UBSnWflyQX4YeoKAq-OBbm5zO778fPhwg_jOwfUfJ0l3NS_b8eO
  9LZwqa_XlNxtG669CHMbgHF2jEiWoF0ocd7VgizUA"}],
            "PayloadDigest": "kzm_AEYZWhhE3akoC19bq8H4vEM3DXbu6tNtvhoGco7Lv
  Rh28tzsiQ9EBf42j3jtw9bz0Fd3g9P6qHZ6813t7Q"}],
        "EnvelopedConnectionDevice": [{
            "dig": "SHA2"},
          "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQkQ0LUhWUUItQlJBUi1DNkNHLVZORDQtR
  DZESy1UUDROIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiMTlWUEcxZ2FIU3VJLWdRWWpJcGlUd3M2ZG9
  0dVBxQnN4aVRuQVVhSVVBTjNVTVVjM0g0RwogIFZZZ0JIUVNyZ2pycjJRSXdaS
  0FoaEdLQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNQUQ0LURDQUQtUUNHNy1SWDZMLTUzTk8tM0pSVi1ORDdPIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6I
  CJTMWc2eGV0NnBta1BQNlhRa2VLQUI4cUZnN1hULUtoNDgwYWd1M0Nrb3FPbGl
  jUnF2RkFXCiAgQVVhVGpBaUpCNHcwX2hHTlBkNmRuTEdBIn19fSwKICAgICJLZ
  XlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVERiI6ICJNQVRQLUNBSEgtTU9
  RRS1TSUlNLURONEktT1FQVC1XVFVRIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlc
  nMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J
  2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJvU0RNV05TMHpTZG43V
  FQ4QzRVTl9HNml5dUZWTDJsYTNwQW9jX3BuaEloeHpFWFFtNTI3CiAgaktwbXl
  qUU1ZUHc3WEF2MVBnT1JPamNBIn19fX19",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MDF4-YA2E-FVGJ-LAG5-IK5Y-FXBB-2I56",
                "signature": "85-DP6_C8dxfvWDl51Y6w5XoJr97POupeq_hYVarH-MSjgdbD
  tnr_7jGCGDvZ-E3A-j1usr9KYWApwYHrgV_8JLcRY-98FEkzqqJBdh3yisEVQH
  gttoGNbnI83GupXsVCCUJzvkphScINkYNzYx_UiQA"}],
            "PayloadDigest": "vEfyh4_fciZJc00t78kiKoJ1xFl_WrigkYWhGl5IMAf9C
  TSo_r8CTX-FYF9ois4JBH8oJCpgB-zR8lyW6CgXjg"}],
        "EnvelopedActivationDevice": [{
            "enc": "A256CBC",
            "dig": "SHA2",
            "kid": "EBQE-ZYAE-QGIW-XRZO-H6VB-4VTB-TQUP",
            "Salt": "Y0JL9xITjmkdY1cMkdxEAg",
            "recipients": [{
                "kid": "MAPD-FY6J-UJM2-HXMZ-YMD2-VHNQ-ZI7L",
                "epk": {
                  "PublicKeyECDH": {
                    "crv": "X448",
                    "Public": "Gyw6QM0frM3qqepbQukK1bmG7iOmfu68EoRfhztGFVcb1tpN-P_9
  i3Dtnhn0BNUFdDBFhtVYbYmA"}},
                "wmk": "5Nh29o7M2Shr7-RnKC5IiahZsjGW-3-ayjns-fICWzqNoVK5MC1r3g"}]},
          "s5HIrQRmWvfb4G7nsJhiFyqpdiC9_af_CySdw-r5xUMhSOHE0K8EDBp
  0Oi60QH6IqI1hz98pf1utE2dpuIVCsrjnunA7QrLzMCE4z0h4WNp_4zDJv-itr
  KNB0f3gDDIUpXkvtdWbgMZzNeMhxeh1XjuixXnPafhMnlcZ0VwuOHstocXBkRQ
  oXy_vx21RHcA1CdaD9_sSV_d-m_sDC0lWA4tLw7Ds66kwDb8Rv61rxy816rxnZ
  -XC4vm3kmMVnsf-Kh14TJtZGB-KQZGxXKjygd_XuKnOslZUySVFqbuDtVNnOGL
  WMszE9U7G_NkCgeskX6yt31QN8SeSrERMBd2ZqVuuhC8xC7w317HnZCfaCccgN
  80ZqV1PWBF_DErtZhsaM1-elNw5jQ-DF3YL-LPy07HeuZFuYsc_C5c6W-rLyyC
  MTZH4FChSZ-w6yQ1XaSdVoJsxPN6yHXYxfwKeCPoCSZFuikFhleSIbZ_yR6bZM
  B2xJwfFPfsrVM4hoyb8afNykijrxD61euZpoi4Lh-58pXHBcQFu4CBD4d8C9uy
  DcTXTYFK64rry2tUP-eNfvwKVQgdgojEkCTdoeca6pDf_xA-4QCXauve2EQzdC
  CE2gqJn-GjxGC9s3ONHdTMKA9m5xom3l5hJvUYS6s7yU9QR-BKVmhIYz0FB_K8
  o-wkYJ0YrlxuMaPGy7HzzpgzhjELjwoenlvX24AIMNTMheplANoy55myWvA80t
  xoluugbne4dS8b1XmOHW73pF0fZcYZStnHNF4MBtP1nbP5SVIehEsEq4jLzLTy
  U7vAP5ADCI7nyi9_BECBkYs_nNmYlGsiOynE5z_DFAWyPjFuWINn4WhSOyIU1t
  uG8sDtariEboF3FdWKZi0LV2437mfWCBYv6j9aJq5pV4QziG8GEUlY9kKGRds2
  XHH-kb0K2Hd0fNaYOls_X64KC6DziLcQGF1j5mxNGHI9siZoSffBOXvcoug8Hx
  u8kJs_1T0GK5V5i77UEx0jy33oanjjTy_1EbGPX-zIMwarvxp0WnhVC_DRLVvJ
  2Hp8kgVFOqgwSdh3grsMmcB_55xbN-KwtsKLLsbDC3_7QRLSHBCfVDZcKXm0_0
  BkCZjz1jc7XCmWbnlNpkGsvJatenkA712E6c8Ei3sIxuCmwWNNcKGBYkFgpbLS
  sd4v-VRsoN1ew9-STOs-AxwVSSATdatMQ4jds4s5X1ZBt60CepkqaHsuuCNNKz
  cl8LW_ydnVQ2S7_60ldhJn9U3qUI007_ydAFIzebjH2aC5h2ZIQgblGMIUmXfN
  ApID-kKT9H1r9Y9FH2JJnR-ZETliMkiAIQX-hyMUp2bhX2l1jA3k7dL3-e1s4O
  nrO3MZGExez-QbMV4xDhBH5xKGqYn6iEyT8y0BecT8C1WlLFK6zVYdNtd5Wrm6
  Y2n6ZEfvyVavWmgjw1Gwaj3bIzY6vU2A2He5x1z8KzQxWzGr1uHg0HqBMDHL0_
  YrBPy1ix6x4RAfPYsPrS_sI8aSAhLtfxMfC44EOaK_hGsmgmbDvighdbBYWH7Y
  9zGEFXx7PQBjyunVGBGIVmdOlqKSgjnV_ASuQXVS8rWWtQFv_HH0D0lNeWZJML
  gv1IW8Kb3u7UX6LyFFKhEn8vRUHivMQpUhD-MLKoZhmyZ1nDriVKerHV5GXT9y
  QoeUBfAscABw8B4fAexST9X4hIVHEkRryqN9_gVWlLsPhI6cvCvERdrzz15cuo
  WlYt66RY_iLPCXdB39pqgS1ufJyXVlTUxgC26NGbQY9AgdlQZE7C69kia31tpN
  oyK_AdIPgIjEFMQ_yRUEtnyu4JqbgAD5oG5r8cThQOfseSYAGAitRk09fKsEuO
  N01juFncxqaMi3Z_BiXHDNuMzZsCu8R9epCPju-DBuQTWENeRcwGuyExW4ApFe
  fY7hy1euEYjvmAdxy25Plw6NMo_MTjFpmpu0RI79aMCpq3G0OAulNlMIPtj2UL
  XHQDT4E50RAOipQZt8gEZvL_kWbrcPLwDMd22gYsFphJNPTGk9MdM5-bSqs7iN
  84HebIkt74TpWqiNaXYZvb9GS00Gif6meF6U9u_eRzOqQVUKbmXCnotU4kxZRb
  -X4Nw87J2H2I8hmvPKeaEU2PkT8u4xXa7G2d6DT7m_qDQ0LEIlc43meHZQEQ-0
  1PT2UC6JlJwSidKWJSXTx9bMaaabixUHY_zF_LGsRiAoANUIcxFUzNSiLaDXvk
  eJ2bRrDUn70cOinqzR-2C-xBwe4hV7XccocHFPvemJeZSwctCR8SVc3lLRZI6S
  wx6BnY4_GuDRa3kJvqWLhxwOaE7qwc-mM53iZjA",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MDF4-YA2E-FVGJ-LAG5-IK5Y-FXBB-2I56",
                "signature": "SBuTYFanmksfT4jyQC4kEB6KxF--rSNx9LrPdjrxOe3KO75PD
  SIqe1M6LLQNTImfSXbcgHMt8PYAz5-3dpxm3DTqD1kAE0F06kPUrD6uLFWIBXW
  _GOsS1UDimJH4KqyCOXpCIdTWxpyrjeVFskBuriYA",
                "witness": "gbvZVM1kwFm_9KffiNllGBhID4pIywj_tqkdmfVXbqk"}],
            "PayloadDigest": "RVuI1N2uL7q4LFzQ-mMGC_PioMCFTI92XIAuLxTXLiDyF
  SOLwKHYl47acTprm_5uF_k9HtPsJJ-77EXU_yYWWg"}],
        "Accounts": [{
            "AccountUDF": "MBEA-67YL-KUQ7-LFXL-BDVK-WA6H-SV7Q",
            "EnvelopedProfileAccount": [{
                "dig": "SHA2"},
              "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1CRUEtNjdZTC1LVVE3LUxGWEwtQ
  kRWSy1XQTZILVNWN1EiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICJwd2pESVR6VmhSMmJncFhGRjR6NFp
  1RTBBT1BiY0JnUExzeWdOMjFEUG5KSUpaWDUwbVZpCiAgYXlTVUpnWXBVRFBKS
  mJEbktudm40bUVBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1BVFMtTDVTTi1PNUFOLUxFUFEtS082WC1RM1BSL
  VlQUEYiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIl94eGFKYThySHBtVjNVX3BDYTlFZkh
  wUkNtanlRb2U4eGxhNkpaaGxkRjR1NTVsd3ZaVjYKICA3MDlSWEIyR00xWDB1b
  2x1aE95YW1hQ0EifX19XSwKICAgICJBY2NvdW50QWRkcmVzc2VzIjogWyJhbGl
  jZUBleGFtcGxlLmNvbSJdLAogICAgIk1lc2hQcm9maWxlVURGIjogIk1DT1otR
  0laMy0zNFZRLUdRNkotRkNTNy1CSklVLUpDT1kiLAogICAgIktleUVuY3J5cHR
  pb24iOiB7CiAgICAgICJVREYiOiAiTUQ2RC1TWUY2LTIzNlEtUTdSNy1NWkdJL
  UlRWlItRVhDTiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICA
  gICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiYVBDV0RwQkozdDF3RGx6YXExREt4TXc0U0p
  SNXdoMWV6RzFTT0JxaFdjcEF6elNaS0kzbQogIGZRMjBfSWlOcGxmamYxTjNYV
  GFOTVlBQSJ9fX0sCiAgICAiS2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUNDNi02WkJPLVdBWlQtM1NPNC1EWk1MLVEySVItTVAzNCIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiYUtIb1l2UHFUaGZsT1V6NWEwTjU0Q3NRZ2ZrQWdOZEZvcTRjNHVtb1g
  3U3ZhM3RIdW0tNwogIDB0Vk5Id29KNVhFZ05HMktlNHNBeGdPQSJ9fX0sCiAgI
  CAiRW52ZWxvcGVkUHJvZmlsZVNlcnZpY2UiOiBbewogICAgICAgICJkaWciOiA
  iU0hBMiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFUyVnlkbWxqWlNJNklIc
  0tJQ0FnSUNKTFpYbFBabVpzYVc1bFUybAogIG5ibUYwZFhKbElqb2dld29nSUN
  BZ0lDQWlWVVJHSWpvZ0lrMUVNMFV0VkZwSFRDMVVNa3RYTFZoUVZWUXRUCiAga
  3hGUkMxS1VGSkhMVUZIVEZVaUxBb2dJQ0FnSUNBaVVIVmliR2xqVUdGeVlXMWx
  kR1Z5Y3lJNklIc0tJQ0EKICBnSUNBZ0lDQWlVSFZpYkdsalMyVjVSVU5FU0NJN
  klIc0tJQ0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlSV1EwTgogIERnaUxBb2dJQ0F
  nSUNBZ0lDQWdJbEIxWW14cFl5STZJQ0k0ZUZGUWRXNXBVazU2VUU1dFVraHRVM
  lY1V25KCiAgaU9WTmpjWE5UUTNBMGNFVnlXbDlJZW1jMldWZHFiRGxOVVVWTGJ
  rMU9DaUFnY1ROeVRVMDRNVVo1Ymw5T1MKICBrRmpZMlJzYlV4SVRFZEJJbjE5Z
  lN3S0lDQWdJQ0pMWlhsRmJtTnllWEIwYVc5dUlqb2dld29nSUNBZ0lDQQogIGl
  WVVJHSWpvZ0lrMUNRVTh0Vmt0R1RTMDNUVXhXTFZoQ1RrVXRWRkpRV1MxUlFVZ
  FRMVmRTTmpNaUxBb2dJCiAgQ0FnSUNBaVVIVmliR2xqVUdGeVlXMWxkR1Z5Y3l
  JNklIc0tJQ0FnSUNBZ0lDQWlVSFZpYkdsalMyVjVSVU4KICBFU0NJNklIc0tJQ
  0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlXRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWl
  VSFZpYgogIEdsaklqb2dJbFZXVkZGdlRGUlBZblZUUVRsVlNERktTVUZ5U1dGT
  VJtZHJlVGhmYlhwSFlWQk9UR0Y0V0ZsCiAgU1ZXVXhjVzlZVVY5UGVtRUtJQ0J
  sWnpKQ05rNXhTMmxLV2tGc1V6VnJYeTFRV0VGek9FRWlmWDE5ZlgwIiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI
  6ICJTSEEyIiwKICAgICAgICAgICAgImtpZCI6ICJNRDNFLVRaR0wtVDJLVy1YU
  FVULU5MRUQtSlBSRy1BR0xVIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICI
  zemozWG5tdUlnVWxvTUdvZzE5X2IxMnVDMXd2aC0tZ1B2dkNNeFBYajJpWXZHV
  Wx0CiAgRFBnQ3FVNUVKOVpuZ005VHlrVDJPU3NZOGdBMm04NERfT3lfS2NyeGN
  nS0szN0pSQUhKbElBakp5RUNwNVYKICBnVUJBNk5ZVGE1aUhuUmFUcXhyaGM0R
  1NCWElRVFlObkxTSl9DSXdrQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI
  6ICJNYTliNkVHN2dZc2FsM2RVb25RNEJnSDRVTFlsYlVGT3R5THQyNUppeGI5Y
  lgKICBCZGhwcFNyMEFkRmo5QmU4QWtvYl9adEFuUm1oeml6a0sxZWd0VUhXQSJ
  9XX19",
              {
                "signatures": [{
                    "alg": "SHA2",
                    "kid": "MDF4-YA2E-FVGJ-LAG5-IK5Y-FXBB-2I56",
                    "signature": "_HCUub4SeVt2cbdVsFNQMo0E9dN7x8eqRVNt3XjxojDL94T3J
  JpV88sYKa28zl_ih07W1YRM5SwA1AydANcXVfxBu3-LEvROhgixHCMuxmyUWsy
  Adn_aSAhtbIXE9uS-X9WEojnGHH_mat1EIiNXxwwA"}],
                "PayloadDigest": "WZslxRLR38CdQ_x9LXB9kFQmj_XvrFy2hqsH_j-9rtJnZ
  hSCtOm2ikd6fw4cO1fGONhFMf3LQaBYRJIwRbvofg"}],
            "EnvelopedConnectionAccount": [{
                "dig": "SHA2"},
              "ewogICJDb25uZWN0aW9uQWNjb3VudCI6IHsKICAgICJLZXlTaWduYXR
  1cmUiOiB7CiAgICAgICJVREYiOiAiTUJOUy1DV0hDLTRJUFAtRllYWi1aRVY3L
  U1aSjItNjNNSiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICA
  gICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsC
  iAgICAgICAgICAiUHVibGljIjogInlFRWdJS3VhRm5qV0lZMjRUVFhtNnlmVmh
  FWmFDMldiX09WdmlaT0NWdENXakZjMElIQlgKICB0MlhDNDh1TEh2czQ1U1RXL
  WpZUjdic0EifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJVREY
  iOiAiTUI3TC1VRFFLLU5XQlItQkg0QS1KWFJBLTdWT1ktNEJNWSIsCiAgICAgI
  CJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjo
  gewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiN2VSb1k4MElSTlZFb3BvYjEyZ1NGZVZrZll5RnZHaW5lak9jLXFlYVpnZWd
  RdVBoVExXUQogIEpGVU9fNE80X3VIbVNlNUJWSFhSWmQ4QSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUNMRy1EVlJCLTR
  HWk0tRlRZSS1ZUkJZLVRSVUwtNUdIRSIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiWWxJTXM5SEdDcmFyM
  mQ5ems5eWNzem9XTlZOWXdrelgtTldkb0UtQ1ZMenRWbFVPT0VLTgogIG5Ga05
  aVm9oNDlwUEQ0cW9MRXhHVDlTQSJ9fX19fQ",
              {
                "signatures": [{
                    "alg": "SHA2",
                    "kid": "MATS-L5SN-O5AN-LEPQ-KO6X-Q3PR-YPPF",
                    "signature": "qtVJtA1e7G2dxhB1VHYq60HxvG0dulaCkRDdOZ_zKBjPvF1zH
  _NC5LLo_ep-Ifk9QkUl0e9qppWAFF8lQIF_zNs1bdhuD0LgbH7Va3HnJacfKhT
  wfUBW0HLQmZY_4AK24MooEpanP13I9ql4GbAkdyEA"}],
                "PayloadDigest": "z-wT7YyVo3tN6Egr6C3wdweuZ7qVVVIU6jYf6LAF6sQMw
  cZQkvCYw6f5vjV6suJswvgBtDTQyUNnqRuDFPvexA"}],
            "EnvelopedActivationAccount": [{
                "enc": "A256CBC",
                "dig": "SHA2",
                "kid": "EBQA-OVNZ-ASLJ-VBRK-6VOK-M3VY-ZRO7",
                "Salt": "youU4QryGwtwbJMQ49et6g",
                "recipients": [{
                    "kid": "MAPD-FY6J-UJM2-HXMZ-YMD2-VHNQ-ZI7L",
                    "epk": {
                      "PublicKeyECDH": {
                        "crv": "X448",
                        "Public": "vFUEryFWIu-LGWkSVvz-qQnQZoWONScCNAMEiE6sYV3PLFSeS284
  memG5V6jkunkgk6UeoItsNSA"}},
                    "wmk": "bapolgBy8xxhjehR5do9BTrGqVT0Tt-MMRLW33hcYdWsCcmZO4r6yQ"}]},
              "PHfR-GtQpygaxLEZdHqh4Foy83pWQXgOoX4IEvNeAdWWkkHJFUbRkQh
  c9UZ5OYNkbj3roAcNZZ-TV5swTSLKPfA0K6GsqiNUqiTBeopveP8-RgbOtZcJv
  3Vw22Xk_JNOqdAxDsyNjBZEa5TX4FDLh0J4-EkJip_WuxBKpaFatZwEX_QgHrU
  CWL6pDZ8ii693yZljy78jExPi9WuHO0g6K36fsOjGTO0EfRlTOwNfi2849UTuO
  MQl_AnWaLfJlqXx9J9ELcKZVTIB1wOwxjzcFWtWxbPa9sRNDmjNx4lWbaBWVNr
  IwwgDNGs_04iTQ-OqdBO-4_bhiy-qYy2hZekoO9NpMX6IxIXfaxNnapo0a-QyD
  b2W3eubXSLZppIEr2THWk56h-JElhj8671XIpe1-1QvvD5NDLgc39CgRyPTrTI
  ZY5hpdsWb1irJb3-Eb7GjwCeCZRno-Xifcl-pebzj_-u4EPAQ4Ry000JG_0DPX
  SpJJDMNj6lE__H84_kiUiUXcz9iJQXqBqh74W9rynKtLcgi5UOl845y8qWPMoy
  l8m9jLqr4lLYxtDSMDdyvbZLPOuo8xke2u6zj1_mIhytyHhghok_f3koTK3ED4
  BRA1QAH8AqDQBtpo3l_QRkxGnInRzoeinNifZ7AnLjwjCVoenlRaBWx1zbe-1f
  Ebabl6RKAoCSjvLdwFvLkQ-5VXuuCk2WZ3VuQTre5asQeuSg21l6LDbhqjdCEo
  I1uhRCoQzOzg2KjoJWTd9uC3tNAa2Sg5ztQ4c4yoV5XrouXEL9L7M3xYLDuTAS
  dTPauRVRzcAJ39VVFsATRoJZTsTKvCnb4B-tRRE5cajkTx-lE69hzYeHmCwbyf
  YGBf4xHI8elVcZkdvncnL6gc6q4y7HZbVYqYzlVgB0uEPDnX5De5SdYlEN83Sb
  g8YCjNmJ4BIzxbtmvxDC_0AeedkStOAYmqiQxvUZzIzjNvHIRzghD4gMhCZVka
  Hu1dSgDjUaR8ea0QYfI2o5E6bdeOcO5yL8FL77Q9XYoMAmmhJFwgfxeOdD3cGl
  VZZD7yIzzQCABJCjNVBQNXP7mnt_qvqBvGcec78NyYQt_Qlqwwy86tsPujWGxw
  gZVL2MbpDeY2AcW57xSCFa7fiRG8yb8eAQgFqIx7dMMWv3vka48-tk1sFpHciu
  6CjtZbbwy2LLVc300AznEo4nWEFgEHZuIy2Sj4AgxGHE6kvaTZqmLPX_QksCgM
  VFJ69Rhri-jupRSqqhOmJzFI9knSh08RdczH0HE2mdHPDC4DdXeyRc55ri6BXn
  6ct8XydOHSo8HK-0CgfMPh-SKeJsQPyzfAh5NoQxEsFCtufBywSXOO-K6nn2IF
  JPUxJiR6so5TZ8zJW4O5uKNsbhcK3Qbg_xNjwVTfuLXBa3I1sL9CTadqgJRqrr
  9rj-QSwZPSZ88DoT0HvVqq_fnTdC38GTnZZ0BQUr0ZBAdAF5r1fme-DIEuM_Qv
  8qxJHMKU3K7GHqZ5N7BpUcuoZHrQ89YMrh6Gm6mora8co6-iYsaXZefyOLPJ_L
  Y0JfDsBdnzw7sH7_E1ejnFPmkJutHKNOVTmkK61AB0OxnhmBVidILD02Wy4ti8
  x2U8LY62HV_IlImSvXrDd0_gwdvypx72DIT6Af21IXJPE_MlK_0sFIOOUsf-Ka
  6Yt9WxJl5jCG0fSjwLEMSLXbHoo5SNQ8reYCcdDi742QYvOX5ch2wVCA_Azumw
  h4-SA19z75p5DAftflID992DEBhhEtR-XQpAeXAMmtYPTboK4Mw-Yv_4VfXtBy
  TUuwb8rDC558dU8HoFz8MQAhtx0YyBQKZpMpf4iRMPLZSQq9Hb2I6x9drKE9sR
  t-HMLf8wMpIEviu31aFtDZkfCNnd7tMcQYjQpW3q-nBxmUJynMyt7HVeVeBp_U
  ctUfdVJuZzhBpKVWlqpUIfNFNnQ-zr-7qao56mRaBGCY_6aEwnilhlcHqFkowg
  klj1ZIVgBbETJGvpYXQ40b94oNH-t2Z1m3ROkTs9lar-nhDwIko1N1nrpLN_b7
  6dxYtfOKTfs96uIas1F4SUJZ_JLELWrPvJn2MoQo6sso02MD-c9O6APYQjP80v
  7sEtYCLTVXEuJMXb_DIcAClJAHdCZnMdckhiNnuQzryRZguZqgan5lWDkeA2IR
  R6Z9IgQjCTkiYfk2br4ZzPM7bul3GzCPXJIbSKMYG6uTSIA0nNEqO1TFzRnR7i
  AtkSrAEEr23oh0K09TLWBMPjHB6wD0yNpdeWoauQ7AGC4aCKe_zJ_GTsnGRbpM
  UN63x3MqlvEOfWU1uoPfSUy37cQiN4KNOjU6sB6TUb8XSnPwzEzlIKSC2gn5ay
  w9F7GIs5Xf95rn74buY0FevOvqfYD4mRWMCAYTYYFOjI9ZMKz2dsmcm3tmiRxK
  uXhf05xxukJoVo5syniMdY4TfhW-0q0xwXJtN4yzn6Jtf4DkLtMacvHw8hfsPI
  3FPGxFX3_98Wa7CITuSl9STxFE-3idkmu2aRRZDcvz0Yv5ByDXMPE14SfRNSIs
  _bGVv0HGrliLbag5n-oGz4yOcnKsaYbUdXm8hdI-NHnodqv2ASGRXUMGL-78Z0
  AF5wh2MuFHcuHYuEnDEqvsrOK3H3EpyFdjHelZZZtorE-ISum7vX1ztqllVvBl
  fVzqV2LgNY6xbGldSsBZnxGr9EhqUcDfrSaKLd07frYavwBrqXKKd6siLtjZII
  sI0mc4f8i4a-tKnlDy44-PlmNd2SFp0Is7if_am5hikWyO8UJn4BQ",
              {
                "signatures": [{
                    "alg": "SHA2",
                    "kid": "MATS-L5SN-O5AN-LEPQ-KO6X-Q3PR-YPPF",
                    "signature": "UnL4c6GelNZW5a7_PJDgSAbJlQzM2UDivh84qbOf892dkFc93
  B46-YP_IF9_vxKxCdDebf1i-pIAjpOTz5y96oa3lBQqsleKAUWN3Jby-wsRL5K
  oAn1PEON6J--B_jzdBKjD3fHMXPjNPpUwJqqKjAIA",
                    "witness": "iFhNOIlHVZIWe1xdSbD50xFD3kohe1Ljft8oVEuYEGg"}],
                "PayloadDigest": "tQ1qsN3JL2ZzPjWLW6GAa5fBuPhIie17Wo_S9zzT3CCzv
  uVY1hZdMXMORPWMd-KTG2D8DB2DDMj_ig8inB1VCQ"}]}]}}}}
</div>
~~~~


# device delete

~~~~
<div="helptext">
<over>
delete   Remove device from device catalog
       Device identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device delete` command removes the specified device from the catalog.

The parameter specifies the device being configured by means of either
the UDF of the device profile or the device identifier.


~~~~
<div="terminal">
<cmd>Alice> device delete 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device delete 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
</div>
~~~~


# device join

~~~~
<div="helptext">
<over>
join   Connect by means of a connection URI from an administration device.
       The device location URI
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device join` command attempts to connect a device to a personal profile
by means of a URI supplied by an administration device.

# device list

~~~~
<div="helptext">
<over>
list   List devices in the device catalog
       Recryption group name in user@example.com format
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device list` command lists the device profiles in the device catalog.


~~~~
<div="terminal">
<cmd>Alice> device list
<rsp></div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device list /json
<rsp>{
  "Result": {
    "Success": true}}
</div>
~~~~


# device pending

~~~~
<div="helptext">
<over>
pending   Get list of pending connection requests
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device pending` command lists the pending device connection requests in
the inbound message spool.


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV
        Connection Request::
        MessageID: 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV
        To:  From: 
        Device:  MDTJ-IEIN-4ST6-ZC3G-OUSP-PBNM-PHYK
        Witness: 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV
MessageID: 2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM
        Connection Request::
        MessageID: 2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM
        To:  From: 
        Device:  MBKR-2YPO-UOPU-2QTE-2YXK-J55K-QBWQ
        Witness: 2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM
</div>
~~~~

Specifying the /json option returns a result of type ResultPending:

~~~~
<div="terminal">
<cmd>Alice> device pending /json
<rsp>{
  "ResultPending": {
    "Success": true,
    "Messages": [{
        "MessageID": "4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV",
        "EnvelopedRequestConnection": [{
            "EnvelopeID": "MCES-PQVF-AIDB-7ITY-UZDL-27MK-KXVI-CRZ7-65GI-PT2Q-6YTP-QRPA-ACJG-GTJ6",
            "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOQ1ZOLUtVVkwtQkdZUy1
  LWk0yLTVHNlotTEw0Si1WSFNGIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWVzd
  ENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL21lc3NhZ2U
  iLAogICJDcmVhdGVkIjogIjIwMjAtMDctMjhUMTU6NDk6MDNaIn0"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJ
  NZXNzYWdlSUQiOiAiTkNWTi1LVVZMLUJHWVMtS1pNMi01RzZaLUxMNEotVkhTR
  iIsCiAgICAiQXV0aGVudGljYXRlZERhdGEiOiBbewogICAgICAgICJkaWciOiA
  iU0hBMiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b
  2dJQ0FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUN
  BZ0lDSlZSRVlpT2lBaVRVUlVTaTFKUlVsT0xUUlRWRFl0V2tNelJ5MVBWCiAgV
  k5RTFZCQ1RrMHRVRWhaU3lJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjB
  aWEp6SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ
  2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0F
  nSUNBZ0lDQWlVSFZpYkdsaklqb2dJa05wYURjMVFsUlBVR0ZoVEhKdWIzWm9Vb
  U42TVZRCiAgNVpXeDRObXRHVm1GSlpHVlFhVFJRU2xKVGVYSXpNR05DYm5kTlE
  zUUtJQ0I0TVVGbFNHRTFkamhYV1dwU04KICB5MWFTak55WldkeVowRWlmWDE5T
  EFvZ0lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZ
  SRVlpT2lBaVRVRlFSQzFHV1RaS0xWVktUVEl0U0ZoTldpMVpUVVF5TFZaSVRsR
  XRXa2szVENJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWp
  vZ2V3b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ
  0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlF
  kV0pzYQogIFdNaU9pQWlVRWxpTFVaVWNsRnpRbHBsU1ROS1JrWm1NVGMwVFU5d
  FVVcFZZVXBOVUdkUmQzQkZNVVZ2YlZnCiAgM1pIcHRSVFI0V0V4T2Jnb2dJRk5
  uZVZsWVVVRjNlR3RvV201b2QyWnViR1p3U0ZCNVFTSjlmWDBzQ2lBZ0kKICBDQ
  WlTMlY1UVhWMGFHVnVkR2xqWVhScGIyNGlPaUI3Q2lBZ0lDQWdJQ0pWUkVZaU9
  pQWlUVVJFU1MxWVNsWgogIFJMVkZSTlZndE5WUXlOaTFaVVVwS0xVUkxOMEV0U
  mtsSE5pSXNDaUFnSUNBZ0lDSlFkV0pzYVdOUVlYSmhiCiAgV1YwWlhKeklqb2d
  ld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGxGUTBSSUlqb2dld29nSUNBZ0lDQ
  WdJQ0EKICBnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0FnSUNBZ0lDQWdJQ0pRZFd
  Kc2FXTWlPaUFpVGpWU1dEWlpWbUpOUgogIFU0d2FsQmxSVFp4U1ZWbU0wNXJaa
  kpUYTJGV2RXY3dWMGxWTkVOSE5rRjNUVmRVUlZsd1MzZzRlZ29nSUZvCiAgd1p
  WWnNhWEEyWW1WbFdEZHRPVjlZTjBzNGJWOWxRU0o5ZlgxOWZRIiwKICAgICAge
  wogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6ICJ
  TSEEyIiwKICAgICAgICAgICAgImtpZCI6ICJNRFRKLUlFSU4tNFNUNi1aQzNHL
  U9VU1AtUEJOTS1QSFlLIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICI5S2h
  jMjBiX1hSTlBIQTF4RkgwM3B2SmZhOEtlSU8xcVdZNlRTZGxvN0VlWWNzcF9JC
  iAgYzBsanlsUWczMS1VQlNuV2ZseVFYNFllb0tBcS1PQmJtNXpPNzc4ZlBod2d
  fak93ZlVmSjBsM05TX2I4ZU8KICA5TFp3cWFfWGxOeHRHNjY5Q0hNYmdIRjJqR
  WlXb0Ywb2NkN1ZnaXpVQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJ
  rem1fQUVZWldoaEUzYWtvQzE5YnE4SDR2RU0zRFhidTZ0TnR2aG9HY283THYKI
  CBSaDI4dHpzaVE5RUJmNDJqM2p0dzliejBGZDNnOVA2cUhaNjgxM3Q3USJ9XSw
  KICAgICJDbGllbnROb25jZSI6ICJxeU9rbllocjhzYWVEaEFkSUI3NHBnIiwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"],
        "ServerNonce": "fFY57xjwJM0s6YETC0UN8A",
        "Witness": "4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV"},
      {
        "MessageID": "2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM",
        "EnvelopedRequestConnection": [{
            "EnvelopeID": "MBXY-X7KQ-VZ5A-YYPI-YTZF-DHZS-L6VO-CVDW-6J3J-FIIJ-WSS5-PFFZ-O2CF-67ZT",
            "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOQVdCLVRNUVQtSkQzUC1
  WQkxILVE1WUUtMzNMRy1MTFE3IiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWVzd
  ENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL21lc3NhZ2U
  iLAogICJDcmVhdGVkIjogIjIwMjAtMDctMjhUMTU6NDk6MDJaIn0"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJ
  NZXNzYWdlSUQiOiAiTkFXQi1UTVFULUpEM1AtVkJMSC1RNVlFLTMzTEctTExRN
  yIsCiAgICAiQXV0aGVudGljYXRlZERhdGEiOiBbewogICAgICAgICJkaWciOiA
  iU0hBMiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b
  2dJQ0FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUN
  BZ0lDSlZSRVlpT2lBaVRVSkxVaTB5V1ZCUExWVlBVRlV0TWxGVVJTMHlXCiAgV
  mhMTFVvMU5Vc3RVVUpYVVNJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjB
  aWEp6SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ
  2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0F
  nSUNBZ0lDQWlVSFZpYkdsaklqb2dJbXRMUVVkbVQxbHBhbHBwVERWclJHRk9TR
  TVKYnpBCiAgNFEwNWpSVzk2V1RsQlVXUjNjMVZpUTBwVFZETlFValJMYUZSMk4
  zTUtJQ0JKU3pKM2FIZE1aRWhVZVhCbmQKICBYQm1NelZZYlRsaVYwRWlmWDE5T
  EFvZ0lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZ
  SRVlpT2lBaVRVTkJUaTFUVjFsRExWQlpSVW90VXpkV055MDFVa1ZXTFRSWlUxV
  XRTa0ZJVUNJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWp
  vZ2V3b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ
  0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlF
  kV0pzYQogIFdNaU9pQWlOamc0YVVobGJHNURka0oxTkZaNFYxRjZNRkF3UlhoS
  VJFZHpTVEZLUldKQ01qZFJSVFpMVm1sCiAgak9WcFNhRm95T0V4U1ZRb2dJRlZ
  OV2xwbU1EaHZVRWhpVkdJd2RUWk5UWFZGU1dJMFFTSjlmWDBzQ2lBZ0kKICBDQ
  WlTMlY1UVhWMGFHVnVkR2xqWVhScGIyNGlPaUI3Q2lBZ0lDQWdJQ0pWUkVZaU9
  pQWlUVUZCTmkxQlNEZAogIE9MVnBOVmxrdFVraFdOUzFWV1VaWExWaFRVVU10U
  VVwV1R5SXNDaUFnSUNBZ0lDSlFkV0pzYVdOUVlYSmhiCiAgV1YwWlhKeklqb2d
  ld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGxGUTBSSUlqb2dld29nSUNBZ0lDQ
  WdJQ0EKICBnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0FnSUNBZ0lDQWdJQ0pRZFd
  Kc2FXTWlPaUFpVmxwV05rMDRWMlpqTgogIEdaMlpqQklNRE5aVDBWeFVsWnhYM
  GR1TTJGUmRITXhOMjlVYlU1cU5sTjVPRWcxWTI1T2QyVk1SQW9nSUd0CiAgelJ
  XdFpUeTFoWDNsb2VXbEhabWxoVEVRMlNTMTVRU0o5ZlgxOWZRIiwKICAgICAge
  wogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6ICJ
  TSEEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQktSLTJZUE8tVU9QVS0yUVRFL
  TJZWEstSjU1Sy1RQldRIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICI1Wmd
  EWkhVckVEeUY3bG5xbUtEdFhNSURKN3BiVDZoNjI0WWtMWEQ4OUZCaEJxeFZDC
  iAgVWxvdXhMakQxRzl3c092T01Gckd3Y2EyU1lBTnI0VnhQUTFmZTJyQUtUYkJ
  4eTJ3b0wxZW5tVXJ0dktSenAKICBxR0hjeUtrWUk4QjdzR0prOWx4cXV4RGRUY
  zRLTHRKOHU2QWhReFRvQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJ
  3N0ZCWXVXazlOQnJaSHBPSnJ3czMxNjFQNWFKbjRpOEVfWDg1aFN3ZkxXSkIKI
  CBGY09XUndPLVo1SVoyd3BaYUIxLTZ3cFJJR3RBc2Z3SHEyNkFDUTBrdyJ9XSw
  KICAgICJDbGllbnROb25jZSI6ICJxNTFDRzlNWG14Q3VPXy1jajBZTndnIiwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"],
        "ServerNonce": "PvrpK7WMtOtQ2Oo4WxyAuQ",
        "Witness": "2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM"}]}}
</div>
~~~~


# device reject

~~~~
<div="helptext">
<over>
reject   Reject a pending connection
       Fingerprint of connection to reject
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device reject` command rejects the specified connection request.

The command must specify the connection identifier of the request 
being accepted. The connection identifier may be abbreviated provided that
this uniquely identifies the connection being accepted and that at least 
four characters are given.


~~~~
<div="terminal">
<cmd>Alice> device reject 2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM
<rsp>Result: Reject
</div>
~~~~

Specifying the /json option returns a result of type ResultProcess:

~~~~
<div="terminal">
<cmd>Alice> device reject 2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM /json
<rsp>{
  "ResultProcess": {
    "Success": true,
    "ProcessResult": {
      "MessageID": "MDVY-PUF3-IBRC-X2MB-BGRE-EO6L-73",
      "Sender": "alice@example.com",
      "Result": "Reject"}}}
</div>
~~~~


# device request

~~~~
<div="helptext">
<over>
request   Connect to an existing profile registered at a portal
       The Mesh Service Account
    /pin   One time use authenticator
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /new   Force creation of new device profile
    /dudf   Device profile fingerprint
    /did   Device identifier
    /dd   Device description
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
<over>
</div>
~~~~

The `device request \<account\>` command requests connection of a device to a mesh profile.

The \<account\> parameter specifies the account for which the connection request is
made.

If the account holder has generated an authentication code, this is specified by means of 
the `/pin` option.




~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MBKR-2YPO-UOPU-2QTE-2YXK-J55K-QBWQ
   Witness value = 2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM
   Personal Mesh = MCOZ-GIZ3-34VQ-GQ6J-FCS7-BJIU-JCOY
</div>
~~~~

Specifying the /json option returns a result of type ResultConnect:

~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com /json
<rsp>{
  "ResultConnect": {
    "Success": true,
    "CatalogedMachine": {
      "ID": "MBKR-2YPO-UOPU-2QTE-2YXK-J55K-QBWQ",
      "EnvelopedProfileMaster": [{
          "dig": "SHA2"},
        "ewogICJQcm9maWxlTWVzaCI6IHsKICAgICJLZXlPZmZsaW5lU2lnbmF
  0dXJlIjogewogICAgICAiVURGIjogIk1DT1otR0laMy0zNFZRLUdRNkotRkNTN
  y1CSklVLUpDT1kiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJRMVVBa0ItWE44Z1ZKcV9HTVF0emRZN2Z
  ydndVZi02OF9nbEV1b3BjcE5VMUo2blNtS1EyCiAgZDVkRkZaMVRYbThoWUNFc
  FFXUk5pWDhBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3sKICA
  gICAgICAiVURGIjogIk1ERjQtWUEyRS1GVkdKLUxBRzUtSUs1WS1GWEJCLTJJN
  TYiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogI
  CAgICAgICAgICAiUHVibGljIjogIjhHZXpMOWdseHEtQ3VIcDREUHdnSFpzMks
  1ZVhtX1BhZTQzcHAtbzluRWdvTHRsTVhUMVQKICB2ZVg0VmpSTG1BMGpRaDFIZ
  XRJNUFtbUEifX19XSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVUR
  GIjogIk1CTFQtM0JEQS1TUjRTLVNSQkEtSlZGQS1ZQ0NHLURBRzIiLAogICAgI
  CAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI
  6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljI
  jogIkhLdDhGdnA2QVA0WW9Xam5Dek1UZlp5N1RYWXUzNjBEOThkN0t2bmhaYVh
  XU0gxOE9qczUKICBfY2EzM0I1WXdxeEhJS3VCSTQtRG5zZUEifX19fX0",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MCOZ-GIZ3-34VQ-GQ6J-FCS7-BJIU-JCOY",
              "signature": "-JM6TM7W2WmDOILniZJJBnfNVHW4VzPQ6Hbl8Td17riEgJVUV
  BS40y_NBwRhfC_70vMJeuXRX40AT1G7zFBh_bUTLXBv7fqk4MDAoDdBt_vDGgK
  _LYhVSej_K-0pYIKovb0FiX5za_QuaMJW_HpPkDQA"}],
          "PayloadDigest": "-E9oIRhcwUVwnNhf1-mRhX1mBqBsucvV_q6Va1zKLMk9G
  4HsfjGyBNi1CtOzqcTcOk3kwqcADQYmeQ8DaH3scw"}],
      "DeviceUDF": "MBKR-2YPO-UOPU-2QTE-2YXK-J55K-QBWQ",
      "EnvelopedProfileDevice": [{
          "dig": "SHA2"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUJLUi0yWVBPLVVPUFUtMlFURS0yW
  VhLLUo1NUstUUJXUSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogImtLQUdmT1lpalppTDVrRGFOSE5JbzA
  4Q05jRW96WTlBUWR3c1ViQ0pTVDNQUjRLaFR2N3MKICBJSzJ3aHdMZEhUeXBnd
  XBmMzVYbTliV0EifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUNBTi1TV1lDLVBZRUotUzdWNy01UkVWLTRZU1UtSkFIUCIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiNjg4aUhlbG5DdkJ1NFZ4V1F6MFAwRXhIREdzSTFKRWJCMjdRRTZLVml
  jOVpSaFoyOExSVQogIFVNWlpmMDhvUEhiVGIwdTZNTXVFSWI0QSJ9fX0sCiAgI
  CAiS2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUFBNi1BSDd
  OLVpNVlktUkhWNS1VWUZXLVhTUUMtQUpWTyIsCiAgICAgICJQdWJsaWNQYXJhb
  WV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICA
  gImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiVlpWNk04V2ZjN
  GZ2ZjBIMDNZT0VxUlZxX0duM2FRdHMxN29UbU5qNlN5OEg1Y25Od2VMRAogIGt
  zRWtZTy1hX3loeWlHZmlhTEQ2SS15QSJ9fX19fQ",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MBKR-2YPO-UOPU-2QTE-2YXK-J55K-QBWQ",
              "signature": "5ZgDZHUrEDyF7lnqmKDtXMIDJ7pbT6h624YkLXD89FBhBqxVC
  UlouxLjD1G9wsOvOMFrGwca2SYANr4VxPQ1fe2rAKTbBxy2woL1enmUrtvKRzp
  qGHcyKkYI8B7sGJk9lxquxDdTc4KLtJ8u6AhQxToA"}],
          "PayloadDigest": "w7FBYuWk9NBrZHpOJrws3161P5aJn4i8E_X85hSwfLWJB
  FcOWRwO-Z5IZ2wpZaB1-6wpRIGtAsfwHq26ACQ0kw"}],
      "EnvelopedMessageConnectionResponse": [{
          "EnvelopeID": "MDVY-PUF3-IBRC-X2MB-BGRE-EO6L-73ID-FPIL-AASL-MCWT-CZQL-KCRJ-AJMD-OHKK",
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICIyQ0hTLTZPTEYtNU5GMi1
  YRUNYLUVaT04tQTJYRC1HRE1NIiwKICAiTWVzc2FnZVR5cGUiOiAiQWNrbm93b
  GVkZ2VDb25uZWN0aW9uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9tZXN
  zYWdlIiwKICAiQ3JlYXRlZCI6ICIyMDIwLTA3LTI4VDE1OjQ5OjAyWiJ9"},
        "ewogICJBY2tub3dsZWRnZUNvbm5lY3Rpb24iOiB7CiA
  gICAiTWVzc2FnZUlEIjogIjJDSFMtNk9MRi01TkYyLVhFQ1gtRVpPTi1BMlhEL
  UdETU0iLAogICAgIkVudmVsb3BlZFJlcXVlc3RDb25uZWN0aW9uIjogW3sKICA
  gICAgICAiRW52ZWxvcGVJRCI6ICJNQlhZLVg3S1EtVlo1QS1ZWVBJLVlUWkYtR
  EhaUy1MNlZPLUNWRFctNkozSi1GSUlKLVdTUzUtUEZGWi1PMkNGLTY3WlQiLAo
  gICAgICAgICJDb250ZW50TWV0YURhdGEiOiAiZXdvZ0lDSlZibWx4ZFdWSlJDS
  TZJQ0pPUVZkQ0xWUk5VVlF0U2tRelVDMQogIFdRa3hJTFZFMVdVVXRNek5NUnk
  xTVRGRTNJaXdLSUNBaVRXVnpjMkZuWlZSNWNHVWlPaUFpVW1WeGRXVnpkCiAgR
  U52Ym01bFkzUnBiMjRpTEFvZ0lDSmpkSGtpT2lBaVlYQndiR2xqWVhScGIyNHZ
  iVzF0TDIxbGMzTmhaMlUKICBpTEFvZ0lDSkRjbVZoZEdWa0lqb2dJakl3TWpBd
  E1EY3RNamhVTVRVNk5EazZNREphSW4wIn0sCiAgICAgICJld29nSUNKU1pYRjF
  aWE4wUTI5dWJtVmpkR2x2YmlJNklIc0tJQ0FnSUNKCiAgTlpYTnpZV2RsU1VRa
  U9pQWlUa0ZYUWkxVVRWRlVMVXBFTTFBdFZrSk1TQzFSTlZsRkxUTXpURWN0VEV
  4Uk4KICB5SXNDaUFnSUNBaVFYVjBhR1Z1ZEdsallYUmxaRVJoZEdFaU9pQmJld
  29nSUNBZ0lDQWdJQ0prYVdjaU9pQQogIGlVMGhCTWlKOUxBb2dJQ0FnSUNBaVp
  YZHZaMGxEU2xGamJUbHRZVmQ0YkZKSFZqSmhWMDVzU1dwdloyVjNiCiAgMmRKU
  TBGblNXdDBiR1ZWT1cxYWJYaHdZbTFXVkdGWFpBb2dJSFZaV0ZJeFkyMVZhVTl
  wUWpkRGFVRm5TVU4KICBCWjBsRFNsWlNSVmxwVDJsQmFWUlZTa3hWYVRCNVYxW
  kNVRXhXVmxCVlJsVjBUV3hHVlZKVE1IbFhDaUFnVgogIG1oTVRGVnZNVTVWYzN
  SVlZVcFlWVk5KYzBOcFFXZEpRMEZuU1VOS1VXUlhTbk5oVjA1UldWaEthR0pYV
  mpCCiAgYVdFcDZTV3B2WjJWM2IyZEpRMEVLSUNCblNVTkJaMGxEU2xGa1YwcHp
  ZVmRPVEZwWWJFWlJNRkpKU1dwdloKICAyVjNiMmRKUTBGblNVTkJaMGxEUVdkS
  mJVNTVaR2xKTmtsRFNrWmFSRkV3VHdvZ0lFTkpjME5wUVdkSlEwRgogIG5TVU5
  CWjBsRFFXbFZTRlpwWWtkc2FrbHFiMmRKYlhSTVVWVmtiVlF4YkhCaGJIQndWR
  VJXY2xKSFJrOVRSCiAgVFZLWW5wQkNpQWdORkV3TldwU1Z6azJWMVJzUWxWWFV
  qTmpNVlpwVVRCd1ZGWkVUbEZWYWxKTVlVWlNNazQKICB6VFV0SlEwSktVM3BLT
  TJGSVpFMWFSV2hWWlZoQ2JtUUtJQ0JZUW0xTmVsWlpZbFJzYVZZd1JXbG1XREU
  1VAogIEVGdlowbERRV2RKYTNSc1pWVldkVmt6U2pWalNGSndZakkwYVU5cFFqZ
  ERhVUZuU1VOQlowbERTZ29nSUZaCiAgU1JWbHBUMmxCYVZSVlRrSlVhVEZVVmp
  Gc1JFeFdRbHBTVlc5MFZYcGtWMDU1TURGVmExWlhURlJTV2xVeFYKICBYUlRhM
  FpKVlVOSmMwTnBRV2RKQ2lBZ1EwRm5TVU5LVVdSWFNuTmhWMDVSV1ZoS2FHSlh
  WakJhV0VwNlNXcAogIHZaMlYzYjJkSlEwRm5TVU5CWjBsRFNsRmtWMHB6WVZkT
  1RGcFliRVpSTUZJS0lDQkpTV3B2WjJWM2IyZEpRCiAgMEZuU1VOQlowbERRV2R
  KYlU1NVpHbEpOa2xEU2xsT1JGRTBTV2wzUzBsRFFXZEpRMEZuU1VOQlowbERTb
  EYKICBrVjBwellRb2dJRmROYVU5cFFXbE9hbWMwWVZWb2JHSkhOVVJrYTBveFR
  rWmFORll4UmpaTlJrRjNVbGhvUwogIFZKRlpIcFRWRVpMVWxkS1EwMXFaRkpTV
  kZwTVZtMXNDaUFnYWs5V2NGTmhSbTk1VDBWNFUxWlJiMmRKUmxaCiAgT1YyeHd
  iVTFFYUhaVlJXaHBWa2RKZDJSVVdrNVVXRlpHVTFkSk1GRlRTamxtV0RCelEyb
  EJaMGtLSUNCRFEKICBXbFRNbFkxVVZoV01HRkhWblZrUjJ4cVdWaFNjR0l5Tkd
  sUGFVSTNRMmxCWjBsRFFXZEpRMHBXVWtWWmFVOQogIHBRV2xVVlVaQ1Rta3hRb
  E5FWkFvZ0lFOU1WbkJPVm14cmRGVnJhRmRPVXpGV1YxVmFXRXhXYUZSVlZVMTB
  VCiAgVlZ3VjFSNVNYTkRhVUZuU1VOQlowbERTbEZrVjBwellWZE9VVmxZU21oa
  UNpQWdWMVl3V2xoS2VrbHFiMmQKICBsZDI5blNVTkJaMGxEUVdkSlEwcFJaRmR
  LYzJGWFRreGFXR3hHVVRCU1NVbHFiMmRsZDI5blNVTkJaMGxEUQogIFdkSlEwR
  UtJQ0JuU1cxT2VXUnBTVFpKUTBwWlRrUlJORWxwZDB0SlEwRm5TVU5CWjBsRFF
  XZEpRMHBSWkZkCiAgS2MyRlhUV2xQYVVGcFZteHdWMDVyTURSV01scHFUZ29nS
  UVkYU1scHFRa2xOUkU1YVZEQldlRlZzV25oWU0KICBHUjFUVEpHVW1SSVRYaE9
  NamxWWWxVMWNVNXNUalZQUldjeFdUSTFUMlF5VmsxU1FXOW5TVWQwQ2lBZ2VsS
  gogIFhkRnBVZVRGb1dETnNiMlZYYkVoYWJXeG9WRVZSTWxOVE1UVlJVMG81Wmx
  neE9XWlJJaXdLSUNBZ0lDQWdlCiAgd29nSUNBZ0lDQWdJQ0p6YVdkdVlYUjFjb
  VZ6SWpvZ1czc0tJQ0FnSUNBZ0lDQWdJQ0FnSW1Gc1p5STZJQ0oKICBUU0VFeUl
  pd0tJQ0FnSUNBZ0lDQWdJQ0FnSW10cFpDSTZJQ0pOUWt0U0xUSlpVRTh0VlU5U
  VZTMHlVVlJGTAogIFRKWldFc3RTalUxU3kxUlFsZFJJaXdLSUNBZ0lDQWdJQ0F
  nSUNBZ0luTnBaMjVoZEhWeVpTSTZJQ0kxV21kCiAgRVdraFZja1ZFZVVZM2JHN
  XhiVXRFZEZoTlNVUktOM0JpVkRab05qSTBXV3RNV0VRNE9VWkNhRUp4ZUZaREM
  KICBpQWdWV3h2ZFhoTWFrUXhSemwzYzA5MlQwMUdja2QzWTJFeVUxbEJUbkkwV
  m5oUVVURm1aVEp5UVV0VVlrSgogIDRlVEozYjB3eFpXNXRWWEowZGt0U2VuQUt
  JQ0J4UjBoamVVdHJXVWs0UWpkelIwcHJPV3g0Y1hWNFJHUlVZCiAgelJMVEhSS
  09IVTJRV2hSZUZSdlFTSjlYU3dLSUNBZ0lDQWdJQ0FpVUdGNWJHOWhaRVJwWjJ
  WemRDSTZJQ0oKICAzTjBaQ1dYVlhhemxPUW5KYVNIQlBTbkozY3pNeE5qRlFOV
  0ZLYmpScE9FVmZXRGcxYUZOM1preFhTa0lLSQogIENCR1kwOVhVbmRQTFZvMVN
  Wb3lkM0JhWVVJeExUWjNjRkpKUjNSQmMyWjNTSEV5TmtGRFVUQnJkeUo5WFN3C
  iAgS0lDQWdJQ0pEYkdsbGJuUk9iMjVqWlNJNklDSnhOVEZEUnpsTldHMTRRM1Z
  QWHkxamFqQlpUbmRuSWl3S0kKICBDQWdJQ0pCWTJOdmRXNTBRV1JrY21WemN5S
  TZJQ0poYkdsalpVQmxlR0Z0Y0d4bExtTnZiU0o5ZlEiXSwKICAgICJTZXJ2ZXJ
  Ob25jZSI6ICJQdnJwSzdXTXRPdFEyT280V3h5QXVRIiwKICAgICJXaXRuZXNzI
  jogIjJDSFMtNk9MRi01TkYyLVhFQ1gtRVpPTi1BMlhELUdETU0ifX0"],
      "EnvelopedAccountAssertion": [{
          "dig": "SHA2"},
        "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1CRUEtNjdZTC1LVVE3LUxGWEwtQ
  kRWSy1XQTZILVNWN1EiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICJwd2pESVR6VmhSMmJncFhGRjR6NFp
  1RTBBT1BiY0JnUExzeWdOMjFEUG5KSUpaWDUwbVZpCiAgYXlTVUpnWXBVRFBKS
  mJEbktudm40bUVBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1BVFMtTDVTTi1PNUFOLUxFUFEtS082WC1RM1BSL
  VlQUEYiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIl94eGFKYThySHBtVjNVX3BDYTlFZkh
  wUkNtanlRb2U4eGxhNkpaaGxkRjR1NTVsd3ZaVjYKICA3MDlSWEIyR00xWDB1b
  2x1aE95YW1hQ0EifX19XSwKICAgICJBY2NvdW50QWRkcmVzc2VzIjogWyJhbGl
  jZUBleGFtcGxlLmNvbSJdLAogICAgIk1lc2hQcm9maWxlVURGIjogIk1DT1otR
  0laMy0zNFZRLUdRNkotRkNTNy1CSklVLUpDT1kiLAogICAgIktleUVuY3J5cHR
  pb24iOiB7CiAgICAgICJVREYiOiAiTUQ2RC1TWUY2LTIzNlEtUTdSNy1NWkdJL
  UlRWlItRVhDTiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICA
  gICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiYVBDV0RwQkozdDF3RGx6YXExREt4TXc0U0p
  SNXdoMWV6RzFTT0JxaFdjcEF6elNaS0kzbQogIGZRMjBfSWlOcGxmamYxTjNYV
  GFOTVlBQSJ9fX0sCiAgICAiS2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUNDNi02WkJPLVdBWlQtM1NPNC1EWk1MLVEySVItTVAzNCIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiYUtIb1l2UHFUaGZsT1V6NWEwTjU0Q3NRZ2ZrQWdOZEZvcTRjNHVtb1g
  3U3ZhM3RIdW0tNwogIDB0Vk5Id29KNVhFZ05HMktlNHNBeGdPQSJ9fX0sCiAgI
  CAiRW52ZWxvcGVkUHJvZmlsZVNlcnZpY2UiOiBbewogICAgICAgICJkaWciOiA
  iU0hBMiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFUyVnlkbWxqWlNJNklIc
  0tJQ0FnSUNKTFpYbFBabVpzYVc1bFUybAogIG5ibUYwZFhKbElqb2dld29nSUN
  BZ0lDQWlWVVJHSWpvZ0lrMUVNMFV0VkZwSFRDMVVNa3RYTFZoUVZWUXRUCiAga
  3hGUkMxS1VGSkhMVUZIVEZVaUxBb2dJQ0FnSUNBaVVIVmliR2xqVUdGeVlXMWx
  kR1Z5Y3lJNklIc0tJQ0EKICBnSUNBZ0lDQWlVSFZpYkdsalMyVjVSVU5FU0NJN
  klIc0tJQ0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlSV1EwTgogIERnaUxBb2dJQ0F
  nSUNBZ0lDQWdJbEIxWW14cFl5STZJQ0k0ZUZGUWRXNXBVazU2VUU1dFVraHRVM
  lY1V25KCiAgaU9WTmpjWE5UUTNBMGNFVnlXbDlJZW1jMldWZHFiRGxOVVVWTGJ
  rMU9DaUFnY1ROeVRVMDRNVVo1Ymw5T1MKICBrRmpZMlJzYlV4SVRFZEJJbjE5Z
  lN3S0lDQWdJQ0pMWlhsRmJtTnllWEIwYVc5dUlqb2dld29nSUNBZ0lDQQogIGl
  WVVJHSWpvZ0lrMUNRVTh0Vmt0R1RTMDNUVXhXTFZoQ1RrVXRWRkpRV1MxUlFVZ
  FRMVmRTTmpNaUxBb2dJCiAgQ0FnSUNBaVVIVmliR2xqVUdGeVlXMWxkR1Z5Y3l
  JNklIc0tJQ0FnSUNBZ0lDQWlVSFZpYkdsalMyVjVSVU4KICBFU0NJNklIc0tJQ
  0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlXRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWl
  VSFZpYgogIEdsaklqb2dJbFZXVkZGdlRGUlBZblZUUVRsVlNERktTVUZ5U1dGT
  VJtZHJlVGhmYlhwSFlWQk9UR0Y0V0ZsCiAgU1ZXVXhjVzlZVVY5UGVtRUtJQ0J
  sWnpKQ05rNXhTMmxLV2tGc1V6VnJYeTFRV0VGek9FRWlmWDE5ZlgwIiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI
  6ICJTSEEyIiwKICAgICAgICAgICAgImtpZCI6ICJNRDNFLVRaR0wtVDJLVy1YU
  FVULU5MRUQtSlBSRy1BR0xVIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICI
  zemozWG5tdUlnVWxvTUdvZzE5X2IxMnVDMXd2aC0tZ1B2dkNNeFBYajJpWXZHV
  Wx0CiAgRFBnQ3FVNUVKOVpuZ005VHlrVDJPU3NZOGdBMm04NERfT3lfS2NyeGN
  nS0szN0pSQUhKbElBakp5RUNwNVYKICBnVUJBNk5ZVGE1aUhuUmFUcXhyaGM0R
  1NCWElRVFlObkxTSl9DSXdrQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI
  6ICJNYTliNkVHN2dZc2FsM2RVb25RNEJnSDRVTFlsYlVGT3R5THQyNUppeGI5Y
  lgKICBCZGhwcFNyMEFkRmo5QmU4QWtvYl9adEFuUm1oeml6a0sxZWd0VUhXQSJ
  9XX19",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MDF4-YA2E-FVGJ-LAG5-IK5Y-FXBB-2I56",
              "signature": "_HCUub4SeVt2cbdVsFNQMo0E9dN7x8eqRVNt3XjxojDL94T3J
  JpV88sYKa28zl_ih07W1YRM5SwA1AydANcXVfxBu3-LEvROhgixHCMuxmyUWsy
  Adn_aSAhtbIXE9uS-X9WEojnGHH_mat1EIiNXxwwA"}],
          "PayloadDigest": "WZslxRLR38CdQ_x9LXB9kFQmj_XvrFy2hqsH_j-9rtJnZ
  hSCtOm2ikd6fw4cO1fGONhFMf3LQaBYRJIwRbvofg"}],
      "AccountAddress": "alice@example.com"}}}
</div>
~~~~



