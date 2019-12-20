

# network

~~~~
<div="helptext">
<over>
network    Manage network profile settings
    add   Add calendar entry from file
    delete   Delete calendar entry
    dump   List network entries
    get   Lookup calendar entry
    import   Add calendar entry from file
<over>
</div>
~~~~


# network add

~~~~
<div="helptext">
<over>
add   Add bookmark
       <Unspecified>
       <Unspecified>
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> bookmark add Folder1/1 http://example.com/ "Example Dot Com"
<rsp>{
  "Uri": "http://example.com/",
  "Title": "\"Example",
  "Path": "Folder1/1"}</div>
~~~~

Specifying the /json option returns a result of type ResultEntry:

~~~~
<div="terminal">
<cmd>Alice> bookmark add Folder1/1 http://example.com/ "Example Dot Com" /json
<rsp>{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Uri": "http://example.com/",
      "Title": "\"Example",
      "Path": "Folder1/1"}}}
</div>
~~~~


# network delete

~~~~
<div="helptext">
<over>
delete   Delete bookmark entry
       Contact entry identifier
    /path   <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> bookmark delete BookmarkPath2
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> bookmark delete BookmarkPath2 /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
</div>
~~~~


# network get

~~~~
<div="helptext">
<over>
get   Lookup bookmark entry
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> bookmark get Folder1/2
<rsp>{
  "Uri": "http://example.net/Bananas",
  "Title": "\"Banana",
  "Path": "Folder1/2"}</div>
~~~~

Specifying the /json option returns a result of type ResultEntry:

~~~~
<div="terminal">
<cmd>Alice> bookmark get Folder1/2 /json
<rsp>{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Uri": "http://example.net/Bananas",
      "Title": "\"Banana",
      "Path": "Folder1/2"}}}
</div>
~~~~


# network list

~~~~
<div="helptext">
<over>
list   List bookmark entries
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> bookmark list
<rsp>{
  "Uri": "http://example.com/",
  "Title": "\"Example",
  "Path": "Folder1/1"}{
  "Uri": "http://example.net/Bananas",
  "Title": "\"Banana",
  "Path": "Folder1/2"}{
  "Uri": "http://example.com/Fred",
  "Title": "\"The",
  "Path": "Folder1/1a"}</div>
~~~~

Specifying the /json option returns a result of type ResultDump:

~~~~
<div="terminal">
<cmd>Alice> bookmark list /json
<rsp>{
  "ResultDump": {
    "Success": true,
    "CatalogedEntries": [{
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
</div>
~~~~


