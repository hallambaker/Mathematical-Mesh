
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQM-JYKW-RVMI-YRCY-RLGB-5MOF-NTAF",
    "Salt":"pplcmftMZNcD1MKtFzQISg",
    "annotations":["iAEAiCALOTKrx56IJMRtShihMI5JySogirdIepCOPH2eTX
  XDiA",
      "iAEBiCDZVfsb179IGGNDaS9DYs9PASs-Hsp7NB61nKXl22RMGQ",
      "iAECiDBpktH2zSPILiwX2YQ-PyNDK4eWdv7J3qc0ATsKOId6OuABvI1kPd
  0VVXfsCyrIOsQ"
      ],
    "recipients":[{
        "kid":"MB3X-PGK5-PDA2-IREB-QCSL-3VEB-FFHR",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"bdOjYeAkXCKoDzYkyLUghmxi6rIJ7fwEflIHYtH4IhM"}},
        "wmk":"wk8MNCSl8ltucRXuDt7ZOq--nXyggY-8_QvHaf4GUirPHEyIZ9
  zszg"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "7wIVRdxzP9l-ObLt5Mr_fw2l6SaJtvmhtfbPz409qXwZ1x7YH1m0DgOsQfWm9a
  ELWF0O-9RYqMhB_CfwjhXCBw"
  ]
~~~~

