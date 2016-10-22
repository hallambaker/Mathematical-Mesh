
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
    "Identifier": "MBSHO-5D2GR-T7TNK-XHJV6-BHX5I-KA6TX-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
9LOpFHTVI9-wtPECFHpRoA",
      "ciphertext": "
-jwZ9rngzGV2Gu7x-IwDXGksDFwIm01TJqSPkR_5CacxMB-r0MzVyeomjMmpCImg",
      "recipients": [{
          "Header": {
            "kid": "MAMNH-KGSPE-RDKMQ-TEKRS-5RRVC-FNIMV"},
          "encrypted_key": "
Y5glmB3szauorgusT293C7CAaHMcHtn1PqtmRz7OVcmjz39-xItg0xzhC6-VPXhS
1ye9qJSwmNHv8sQQ8vNi7pWijM-NKFUJhkjEo5iM6CKcpxlphh4gW8exEH-HScvB
5TNZk0wYmmR9LdTribgNlWAwu-n3I9xN9tZAr9icaggGH7GbSO9C9l8IgjpbZsDh
B7bBAuOGNviOy-3mIIF0bXo3EBCS3a_TGFtMicEtWa0AdgpM8hDdOCLZ738HBuxN
vku5SWIGCdx29povPuSalkBuPBX5CFnkq2IqR51QUTRyJtkEl6ts9oprPcJ4GEZd
fgASNb4g4LEP8JC7WmJeQg"},
        {
          "Header": {
            "kid": "MB6UF-V26OG-ME234-PHNWP-NS4RQ-V64YO"},
          "encrypted_key": "
fTFLdjuIw-8uFFmwm5twpiK05F6_tZMO6ZrDjVnjsi_VfOoCPP8hFFemfvx9XqSg
KmhVMysq_sJ6tw40duUNkOZcgaXpkfbBPFlobQPLMIfQydklq_njTTFYHWQhT-ui
aRTu4vUZ_n_R478fF7gKEn5LSCFIDH52AZWgpnRfMsIGdrKJUhPwbQV4vuwd4FFK
uRwLlTMVPfGOUSww38VZx0uIAJdqHztl5gKP3rP2Ld1lpDcGxX-ZYwDQQCdSlH0j
-Z8wezlnbLtTV5ri3TrYpZYEto_TYDVQlPWNArmQhjhrX8q9-pyAxBaEMFA4MhbP
BMN4sq6M34sC6Yc5nS3s1Q"}]}}}
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

