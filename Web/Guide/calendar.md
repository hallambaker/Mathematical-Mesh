
# Using the `calendar` Command Set

The `calendar` command set is used to manage a calendar configuration catalog which contains
a entries describing how to access particular calendars.

Calendar entries are typically exchanged in iCal format. This is not currently
implemented and a placeholder format is implemented instead.

## Adding calendars

The `password add` command adds a calendar entry to a catalog:


````
Alice> calendar add CalendarEntry1.json CalID1
{
  "Key": "CalID1"}Alice> calendar add CalendarEntry2.json CalID2
{
  "Key": "CalID2"}````


## Finding calendars

The `password get`  command retreives a calendar entry by label:


````
Alice> calendar get CalID1
{
  "Key": "CalID1"}````

## Deleting calendars

Calendar entries may be deleted using the  `calendar delete` command:


````
Alice> calendar delete CalID1
{
  "Key": "CalID1"}Alice> calendar list
ERROR - The command  is not known.
````

## Listing calendars

A complete list of calendars is obtained using the  `calendar list` command:


````
Alice> calendar list
ERROR - The command  is not known.
````

## Adding devices

Devices are given authorization to access the calendars catalog using the 
 `device auth` command:

 %  ConsoleExample (Examples.CalendarAuth);


