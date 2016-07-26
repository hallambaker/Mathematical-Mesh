
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
    "Identifier": "MAJMS-TTR45-4BNIN-IFG7X-AXU44-UAVAL-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
o-Avsu8FCivNW6DhflKplQ",
      "ciphertext": "
fO3kEPY3fQSQIB0J2zYxwc_KsUm-whpH01SLFpCeoEQe-_8A3jxIPGLVxHOvkDdF",
      "recipients": [{
          "Header": {
            "kid": "MA7S6-EC6WL-E6TL4-OSAP5-QGPAF-ALAQU"},
          "encrypted_key": "
TZu3IC5nX2MFkpm1lsCvKJDzcBAkkfk9gkfqMOc8Cp9Y9QtVGmUURiJ0--THyvdp
Wbp8zVF9rKoEOyJ5LkyfPiP0TDdCq3xiKtGWQ7IO4Saf7KOiEZMEhk2zQ-hO74JO
fGZ-prgjYlXVqdPB_ynIOXQGbF1Yaellntt3MrBENVO5h998Jdy8qNRnU8N85oKG
ZPEtm03Vt_h-2GxiJlKhgVZP21C1MlTcRk4LYCmMSSo62AJmA8G3uIFiTx37FgI5
dGARGFR52O4Dg8X4vT9vjirC-kLjoGTncIMYIiZwA11IZWKOMUTT0HADHCbuoJIK
tLInSbUL6rV2bQJ1PMlkOQ"},
        {
          "Header": {
            "kid": "MCYUU-YL54V-YV6T5-ENZHM-XMRFS-BO2XB"},
          "encrypted_key": "
cGN_guz2VxoZKZ2hfBO5YDFSGGpRxBZdZHTWQM0jXGRKCERo3n7abXxE3FizB4sD
ItlLbP-unxFazsFc7OcLpGjJDhIZGCDYiymnHeiHUgra0exiaJR-zpSEGAC28BmV
2RUmdU0RqORsQ5q5u08I4g9uSkYaHFlz2nnG1b-JnY6MaFBoGIhcKav41BbkqQVu
byk9qzyHPyAWaKW-3lB-zxXNNRc0GhTBH-U4SgAugAvF7rggW5od-csnsbGrZxq-
R-IHCI2lQ4W3w6A9bAhkGoR1FZ7hvC5x2Trq2uxw6lFFsFDGCOo5EqbCGEA1fRha
rq_tnZqoxOlC4FzqvGwgTQ"}]}}}
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

