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
<rsp>ERROR - Object reference not set to an instance of an object.
<cmd>Alice> calendar add CalendarEntry2.json CalID2
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~


## Finding calendars

The `password get`  command retreives a calendar entry by label:


~~~~
<div="terminal">
<cmd>Alice> calendar get CalID1
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

## Deleting calendars

Calendar entries may be deleted using the  `calendar delete` command:


~~~~
<div="terminal">
<cmd>Alice> calendar delete CalID1
<rsp>ERROR - Object reference not set to an instance of an object.
<cmd>Alice> calendar list
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

## Listing calendars

A complete list of calendars is obtained using the  `calendar list` command:


~~~~
<div="terminal">
<cmd>Alice> calendar list
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

## Adding devices

Devices are given authorization to access the calendars catalog using the 
 `device auth` command:

 %  ConsoleExample (ShellCalendar.CalendarAuth);


