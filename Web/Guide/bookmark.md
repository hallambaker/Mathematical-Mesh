<title>bookmark
# Using the bookmark Command Set

The `bookmark` command set is used to manage a bookmarks catalog which contains
a collection of bookmarks and citations and shares them between devices connected 
to the profile with the relevant access authorization.

It should be noted that by its very nature, a bookmark manager is most likely 
to be useful within an application that uses bookmarks for navigation. The
commands provided in the 'meshman' tool are intended to support debuging and 
maintenance of such applications and afford a means of interacting through scripts.

The term 'bookmark' is interpreted loosely to mean any piece of index information
that the user might want to index and add to a catalog for future use. This
includes traditional Web bookmarks and citations to academic articles.

The current version of the Mesh protocols only support access to a single personal 
bookmark catalog but the approach could, in principle, be extanded to support multiple
named bookmark catalogs per user and catalogs sharted between multiple users.

[Future Feature: Bookmark/Abstract] The abstract and reaction features are not yet implemented

[Future Feature: Bookmark/JSON] Allow upload of a JSON file with the bookmark entey


## Adding bookmarks

The `bookmark add` command adds a bookmark entry to a catalog:


~~~~
<div="terminal">
<cmd>Alice> meshman bookmark add http://example.com/ "Example Dot Com" ^
    /id=Folder1-1 
<rsp>[NBU6-H6UE-VYAW-MKTE-NNS4-MMFA-4D7G/Folder1-1] http://example.com/
"Example
<cmd>Alice> meshman bookmark add http://example.net/Bananas "Banana Site" ^
    /id=Folder1-2 
<rsp>[NB7Z-FTZA-R7EC-3NM6-PQRK-5YIQ-GZF5/Folder1-2] http://example.net/Ban
anas
"Banana
<cmd>Alice> meshman bookmark add http://example.com/Fred "The Fred Space" ^
    /id=Folder1-1a
<rsp>[NDXB-R3GE-LXUA-OTOT-C7MT-44EH-UWT4/Folder1-1a] http://example.com/Fr
ed
"The
</div>
~~~~

The path mechanism is clearly clunky and should be eliminated in favor or a series of
hashtag type search terms which may be hierarchical if this seems useful.

The add command should be expanded to allow an abstract and reaction to be included.
So if I find material useful, I give it thumbs up, terrible, a thumbs down.

It should also be possible to attach comments to bookmarks giving a longer explanation.


## Finding bookmarks

The `bookmark get`  command retreives a bookmark  by its index label:


~~~~
<div="terminal">
<cmd>Alice> meshman bookmark get Folder1-2
<rsp>[NB7Z-FTZA-R7EC-3NM6-PQRK-5YIQ-GZF5/Folder1-2] http://example.net/Ban
anas
"Banana
</div>
~~~~

## Deleting bookmarks

Bookmark entries may be deleted using the  `bookmark delete` command:


~~~~
<div="terminal">
<cmd>Alice> meshman bookmark delete Folder1-2
<cmd>Alice> meshman bookmark list
<rsp>[NCVL-GKQ7-UFSC-C2M4-XKN2-BOKI-WQ56/Sites-1] http://www.example.com
site1
[NBU6-H6UE-VYAW-MKTE-NNS4-MMFA-4D7G/Folder1-1] http://example.com/
"Example
[NDXB-R3GE-LXUA-OTOT-C7MT-44EH-UWT4/Folder1-1a] http://example.com/Fr
ed
"The
</div>
~~~~

## Listing bookmarks

A complete list of bookmarks is obtained using the  `bookmark list` command:


~~~~
<div="terminal">
<cmd>Alice> meshman bookmark list
<rsp>[NCVL-GKQ7-UFSC-C2M4-XKN2-BOKI-WQ56/Sites-1] http://www.example.com
site1
[NBU6-H6UE-VYAW-MKTE-NNS4-MMFA-4D7G/Folder1-1] http://example.com/
"Example
[NB7Z-FTZA-R7EC-3NM6-PQRK-5YIQ-GZF5/Folder1-2] http://example.net/Ban
anas
"Banana
[NDXB-R3GE-LXUA-OTOT-C7MT-44EH-UWT4/Folder1-1a] http://example.com/Fr
ed
"The
</div>
~~~~

## Adding devices




~~~~
<div="terminal">
<cmd>Alice5> meshman bookmark list
<rsp>ERROR - Unspecified error
</div>
~~~~

Devices are given authorization to access the bookmarks catalog using the 
 `device auth` command:



~~~~
<div="terminal">
<cmd>Alice> meshman device auth Alice5 /all
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~

The new device now has access to the Bookmarks catalog:


~~~~
<div="terminal">
<cmd>Alice5> meshman bookmark list
<rsp>ERROR - Unspecified error
</div>
~~~~
