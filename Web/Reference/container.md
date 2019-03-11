

# container

````
container    
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
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
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
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /type   The container type, plain/tree/digest/chain/tree
    /out   New container
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
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   <Unspecified>
````
# container delete

````
delete   <Unspecified>
       Container to append to
       File to append
    /key   <Unspecified>
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
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````
# container extract

````
extract   Extract the specified record from the container
       Container to read
       Extracted file
    /record   Index number of file to extract
    /file   Name of file to extract
    /key   <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
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
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /decrypt   Decrypt contents
    /index   Append an index record to the end
    /purge   Purge unused data etc.
````
# container verify

````
verify   Verify signatures and digests on container.
       Container to read
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

