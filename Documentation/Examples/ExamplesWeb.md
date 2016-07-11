
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
    "Identifier": "MAQLH-YXEBA-OSNJ3-2ZCWB-QDEMW-KXLQY-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
qcnH2tPivg5JIrIzWa_KQA",
      "ciphertext": "
aute6ZbMgsxIkYb3V9x6BkQr-84f_jPfYFgFFdU3WCInPQAmKfbdZYbjOz0chqFw",
      "recipients": [{
          "Header": {
            "kid": "MCEWX-F352S-NDFEU-3F2FN-T7EGP-ZJLQW"},
          "encrypted_key": "
azhfOvb-gef3_n3lhsTPpOEozl9aM7h4jFHfPBbAvSDDkv2ap5pwsMsekpC1xjkA
sEFXG4EOX3QCpGNiijlO3qA4DF7s-qfm84r7z4jkx62HND7q-UHY6MDPgv3OXFBL
OQi2WmQ7wZq-GTYZJCNkZn6p1U0dkT19Sj_cay4RuFXrGuroHCOk0kJBJm8cbJh4
Rstb2FcsCarjPR8FOWQewIO_sPGxF7YON1F1NzoYoN-ydlLOdP5oxcq2oESZYyc9
Q8l6muv922tuzrsCGGfQp44Dcgw4OfFo6iXQd0IRDKLzztSXZR5QJErwIqPaynHf
UohO1W4fOcs1LlLyE9vA2w"},
        {
          "Header": {
            "kid": "MAR6R-6FP2S-CT42Y-L2PQC-KOCBY-EWIJT"},
          "encrypted_key": "
I1rKI6QZjojR-cm5xYUYdtK2XL4G74sswWk7hgESWPiR0JEneWKmnvM2N_MsY2LS
7FqFcNCBo3qGm8vT3nTSgeJrVnjY6XFSdZpOw9tShrOlxhpneES1cTh_PI6gVxDF
NVPa6gNoPVroXwDZ967km7IwI0khgemHdPEiJAQW_r7uOE5bqZjD_jCiNhV6D1-y
_eto96WOZ54OgPFvnIPqqvTCCWsypEfZYc7HCBQohtJ1q0ba5j9Hxr8SFB1IrkNx
cm-O0KbUqgLsy1K9RfZf7VCK8pW2e3vNYOD4lDxB4hkA7-AsxB2OJnCghVb1Ko5Q
SpVqSUbL5rxobSjx_xG2cA"}]}}}
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

