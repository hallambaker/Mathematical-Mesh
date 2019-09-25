

# container

````
container    DARE container commands
    append   Append the specified file as an entry to the specified container
    archive   Create a new DARE Container and archive the specified files
    copy   Copy container contents to create a new container
    create   Create a new DARE Container
    delete   <Unspecified>
    extract   Extract the specified record from the container
    index   Compile an index for the specified container and append to the end.
    verify   Verify signatures and digests on container.
````


# container create

````
create   Create a new DARE Container
       New container
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /type   The container type, plain/tree/digest/chain/tree
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `container create` command creates a container with the specified cryptographic
enhancements.


````
Alice> container create Container.dcon
````

Specifying the /json option returns a result of type ResultFile:

````
Alice> container create Container.dcon /json
{
  "ResultFile": {
    "Success": true,
    "Filename": "Container.dcon"}}
````

# container archive

````
archive   Create a new DARE Container and archive the specified files
       Directory containing files to create archive from
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /type   The container type, plain/tree/digest/chain/tree
    /out   New container
````

The `container archive` command creates a container with the specified cryptographic
enhancements and adds the spefied file(s).


````
Alice> container archive ContainerArchive.dcon TestDir1
ERROR - Path cannot be null.
Parameter name: path
````

Specifying the /json option returns a result of type Result:

````
Alice> container archive ContainerArchive.dcon TestDir1 /json
{
  "Result": {
    "Success": false,
    "Reason": "Path cannot be null.\r\nParameter name: path"}}
````

# container verify

````
verify   Verify signatures and digests on container.
       Container to read
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `container verify` command verifies the authentication data of the specified 
container.


````
Alice> container verify ContainerArchiveEncrypt.dcon
````

Specifying the /json option returns a result of type ResultFile:

````
Alice> container verify ContainerArchiveEncrypt.dcon /json
{
  "ResultFile": {
    "Success": true,
    "Filename": "ContainerArchiveEncrypt.dcon"}}
````


# container extract

````
extract   Extract the specified record from the container
       Container to read
       Extracted file
    /record   Index number of file to extract
    /file   Name of file to extract
    /key   <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `container extract` command extracts the specified container entries and writes them
to files.


````
Alice> container extract Container.dcon TestOut
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
Alice> container extract Container.dcon TestOut /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# container append

````
append   Append the specified file as an entry to the specified container
       Container to append to
       File to append
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   <Unspecified>
````

The `container append` command appends the specified file to the container.


````
Alice> container append Container.dcon TestFile1.txtcontainer append Container.dcon TestFile2.txtcontainer append Container.dcon TestFile3.txt
ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\TestFile1.txtcontainer'.
````

Specifying the /json option returns a result of type Result:

````
Alice> container append Container.dcon TestFile1.txtcontainer append Container.dcon TestFile2.txtcontainer append Container.dcon TestFile3.txt /json
{
  "Result": {
    "Success": false,
    "Reason": "Could not find file 'C:\\Users\\hallam\\Test\\WorkingDirectory\\TestFile1.txtcontainer'."}}
````


# container delete

````
delete   <Unspecified>
       Container to append to
    /file   Name of file to delete
    /key   <Unspecified>
````

The `container delete` command marks the specified file entry as deleted in the
container but does not erase the data from the file.


````
Alice> container delete Container.dcon  TestFile2.txt
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
Alice> container delete Container.dcon  TestFile2.txt /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# container index

````
index   Compile an index for the specified container and append to the end.
       Container to append to
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `container index` command appends an index record to the end of the container.


````
Alice> container index Container.dcon
````

Specifying the /json option returns a result of type ResultFile:

````
Alice> container index Container.dcon /json
{
  "ResultFile": {
    "Success": true,
    "Filename": "Container.dcon"}}
````

# container copy

````
copy   Copy container contents to create a new container
       Container to read
       Copy
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /type   The container type, plain/tree/digest/chain/tree
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /decrypt   Decrypt contents
    /index   Append an index record to the end
    /purge   Purge unused data etc.
````

The `container copy` command copies a container applying the specified filtering 
and indexing criteria.


````
Alice> container copy Container2.dcon
ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Container2.dcon'.
````

Specifying the /json option returns a result of type Result:

````
Alice> container copy Container2.dcon /json
{
  "Result": {
    "Success": false,
    "Reason": "Could not find file 'C:\\Users\\hallam\\Test\\WorkingDirectory\\Container2.dcon'."}}
````

