
The request payload only specifies that is is a request for the service description:


~~~~
{
  "HelloRequest":{}}
~~~~


The response payload describes the service and the host providing that service:


~~~~
{
  "MeshHelloResponse":{
    "EnvelopedProfileService":[{
        "EnvelopeId":"MD3E-FN6W-3G45-YQ43-QXYR-CU4X-RKG5",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRDNFLUZONlctM0
  c0NS1ZUTQzLVFYWVItQ1U0WC1SS0c1IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMy0wNi0yOFQxNzowMDoxM1oifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJTZXJ2aWNlQXV0aGVudG
  ljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJDNy1HQlU2LUNMTDctVVNKTS1VQ1E
  yLTcyUjItMkg3TyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAg
  ICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgI
  CAgICAgICJQdWJsaWMiOiAiVHFJdTBrRXdqbmplWGVaZUlENTNhOTg5M2VSSC1CUl
  BjNWlRMV9kLUpfQV9FekdjbHFHVAogIGxhSEpTT3lmMWJmdTBRMlZOa1d0aXdVQSJ
  9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJJ
  SC1CV1AyLVo0M1otTklSNi1TV0xZLVdJTUQtUzdBSyIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiMmVhcG5KMWdEWk4
  0YkhKR29IWUxjaUNjTENNbW5UWnRhREYtZTI2QnhKd0VfMHZPNVBBVwogIENrYzV4
  WmVHY0dyM0lUcGR6cldoQUZpQSJ9fX0sCiAgICAiU2VydmljZVNpZ25hdHVyZSI6I
  HsKICAgICAgIlVkZiI6ICJNQVlILVdMWVUtVTZUWC1TNjRWLUU1V1MtNUxMTy1DNF
  pXIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0t
  leUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiSF95VEIzck5fT1A4Nk5qa2xVT0hyX1dQMXZnWFFIb1dYbk9YUnNRa
  3Y5a2djWHJNRDNGRQogIEJKQWh4UzRiRnJRSmw3cC1HVFZlMjBZQSJ9fX0sCiAgIC
  AiUHJvZmlsZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNRDNFLUZONlctM0c
  0NS1ZUTQzLVFYWVItQ1U0WC1SS0c1IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiWC1Wc1hoNjBnSUQ0SEg4SmgtSD
  RZMXNnckNJeVlTTzNyYkVyZDdiZTdNVjBFNnhHN1h4cwogIFNlTzRPQ0ZRSUJzemh
  VYU80MUtYMkFNQSJ9fX19fQ",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MD3E-FN6W-3G45-YQ43-QXYR-CU4X-RKG5",
            "signature":"XrWp20JnnxON7w0t1c-i7fbPsiJkEOLOXV0R-6av
  bIheT0uRu2k5uD93tXc4a2GFi9nqS7i14kyABxzXkOay0sbmSQAgjEH6kUq10rmS0
  HuAKEdov4GHho1VMfIlXTewwe9U1ACf5TUMz5eBaoWuWSwA"}
          ],
        "PayloadDigest":"owJg7eKJj2zd2AaEkrR90lit59cmLS_W1D_vVAFM
  AtGFG6y5RGEx0q-B39dS6oW1UTQx2jRovu-cXDhiHOJLTA"}
      ],
    "Version":{
      "Major":3,
      "Minor":0,
      "Encodings":[{
          "ID":["application/json"
            ]}
        ]},
    "Status":201}}
~~~~




