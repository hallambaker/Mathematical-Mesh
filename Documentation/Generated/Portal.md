#Portal

##Portal Transactions

##Portal Messages

##Portal Structures

###Structure: PortalEntry


:Created :
::DateTime [0..1]   

Time the pending item was created.

:Modified :
::DateTime [0..1]   

Time the pending item was last modified.

###Structure: Account

Entry containing the 
UniqueID is Account[Name]-[Portal]
Indexed by [Name], [UserProfileUDF] [Most recent open]


:Created :
::DateTime [0..1]   

Time the pending item was created.

:Modified :
::DateTime [0..1]   

Time the pending item was last modified.

:AccountID :
::String [0..1]   

Assigned account identifier, e.g. 'alice@example.com'. Account names are 
not case sensitive.

:UserProfileUDF :
::String [0..1]   

Fingerprint of associated user profile

:Status :
::String [0..1]   

Status of the account, valid values are 'Open', 'Closed',
'Suspended'

###Structure: AccountProfile


:Created :
::DateTime [0..1]   

Time the pending item was created.

:Modified :
::DateTime [0..1]   

Time the pending item was last modified.

:AccountID :
::String [0..1]   

Assigned account identifier, e.g. 'alice@example.com'. Account names are 
not case sensitive.

:UserProfileUDF :
::String [0..1]   

Fingerprint of associated user profile

:Status :
::String [0..1]   

Status of the account, valid values are 'Open', 'Closed',
'Suspended'

:Profile :
::SignedPersonalProfile [0..1]   

[TBS]

###Structure: ConnectionsPending

Object containing the list of currently pending device connection requests
for the specified account. 
Unique-ID is ConnectionsPending-[UserProfileUDF]


:Created :
::DateTime [0..1]   

Time the pending item was created.

:Modified :
::DateTime [0..1]   

Time the pending item was last modified.

:AccountID :
::String [0..1]   

Assigned account identifier, e.g. 'alice@example.com'. Account names are 
not case sensitive.

:UserProfileUDF :
::String [0..1]   

Fingerprint of associated user profile

:Status :
::String [0..1]   

Status of the account, valid values are 'Open', 'Closed',
'Suspended'

:Requests :
::SignedConnectionRequest [0..Many]   

List of pending requests

