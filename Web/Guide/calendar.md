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
  "Key": "NBAV-GPP4-X3P4-XBMH-IWUX-ZB4A-B7V5"}<cmd>Alice> calendar add CalendarEntry2.json CalID2
<rsp>{
  "Title": "CalendarEntry2.json",
  "Key": "NDTW-A4KX-SLAY-PA3A-QTWH-RQ37-TSKM"}</div>
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

CatalogedTask

</div>
~~~~

## Adding devices

Devices are given authorization to access the calendars catalog using the 
 `device auth` command:

 %  ConsoleExample (ShellCalendar.CalendarAuth);


