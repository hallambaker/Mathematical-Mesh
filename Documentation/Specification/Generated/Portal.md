

#Mesh Portal Objects

The precise implementation of the portal service and the
data structures representing state at the portal
service are outside the scope of this specification.

The specification of the Mesh Portal objects given here is to
enable future formal specification of the portal protocols
by defining the state changes resulting from portal
transactions.

##Mesh Portal Log Entries

Like the Mesh itself, the state of the portal is tracked by an
append only log. This log contains entries binding account identifiers
to mesh profiles and lists of pending connections.

###Structure: PortalEntry


Created: DateTime (Optional)

:Time the pending item was created.

Modified: DateTime (Optional)

:Time the pending item was last modified.

###Structure: Account

Entry containing the 
UniqueID is Account[Name]-[Portal]
Indexed by [Name], [UserProfileUDF] [Most recent open]

* Inherits: PortalEntry


AccountID: String (Optional)

:Assigned account identifier, e.g. 'alice@example.com'. Account names are 
not case sensitive.

UserProfileUDF: String (Optional)

:Fingerprint of associated user profile

Status: String (Optional)

:Status of the account, valid values are 'Open', 'Closed',
'Suspended'

###Structure: AccountProfile

* Inherits: Account


Profile: SignedPersonalProfile (Optional)

:The personal profile associated with the account.

###Structure: ConnectionsPending

Object containing the list of currently pending device connection requests
for the specified account. 
Unique-ID is ConnectionsPending-[UserProfileUDF]

* Inherits: Account


Requests: SignedConnectionRequest [0..Many]

:List of pending requests

