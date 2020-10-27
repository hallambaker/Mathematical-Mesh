
For example, consider the following mail message:

~~~~
~~~~

Existing encryption approaches require that header fields such as the subject line be encrypted 
with the body of the message or not encrypted at all. Neither approach is satisfactory.
In this example, the subject line gives away important information that the sender
probably assumed would be encrypted. But if the subject line is encrypted together with the
message body, a mail client must retrieve at least part of the message body to provide a 
'folder' view.

The plaintext form of the equivalent DARE Message encoding is:

~~~~
$$$$ Empty $$$$
~~~~

This contains the same information as before but the mail message headers are 
now presented as  a list of Encoded Data Sequences.

