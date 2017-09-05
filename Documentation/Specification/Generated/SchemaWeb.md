

#Web Password Application Profile Objects

##Subsection

###Structure: PasswordProfile

* Inherits: ApplicationProfile

Stores usernames and passwords

[None]

###Structure: PasswordProfilePrivate

* Inherits: ApplicationProfilePrivate

Private part of the profile.


<dl><dt>AutoGenerate: 
<dd>Boolean (Optional)


If true, a client MAY offer to automatically generate strong
(i.e. not memorable) passwords for a user. A user would not
normally want to use this feature unless they have access to
Mesh password management on every device they use to browse
the Web

<dl><dt>Entries: 
<dd>PasswordEntry [0..Many]


A list of password credential entries.

<dl><dt>NeverAsk: 
<dd>String [0..Many]


A list of domain names of sites for which clients MUST NOT
ask to store passwords for.

###Structure: PasswordEntry

Username password entry for a single site


<dl><dt>Sites: 
<dd>String [0..Many]


DNS name of site *.example.com matches www.example.com
etc.

<dl><dt>Username: 
<dd>String (Optional)


Case sensitive username

<dl><dt>Password: 
<dd>String (Optional)


Case sensitive password.

