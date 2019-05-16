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
