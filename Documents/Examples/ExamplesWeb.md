
#Password Management

Alice decides to use the Mesh to manage her Web usernames and passwords.

She creates two accounts:

* example.com: username 'alice', password 'secret'

* cnn.com: username 'alice1', password 'secret'


The JSON encoding of the password data is as follows:

~~~~
{Example.PasswordProfile1.Private.ToString()}
~~~~

The JSON encoded password data is then encrypted and stored in an
application profile as follows:

~~~~
{Example.PasswordProfile1}
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
{Example.PasswordProfile2.Private.ToString()}
~~~~

Alice is happy to use the password manager for her general Web sites but
not for the password she uses to log in to her bank account. When asked
if the password should be stored in the Mesh, Alice declines and asks 
not to be asked in the future.

~~~~
{Example.PasswordProfile3.Private.ToString()}
~~~~

