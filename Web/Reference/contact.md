

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
<cmd>Doug> meshman contact dynamic 
<rsp>ERROR - The feature has not been implemented
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
<rsp>Entry<CatalogedContact>: MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Person MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Anchor MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Address alice@example.com

Entry<CatalogedContact>: NAQN-NQDL-LKHW-DY3U-QAFS-N2LW-6DHS
  Person 
  Anchor MCKB-VDWV-FXBV-ZEQC-62VO-UWU7-RKYC
  Address bob@example.com

Entry<CatalogedContact>: NBJM-J77F-WGI4-U42M-A273-L4LO-KUL4
  Person 
  Anchor MCXX-WFN3-4M63-LOT6-PO7W-PDME-JZCK
  Address groupw@example.com

Entry<CatalogedContact>: NBYB-VQJX-5JFD-M35Q-OFJD-TXNQ-R3A2
  Person 
  Anchor MCXX-WFN3-4M63-LOT6-PO7W-PDME-JZCK
  Address groupw@example.com

Entry<CatalogedContact>: NBDI-IEHI-35UN-DNGC-KVZN-37NZ-DCIH
  Person 
  Anchor MCXX-WFN3-4M63-LOT6-PO7W-PDME-JZCK
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



