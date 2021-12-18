

# network

~~~~
<div="helptext">
<over>
network    Manage network profile settings
    add   Add calendar entry from file
    delete   Delete calendar entry
    get   Lookup calendar entry
    import   Add calendar entry from file
    list   List network entries
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
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> meshman bookmark add Folder1/1 http://example.com/ "Example Dot Com"
<rsp>{
  "Uri": "http://example.com/",
  "Title": "\"Example",
  "Path": "Folder1/1"}
</div>
~~~~

Specifying the /json option returns a result of type ResultEntry:

~~~~
<div="terminal">
<cmd>Alice> meshman bookmark add Folder1/1 http://example.com/ "Example Dot Com" /json
<rsp>{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "CatalogedBookmark": {
        "Uri": "http://example.com/",
        "Title": "\"Example",
        "Path": "Folder1/1"}}}}
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
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> meshman bookmark delete BookmarkPath2
<rsp>ERROR - The entry could not be found in the store.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> meshman bookmark delete BookmarkPath2 /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The entry could not be found in the store."}}
</div>
~~~~


# network get

~~~~
<div="helptext">
<over>
get   Lookup bookmark entry
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> meshman bookmark get Folder1/2
<rsp>{
  "Uri": "http://example.net/Bananas",
  "Title": "\"Banana",
  "Path": "Folder1/2"}
</div>
~~~~

Specifying the /json option returns a result of type ResultEntry:

~~~~
<div="terminal">
<cmd>Alice> meshman bookmark get Folder1/2 /json
<rsp>{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "CatalogedBookmark": {
        "Uri": "http://example.net/Bananas",
        "Title": "\"Banana",
        "Path": "Folder1/2"}}}}
</div>
~~~~


# network list

~~~~
<div="helptext">
<over>
list   List bookmark entries
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> meshman bookmark list
<rsp>CatalogedBookmark

CatalogedBookmark

CatalogedBookmark

CatalogedBookmark

</div>
~~~~

Specifying the /json option returns a result of type ResultDump:

~~~~
<div="terminal">
<cmd>Alice> meshman bookmark list /json
<rsp>{
  "ResultDump": {
    "Success": true,
    "CatalogedEntries": [{
        "CatalogedBookmark": {
          "Uri": "http://www.example.com",
          "Title": "site1",
          "Path": "Sites.1"}},
      {
        "CatalogedBookmark": {
          "Uri": "http://example.com/",
          "Title": "\"Example",
          "Path": "Folder1/1"}},
      {
        "CatalogedBookmark": {
          "Uri": "http://example.net/Bananas",
          "Title": "\"Banana",
          "Path": "Folder1/2"}},
      {
        "CatalogedBookmark": {
          "Uri": "http://example.com/Fred",
          "Title": "\"The",
          "Path": "Folder1/1a"}}]}}
</div>
~~~~


