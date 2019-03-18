

# network

````
network    Manage network profile settings
    add   Add calendar entry from file
    delete   Delete calendar entry
    dump   List network entries
    get   Lookup calendar entry
````


# network add

````
add   Add bookmark
       <Unspecified>
       <Unspecified>
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>bookmark add Folder1/1 http://example.com/ "Example Dot Com"
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>bookmark add Folder1/1 http://example.com/ "Example Dot Com" /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# network delete

````
delete   Delete bookmark entry
       Contact entry identifier
    /path   <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>bookmark delete BookmarkPath2
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>bookmark delete BookmarkPath2 /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# network get

````
get   Lookup bookmark entry
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>bookmark get Folder1/2
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>bookmark get Folder1/2 /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# network list

````
list   List bookmark entries
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>bookmark list
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>bookmark list /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

