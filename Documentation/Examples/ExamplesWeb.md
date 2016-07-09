
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
    "Identifier": "MBVBG-SM37C-7P5OT-VRAUN-ZSQG5-3BAJW-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
WSE2zrH3Fz8snMqzno2zLQ",
      "ciphertext": "
SRIoO5rXXBEwHKwWyeXO3xItPBDJv5e3EIuWomBX7gv2-f13l4q7SdpacyfENR8R",
      "recipients": [{
          "Header": {
            "kid": "MCW27-PQHPW-74AOT-RXCIX-CUIXZ-7EBUB"},
          "encrypted_key": "
N7175Zjy5dDK48fc_Li7VCqXNt-wOe-st9JXRziYdL1mOQBrO-6Qhof0DzuX0tvO
yZjuCTpUUj6ZQxhr2dUy0n22WCwk5b309uT2Sa-QQRe_2glICb1vpp0CLOiFU64V
L08eg_Wy_9DG90jhIDWf-L5JoxD7BI2dZaGaEm51PU7nPu5DBPhdMejH-K_ZICNZ
5YKBpQ5JlWnN0d3kK6NlYDCFakUCXLqZwj-SefNgobwAUIio3kn8_rlNfEFbBs8f
9opA2k4w_e3bNs5fqsxW2iWQ_9P19l1IgefJioqWt9RniaSopYvJqyBTZiNC5IAY
EJMZ4MnQqXcf7OCY02ddOw"},
        {
          "Header": {
            "kid": "MAGNJ-JRPDN-AUY6X-6TL3E-GMDCB-IWW2X"},
          "encrypted_key": "
FZluqAmcbm4F2uaTDNbRlBWe86MYLLCForKQBGdpEjTAZhoTlh80fPPg-VZHXZPm
lM34SLrFBR4Fu-I13oRDzhluKSOoPviolzbBQOWJT4Z24fvqF7kNvkOa4c0NfQ5r
g09gtitVO-w_xAH7cZw4f0Dz1nN1SosSRp9gAPnF5Pc91gjr5mxd-pf4iMBanfAq
KTxq81FZRErCFoeFPOPZZ-bdIOmyt4jhd3_ILS_pvU_uZgBY2Rix2pWa6_ua5uGx
OQ24h5fwKSJB6ibrl1FrGBn6Pgvg05FCJo-4LwoKCo6woGFNT-ubHz_tP0OcyPsE
9RYsGzahx6XyTgXO_m7_Cg"}]}}}
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

