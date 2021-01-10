
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQC-6X3M-NSS6-Z3VT-BOE7-XROG-7STL",
    "Salt":"0FAsxGxJPyNU3DVNxm0kLA",
    "annotations":["iAEAiCA7Q1ffdDXkhBpgmE6yvI5sWMSVOBx-0XfhAKMa27
  1F2Q",
      "iAEBiCA3WQUTEsW_rDN7S9wdngFqOq_49FNngLu24Y1r4RRzZQ",
      "iAECiDCOr9j0dzjceNMuIWQYsoNfUzcSDiJozi0E49GQU-cmE-M24zaHZE
  MT4yRT-bpvVMI"
      ],
    "recipients":[{
        "kid":"MDP3-2S7M-HGCP-O7OY-OHWG-JRDP-UUTI",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"ZaOyR5m5tPytobWcCydnZu1j2zaoWsXYPQvvVUBcKHU"}},
        "wmk":"JabncES1yrZ2K_C1xTmkG0d0WKOtJzFFYqSMZyaFcUvBVh9q7Q
  QZpg"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "pcAAPFHdCjGnwxnCwKSj4eVPDbtfRldE4pJoWL4pkexsy8pydit8ZUPj-UmKGa
  iiOF15POWQR3btHE4TV7Mqeg"
  ]
~~~~

