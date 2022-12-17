
Alice decides to change her service provider to provider. She
also decides that her callsign looks better with an initial capital and so changes the 
presentation form to Alice. This change does not
require require a new callsign to be registered as this has tghe same canonical form
alice.

~~~~
{
  "Callsign":{
    "Id":"alice",
    "Presentation":"Alice",
    "Holder":"MBHS-EKNA-7EJZ-VMUQ-HI5U-4FH3-RV3T",
    "Service":"provider"}}
~~~~

The registrar receives the request and forwards it to the registry which creates a 
registration record that is enrolled in the callsign log:

~~~~
{
  "Registration":{
    "Id":"NBBT-SEMX-O32L-D7M3-IHP6-GJO4-XSED",
    "Entry":[{
        "dig":"S512"},
      "ewogICJDYWxsc2lnbiI6IHsKICAgICJJZCI6ICJhbGljZSIsCiAgICAiUH
  Jlc2VudGF0aW9uIjogIkFsaWNlIiwKICAgICJIb2xkZXIiOiAiTUJIUy1FS05BLTd
  FSlotVk1VUS1ISTVVLTRGSDMtUlYzVCIsCiAgICAiU2VydmljZSI6ICJwcm92aWRl
  ciJ9fQ",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBHS-EKNA-7EJZ-VMUQ-HI5U-4FH3-RV3T",
            "signature":"l5kZXYUpcoieHn8uIIRLnF4aP3uyi7Ekk6bpWkeg
  7NWLwcImhXPDrXJo4HRPMWFExJtPpv41gPcAcAlgTIe3RISgI5_GNcuIaBJdwGytp
  1dbl0HsiciPvxDKaTC1RWUPA1wG_UXzC4Xc-gO64ZK4BzQA"}
          ],
        "PayloadDigest":"Et8xDoEm1MDB4X3o9vAUiDWvbjlZNVR5ZsQMQeX6
  vX8OCcEzL5lkD9zDxPwc8ecug_CCxdNpMoVhOeecygZ2Wg"}
      ],
    "Submitted":"2021-04-03T14:47:49Z",
    "Reason":"Initial"}}
~~~~
