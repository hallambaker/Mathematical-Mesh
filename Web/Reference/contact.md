

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
Missing example 28
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
<rsp>Entry<CatalogedContact>: MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
  Person MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
  Anchor MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
  Address alice@example.com

Entry<CatalogedContact>: NDEM-WE24-3HOC-XLZC-GC2G-ZXOF-C6HU
  Person 
  Anchor MAEP-FJ5L-ZDUD-4PA4-MLEF-ZZJG-LDER
  Address bob@example.com

Entry<CatalogedContact>: NBMX-PJ74-OQ3W-ZBM3-U525-RJYR-2QCG
  Person 
  Anchor MD2J-ZY5P-QMLE-2UBT-X7QH-C5OO-37K4
  Address groupw@example.com

Entry<CatalogedContact>: NDRA-RYQ6-BGI6-S6ST-3EQO-SIHS-SZ5N
  Person 
  Anchor MD2J-ZY5P-QMLE-2UBT-X7QH-C5OO-37K4
  Address groupw@example.com

Entry<CatalogedContact>: NBR7-T7B7-5BPM-Q6CO-4W7F-PCSK-CHMN
  Person 
  Anchor MD2J-ZY5P-QMLE-2UBT-X7QH-C5OO-37K4
  Address groupw@example.com

Entry<CatalogedContact>: NCNT-D7WI-7OGD-Q4X5-VKN5-2GYO-NQ6M
  Person 
  Anchor MD2J-ZY5P-QMLE-2UBT-X7QH-C5OO-37K4
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

