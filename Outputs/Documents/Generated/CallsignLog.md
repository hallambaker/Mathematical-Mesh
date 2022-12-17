

##Callsign log entries

###Profile and account registration

###Structure: ProfileRegistry

Describes a callsign registry.

[No fields]

###Structure: ProfileResolver

Describes a callsign resolver.

<dl>
<dt>RegistryAddress: String (Optional)
<dd>The address of the registry
<dt>EnvelopedProfileRegistry: Enveloped<ProfileAccount> (Optional)
<dd>The registry that this resolver resolves.
<dt>CommonEncryption: KeyData (Optional)
<dd>Key currently used to encrypt data under this profile
<dt>CommonAuthentication: KeyData (Optional)
<dd>Key used to authenticate requests made under this user account.
This key SHOULD NOT be provisioned to any device except for the
purpose of enabling account recovery.
</dl>
###Callsign registration and transfer

The following classes are used as common elements in
Mesh profile specifications.

###Structure: Registration

A callsign or Notarization registration

<dl>
<dt>Id: String (Optional)
<dd>Unique registration identifier
<dt>Entry: Enveloped<CallsignBinding> (Optional)
<dd>The signed callsign binding
<dt>Submitted: DateTime (Optional)
<dd>The UTC time instant that the claim was submitted.
<dt>Registrar: String (Optional)
<dd>Callsign of the registrar that made the registration request
<dt>PriorId: String (Optional)
<dd>If present, specifies a previous registration with the same identifier.
<dt>Reason: String (Optional)
<dd>Reason for creating a registration:
Initial/ Update/ Voluntary/ Administrative/ Revoke
</dl>
###Structure: CatalogedRegistration

<dl>
<dt>Canonical: String (Optional)
<dd>The canonical form of the callsign.
<dt>Id: String (Optional)
<dd>Unique registration identifier
<dt>EnvelopedRegistration: Enveloped<Registration> (Optional)
<dd>The registration entry for the item.
</dl>
###Character page definition

###Structure: Page

<dl>
<dt>Id: String (Optional)
<dd>Character page identifier
<dt>Allow: String [0..Many]
<dd>Additional allowed pages.
</dl>
###Structure: CharacterSpan

<dl>
<dt>First: Integer (Optional)
<dd>The first character in the range (inclusive)
<dt>Last: Integer (Optional)
<dd>The last character in the range (inclusive), if ommitted or
equal to zero, this is the same as Last.
</dl>
###Structure: Canonical

<dl>
<dt>Inherits:  CharacterSpan
</dl>

Canonical character span.

[No fields]

###Structure: MapChar

<dl>
<dt>Inherits:  CharacterSpan
</dl>

Specifies a variant mapping the range of characters First..First+n to
a range of characters Target..Target+n. Where n = Last - First+1

<dl>
<dt>Target: Integer (Optional)
<dd>The character that First is mapped to.
</dl>
###Structure: MapString

<dl>
<dt>Inherits:  CharacterSpan
</dl>

Specifies a mapping of non canonical characters in the range specified by 
First..Last to the string Target.

<dl>
<dt>Target: String (Optional)
<dd>Specifies a character string that the Source character(s) are mapped to.
If count is greater than 1, all the characters map to the same string.
</dl>
###Notarization

###Structure: Notarization

<dl>
<dt>Entries: Enveloped<Witness> [0..Many]
<dd>Enveloped witness value of a specific append only log.
<dt>Proof: Proof (Optional)
<dd>Proof path validating the previous notary token that was entered in the
log.
</dl>
###Trust Assertions

###Structure: Challenge

Registers a challenge to one or more callsigns that have been registered.

<dl>
<dt>Subjects: String [0..Many]
<dd>The callsigns subject to challenge
<dt>Basis: String [0..Many]
<dd>The basis for the challenge
</dl>
##Message Classes

###Structure: CallsignRegistrationRequest

Connection request message. This message contains the information

<dl>
<dt>EnvelopedCallsignBinding: Enveloped<CallsignBinding> (Optional)
<dd>The enveloped binnding of the callsign to the profile.	
</dl>
###Structure: CallsignRegistrationResponse

<dl>
<dt>Registered: Boolean (Optional)
<dd>True if and only if a new registration was created.
<dt>CatalogedRegistration: CatalogedRegistration (Optional)
<dd>The resulting catalog entry if accepted or the prior registration otherwise.
<dt>Reason: String (Optional)
<dd>Reason for refusing the registration.
</dl>
###Structure: ProcessResultCallsignRegistration

<dl>
<dt>CallsignRegistrationResponse: CallsignRegistrationResponse (Optional)
</dl>
