
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQC-XQQN-C2KM-ZRHJ-TTFJ-OEMB-W2OZ",
    "Salt":"1clb3pU1IrSYIDNe78ENMA",
    "annotations":["iAEAiCB5iPkkSFN5sofk8nG1SfVj4qhn132W8EZi47ODdP
  9eCA",
      "iAEBiCDL5s1vXS6CwtdVOamP4TRyR4scnt9jHd680IX7Jw7bgg",
      "iAECiDAVYEXjtMvLg4XtzMNxSzicisgsYyvSMH80Zm5KnuwdZb8WAufkze
  dVXh1ae27BjdY"
      ],
    "recipients":[{
        "kid":"MBOE-T7MX-VJL5-QTW2-ZCHK-6ED5-MN3X",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"5qqCt0cylW6zUnjHrJRupLSE2QbUBKtN7Zwlse95APw"}},
        "wmk":"i7nxngoPHECA-14gdPrdWYmDRI4ioPMZu8XGgNWqIgHjgGi64w
  8HEw"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "7kDy7o9S9-GVJX4ULuyTaNbaDTHlK8FeSKmsMkRP2Cbi_8j4TtyQUEf0jzjwER
  llEaYhPQH_OH1WGxoJVELKEQ"
  ]
~~~~

