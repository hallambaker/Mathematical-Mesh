

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
add   Add calendar entry from file
       <Unspecified>
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>network add NetworkEntry1.json NetID1
{
  "Key": "NetID1"}````

Specifying the /json option returns a result of type ResultEntry:

````
>network add NetworkEntry1.json NetID1 /json
{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Key": "NetID1"}}}
````

# network delete

````
delete   Delete calendar entry
       Network entry identifier
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>network delete NetID2
{
  "Key": "NetID2"}````

Specifying the /json option returns a result of type ResultEntry:

````
>network delete NetID2 /json
{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Key": "NetID2"}}}
````

# network get

````
get   Lookup calendar entry
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>network get NetID2
{
  "Key": "NetID2"}````

Specifying the /json option returns a result of type ResultEntry:

````
>network get NetID2 /json
{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Key": "NetID2"}}}
````

# network dump

````
dump   List network entries
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>network list
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>network list /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

