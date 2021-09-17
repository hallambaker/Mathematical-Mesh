The user specifies the initial account address to be used (alice@example.com). Use of this address
is of course dependent on authorization by the Mesh Service Provider (example.com)
and is likely to require authentication and possibly payment.


~~~~
<div="terminal">
<cmd>Alice> account create alice@example.com
<rsp>Account=alice@example.com
UDF=MC76-AK7P-CEKP-ILKC-MEXU-EOIF-I6BF
</div>
~~~~

The command returns the value of Alice's Mesh Account fingerprint . 
This value is used as a unique identifier that is cryptographically bound to the signature key used
to authenticate the account profile.

