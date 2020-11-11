The user specifies the initial account address to be used (alice@example.com). Use of this address
is of course dependent on authorization by the Mesh Service Provider (example.com)
and is likely to require authentication and possibly payment.


~~~~
<div="terminal">
<cmd>Alice> account create alice@example.com
<rsp>Account=MDOS-GLM5-GHBD-V2BW-ORPW-ZV5H-ZZKS
</div>
~~~~

The command returns the value of Alice's Mesh Account fingerprint . 
This value is used as a unique identifier that is cryptographically bound to the signature key used
to authenticate the account profile.

