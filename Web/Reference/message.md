

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

~~~~
<div="terminal">
<cmd>Bob> meshman message confirm alice@example.com "Purchase equipment for $6,000?"
<rsp>Envelope ID: MCK7-MAGD-TRMF-QQPS-NG64-IGG4-CXUS
Message ID: NCAV-N6DG-ZWX2-VIPG-IBFH-JTKM-5YWR
Response ID: MDL3-PED3-HL55-C62T-DANJ-SA67-BAZC
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

~~~~
<div="terminal">
<cmd>Bob> meshman message contact alice@example.com
<rsp>Envelope ID: MCYQ-CVAT-J4F3-DFAE-5R6T-JTKG-4VI6
Message ID: NARA-7QXY-OIUO-A4VX-WRSG-FWED-W37V
Response ID: MBST-46UM-4A2W-TQMR-TW77-7DWP-LQQG
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

~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NARA-7QXY-OIUO-A4VX-WRSG-FWED-W37V
        Contact Request::
        MessageID: NARA-7QXY-OIUO-A4VX-WRSG-FWED-W37V
        To: alice@example.com From: bob@example.com
        PIN: ABII-GHTL-WP4P-XBLL-4RA2-AWIE-GFEA
MessageID: NBKK-WDGA-Z36W-IOD6-HZBW-DSNB-2CR5
        Group invitation::
        MessageID: NBKK-WDGA-Z36W-IOD6-HZBW-DSNB-2CR5
        To: alice@example.com From: alice@example.com
MessageID: NBW3-QGBQ-U26Q-ECMH-3BAD-BYI5-7J4J
        Confirmation Request::
        MessageID: NBW3-QGBQ-U26Q-ECMH-3BAD-BYI5-7J4J
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDRW-AINC-CW2Z-REBY-UILU-O2EI-MZPK
        Contact Request::
        MessageID: NDRW-AINC-CW2Z-REBY-UILU-O2EI-MZPK
        To: alice@example.com From: bob@example.com
        PIN: ADXO-VQ4V-WNRY-WD65-PHYE-GK2E-TWZQ
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

~~~~
<div="terminal">
<cmd>Bob> meshman message status tbs
<rsp>Pending
</div>
~~~~







