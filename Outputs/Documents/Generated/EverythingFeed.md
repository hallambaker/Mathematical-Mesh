

##Shared Classes

The following classes are used as common elements in
Mesh profile specifications.

###Structure: Header

Describes the feed

<dl>
<dt>Title: String (Optional)
<dd>The name of the channel. 
<dt>Link: String (Optional)
<dd>The URL to the HTML website corresponding to the channel.
<dt>Description: String (Optional)
<dd>Phrase or sentence describing the channel
<dt>Language: String (Optional)
<dd>The language the channel is written in. As specified in the HTM: lang attribute.
<dt>Copyright: String (Optional)
<dd>Copyright notice for content in the channel.
<dt>ManagingEditor: String (Optional)
<dd>Email address for person responsible for editorial content.
<dt>WebMaster: String (Optional)
<dd>Email address for person responsible for technical issues relating to channel.
<dt>Category: String [0..Many]
<dd>Specifies one or more categories that the channel belongs to. 
<dt>Generator: String (Optional)
<dd>A string indicating the program used to generate the channel.
<dt>Docs: String (Optional)
<dd>A URL that points to the documentation for the format used in the RSS file.
<dt>cloud: String (Optional)
<dd>Allows processes to register with a cloud to be notified of updates to the channel, 
implementing a lightweight publish-subscribe protocol for RSS feeds.
<dt>Image: String (Optional)
<dd>Specifies a GIF, JPEG, PNG or SVG image that can be displayed with the channel
<dt>Rating: String (Optional)
<dd>A PICS rating for the channel.
<dt>TextInput: TextInput (Optional)
<dd>Specifies a text input box that can be displayed with the channel for HTML 
or RSS feedreader interaction.
<dt>skipHours: String (Optional)
<dd>A hint for aggregators telling them which hours they can skip. This 
element contains up to 24 hour sub-elements whose value is a number 
between 0 and 23, representing a time in UTC, when aggregators, 
if they support the feature, may not read the channel on hours listed 
in the skipHours element. The hour beginning at midnight is hour zero.
<dt>skipDays: String (Optional)
<dd>A hint for aggregators telling them which days they can skip. This element 
contains up to seven day sub-elements whose value is Monday, Tuesday, 
Wednesday, Thursday, Friday, Saturday or Sunday. Aggregators may not read 
the channel during days listed in the skipDays element.
</dl>
###Structure: TextInput

Provided for compatibility with legacy RSS readers.

<dl>
<dt>Title: String (Optional)
<dd>The label of the Submit button in the text input area.
<dt>Description: String (Optional)
<dd>Explains the text input area
<dt>Name: String (Optional)
<dd>The name of the text object in the text input area.
<dt>Link: String (Optional)
<dd>The URL of the CGI script that processes text input requests.
</dl>
###Structure: Footer

<dl>
<dt>Inherits:  Header
</dl>

<dl>
<dt>PubDate: DateTime (Optional)
<dd>The publication date for the content in the channel.
<dt>LastBuildDate: DateTime (Optional)
<dd>The last time the content of the channel changed.
</dl>
###Structure: Item

Base class for feed items.

<dl>
<dt>Author: String (Optional)
<dd>Identifies the author of the item. Defaults to the value specified
in the feed descriptor.
<dt>PubDate: DateTime (Optional)
<dd>Indicates when the item was published.
</dl>
###Structure: Feedback

<dl>
<dt>Inherits:  Item
</dl>

A response item consisting of only a subject specified and semantic, no
content is included.

<dl>
<dt>Subject: String (Optional)
<dd>The URI of the subject matter being commented on.
<dt>Semantic: String (Optional)
<dd>The feedback semantic
</dl>
###Structure: Comment

<dl>
<dt>Inherits:  Item
</dl>

A response item consisting of a short form response to a single
subject.

<dl>
<dt>ContentType: String (Optional)
<dd>The content type.
<dt>Text: Binary (Optional)
<dd>The comment content.
</dl>
###Structure: Publication

<dl>
<dt>Inherits:  Feedback
</dl>

Publication notice for a document that is not a comment on another
publication or comment or is of extended length.

<dl>
<dt>Title: String (Optional)
<dd>The title of the item.	
<dt>Link: String (Optional)
<dd>A URI from which the content may be retreived. This is used for 
longer content such as a document.
<dt>Description: String (Optional)
<dd>The item synopsis.
<dt>Category: String [0..Many]
<dd>Includes the item in one or more categories.
<dt>Comments: String (Optional)
<dd>URL of a page for comments relating to the item.
<dt>Enclosure: String (Optional)
<dd>Describes a media object that is attached to the item.
<dt>Guid: String (Optional)
<dd>A string that uniquely identifies the item.
<dt>Source: String (Optional)
<dd>The RSS channel that the item came from.
</dl>
