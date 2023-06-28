

# message

~~~~
<div="helptext">
<over>
message    Contact and confirmation message options
    accept   Accept a pending request
    block   Reject a pending request and block requests from that source
    confirm   Post a confirmation request to a user
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
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
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
<cmd>Alice> meshman message accept NAQL-6SJP-VLQD-7BNN-EB6L-DLQQ-K2ZE
<rsp></div>
~~~~



# message block

~~~~
<div="helptext">
<over>
block   Reject a pending request and block requests from that source
       Specifies the request to reject and block
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
       Text of the request message
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

The `message confirm` command initiates a confirmation interaction by sending a
confirmation request to the named party.

The first parameter is required and specifies the intended recipient.

The second parameter specifies the request text and is currently required but
may become optional if alternative means of specifying the request text are 
supported.



~~~~
<div="terminal">
<cmd>Bob> meshman message confirm alice@example.com "Purchase equipment for $6,000?"
<rsp>Envelope ID: MDMJ-B52P-PMGN-YGIX-GRFG-I4CJ-LPIJ
Message ID: NAGC-HVFG-US7J-BANB-YHPP-7DYJ-BJAZ
Response ID: MA5G-3V7Z-BXSO-ZBLQ-V43K-EZ7Z-NR2X
</div>
~~~~



# message request

~~~~
<div="helptext">
<over>
request   Post a conection request to a user
       The recipient to send the conection request to
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

The `message contact` command  initiates a contact interaction by sending a
confirmation request to the named party.

The first parameter is required and specifies the intended recipient.


~~~~
<div="terminal">
<cmd>Bob> meshman contact request alice@example.com
<rsp>Envelope ID: MAE2-VMU3-PDAH-HZX7-CGYV-75XQ-Z4EA
Message ID: NAQL-6SJP-VLQD-7BNN-EB6L-DLQQ-K2ZE
Response ID: MDNG-ME2U-6X4T-FEVR-46MH-2RLM-WCOP
</div>
~~~~



# message pending

~~~~
<div="helptext">
<over>
pending   List pending requests
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /unread   Return unread messages
    /read   Return read messages
    /raw   Return messages in raw form
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
<cmd>Alice> meshman account sync
<rsp></div>
~~~~



# message reject

~~~~
<div="helptext">
<over>
reject   Reject a pending request
       Specifies the request to reject
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

The `message reject` command rejects a confirmation request. A request message is
created, signed under the device key and returned to the recipient's service
provider for forwarding to the requestor.

The confirmation request to be rejected is specified by its message identifier.

The required parameter is the message identifier of the request to be rejected.



~~~~
<div="terminal">
<cmd>Alice> meshman message reject ND2G-PHUE-PLPY-QAPP-UU6P-BAXW-EOBS
<rsp></div>
~~~~



# message status

~~~~
<div="helptext">
<over>
status   Request status of pending request
       Specifies the request to provide the status of
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

The `message status` command returns the status of a previously sent confirmation
request.

The confirmation request to be queried is specified by its message identifier.



~~~~
Missing example 7
~~~~





