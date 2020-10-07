

# container

~~~~
<div="helptext">
<over>
container    DARE container commands
    append   Append the specified file as an entry to the specified container
    archive   Create a new DARE Container and archive the specified files
    copy   Copy container contents to create a new container
    create   Create a new DARE Container
    delete   <Unspecified>
    extract   Extract the specified record from the container
    index   Compile an index for the specified container and append to the end.
    verify   Verify signatures and digests on container.
<over>
</div>
~~~~


# container create

~~~~
<div="helptext">
<over>
create   Create a new DARE Container
       New container
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /type   The container type, plain/tree/digest/chain/tree
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `container create` command creates a container with the specified cryptographic
enhancements.


~~~~
<div="terminal">
<cmd>Alice> container create Container.dcon
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultFile:

~~~~
<div="terminal">
<cmd>Alice> container create Container.dcon /json
<rsp>{
  "ResultFile": {
    "Success": true,
    "Filename": "Container.dcon"}}
</div>
~~~~


# container archive

~~~~
<div="helptext">
<over>
archive   Create a new DARE Container and archive the specified files
       Directory containing files to create archive from
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /type   The container type, plain/tree/digest/chain/tree
    /out   New container
<over>
</div>
~~~~

The `container archive` command creates a container with the specified cryptographic
enhancements and adds the spefied file(s).


~~~~
<div="terminal">
<cmd>Alice> container archive ContainerArchive.dcon TestDir1
<rsp>ERROR - Path cannot be null. (Parameter 'path')
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> container archive ContainerArchive.dcon TestDir1 /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Path cannot be null. (Parameter 'path')"}}
</div>
~~~~


# container verify

~~~~
<div="helptext">
<over>
verify   Verify signatures and digests on container.
       Container to read
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `container verify` command verifies the authentication data of the specified 
container.


~~~~
<div="terminal">
<cmd>Alice> container verify ContainerArchiveEncrypt.dcon
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultFile:

~~~~
<div="terminal">
<cmd>Alice> container verify ContainerArchiveEncrypt.dcon /json
<rsp>{
  "ResultFile": {
    "Success": true,
    "Filename": "ContainerArchiveEncrypt.dcon"}}
</div>
~~~~



# container extract

~~~~
<div="helptext">
<over>
extract   Extract the specified record from the container
       Container to read
       Extracted file
    /record   Index number of file to extract
    /file   Name of file to extract
    /key   <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `container extract` command extracts the specified container entries and writes them
to files.


~~~~
<div="terminal">
<cmd>Alice> container extract Container.dcon TestOut
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> container extract Container.dcon TestOut /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
</div>
~~~~


# container append

~~~~
<div="helptext">
<over>
append   Append the specified file as an entry to the specified container
       Container to append to
       File to append
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   <Unspecified>
<over>
</div>
~~~~

The `container append` command appends the specified file to the container.


~~~~
<div="terminal">
<cmd>Alice> container append Container.dcon TestFile1.txtcontainer append Container.dcon TestFile2.txtcontainer append Container.dcon TestFile3.txt
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\TestFile1.txtcontainer'.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> container append Container.dcon TestFile1.txtcontainer append Container.dcon TestFile2.txtcontainer append Container.dcon TestFile3.txt /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Could not find file 'C:\\Users\\hallam\\Test\\WorkingDirectory\\TestFile1.txtcontainer'."}}
</div>
~~~~



# container delete

~~~~
<div="helptext">
<over>
delete   <Unspecified>
       Container to append to
    /file   Name of file to delete
    /key   <Unspecified>
<over>
</div>
~~~~

The `container delete` command marks the specified file entry as deleted in the
container but does not erase the data from the file.


~~~~
<div="terminal">
<cmd>Alice> container delete Container.dcon  TestFile2.txt
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> container delete Container.dcon  TestFile2.txt /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
</div>
~~~~


# container index

~~~~
<div="helptext">
<over>
index   Compile an index for the specified container and append to the end.
       Container to append to
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `container index` command appends an index record to the end of the container.


~~~~
<div="terminal">
<cmd>Alice> container index Container.dcon
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultFile:

~~~~
<div="terminal">
<cmd>Alice> container index Container.dcon /json
<rsp>{
  "ResultFile": {
    "Success": true,
    "Filename": "Container.dcon"}}
</div>
~~~~


# container copy

~~~~
<div="helptext">
<over>
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
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /decrypt   Decrypt contents
    /index   Append an index record to the end
    /purge   Purge unused data etc.
<over>
</div>
~~~~

The `container copy` command copies a container applying the specified filtering 
and indexing criteria.


~~~~
<div="terminal">
<cmd>Alice> container copy Container2.dcon
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Container2.dcon'.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> container copy Container2.dcon /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Could not find file 'C:\\Users\\hallam\\Test\\WorkingDirectory\\Container2.dcon'."}}
</div>
~~~~


