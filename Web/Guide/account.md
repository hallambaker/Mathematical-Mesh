<title>account
# Using the account Command Set

The account command set contains commands used to create and manage
Mesh accounts.


## Creating a Mesh Account

Create a new Mesh profile


~~~~
<div="terminal">
<cmd>Alice> mesh create
<rsp>Device Profile UDF=MC7B-CDOG-VA7F-TCBO-4JCY-QC6F-2F5A
Personal Profile UDF=MCOZ-GIZ3-34VQ-GQ6J-FCS7-BJIU-JCOY
</div>
~~~~

Add an account to the profile


~~~~
<div="terminal">
<cmd>Alice> account create personal
<rsp>Account=MDNT-Y3SK-UGF5-NPYP-XDCK-OWHW-Z7FN
</div>
~~~~

The `account service` command registers a profile:


~~~~
<div="terminal">
<cmd>Alice> account register alice@example.com
<rsp>Account=MDNT-Y3SK-UGF5-NPYP-XDCK-OWHW-Z7FN
AccountAddress=alice@example.com
</div>
~~~~

Or we can perform all three tasks at once by creating an account and registering it with a 
service when we create the profile:


~~~~
<div="terminal">
<cmd>Bob> mesh create /account personal /service=bob@example.com
<rsp>Device Profile UDF=MCBC-VZT3-Y2IL-YINN-E2AJ-IGJ4-I7WH
Personal Profile UDF=MCR5-FJGK-SBIM-QHAL-R5NH-MP2K-NBCX
</div>
~~~~



## Contacting a Mesh Service.

## Registering an account with a service.

## Synchronizing an account with a service



