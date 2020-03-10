

#Catalog Application Profiles

Catalogues are application profiles that consist of a set of related
information (contacts, passwords, bookmarks) but do not contain 
any cryptographic private keys or device specific data.
These restrictions allow management of these profiles to be simplified.

##Shared

The following objects are common to multiple profiles.

###Structure: ApplicationProfileCatalog

<dl>
<dt>Inherits:  ApplicationProfile
</dl>

Base class for all application profiles that are tied to an 
account profile

<dl>
<dt>AccountIdentifier: String (Optional)
<dd>The account to which this profile is bound
<dt>PersonalUDF: String (Optional)
<dd>The person to which this profile is bound
</dl>
###Structure: CatalogEntry

Base class for catalog entries, contains base information on which
catalog operations are performed.

<dl>
<dt>ID: String (Optional)
<dd>Unique identifier for the entry. If present, overrides the identifier 
specified in the entry.
<dt>Added: DateTime (Optional)
<dd>The time the site was added
<dt>Updated: DateTime (Optional)
<dd>The last time the entry was updated
<dt>Deleted: DateTime (Optional)
<dd>The last time the entry was updated
<dt>Label: String [0..Many]
<dd>Labels identifying the group(s) that the entry is filed under
<dt>Source: TypedData [0..Many]
<dd>Source data for the entry
</dl>
###Structure: TypedData

Typed content.

<dl>
<dt>ContentType: String (Optional)
<dd>IANA Content Type identifier
<dt>Data: Binary (Optional)
<dd>The described data
</dl>
##Credential Catalog

Profile for recording access credentials for Web sites and other projects. Currently this is 
limited to usernames and passwords but could expand to include other credential 
forms.

###Structure: CredentialProfile

<dl>
<dt>Inherits:  ApplicationProfileCatalog
</dl>

Stores usernames and passwords. There are no public fields.

[No fields]

###Structure: CredentialProfilePrivate

<dl>
<dt>Inherits:  ApplicationProfilePrivate
</dl>

Private part of the profile.

<dl>
<dt>AutoGenerate: Boolean (Optional)
<dd>If true, a client MAY offer to automatically generate strong
(i.e. not memorable) passwords for a user. A user would not
normally want to use this feature unless they have access to
Mesh password management on every device they use to browse
the Web
<dt>Entries: CredentialEntry [0..Many]
<dd>A list of password credential entries.
<dt>NeverAsk: String [0..Many]
<dd>A list of domain names of sites for which clients MUST NOT
ask to store passwords for.
</dl>
###Structure: CredentialEntry

<dl>
<dt>Inherits:  CatalogEntry
</dl>

Username password entry for a single site

<dl>
<dt>Sites: String [0..Many]
<dd>DNS name of site *.example.com matches www.example.com
etc.
<dt>Username: String (Optional)
<dd>Case sensitive username
<dt>Password: String (Optional)
<dd>Case sensitive password.
<dt>Protocol: String (Optional)
<dd>Protocol identifier, e.g. http, sftp, ssh, etc.
</dl>
##Bookmark Catalog

Profile for recording Web site bookmarks and related information.

###Structure: BookmarkProfile

<dl>
<dt>Inherits:  ApplicationProfileCatalog
</dl>

Stores Web site bookmarks in a hierarchical 

[No fields]

###Structure: BookmarkProfilePrivate

<dl>
<dt>Inherits:  ApplicationProfilePrivate
</dl>

Private part of the profile.

<dl>
<dt>Entries: BookmarkEntry [0..Many]
<dd>The bookmark entries
</dl>
###Structure: BookmarkEntry

<dl>
<dt>Inherits:  CatalogEntry
</dl>

Bookmark entry for a single site

<dl>
<dt>Title: String (Optional)
<dd>The resource name
<dt>Uri: String (Optional)
<dd>The resource identifier
<dt>ImageUDF: String [0..Many]
<dd>UDF fingerprint of related favicon image
</dl>
##Contact Catalog

Profile for recording user contact information

###Structure: ContactProfile

<dl>
<dt>Inherits:  ApplicationProfileCatalog
</dl>

Stores Web site bookmarks in a hierarchical 

[No fields]

###Structure: ContactProfilePrivate

<dl>
<dt>Inherits:  ApplicationProfilePrivate
</dl>

Private part of the profile.

<dl>
<dt>Entries: ContactEntry [0..Many]
<dd>The contact entries
</dl>
###Structure: ContactEntry

<dl>
<dt>Inherits:  CatalogEntry
</dl>

Contact entry

<dl>
<dt>Personals: PersonalName [0..Many]
<dd>Personal names.
<dt>MeshUDFs: String [0..Many]
<dd>List of mesh profiles fingerprints for the user.
<dt>Internets: Internet [0..Many]
<dd>List of Internet, telephone, etc addresses for contacting this party
<dt>Postals: Postal [0..Many]
<dd>List of postal addresses for this party
</dl>
###Structure: PersonalName

Personal name structure.

<dl>
<dt>First: String (Optional)
<dd>First name
<dt>Last: String (Optional)
<dd>Last name
<dt>Midle: String (Optional)
<dd>Middle names (if used).
</dl>
###Structure: Address

Contact address.

<dl>
<dt>Label: String [0..Many]
<dd>Labels identifying the modes in which the label may be used
e.g. Home, Business, Mobile		
<dt>Attributes: String [0..Many]
<dd>Attributes describing the mode in which the contact address may be used.
</dl>
###Structure: Internet

Internet contact address

<dl>
<dt>Inherits:  Address
</dl>

<dl>
<dt>Uri: String (Optional)
<dd>The resource identifier describing the mode of contact
</dl>
###Structure: Postal

Postal or geographic address.

<dl>
<dt>Inherits:  Address
</dl>

<dl>
<dt>Adressee: String (Optional)
<dd>The postal name
<dt>Street: String (Optional)
<dd>Street name and number
<dt>Town: String (Optional)
<dd>Name of town or city
<dt>Region: String (Optional)
<dd>State, county, department or other government unit.
<dt>Country: String (Optional)
<dd>The country name
<dt>Code: String (Optional)
<dd>The ISO 3 letter country code
</dl>
###Structure: ContactPerson

<dl>
<dt>Inherits:  ContactEntry
</dl>

Contact entry for a single person

<dl>
<dt>FullName: String (Optional)
<dd>The name of the person
<dt>Organization: String [0..Many]
<dd>The name of the organizations the person is associated with
</dl>
###Structure: ContactOrganization

<dl>
<dt>Inherits:  ContactEntry
</dl>

Contact entry for a single organization

<dl>
<dt>FullName: String (Optional)
<dd>The name of the organization
</dl>
###Structure: NetworkProfile

<dl>
<dt>Inherits:  ApplicationProfileCatalog
</dl>

Stores usernames and passwords. There are no public fields.

[No fields]

###Structure: NetworkProfilePrivate

<dl>
<dt>Inherits:  ApplicationProfilePrivate
</dl>

Private part of the profile.

<dl>
<dt>AccessPoints: NetworkEntry [0..Many]
<dd>A list of access point entries
<dt>VPNs: NetworkEntry [0..Many]
<dd>A list of VPN entries
</dl>
###Structure: NetworkEntry

<dl>
<dt>Inherits:  CredentialEntry
</dl>

Describes network access credentials

<dl>
<dt>Configuration: String (Optional)
<dd>Network configuration data.
</dl>
