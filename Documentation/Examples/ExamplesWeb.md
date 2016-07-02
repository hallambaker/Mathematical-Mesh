
#Password Management

Alice decides to use the Mesh to manage her Web usernames and passwords.

She creates two accounts:

* example.com: username 'alice', password 'secret'

* cnn.com: username 'alice1', password 'secret'


The JSON encoding of the password data is as follows:

~~~~
{
  "PasswordProfilePrivate": {
    "Entries": [{
        "Sites": ["example.com"],
        "Username": "alice",
        "Password": "secret"},
      {
        "Sites": ["cnn.com"],
        "Username": "alice1",
        "Password": "secret"}]}}
~~~~

The JSON encoded password data is then encrypted and stored in an
application profile as follows:

~~~~
{
  "PasswordProfile": {
    "Identifier": "MDSYN-PXEKK-QTTTR-3AS3H-MQLHC-DTO7G-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
YhjmV0bW-w12tbGXvh-7tQ",
      "ciphertext": "
x7a9uxSL6F8KuFUhD75SrA3rQyucqgarZhBItIbr5BEmwt0Av3JHgdSJsZQhu2Wm",
      "recipients": [{
          "Header": {
            "kid": "MCK5Y-7KP4O-UNALP-ZPN6B-NWIRD-W4WWO"},
          "encrypted_key": "
n10q6FXujbyVwEiNLFVayIEdc5WkRTsl5Tnw4Va0hgbBmybSnOlH-JusvNl_YxIr
dkwqVokQbq0H6pTlE4J_Vn00T4tsM4nYj3iuUvZi1_mf35-cKQpqbHGWbdA8FFpU
hd-3GuA2wkvwnJBua-skOuZdZV1pYOycZXySZYyK2me5H7H8Q6_URhBbVZf8mqfv
0Tqw3Jq3Q5PwOKhBHRG8EmmV6RPFgPPSPLb_NMCeX5w4NXTzQnwVdXc5hzyhIYHO
VaoauB3rv9rcu2V3gmmSMzqTDkpAmoXBL1a9ybAoOPP_CtF2lg01FWs21FRMea8h
Y40qz6OVHlzx-s4oWbXQyQ"},
        {
          "Header": {
            "kid": "MA2LR-P56A6-2FFKZ-VPENT-FQQIE-36JKL"},
          "encrypted_key": "
GV0tSrCJDBdvaEPPClEqTFt8s3xLPT6b7toIDu0EfBxFOAv_Ok23Gh87zlzzjWFM
ljqz3r1DP30s4WQO8c2HaRTQ10vUIUal4SidobA-VQ-A1dm8b3q64WG1rkAA60sJ
PxjTDEiNxamL03mMacdJ83MXGgA2Ob59JVyJjRaFLCBaL-vhE73A-NuEYpr1fLwp
J-L1nqcKyHMzr6PWQtHkEw2T2icGN5cgNTSFhZH8YjtYzBAcE_wFjj1QaDXBCWYq
BlMfZj1G-UolV0V5Pfk2IpLG_FVvXSNH7t1j7IDKtkoN2FityEXV-QQM4ui8rCBZ
wSp6-m9PO1_ZvEIGXiWqsg"}]}}}
~~~~

As we saw earlier, Alice really needs to start using stronger passwords. 
Fortunately, having access to a password manager means that Alice doesn't
need to remember different passwords for every site she uses any more.

In addition to offering to use the Mesh to remember passwords, a Web
browser can offer to automatically generate a password for a site.
This can be a much stronger password than the user would normally want
to choose if they had to remember it.

Alice chooses to use password generation. Her password manager profile is
updated to reflect this new choice.

~~~~
{
  "PasswordProfilePrivate": {
    "AutoGenerate": true,
    "Entries": [{
        "Sites": ["example.com"],
        "Username": "alice",
        "Password": "secret"},
      {
        "Sites": ["cnn.com"],
        "Username": "alice1",
        "Password": "secret"}]}}
~~~~

Alice is happy to use the password manager for her general Web sites but
not for the password she uses to log in to her bank account. When asked
if the password should be stored in the Mesh, Alice declines and asks 
not to be asked in the future.

~~~~
{
  "PasswordProfilePrivate": {
    "AutoGenerate": true,
    "Entries": [{
        "Sites": ["example.com"],
        "Username": "alice",
        "Password": "secret"},
      {
        "Sites": ["cnn.com"],
        "Username": "alice1",
        "Password": "secret"}],
    "NeverAsk": ["bank.com"]}}
~~~~

