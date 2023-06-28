

#Shared Classes

The following classes are used as common elements in
Mesh profile specifications.a

###Structure: AccountEntry

Represents a Mesh Account.

<dl>
<dt>Directory: String (Optional)
<dd>Subdirectory containing the catalogs and spools for the account.
<dt>ProfileUdf: String (Optional)
<dd>The fingerprint of the profile
<dt>Quota: Integer (Optional)
<dd>The quota assigned to this user in KB
<dt>Status: String (Optional)
<dd>The profile status. Valid values are "Pending", "Connected", "Blocked"
<dt>LocalAddress: String (Optional)
<dd>Account address in user@domain format
</dl>
###Structure: AccountUser

<dl>
<dt>Inherits:  AccountEntry
</dl>

Represents a Mesh Account

<dl>
<dt>EnvelopedProfileUser: Enveloped<ProfileAccount> (Optional)
<dd>The signed assertion describing the account.
<dt>EnvelopedAccountHostAssignment: Enveloped<AccountHostAssignment> (Optional)
<dd>The enveloped assignment describing how the client should
discover the host and encrypt data to it.
</dl>
