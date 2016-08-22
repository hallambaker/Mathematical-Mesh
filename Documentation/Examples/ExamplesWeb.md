
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
    "Identifier": "MCKZY-MQMR4-BZSIO-5X4YA-6GJY2-PHVVM-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
oyj9h7NKB1IFwPNoLTy14w",
      "ciphertext": "
OyfLtmtdRrNqRasFcZYaj6sG3AQenMejbdlBEC2AsyU1I0Z7U-NY_qiy-_rIXKWl",
      "recipients": [{
          "Header": {
            "kid": "MAEJX-AM5C7-V25FK-MFEUM-WD2Y4-OAV6L"},
          "encrypted_key": "
TAiJhSBLbTMI4Gf-05-mypLi6eEN7KCJ1ANzBrRwec9sevL-eWY6pt6l_abb14Pf
kt9IsF1h3heNKwlxI9eZpBPqvUOe_u2EqeRBySxaywTYV9kYHSZcDh5BQAxosYa6
ah8kHxEXiY0dEU15TZ0TUes3hUfYuYwgffsmL3XXLwYj_m2T8sMuHvt2hPtwsWm7
QQgn4YQ8xSMO3kIIPl_Elp8HkISM9sbpWSLjAQT8ILpeEhsSwbFLIrYAVbChwi2x
VKl0jlkn0bt8amoM-n5HOE7xUEE1cygG-NEidSxNXhpMnCarNZP70TX_6-Ke98Uz
YS2fAxhbWGzgtek5hTnUbg"},
        {
          "Header": {
            "kid": "MADBY-64XY2-CCN7I-2NDQ2-NYHZ4-M6CQ6"},
          "encrypted_key": "
jNrEhCbIOhSfztHV2hthTKTVRpIh8Qug0tKs3Chb2BDbnKNjfpKwk_Pyr5C1fl9M
zv2WbkokiLqVfYr8fVty2qFi2loTHUm-JIAP-LY78H-INbRbOdCF0272cGmSZwK6
UoHtZ-SzQRF-DRwsKGbl18XD1W0shBzFUMakpa4irx3tw98U__07HpkZJ-fqYsEv
oHI5QLg0aC3qpsvAhElAPQzdbLK2bJbbANOlKJYxYiiE8EpIW4clfHBlUkzu89es
yX4Ao7lzo0ZhrBmDFIHns_4Q7kJRO0mDBSt3F4vJbOo2bpKFgQvIpI6ZSnrr16t6
tw71Oi0G1LglW9zNdYrKpw"}]}}}
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

