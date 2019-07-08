

# calendar

````
calendar    Manage calendar catalogs connected to an account
    add   Add calendar entry from file
    delete   Delete calendar entry
    dump   List calendar entries
    get   Lookup calendar entry
````


# calendar add

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
Alice> calendar add CalendarEntry1.json CalID1
{
  "Key": "CalID1"}````

Specifying the /json option returns a result of type ResultEntry:

````
Alice> calendar add CalendarEntry1.json CalID1 /json
{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Key": "CalID1"}}}
````

# calendar delete

````
delete   Delete calendar entry
       Contact entry identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> calendar delete CalID1
{
  "Key": "CalID1"}````

Specifying the /json option returns a result of type ResultEntry:

````
Alice> calendar delete CalID1 /json
{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Key": "CalID1"}}}
````

# calendar get

````
get   Lookup calendar entry
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> calendar get CalID1
{
  "Key": "CalID1"}````

Specifying the /json option returns a result of type ResultEntry:

````
Alice> calendar get CalID1 /json
{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Key": "CalID1"}}}
````

# calendar dump

````
dump   List calendar entries
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> calendar list
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
Alice> calendar list /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````


