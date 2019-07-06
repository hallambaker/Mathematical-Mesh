

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
{
  "Uri": "http://example.com/",
  "Title": "\"Example",
  "Path": "Folder1/1"}````

Specifying the /json option returns a result of type ResultEntry:

````
>bookmark add Folder1/1 http://example.com/ "Example Dot Com" /json
{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Uri": "http://example.com/",
      "Title": "\"Example",
      "Path": "Folder1/1"}}}
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
{
  "Uri": "http://example.net/Bananas",
  "Title": "\"Banana",
  "Path": "Folder1/2"}````

Specifying the /json option returns a result of type ResultEntry:

````
>bookmark get Folder1/2 /json
{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Uri": "http://example.net/Bananas",
      "Title": "\"Banana",
      "Path": "Folder1/2"}}}
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
{
  "Uri": "http://example.com/",
  "Title": "\"Example",
  "Path": "Folder1/1"}{
  "Uri": "http://example.net/Bananas",
  "Title": "\"Banana",
  "Path": "Folder1/2"}{
  "Uri": "http://example.com/Fred",
  "Title": "\"The",
  "Path": "Folder1/1a"}````

Specifying the /json option returns a result of type ResultDump:

````
>bookmark list /json
{
  "ResultDump": {
    "Success": true,
    "CatalogEntries": [{
        "Uri": "http://example.com/",
        "Title": "\"Example",
        "Path": "Folder1/1"},
      {
        "Uri": "http://example.net/Bananas",
        "Title": "\"Banana",
        "Path": "Folder1/2"},
      {
        "Uri": "http://example.com/Fred",
        "Title": "\"The",
        "Path": "Folder1/1a"}]}}
````

