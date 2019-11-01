

# mesh

````
mesh    Commands for creating and managing a personal Mesh
    create   Create new personal profile
    escrow   Create a set of key escrow shares
    export   Export the specified profile data to the specified file
    get   Describe the specified profile
    import   Import the specified profile data to the specified file
    list   List all profiles on the local machine
    recover   Recover escrowed profile
````

# mesh create

````
create   Create new personal profile
    /account   New account
    /service   New service
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /new   Force creation of new device profile
    /dudf   Device profile fingerprint
    /did   Device identifier
    /dd   Device description
    /alg   List of algorithm specifiers
````

The `profile create` command creates a new Mesh master profile and 
(optionally) registers it with a Mesh service.

By default, the default device profile of the current account is registered as an
administrator device of the newly created profile. If no default device exists, a 
new device profile is created. The `/new` option may be used to force a new device
profile to be created.

The `/did` and `/dd` options specify an identifier and description for the device if
a new profile is created. Otherwise, platform defaults are used.

Cryptographic algorithms to be used for the signature and encryption algorithms 
may be specified using the `/alg` option.

**Missing Example***


# mesh escrow

````
escrow   Create a set of key escrow shares
       <Unspecified>
    /alg   List of algorithm specifiers
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /quorum   <Unspecified>
    /shares   <Unspecified>
````

The `profile escrow` command 

**Missing Example***

# mesh export

````
export   Export the specified profile data to the specified file
       <Unspecified>
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile export` command 

**Missing Example***

# mesh get

````
get   Describe the specified profile
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile get` command 

**Missing Example***




# mesh import

````
import   Import the specified profile data to the specified file
       <Unspecified>
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile import` command 

**Missing Example***

# mesh list

````
list   List all profiles on the local machine
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /mudf   Master profile fingerprint
````

The `profile list` command 

**Missing Example***


# mesh recover

````
recover   Recover escrowed profile
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /file   <Unspecified>
    /verify   <Unspecified>
````

The `profile recover` command 

**Missing Example***

