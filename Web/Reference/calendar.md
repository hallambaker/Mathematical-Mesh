

# calendar

````
calendar    Manage calendar catalogs connected to an account
    add   Add calendar entry
    delete   Delete calendar entry
    dump   List calendar entries
    get   Lookup calendar entry
    import   Add calendar entry from file
````


# calendar add

````
add   Add calendar entry
       <Unspecified>
    /id   <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> calendar add CalendarEntry1.json CalID1
{
  "Title": "CalendarEntry1.json",
  "Key": "NCVX-HLBU-5L23-VYYD-WUBR-4DPF-I2BE"}````

Specifying the /json option returns a result of type ResultEntry:

````
Alice> calendar add CalendarEntry1.json CalID1 /json
{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Title": "CalendarEntry1.json",
      "Key": "NCVX-HLBU-5L23-VYYD-WUBR-4DPF-I2BE"}}}
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
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
Alice> calendar delete CalID1 /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
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
Empty
````

Specifying the /json option returns a result of type ResultEntry:

````
Alice> calendar get CalID1 /json
{
  "ResultEntry": {
    "Success": false}}
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


