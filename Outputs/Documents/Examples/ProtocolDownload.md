
The previous status operation has reported that a new envelope has been added to
the credential store. The device requests this data from the service:


~~~~
{
  "DownloadRequest":{
    "Select":[{
        "Container":"MMM_Credential",
        "IndexMin":3,
        "IndexMax":4}
      ]}}
~~~~


The response contains the requested envelope:


~~~~
{
  "DownloadResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "Updates":[{
        "Container":"MMM_Credential",
        "Envelopes":[[{
              "PayloadDigest":"YPLzDhhS7EN_kZDTvNG5M0SM-FHOzqbbb5
  tpe2QiPcqvMbeL5wG5DixDsKpHyp2Be1-JIzC2svJLMmxThxoKQA",
              "TreeDigest":"xIiGmicJxjUJWEjWM6nqwKIG0Hmotr9pjFxTE
  FXeCCW1klZVWj4rJv1X4byJvxplJwtGVWYph9YEi0ZMFrNkRw",
              "enc":"A256CBC",
              "dig":"S512",
              "Salt":"lUbGQVUnbrUB9k4ZwNQGMA",
              "recipients":[{
                  "kid":"MDG5-EPRO-L3LG-GGFU-WKSG-EXU3-GGAB",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"NHRQRC52QsQUM8p7-p0Tc9QGm-VcojGal
  1n8tpbVd-H127mYjgGDV5vB7VqMBClC6aVISJTzWE4A"}},
                  "wmk":"cyTvjux3YTmm8XgzUXXI3VBxRFXh3ueSteXaHHFu
  g5EdKpF82OFP8Q"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIiwKICAiRmlyc3QiOiAxLAogI
  CJQcmV2aW91cyI6IDF9",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":825},
              "Received":"2022-04-20T16:17:23Z"},
            "3-njoLi2gG1Bc3eb2vGW5WJ2cHs8D7s-wrvy7L2jEAVHWlBgp4gY
  y4Pi89A70PJy3zsrJohsEw6zuqwGH9ETUmjuNWWq5cgBn2KZfz3dRdmQ8U0zw5E5y
  4qY15v5dyzaN2qh7CTUyQtxupsFhgImGYiOhnqEoCi5udTs1YpC5mg",
            {}
            ]
          ]}
      ]}}
~~~~


Future: The current implementation of the download operation is limited by the
capabilities of the HTTP binding of the RUD transport. A future binding allowing 
operations that consist of a single request followed by a sequence of responses 
will allow much greater flexibility.

