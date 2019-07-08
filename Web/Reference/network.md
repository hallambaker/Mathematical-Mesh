

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
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> network add NetworkEntry1.json NetID1
{
  "Key": "NetID1"}````

Specifying the /json option returns a result of type ResultEntry:

````
Alice> network add NetworkEntry1.json NetID1 /json
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
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> network delete NetID2
{
  "Key": "NetID2"}````

Specifying the /json option returns a result of type ResultEntry:

````
Alice> network delete NetID2 /json
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
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> network get NetID2
{
  "Key": "NetID2"}````

Specifying the /json option returns a result of type ResultEntry:

````
Alice> network get NetID2 /json
{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Key": "NetID2"}}}
````

# network dump

````
dump   List network entries
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> network list
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
Alice> network list /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

