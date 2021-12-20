

# contact

~~~~
<div="helptext">
<over>
contact    Manage contact catalogs connected to an account
    delete   Delete contact entry
    dynamic   Create dynamic contact retrieval URI
    exchange   Request contact from URI presenting own contact
    export   Export contact entry from catalog
    fetch   Request contact from URI without presenting own contact
    get   Lookup contact entry
    import   Import contact entry from file
    list   List contact entries
    self   Update contact entry for self
    static   Create static contact retrieval URI
<over>
</div>
~~~~

# contact delete

~~~~
<div="helptext">
<over>
delete   Delete contact entry
       Contact entry identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'contact delete' command deletes a contact entry entry by means of 
its unique catalog identifier.


~~~~
<div="terminal">
<cmd>Alice> meshman contact delete carol@example.com
<rsp>ERROR - The entry could not be found in the store.
</div>
~~~~





# contact dynamic

~~~~
<div="helptext">
<over>
dynamic   Create dynamic contact retrieval URI
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'contact dynamic' command creates a dynamic contact URI such as
might be presented to another user as a QR code. The URI combines the
location data for the contact with an PIN that may
be used to authenticate the response in a mutual exchange.

# contact exchange

~~~~
<div="helptext">
<over>
exchange   Request contact from URI presenting own contact
       Contact exchange URI
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'contact exchange' command is used to complete a mutual contact exchange
by means of a dynamic URI.


# contact export

~~~~
<div="helptext">
<over>
export   Export contact entry from catalog
       Contact entry identifier
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The  'contact export' command exports the spcified contact entry to a file
in the specified format.

# contact fetch

~~~~
<div="helptext">
<over>
fetch   Request contact from URI without presenting own contact
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'contact fetch' command is used to acquire a dynamic or static contact
presented as a URI or QR code without reciprocating the exchange.



# contact get

~~~~
<div="helptext">
<over>
get   Lookup contact entry
       Contact entry identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /encrypt   Encrypt the contact under the specified key
<over>
</div>
~~~~

The 'contact get' command retrieves a contact entry by means of its 
unique catalog identifier.



~~~~
<div="terminal">
<cmd>Alice> meshman contact get carol@example.com
<rsp>
</div>
~~~~




# contact import

~~~~
<div="helptext">
<over>
import   Import contact entry from file
       File containing the contact entry to add
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'contact import' command is used to add a contact entry to the catalog
from a file



~~~~
Missing example 27
~~~~





# contact list

~~~~
<div="helptext">
<over>
list   List contact entries
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'contact list' command lists all data in the contact catalog.


~~~~
<div="terminal">
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ
  Person MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ
  Anchor MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ
  Address alice@example.com

Entry<CatalogedContact>: ND3C-FKIQ-OBU3-V4JR-DEKG-XMPY-TQMH
  Person 
  Anchor MCP6-3M76-EWWZ-BD3D-VAMF-HJ6X-H7A4
  Address bob@example.com

Entry<CatalogedContact>: NCLZ-GAKI-BJC2-IHNB-RPF6-LOZP-YRSE
  Person 
  Anchor MDXI-T5OT-YIXR-OLTB-YW7L-HKZC-OOT7
  Address groupw@example.com

Entry<CatalogedContact>: NDTC-2PDB-IB3B-MKSY-E4NR-ZJQB-UKOF
  Person 
  Anchor MDXI-T5OT-YIXR-OLTB-YW7L-HKZC-OOT7
  Address groupw@example.com

Entry<CatalogedContact>: NBEH-4E2S-U5T2-6IFK-BZSV-SISO-AY5X
  Person 
  Anchor MDXI-T5OT-YIXR-OLTB-YW7L-HKZC-OOT7
  Address groupw@example.com

Entry<CatalogedContact>: NBNJ-CW7O-UPNW-UAOF-LWME-TWPL-2QTQ
  Person 
  Anchor MDXI-T5OT-YIXR-OLTB-YW7L-HKZC-OOT7
  Address groupw@example.com

</div>
~~~~



# contact self

~~~~
<div="helptext">
<over>
self   Update contact entry for self
    /file   File containing the contact entry to add
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'contact static' command creates a URI from which a static QR code may be created
to allow contact information to be published on a business card etc. in machine
readable form.

# contact static

~~~~
<div="helptext">
<over>
static   Create static contact retrieval URI
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

