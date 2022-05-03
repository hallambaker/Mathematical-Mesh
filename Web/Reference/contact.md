

# contact

~~~~
<div="helptext">
<over>
contact    Manage contact catalogs connected to an account
    add   Add contact entry from specified parameters
    delete   Delete contact entry
    dynamic   Create dynamic contact retrieval URI
    exchange   Request contact from URI presenting own contact
    fetch   Request contact from URI without presenting own contact
    get   Lookup contact entry
    import   Import contact entry from file
    list   List contact entries
    request   Post a conection request to a user
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
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'contact delete' command deletes a contact entry entry by means of 
its unique catalog identifier.


~~~~
Missing example 9
~~~~

# contact dynamic

~~~~
<div="helptext">
<over>
dynamic   Create dynamic contact retrieval URI
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
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



~~~~
<div="terminal">
<cmd>Carol> meshman contact dynamic alice@example.com
<rsp>Device Profile UDF=
</div>
~~~~



# contact exchange

~~~~
<div="helptext">
<over>
exchange   Request contact from URI presenting own contact
       Contact exchange URI
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'contact exchange' command is used to complete a mutual contact exchange
by means of a dynamic URI.


~~~~
<div="terminal">
<cmd>Alice> meshman contact exchange mcu://carol@example.com/EFQF-DPLD-IIUR-ZIUO-G5PK-4WRD-ZFGA
<rsp></div>
~~~~




# contact fetch

~~~~
<div="helptext">
<over>
fetch   Request contact from URI without presenting own contact
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'contact fetch' command is used to acquire a dynamic or static contact
presented as a URI or QR code without reciprocating the exchange.


~~~~
<div="terminal">
<cmd>Alice> meshman contact fetch mcu://doug@example.com/EFQJ-TZRT-O3DN-YTJH-TOUC-IMGI-6KAQ
<rsp>[CatalogedContact]

</div>
~~~~



# contact get

~~~~
<div="helptext">
<over>
get   Lookup contact entry
       Contact entry identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
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
<rsp>[CatalogedContact]

</div>
~~~~



# contact import

~~~~
<div="helptext">
<over>
import   Import contact entry from file
       File containing the contact entry to add
    /self   Contact is for self
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'contact import' command is used to add a contact entry to the catalog
from a file


~~~~
Missing example 10
~~~~

# contact list

~~~~
<div="helptext">
<over>
list   List contact entries
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
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
<rsp>Entry<CatalogedContact>: MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Person MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Anchor MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Address alice@example.com

Entry<CatalogedContact>: NBE6-3ZYP-G52L-B6HG-EIRK-XZ7H-73HR
  Person 
  Anchor MDDO-B6Z7-4YXY-BJLQ-WFQZ-BOMG-QB6Y
  Address bob@example.com

Entry<CatalogedContact>: NDGW-DE77-QMTX-65RU-GNV2-LMT3-TFDI
  Person 
  Anchor MDUH-SCDO-UMPO-LCBP-QGOU-AZIG-PJ5D
  Address groupw@example.com

Entry<CatalogedContact>: NCX4-Y3QO-5DIZ-23JD-HHLG-EY5C-T3KQ
  Person 
  Anchor MDUH-SCDO-UMPO-LCBP-QGOU-AZIG-PJ5D
  Address groupw@example.com

Entry<CatalogedContact>: NB3K-UFSL-CNOL-VR4I-BXVW-KEUE-4RFG
  Person 
  Anchor MB3W-TFQZ-FMLI-7V2O-TINP-Z33G-VSLD
  Address carol@example.com

</div>
~~~~




# contact static

~~~~
<div="helptext">
<over>
static   Create static contact retrieval URI
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'contact static' command creates a URI from which a static QR code may be created
to allow contact information to be published on a business card etc. in machine
readable form.

~~~~
<div="terminal">
<cmd>Doug> meshman contact static 
<rsp>Device Profile UDF=
</div>
~~~~



