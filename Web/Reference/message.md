

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
<rsp>Envelope ID: MA2M-E7MJ-5DPC-TWHA-2WC4-3WKS-GZV7
Message ID: NDL3-WREK-BPQQ-ZTOH-FSOR-FHD2-OYNW
Response ID: MDB2-IBLG-657S-K43Q-IQVY-5UAF-3CHS
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
<rsp>Envelope ID: MAGS-FJA4-B3DP-75QH-LDH6-EVXN-EXLO
Message ID: NBMT-K2BY-N7SO-2V7J-A2AF-LSDD-IIOV
Response ID: MBNB-C33D-LD54-SUK7-UJ7Y-UZPZ-ZPPZ
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
<rsp>MessageID: NBMT-K2BY-N7SO-2V7J-A2AF-LSDD-IIOV
        Contact Request::
        MessageID: NBMT-K2BY-N7SO-2V7J-A2AF-LSDD-IIOV
        To: alice@example.com From: bob@example.com
        PIN: ADLY-QWJJ-CIZZ-P4PP-4MA5-CGRF-OCUQ
MessageID: NDVT-POHA-PJWP-AABG-YXO2-JU2C-4LYT
        Group invitation::
        MessageID: NDVT-POHA-PJWP-AABG-YXO2-JU2C-4LYT
        To: alice@example.com From: alice@example.com
MessageID: NCM5-RFA7-MCBH-UTRQ-2DPH-RIUN-DZEE
        Confirmation Request::
        MessageID: NCM5-RFA7-MCBH-UTRQ-2DPH-RIUN-DZEE
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDA2-TF33-S2GI-CUQB-W7MD-7SUH-TMHU
        Contact Request::
        MessageID: NDA2-TF33-S2GI-CUQB-W7MD-7SUH-TMHU
        To: alice@example.com From: bob@example.com
        PIN: ABS6-M3HZ-3XC3-T2MP-5KAC-7UQW-M65A
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







