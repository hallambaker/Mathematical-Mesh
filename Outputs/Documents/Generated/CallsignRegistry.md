

##Registry service

###Registry Account

###Structure: CatalogedRegistry

<dl>
<dt>MaximumRequestLength: Integer (Optional)
<dt>MaximumCallsignLength: Integer (Optional)
<dt>EnvelopedConnectionAddress: Enveloped<ConnectionStripped> (Optional)
<dd>The connection allowing control of the registry.
<dt>EnvelopedProfileRegistry: Enveloped<ProfileAccount> (Optional)
<dd>The Mesh profile
<dt>EnvelopedActivationCommon: Enveloped<ActivationCommon> (Optional)
<dd>The activation data for the registry.
</dl>
###Structure: ActivationApplicationRegistry

<dl>
<dt>AccountEncryption: KeyData (Optional)
<dd>Key used to decrypt registry messages.
<dt>AdministratorSignature: KeyData (Optional)
<dd>Key or capability used to sign the registry log
</dl>
###Structure: ApplicationEntryRegistry

<dl>
<dt>EnvelopedActivation: Enveloped<ActivationApplicationRegistry> (Optional)
<dt>EnvelopedConnectionService: Enveloped<ConnectionService> (Optional)
<dd>Signed connection service delegation allowing the device to
access the account.
</dl>
