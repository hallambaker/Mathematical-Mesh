

# contact

~~~~
<div="helptext">
<over>
contact    Manage contact catalogs connected to an account
    delete   Delete contact entry
    dynamic   Create dynamic contact retrieval URI
    exchange   Request contact from URI presenting own contact
    fetch   Request contact from URI without presenting own contact
    get   Lookup contact entry
    import   Import contact entry from file
    list   List contact entries
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
<div="terminal">
<cmd>Alice> meshman contact delete tbs
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
<cmd>Alice> meshman contact exchange uri
<rsp>ERROR - The specified connection URI was invalid
</div>
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
<cmd>Alice> meshman contact fetch uri
<rsp>ERROR - The specified connection URI was invalid
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
<div="terminal">
<cmd>Alice> meshman contact import tbs
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\tbs'.
</div>
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
<rsp>Entry<CatalogedContact>: MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Person MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Anchor MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Address alice@example.com

Entry<CatalogedContact>: NDI6-Y4Q5-3K7C-UFFO-ZIZP-HFCS-R34U
  Person 
  Anchor MBNR-RPGE-7V2C-JI4N-F3NF-OD32-MV7R
  Address bob@example.com

Entry<CatalogedContact>: NDAW-LPN7-CMK6-JNTR-A573-CIFE-K34V
  Person 
  Anchor MDLU-46TL-V47W-BWT7-PSUV-FCKP-BEE6
  Address groupw@example.com

Entry<CatalogedContact>: NB2Y-J5D4-SHIA-WBWE-2EDA-D45R-56AU
  Person 
  Anchor MDLU-46TL-V47W-BWT7-PSUV-FCKP-BEE6
  Address groupw@example.com

Entry<CatalogedContact>: NA4V-YEYP-3K74-6ESA-M22I-FFBL-3WWB
  Person 
  Anchor MDLU-46TL-V47W-BWT7-PSUV-FCKP-BEE6
  Address groupw@example.com

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
<rsp>ERROR - The feature has not been implemented
</div>
~~~~



