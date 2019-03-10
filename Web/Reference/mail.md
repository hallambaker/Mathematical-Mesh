

# profile

````
profile    
    accept   Accept a pending connection
    connect   Connect to an existing profile registered at a portal
    device   Create new device profile
    dump   Describe the specified profile
    escrow   Create a set of key escrow shares
    export   Export the specified profile data to the specified file
    hello   Connect to the service(s) a profile is connected to and report status.
    import   Import the specified profile data to the specified file
    list   List all profiles on the local machine
    master   Create new personal profile
    pending   Get list of pending connection requests
    pin   Accept a pending connection
    recover   Recover escrowed profile
    register   Register existing profile at a new portal
    reject   Reject a pending connection
    sync   Synchronize local copies of Mesh profiles with the server
````


# profile add

````
add   Add a mail application profile to a personal profile
       Mail account to create profile from
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /openpgp   Create encryption and signature keys for OpenPGP
    /smime   Create encryption and signature keys for S/MIME
    /configuration   Configuration file describing network settings
    /ca   Certificate Authority to request certificate from
    /inbound   inbound service configuration
    /outbound   outbound service configuration
    /alg   List of algorithm specifiers
````
# profile update

````
update   Update an existing mail application profile
       Mail account to update
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````
# profile private

````
private   Extract the private key for the specified account
       Mail account to update
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /password   Password to encrypt private key
    /file   Output file
````
# profile public

````
public   Extract the public key/certificate for the specified account
       Mail account identifier
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /file   Output file
````
# profile private

````
private   Extract the private key for the specified account
       Mail account to update
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /password   Password to encrypt private key
    /file   Output file
````
# profile public

````
public   Extract the public key/certificate for the specified account
       Mail account identifier
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /file   Output file
````


