# Goedel.Mesh.Client

The Client libraries support three main contexts

* *ContextDevice* Supports non-administrative actions concerning a device. E.g. returning a ContextAccount

* *ContextAdmin* Supports administrative actions concerning a device. E.g. creating a new account

* *ContextAccount* Supports operations on an account.

* *Context Service* Supports operations on an account via a specific service

## MeshMachineClient

The base class for operations that generate new or connect to existing Device contexts.

### To create an account

````
var testEnvironmentCommon = new TestEnvironmentCommon();
var machineAdmin = new MeshMachineTest(testEnvironmentCommon, DeviceAliceAdmin);

// Generate the Mesh master profile and return an administration context for it.
var contextMeshAdmin = machineAdmin.CreateMesh("main");

// Generate a new account without binding to a service
var contextAccountAlice = contextMeshAdmin.CreateAccount("main");

// Add a service
var contextAccountService = contextAccountAlice.AddService("alice@example.com");
````

Convenience - Account without service

````
var contextMeshAdmin = machineAdmin.CreateAccount("main");
````


Convenience - Account with service

````
var contextMeshAdmin = machineAdmin.CreateService("alice@example.com");
````


### To recreate an account from escrow

````
var contextMeshAdmin = machineAdmin.CreateMesh("main");
var (escrow, shares) = contextMeshAdmin.Escrow(3, 2);
var recoverShares = new KeyShare[] { shares[0], shares[2] };

var contextMeshAdminRecovered = machineAdmin.CreateMesh("main", escrow, recoverShares);
````

## Directory Layout

Keys and profiles are laid out as follows:

### Keys

Keys are stored in a platform specific directory. 


<dl>
<dt>Windows</dt>
<dd> </dd>
<dt>Unix</dt>
<dd>`.mesh\keys`</dd>
</dl>

### Profiles

Profiles are stored in a platform specific directory. 

<dl>
<dt>Windows</dt>
<dd> </dd>
<dt>Unix</dt>
<dd>`.mesh\profiles`</dd>
</dl>

In each case, the directory structure is as follows

<dl>
<dt>`root.dcat`</dt>
<dd>The Host Catalog containing entries for the Mesh and Account entries to be used by this host.</dd>
<dt>[Mesh-UDF]`.dcat`</dt>
<dd>The Mesh device catalog for the Mesh with fingerprint [Mesh-UDF]</dd>
<dt>[Account-UDF]/`CatalogContact.dcat`</dt>
<dd>The Mesh credential catalog for the Account with fingerprint [Mesh-Account]</dd>
<dt>[Account-UDF]/`CatalogCredential.dcat`</dt>
<dd>The Mesh credential catalog for the Account with fingerprint [Mesh-Account]</dd>
<dt>[Account-UDF]/`CatalogBookmark.dcat`</dt>
<dd>The Mesh bookmark catalog for the Account with fingerprint [Mesh-Account]</dd>
<dt>[Account-UDF]/`CatalogCalendar.dcat`</dt>
<dd>The Mesh calendar catalog for the Account with fingerprint [Mesh-Account]</dd>
<dt>[Account-UDF]/`CatalogNetwork.dcat`</dt>
<dd>The Mesh network catalog for the Account with fingerprint [Mesh-Account]</dd>
<dt>[Account-UDF]/`CatalogApplication.dcat`</dt>
<dd>The Mesh application catalog for the Account with fingerprint [Mesh-Account]</dd>
<dt>[Account-UDF]/`SpoolInbound.dcat`</dt>
<dd>The Mesh inbound spool for the Account with fingerprint [Mesh-Account]</dd>
<dt>[Account-UDF]/`SpoolOutbound.dcat`</dt>
<dd>The Mesh outbound spool for the Account with fingerprint [Mesh-Account]</dd>
</dl>