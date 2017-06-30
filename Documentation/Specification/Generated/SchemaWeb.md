

#Web Password Application Profile Objects

###Structure: PasswordProfile

* Inherits: ApplicationProfile

Stores usernames and passwords

[None]

###Structure: PasswordProfilePrivate

* Inherits: ApplicationProfilePrivate

Private part of the profile.


AutoGenerate: Boolean (Optional)

:If true, a client MAY offer to automatically generate strong
(i.e. not memorable) passwords for a user. A user would not
normally want to use this feature unless they have access to
Mesh password management on every device they use to browse
the Web

Entries: PasswordEntry [0..Many]

:A list of password credential entries.

NeverAsk: String [0..Many]

:A list of domain names of sites for which clients MUST NOT
ask to store passwords for.

###Structure: PasswordEntry

Username password entry for a single site


Sites: String [0..Many]

:DNS name of site *.example.com matches www.example.com
etc.

Username: String (Optional)

:Case sensitive username

Password: String (Optional)

:Case sensitive password.

