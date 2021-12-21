

# bookmark

~~~~
<div="helptext">
<over>
bookmark    Manage bookmark catalogs connected to an account
    add   Add bookmark entry from specified parameters
    delete   Delete bookmark entry
    get   Lookup bookmark entry
    import   Add bookmark entry from file
    list   List bookmark entries
<over>
</div>
~~~~

The `bookmark` command set is used to manage a bookmarks catalog which contains
a collection of bookmarks and citations and shares them between devices connected 
to the profile with the relevant access authorization.

It should be noted that by its very nature, a bookmark manager is most likely 
to be useful within an application that uses bookmarks for navigation. The
commands provided in the 'meshman' tool are intended to support debuging and 
maintenance of such applications and afford a means of interacting through scripts.


# bookmark add

~~~~
<div="helptext">
<over>
add   Add bookmark entry from specified parameters
       Keywords under which the bookmark is to be indexed
       The recorded link
       Title of the recorded item
    /abstract   Abstract of the recorded item
    /comment   Comment on reason for adding
    /react   Reactions to the recorded item
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'bookmark add' command is used to add bookmarks to the catalog.

The catalog labels, uri and title are specified as parameters.

An abstract, comment and reaction tags may be specified as options.


~~~~
<div="terminal">
<cmd>Alice> meshman bookmark add Folder1/1 http://example.com/ "Example Dot Com"
<rsp>{
  "Uri": "http://example.com/",
  "Title": "\"Example",
  "Path": "Folder1/1"}
</div>
~~~~



# bookmark delete

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

The 'bookmark delete' command deletes a bookmark by means of its unique catalog identifier.


~~~~
<div="terminal">
<cmd>Alice> meshman bookmark delete BookmarkPath2
<rsp>ERROR - The entry could not be found in the store.
</div>
~~~~



# bookmark get

~~~~
<div="helptext">
<over>
get   Lookup bookmark entry
       The unique entry identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'bookmark get' command retrieves a bookmark by means of its unique catalog identifier.


~~~~
<div="terminal">
<cmd>Alice> meshman bookmark get Folder1/2
<rsp>{
  "Uri": "http://example.net/Bananas",
  "Title": "\"Banana",
  "Path": "Folder1/2"}
</div>
~~~~



# bookmark import

~~~~
<div="helptext">
<over>
import   Add network entry from file
       File containing the network entry to add
    /id   Unique entry identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'bookmark import' command is used to add a bookmark entry to the catalog
from a file


# bookmark list

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

The 'bookmark list' command lists all data in the bookmark catalog.


~~~~
<div="terminal">
<cmd>Alice> meshman bookmark list
<rsp>CatalogedBookmark

CatalogedBookmark

CatalogedBookmark

CatalogedBookmark

</div>
~~~~



