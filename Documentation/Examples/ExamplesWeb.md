
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
    "Identifier": "MDMTS-FZHC3-EFGDT-NT4Y2-FTLRK-YNGVA-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
sqoXhPpS4ONLUNcR0YmGAw",
      "ciphertext": "
DlsSziENqPvPFrbG3UquqwBR2EOtlgZljRE48yZs4Orz04mrEaadlZ9ZfHjsscxB",
      "recipients": [{
          "Header": {
            "kid": "MAEPJ-2YTTP-UIVVR-DG4U7-DT3TX-L2JAO"},
          "encrypted_key": "
50J_xfrIpVBdAS5rN06xcuo5j2MZybZLMaBCBcpEtoDphYuRA_it6WVLT-ae3NQY
GuXDkiRWCWMxHyArV1sW4W6Vp7yar8FZsyLCxmeMG3wL2TslXxvqP6KRTPxnTs7y
v0w9Lvk_YGMJFeA2GmqWwIoIKkze6MDDWDjjkMpLC32wiDK7nwnvZA4NiYs_LSTT
3yPNNBsNCFvjNFX4ycLpz5ej_WekSgr7F-N9LsDUgQOiz-D760nvuvFlYeoMTo31
CHD4rlTxhvwOkfswMkwYsP2HU19l10BXVn1uUdrItJqthuSyxhidauCtaU8DkrbN
gqfy4yy0HD6hVtxKN93XLQ"},
        {
          "Header": {
            "kid": "MC7TP-QRHUB-42UY6-OAPV5-WRQ5K-AJLOM"},
          "encrypted_key": "
yR4k8eWKqvSOaf_Ckjdzq7yDQn_1-u6YiR3T4t_2keZVZdVGVKnra1mS_9cMgtxK
ezb_0Y6e9tYL_WS7cacHjs7RXmvc0kmd0oLx6mxCWWB4Eys3cjm9e9xZcwOlvOP0
Cbdkzga57W3V9dpdMs2Q8xJfYGJrAtQzjw6HEWvDQFezzR9etV-rVcjCiScwQa4f
jkSr7-IQsXP0nh4RXfifoQmHNNMPlnLoAITWNZ3Vf-qBWgVEUV8ZF_fWp2j8SsZh
mae7zSx1ik0wh8vm7r5TpnlVUsicW5RiwtACTQLT67uTOc8QGdnwcSN8qUNE_bTV
bTfYNdkixDfFXz4TPBgirg"}]}}}
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

