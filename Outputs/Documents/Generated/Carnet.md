

###Profile and account registration

###Structure: ProfileCarnet

Describes a carnet issuer.

[No fields]

###Structure: CatalogedCarnet

<dl>
<dt>Key: String (Optional)
<dt>EnvelopedConnectionAddress: Enveloped<ConnectionStripped> (Optional)
<dd>The connection allowing control of the registry.
<dt>EnvelopedProfileCarnet: Enveloped<ProfileCarnet> (Optional)
<dd>The Mesh profile
<dt>EnvelopedActivationCommon: Enveloped<ActivationCommon> (Optional)
<dd>The activation data for the registry.
</dl>
##Carnet service

###Shared Classes

<dt>SRV Prefix: _carnet._tcp

<dt>HTTP Well Known Service Prefix: /.well-known/carnet




###Message: CarnetRequest

Base class for all requests made to a registrar

[No fields]

###Message: CarnetResponse

Base class for all response messages. Contains only the
status code and status description fields.

[No fields]

