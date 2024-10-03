

# contact

~~~~
<div="helptext">
<over>
contact    Manage contact catalogs connected to an account
    add   Add contact entry from specified parameters
    delete   Delete contact entry
    dynamic   Create dynamic contact retrieval URI
    exchange   Request contact from URI presenting own contact
    export   Export contact entry from file
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
Missing example 11
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
<cmd>Alice> meshman contact exchange mcd://carol@example.com/EGDV-Z3GM-27VS-KONB-5IKL-7NBQ-EMZW-2TSA-76XR-SZVM-5NBX-DL45-PLIN-A
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
<cmd>Alice> meshman contact fetch mcd://doug@example.com/EHZK-ZKQG-YIY2-KVNY-AA5U-AFUA-CUM2-CHW4-RMHJ-VGMN-P4I4-5LI2-JCFV-6
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
Missing example 12
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
<rsp>Entry<CatalogedContact>: MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
  Person MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
  Anchor MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
  Address alice@example.com

Entry<CatalogedContact>: NCQT-M4X2-LSIJ-GRPC-FUXJ-YIK7-KV33
  Person 
  Anchor MBQN-O35O-S5NJ-XZ5K-7RRD-NAMW-VN6H
  Address bob@example.com

Entry<CatalogedContact>: NDBE-XPGH-FLCF-57RP-IT5N-XHBB-PK7A
  Person 
  Anchor MBQG-AYCC-THQE-A3RF-CF4V-GEEW-GL3Z
  Address groupw@example.com

Entry<CatalogedContact>: NCYT-PO6T-OK42-BKSL-B3LX-BNB7-SKA7
  Person 
  Anchor MBQG-AYCC-THQE-A3RF-CF4V-GEEW-GL3Z
  Address groupw@example.com

Entry<CatalogedContact>: NCRY-X27D-VG2N-CHET-RRMT-53AL-R3A6
  Person 
  Anchor MBQD-WBR4-Q3OT-7OYB-N7ZY-YM7G-ZKYE
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



