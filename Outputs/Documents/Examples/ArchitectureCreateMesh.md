The user specifies the initial account address to be used (alice@example.com). Use of this address
is of course dependent on authorization by the Mesh Service Provider (example.com)
and is likely to require authentication and possibly payment.


~~~~
<div="terminal">
<cmd>Alice> account create alice@example.com
<rsp>Account=alice@example.com
UDF=MCK5-26MC-Q726-YY6I-AJJZ-Z2YA-IAIE
</div>
~~~~

The command returns the value of Alice's Mesh Account fingerprint . 
This value is used as a unique identifier that is cryptographically bound to the signature key used
to authenticate the account profile.

