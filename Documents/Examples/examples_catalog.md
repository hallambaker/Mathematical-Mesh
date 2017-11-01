
<h2>Catalog Example

Alice creates a new bookmarks profile which is shared between her laptop and
her phone. The initial profile is empty:

~~~~
{
  "BookmarkProfilePrivate": {
    "Entries": []}}
~~~~

Alice adds a bookmark entry to her profile on the browser on her laptop:

~~~~
{
  "BookmarkProfilePrivate": {
    "Entries": [{
        "Added": "2017-10-25T16:29:48Z",
        "Title": "First Site",
        "Uri": "http://example.com/"}]}}
~~~~

Later, Alice is attempting to connect to a site on her phone but has no network 
connection. She decides to bookmark the site instead. 

~~~~
{
  "BookmarkProfilePrivate": {
    "Entries": [{
        "Added": "2017-10-25T18:04:26Z",
        "Title": "Second Site",
        "Uri": "https://example.com/"}]}}
~~~~

At this point, the profiles on Alice's two devices are out of sync. When the phone is
finally able to connect to the network, the profiles are merged:

~~~~
{
  "BookmarkProfilePrivate": {
    "Entries": [{
        "Added": "2017-10-25T16:29:48Z",
        "Title": "First Site",
        "Uri": "http://example.com/"},
      {
        "Added": "2017-10-25T18:04:26Z",
        "Title": "Second Site",
        "Uri": "https://example.com/"}]}}
~~~~


