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
<cmd>Alice> meshman calendar add CalendarEntry1.json CalID1
<rsp>{
  "Title": "CalendarEntry1.json",
  "Key": "NDJD-2XYH-E7DS-OUQM-GYDR-MSDR-AGJD"}
<cmd>Alice> meshman calendar add CalendarEntry2.json CalID2
<rsp>{
  "Title": "CalendarEntry2.json",
  "Key": "NCLP-3LS4-EU2Z-JUAR-U7SW-WB2V-XG3Z"}
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

Devices are given authorization to access the calendars catalog using the 
 `device auth` command:

 %  ConsoleExample (ShellCalendar.CalendarAuth);


