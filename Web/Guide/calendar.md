<title>calendar
# Using the calendar Command Set

The `calendar` command set is used to manage a calendar configuration catalog which contains
a entries describing how to access particular calendars.

Calendar entries are typically exchanged in iCal format. This is not currently
implemented and a placeholder format is implemented instead.

## Adding calendars

The `password add` command adds a calendar entry to a catalog:


~~~~
<div="terminal">
<cmd>Alice> calendar add CalendarEntry1.json CalID1
<rsp>{
  "Title": "CalendarEntry1.json",
  "Key": "NAP7-FOLE-XNRS-EY2Y-GO5O-JC7A-SFHK"}<cmd>Alice> calendar add CalendarEntry2.json CalID2
<rsp>{
  "Title": "CalendarEntry2.json",
  "Key": "NBYZ-3J4S-6A5Y-VPWL-PQ75-H44X-D4JS"}</div>
~~~~


## Finding calendars

The `password get`  command retreives a calendar entry by label:


~~~~
<div="terminal">
<cmd>Alice> calendar get CalID1
<rsp>Empty
</div>
~~~~

## Deleting calendars

Calendar entries may be deleted using the  `calendar delete` command:


~~~~
<div="terminal">
<cmd>Alice> calendar delete CalID1
<rsp>ERROR - The entry could not be found in the store.
<cmd>Alice> calendar list
<rsp>CatalogedTask

CatalogedTask

</div>
~~~~

## Listing calendars

A complete list of calendars is obtained using the  `calendar list` command:


~~~~
<div="terminal">
<cmd>Alice> calendar list
<rsp>CatalogedTask

CatalogedTask

</div>
~~~~

## Adding devices

Devices are given authorization to access the calendars catalog using the 
 `device auth` command:

 %  ConsoleExample (Examples.CalendarAuth);


