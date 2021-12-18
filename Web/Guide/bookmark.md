<title>bookmark
# Using the bookmark Command Set

The `bookmark` command set is used to manage a bookmarks catalog which contains
a collection of bookmarks and citations and shares them between devices connected 
to the profile with the relevant access authorization.

The term 'bookmark' is interpreted loosely to mean any piece of index information
that the user might want to index and add to a catalog for future use. This
includes traditional Web bookmarks and citations to academic articles.

The current version of the Mesh protocols only support access to a single personal 
bookmark catalog but the approach could, in principle, be extanded to support multiple
named bookmark catalogs per user and catalogs sharted between multiple users.

## Adding bookmarks

The `bookmark add` command adds a bookmark entry to a catalog:


~~~~
<div="terminal">
<cmd>Alice> meshman bookmark add Folder1/1 http://example.com/ "Example Dot ^
    Com"
<rsp>{
  "Uri": "http://example.com/",
  "Title": "\"Example",
  "Path": "Folder1/1"}
<cmd>Alice> meshman bookmark add Folder1/2 http://example.net/Bananas ^
    "Banana Site"
<rsp>{
  "Uri": "http://example.net/Bananas",
  "Title": "\"Banana",
  "Path": "Folder1/2"}
<cmd>Alice> meshman bookmark add Folder1/1a http://example.com/Fred "The ^
    Fred Space"
<rsp>{
  "Uri": "http://example.com/Fred",
  "Title": "\"The",
  "Path": "Folder1/1a"}
</div>
~~~~


## Finding bookmarks

The `bookmark get`  command retreives a bookmark  by its index label:


~~~~
<div="terminal">
<cmd>Alice> meshman bookmark get Folder1/2
<rsp>{
  "Uri": "http://example.net/Bananas",
  "Title": "\"Banana",
  "Path": "Folder1/2"}
</div>
~~~~

## Deleting bookmarks

Bookmark entries may be deleted using the  `bookmark delete` command:


~~~~
<div="terminal">
<cmd>Alice> meshman bookmark delete BookmarkPath2
<rsp>ERROR - The entry could not be found in the store.
</div>
~~~~

## Listing bookmarks

A complete list of bookmarks is obtained using the  `bookmark list` command:


~~~~
<div="terminal">
<cmd>Alice> meshman bookmark list
<rsp>CatalogedBookmark

CatalogedBookmark

CatalogedBookmark

CatalogedBookmark

</div>
~~~~

## Adding devices

Devices are given authorization to access the bookmarks catalog using the 
 `device auth` command:


~~~~
Missing example 49
~~~~

The new device now has access to the Bookmarks catalog:


~~~~
Missing example 50
~~~~
