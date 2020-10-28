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
Missing example 1
~~~~


## Finding bookmarks

The `bookmark get`  command retreives a bookmark  by its index label:


~~~~
Missing example 2
~~~~

## Deleting bookmarks

Bookmark entries may be deleted using the  `bookmark delete` command:


~~~~
Missing example 3
~~~~

## Listing bookmarks

A complete list of bookmarks is obtained using the  `bookmark list` command:


~~~~
Missing example 4
~~~~

## Adding devices

Devices are given authorization to access the bookmarks catalog using the 
 `device auth` command:


~~~~
Missing example 5
~~~~

The new device now has access to the Bookmarks catalog:


~~~~
Missing example 6
~~~~
