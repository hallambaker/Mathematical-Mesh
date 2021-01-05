

#DARE Container Schema

TBS stuff

##Container Headers

TBS stuff

###Structure: SequenceInfo

Information that describes container information

<dl>
<dt>DataEncoding: String (Optional)
<dd>Specifies the data encoding for the header section of for the following frames.
This value is ONLY valid in Frame 0 which MUST have a header encoded in JSON.
<dt>ContainerType: String (Optional)
<dd>Specifies the container type for the following records.
This value is ONLY valid in Frame 0 which MUST have a header encoded in JSON.
<dt>Index: Integer (Optional)
<dd>The record index within the file. This MUST be unique and 
satisfy any additional requirements determined by the ContainerType.
<dt>IsMeta: Boolean (Optional)
<dd>If true, the current frame is a meta frame and does not contain a payload.
<dd>Note: Meta frames MAY be present in any container. Applications MUST
accept containers that contain meta frames at any position in the file.
Applications MUST NOT interpret a meta frame as a data frame with an enpty payload.
<dt>Default: Boolean (Optional)
<dd>If set true in a persistent container, specifies that this record contains
the default object for the container.
<dt>TreePosition: Integer (Optional)
<dd>Position of the frame containing the apex of the preceding sub-tree.
<dt>IndexPosition: Integer (Optional)
<dd>Specifies the position in the file at which the last index entry is
to be found
<dt>ExchangePosition: Integer (Optional)
<dd>Specifies the position in the file at which the key exchange data is
to be found
</dl>
##Index Structures

TBS stuff

###Structure: SequenceIndex

A container index

<dl>
<dt>Full: Boolean (Optional)
<dd>If true, the index is complete and contains position entries for all the 
frames in the file. If absent or false, the index is incremental and only
contains position entries for records added since the last 
frame containing a ContainerIndex.
<dt>Positions: IndexPosition [0..Many]
<dd>List of container position entries
</dl>
###Structure: IndexPosition

Specifies the position in a file at which a specified record index is found

<dl>
<dt>Index: Integer (Optional)
<dd>The record index within the file.
<dt>Position: Integer (Optional)
<dd>The record position within the file relative to the index base.
<dt>UniqueId: String (Optional)
<dd>Unique object identifier
</dl>
###Structure: KeyValue

Specifies a key/value entry

<dl>
<dt>Key: String (Optional)
<dd>The key
<dt>Value: String (Optional)
<dd>The value corresponding to the key
</dl>
