<title>calendar
# Using the calendar Command Set

The `calendar` command set is used to manage a calendar configuration catalog which contains
a entries describing how to access particular calendars.

It should be noted that by its very nature, a calendar tool is most likely 
to be useful within a calendar application. The
commands provided in the 'meshman' tool are intended to support debuging and 
maintenance of such applications and afford a means of interacting through scripts.

As with bookmarks, calendar entries should be considered as including all forms of
task announcement, including those that are not appointments and do not take place at
a fixed time.

For example, Alice might send messages to Bob telling him that she wants to meet
him the next day at 3pm or that she would like to meet at a time convenient to him
within the next week. Carol migt send a message to Bob telling him to buy more
lawn and leaf bags when he is in a store that sells them.

The format of all these tasks is 'when condition X is met do Y', and it makes 
good sense to use the same application for all of them, particularly when that
application is running on a device that constantly tracks its current location, not
just the current time.


## Adding calendar entries

The `password add` and `password import` command 
add calendar entries to a catalog. The add command creates an entry from
the command line options. The import command adds an entry from a file.


The catalog entry is specified in a file containing the calendar entry data. Currently,
only JSON entry files are supported.

[Future Feature: Calendar/iCal] Allow iCal description of the entry to add.
Calendar entries are typically exchanged in iCal format. This is not currently
implemented and a placeholder format is implemented instead.



~~~~
<div="terminal">
<cmd>Alice> meshman calendar add CalendarEntry1.json CalID1
<rsp>{
  "Title": "CalendarEntry1.json",
  "Key": "NCCO-AW4T-O25V-DXZ2-2CYA-FFDL-XTRP"}
<cmd>Alice> meshman calendar add CalendarEntry2.json CalID2
<rsp>{
  "Title": "CalendarEntry2.json",
  "Key": "NDBN-TAS4-G554-PD2V-BNLM-A6CM-63SS"}
</div>
~~~~


## Finding calendars

The `password get`  command retreives a calendar entry by label:


~~~~
<div="terminal">
<cmd>Alice> meshman calendar get CalID1
<rsp>
</div>
~~~~

## Deleting calendars

Calendar entries may be deleted using the  `calendar delete` command:


~~~~
<div="terminal">
<cmd>Alice> meshman calendar delete CalID1
<rsp>ERROR - The entry could not be found in the store.
<cmd>Alice> meshman calendar list
<rsp>CatalogedTask

CatalogedTask

CatalogedTask

</div>
~~~~

## Listing calendars

A complete list of calendars is obtained using the  `calendar list` command:


~~~~
<div="terminal">
<cmd>Alice> meshman calendar list
<rsp>CatalogedTask

CatalogedTask

CatalogedTask

</div>
~~~~

## Adding devices


~~~~
<div="terminal">
<cmd>Alice5> meshman bookmark list
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Devices are given authorization to access the calendars catalog using the 
 `device auth` command:


~~~~
<div="terminal">
<cmd>Alice> meshman device auth Alice5 /all
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~


The new device now has access to the Calendar catalog:


~~~~
<div="terminal">
<cmd>Alice5> meshman bookmark list
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

