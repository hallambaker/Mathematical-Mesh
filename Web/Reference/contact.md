

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
<rsp>Entry<CatalogedContact>: MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT
  Person MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT
  Anchor MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT
  Address alice@example.com

Entry<CatalogedContact>: NDF5-DIN6-FBRI-UI2D-XLQF-SKWC-TCB5
  Person 
  Anchor MDBR-EJYT-5KJY-Z73B-IG7E-WFSN-MRKH
  Address bob@example.com

Entry<CatalogedContact>: NCPX-63X3-SRNM-KJDU-VED6-MYU2-EUG6
  Person 
  Anchor MCVG-W4LF-4BAI-2ZCY-NHCU-E3HO-VVHY
  Address groupw@example.com

Entry<CatalogedContact>: NCPH-YMTN-5HKG-E3GR-YFZC-RDC5-ZM4D
  Person 
  Anchor MCVG-W4LF-4BAI-2ZCY-NHCU-E3HO-VVHY
  Address groupw@example.com

Entry<CatalogedContact>: NDR4-XO5G-PIYW-6H47-ZAGK-ISPY-H2ES
  Person 
  Anchor MCVG-W4LF-4BAI-2ZCY-NHCU-E3HO-VVHY
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

