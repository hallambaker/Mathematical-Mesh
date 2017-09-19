
<h3>Credentials Example


~~~~
{
  "CredentialProfilePrivate": {
    "AutoGenerate": true,
    "Entries": [{
        "Sites": ["luggage.example.net"],
        "Username": "Alice",
        "Password": "12345"},
      {
        "Label": ["Linux"],
        "Sites": ["host.example.net"],
        "Username": "BitAlice",
        "Password": "password",
        "Protocol": "ssh"}],
    "NeverAsk": ["secure.example.com",
      "bank.example.com"]}}
~~~~

