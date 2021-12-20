

# message

~~~~
<div="helptext">
<over>
message    Contact and confirmation message options
    accept   Accept a pending request
    block   Reject a pending request and block requests from that source
    confirm   Post a confirmation request to a user
    contact   Post a conection request to a user
    pending   List pending requests
    reject   Reject a pending request
    status   Request status of pending request
<over>
</div>
~~~~

The `message` command set contains commands that send, receive and respond to 
Mesh transactional messages.

# message accept

~~~~
<div="helptext">
<over>
accept   Accept a pending request
       Specifies the request to accept
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `message accept` command accepts a confirmation request. A request message is
created, signed under the device key and returned to the recipient's service
provider for forwarding to the requestor.

The confirmation request to be accepted is specified by its message identifier.

The required parameter is the message identifier of the request to be accepted.



~~~~
<div="terminal">
<cmd>Alice> meshman message accept tbs
<rsp>ERROR - The specified message could not be found.
</div>
~~~~



# message block

~~~~
<div="helptext">
<over>
block   Reject a pending request and block requests from that source
       Specifies the request to reject and block
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `message block` command adds a party to the user's blocklist.

The required parameter is the identifier of the party to be blocked. This may
be a local name defined in the contacts book or an address.


~~~~
<div="terminal">
<cmd>Alice> meshman message block mallet@example.com
<rsp></div>
~~~~



# message confirm

~~~~
<div="helptext">
<over>
confirm   Post a confirmation request to a user
       The recipient to send the confirmation request to
       The recipient to send the confirmation request to
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `message confirm` command initiates a confirmation interaction by sending a
confirmation request to the named party.

The first parameter is required and specifies the intended recipient.

The second parameter specifies the request text and is currently required but
may become optional if alternative means of specifying the request text are 
supported.



~~~~
<div="terminal">
<cmd>Bob> meshman message confirm alice@example.com "Purchase equipment for $6,000?"
<rsp>Envelope ID: MCG6-KORP-RH2E-275I-PCMR-PNOH-HSEM
Message ID: NCSF-HZDX-U33H-7DDN-3GTI-N6Z7-43G4
Response ID: MAK3-SFSS-JZ25-E26S-VC6T-NYY6-AQLK
</div>
~~~~



# message contact

~~~~
<div="helptext">
<over>
contact   Post a conection request to a user
       The recipient to send the conection request to
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `message contact` command  initiates a contact interaction by sending a
confirmation request to the named party.

The first parameter is required and specifies the intended recipient.


~~~~
<div="terminal">
<cmd>Bob> meshman message contact alice@example.com
<rsp>Envelope ID: MBD2-SNOX-GQ4O-EP2P-KPXY-4OMJ-EPI4
Message ID: NAMZ-G5FP-OHEH-74PH-ZIII-IYCP-IOJ4
Response ID: MBB7-ZU3T-CLUR-BTNY-3UI5-FNEH-FDUV
</div>
~~~~



# message pending

~~~~
<div="helptext">
<over>
pending   List pending requests
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /unread   <Unspecified>
    /read   <Unspecified>
    /raw   <Unspecified>
<over>
</div>
~~~~

The `message pending` command returns all pending messages in the spool. It
is used in the same way as the `device pending` command except that it causes
all pending messages matching the specified criteria to be returned, not just
the pending messages.

The 'read' and 'unread' flags may be used to filter responses to return messages
that have been read or are unread. By default, only unread messages are returned.



~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NAMZ-G5FP-OHEH-74PH-ZIII-IYCP-IOJ4
        Contact Request::
        MessageID: NAMZ-G5FP-OHEH-74PH-ZIII-IYCP-IOJ4
        To: alice@example.com From: bob@example.com
        PIN: AB4L-U4J7-LLTR-ERNG-QPQP-DHZO-CGLQ
MessageID: NBLB-D3DX-6Z6Z-PQCS-4NEO-RQGQ-HQUL
        Group invitation::
        MessageID: NBLB-D3DX-6Z6Z-PQCS-4NEO-RQGQ-HQUL
        To: alice@example.com From: alice@example.com
MessageID: NDI6-772L-UUBU-RIFV-S5GM-3B3J-4LFV
        Confirmation Request::
        MessageID: NDI6-772L-UUBU-RIFV-S5GM-3B3J-4LFV
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NAHB-XJ7W-IEJY-NB4D-27UK-Y2HS-WPEA
        Contact Request::
        MessageID: NAHB-XJ7W-IEJY-NB4D-27UK-Y2HS-WPEA
        To: alice@example.com From: bob@example.com
        PIN: AA3C-HQL4-JNCZ-BJTD-IVOS-G5KU-2YIA
</div>
~~~~



# message reject

~~~~
<div="helptext">
<over>
reject   Reject a pending request
       Specifies the request to reject
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `message reject` command rejects a confirmation request. A request message is
created, signed under the device key and returned to the recipient's service
provider for forwarding to the requestor.

The confirmation request to be rejected is specified by its message identifier.

The required parameter is the message identifier of the request to be rejected.



~~~~
<div="terminal">
<cmd>Alice> meshman message reject tbs
<rsp>ERROR - The specified message could not be found.
</div>
~~~~



# message status

~~~~
<div="helptext">
<over>
status   Request status of pending request
       Specifies the request to provide the status of
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `message status` command returns the status of a previously sent confirmation
request.

The confirmation request to be queried is specified by its message identifier.



~~~~
<div="terminal">
<cmd>Bob> meshman message status tbs
<rsp>Pending
</div>
~~~~







